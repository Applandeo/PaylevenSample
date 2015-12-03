using System;
using Foundation;

namespace PaylevenSample
{
	public static class PaymentHelper
	{
		private const string randomAlphabet = ""; // TODO: Add random alphabet chars

		public static NSString GetRandomNSString()
		{
			string alphabet = randomAlphabet;
			var alphabetLength = alphabet.Length;
			nint stringLength = 20;
			NSMutableString mstring = new NSMutableString(stringLength);

			for (var index = 0; index < stringLength; index++)
			{
				int randomIndex = new Random().Next(1, alphabetLength);
				mstring.Append(new NSString(alphabet[randomIndex].ToString()));
			}

			return mstring;
		}

		public static NSDecimalNumber LocaleAmount(string amount)
		{
			NSLocale locale = NSLocale.CurrentLocale;  
			return new NSDecimalNumber(amount, locale);
		}
	}
}

