using ObjCRuntime;

namespace menu_repro;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new ViewController ();
		var button = new UIButton (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			//TextAlignment = UITextAlignment.Center,
			//Text = "Hello, iOS!",
			AutoresizingMask = UIViewAutoresizing.All,
			//TitleLabel
		};
		button.SetTitle("Foo", UIControlState.Normal);
		button.Menu = UIMenu.Create([UIAction.Create("Foo", null, "foo", (_) => {})]);
		button.ShowsMenuAsPrimaryAction = true;
		vc.View!.AddSubview (button);
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}

	class ViewController : UIViewController
	{
        public override void DismissViewController(bool animated, Action? completionHandler)
        {
            base.DismissViewController(animated, completionHandler);
        }
    }
}
