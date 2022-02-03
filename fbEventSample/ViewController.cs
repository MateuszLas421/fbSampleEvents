using Facebook.CoreKit;
using Foundation;
using System;
using UIKit;

namespace fbEventSample
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ClickButton_1(NSObject sender)
        {
            PushEvent("Click 1 Without parametrs");
        }

        partial void ClickButton_2(NSObject sender)
        {
            var key = new NSString("value");
            var number = new NSNumber(213);
            PushEvent("Click 2", new NSDictionary<NSString, NSObject>(key, number));
        }

        partial void ClickButton_3(NSObject sender)
        {
            PushEvent("Click 3", new NSDictionary<NSString, NSObject>());
        }

        private void PushEvent(string eventName, NSDictionary<NSString, NSObject> value)
        {
            AppEvents.LogEvent(eventName, value);
        }

        private void PushEvent(string eventName)
        {
            AppEvents.LogEvent(eventName);
        }
    }
}
