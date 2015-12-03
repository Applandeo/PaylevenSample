
using System;

using Foundation;
using UIKit;

namespace PaylevenSample
{
	public partial class PaymentViewController : UIViewController
	{

		private const string YourCurrency = ""; // TODO: Add your payment currency
		private const string YourLogin = ""; // TODO: Add payleven account login
		private const string YourPassword = ""; // TODO: Add payleven account password

		public string YourAmount { get; set; }

		public PaymentViewController () : base ("PaymentViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Set payment amount
			YourAmount = "0.0";

			// Begin payment
			var payleven = new Payleven ();
			payleven.Init(PaylevenAction, YourCurrency);
			payleven.LogInAndPay(new NSString (YourLogin), new NSString (YourPassword), YourAmount);
		}



		public void PaylevenAction(PLVPaylevenStatus status)
		{
			// TODO: Add logic for response status from payleven manager
		}
	}
}

