using System;
using ObjCRuntime;

namespace PaylevenLib
{
	[Native]
	public enum PLVCardholderVerificationMethod : long
	{
		PLVCardholderVerificationMethodUnknown,
		PLVCardholderVerificationMethodNone,
		PLVCardholderVerificationMethodPIN,
		PLVCardholderVerificationMethodSignature,
		PLVCardholderVerificationMethodPINSignature
	}

	[Native]
	public enum PLVPaylevenLoginState : long
	{
		PLVPaylevenLoginStateLoggedOut,
		PLVPaylevenLoginStateLoggingIn,
		PLVPaylevenLoginStateLoggedIn,
		PLVPaylevenLoginStateLoggingOut
	}

	[Native]
	public enum PLVPaymentResultState : long
	{
		PLVPaymentResultStateApproved,
		PLVPaymentResultStateDeclined,
		PLVPaymentResultStateCancelled
	}

	[Native]
	public enum PLVPointOfSaleEntryMode : long
	{
		PLVPointOfSaleEntryModeUnknown,
		PLVPointOfSaleEntryModeIntegratedCircuitCard,
		PLVPointOfSaleEntryModeMagneticStripeReader,
		PLVPointOfSaleEntryModePANKeyEntry
	}
}

