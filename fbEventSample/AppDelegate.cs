using AppTrackingTransparency;
using Facebook.CoreKit;
using Foundation;
using UIKit;

namespace fbEventSample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            ApplicationDelegate.SharedInstance.FinishedLaunching(application, launchOptions);
            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public override UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public override void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        public override void OnActivated(UIApplication application)
        {
            Settings.AppId = "893904987903240";
            Settings.DisplayName = "testapp";
            if (UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
            {
                ATTrackingManager.RequestTrackingAuthorization((result) =>
                {
                    switch (result)
                    {
                        case ATTrackingManagerAuthorizationStatus.Authorized:
                            Settings.AdvertiserIdCollectionEnabled = true;
                            Settings.AutoLogAppEventsEnabled = true;
                            Settings.AdvertiserTrackingEnabled = true;
                            break;
                        default:
                            Settings.AdvertiserIdCollectionEnabled = false;
                            Settings.AutoLogAppEventsEnabled = false;
                            Settings.AdvertiserTrackingEnabled = false;
                            break;
                    }
                    ApplicationDelegate.SharedInstance.InitializeSdk();
                    Settings.EnableLoggingBehavior(LoggingBehavior.AppEvents);
                    AppEvents.Shared.ActivateApp();
                });
            }
            else
            {
                Settings.AdvertiserIdCollectionEnabled = true;
                Settings.AutoLogAppEventsEnabled = true;
                Settings.AdvertiserTrackingEnabled = true;
                ApplicationDelegate.SharedInstance.InitializeSdk();
                Settings.EnableLoggingBehavior(LoggingBehavior.AppEvents);
                AppEvents.Shared.ActivateApp();
            }

        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            base.OpenUrl(app, url, options);
            return ApplicationDelegate.SharedInstance.OpenUrl(app, url, options);
        }
    }
}

