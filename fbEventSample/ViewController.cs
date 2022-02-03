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

        }

        partial void ClickButton_3(NSObject sender)
        {

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
