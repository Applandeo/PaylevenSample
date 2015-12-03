using System;

namespace PaylevenSample
{
	public enum PLVPaylevenStatus : long
	{
		PLVPaylevenStatusOK,
		PLVPaylevenStatusDeviceIsNotReady,
		PLVPaylevenStatusCoordsIsNotValid,
		PLVPaylevenStatusCouldNotCreatePayment,
		PLVPaylevenStatusLoginError,
		PLVPaylevenStatusDeviceNotFound,
		PLVPaylevenStatusError
	}
}

