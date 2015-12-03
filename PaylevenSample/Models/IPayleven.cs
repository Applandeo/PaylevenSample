using System;
using Foundation;

namespace PaylevenSample
{
	public interface IPayleven
	{
		void Init(Action<PLVPaylevenStatus> action, string currency);

		void LogInAndPay(NSString userName, NSString userPassword, string paymentAmount);
	}
}

