using System;
using Foundation;
using CoreLocation;
using UIKit;

namespace PaylevenSample
{
	public class Payleven : IPayleven
	{
		private CLLocationManager locationManager;
		private PaylevenManager paylevenManager;

		public Payleven()
		{
		}

		public void Init(Action<PLVPaylevenStatus> action, string currency)
		{
			locationManager = new CLLocationManager();
			// TODO: Get current location
			
			paylevenManager = new PaylevenManager(action, currency, 52.252505, 21.023012);
		}

		public void LogInAndPay(NSString userName, NSString userPassword, string paymentAmount)
		{
			paylevenManager.LogInAndPay(userName, userPassword, paymentAmount); 
		}
	}
}

