using System;
using PaylevenLib;
using Foundation;
using System.Linq;
using CoreLocation;
using UIKit;
using System.Threading;
using CoreGraphics;

namespace PaylevenSample
{
	public class PaylevenManager: PLVPaymentTaskDelegate
	{
		private PLVPayleven Payleven { get; set; }
		private PLVPaymentTask PaymentTask { get; set; }
		private CLLocationCoordinate2D LocationCoordinate { get; set; }
		private Action<PLVPaylevenStatus> StatusAction { get; set; }
		private NSString Currency { get; set; }

		private const string ApiKey = ""; // TODO: Add your Api key

		public PaylevenManager(Action<PLVPaylevenStatus> action, string currency, double latitude, double longitude)
		{ 
			Payleven = new PLVPayleven();

			StatusAction = action;
			Currency = new NSString(currency);
			LocationCoordinate = new CLLocationCoordinate2D (latitude, longitude);
		}

		#region Login & Logout
		public void LogInAndPay(NSString userName, NSString userPassword, string amount)
		{
			if (Payleven.LoginState == PLVPaylevenLoginState.PLVPaylevenLoginStateLoggedIn) 
			{
				// Payleven: prepare device and make payment
				PrepareDeviceAndPay (amount);
			}
			else 
			{
				// Payleven: login user
				Payleven.LoginWithUsername(userName, userPassword, new NSString (ApiKey), (errorHandler) =>
					{ 
						if (errorHandler == null)
						{
							// Payleven: login successful
							PrepareDeviceAndPay(amount);
						}
						else
						{
							// Payleven: login failed
							StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusLoginError); 
						}
					});
			}
		}

		public void LogOut()
		{
			Payleven.LogoutWithCompletionHandler((errorHandler) =>
				{
					// TODO: check if there is error
				});
		}

		#endregion

		public void PrepareDeviceAndPay(string paymentAmount)
		{
			if (Payleven.Devices == null || Payleven.Devices.Count() == 0)
			{
				// Payleven: devices list is empty");
				StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusDeviceNotFound); 
				return;
			}

			var device = Payleven.Devices.FirstOrDefault ();

			device.PrepareWithCompletionHandler((completionHandler) =>
				{  
					if (device.Ready)
					{ 
						// Payleven: making payment, device is ready
						Pay(device, paymentAmount);
					}
					else
					{
						// Payleven: device is not ready, check error code
						StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusDeviceIsNotReady); 
					}
				});
		}

		public void Pay(PLVDevice device, string paymentAmount)
		{ 
			if (device == null)
			{
				// Payleven: device not found 
				StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusDeviceNotFound); 
				return;
			}

			if (!LocationCoordinate.IsValid())
			{
				// Payleven: coordinates are not valid
				StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusCoordsIsNotValid); 
				return;
			}
				
			var paymentRequest = new PLVPaymentRequest(PaymentHelper.GetRandomNSString(), PaymentHelper.LocaleAmount(paymentAmount), 
				Currency, LocationCoordinate);

			var paymentTask = Payleven.PaymentTaskWithRequest(paymentRequest, device, this);

			if (paymentTask == null)
			{
				// Payleven: error with creating payment
				StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusError); 
				return;
			}
			else
				// Payleven: payment has started!  
				paymentTask.Start();
		}
			
		#region Overrided methods
		public override void PLVPaymentTask(PLVPaymentTask paymentTask, Action<bool, CGImage> completionHandler)
		{
			completionHandler.Invoke(true, null);
		}

		public override void PaymentTaskDidFinish(PLVPaymentTask paymentTask)
		{
			StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusOK);
		}

		public override void PLVPaymentTask(PLVPaymentTask paymentTask, NSError error)
		{
			if (error != null)
			{
				// Payleven: task failed, you can check error code
				StatusAction.Invoke(PLVPaylevenStatus.PLVPaylevenStatusError);
			}
		}
		#endregion
	}
}