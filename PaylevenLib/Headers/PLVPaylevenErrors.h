//
//  PLVPaylevenErrors.h
//  PaylevenSDK
//
//  Created by Alexei Kuznetsov on 22/10/14.
//  Copyright (c) 2014 payleven Holding GmbH. All rights reserved.
//

#import <Foundation/Foundation.h>


/** Payleven error domain. */
extern NSString * const PLVPaylevenErrorDomain;

enum {
    /** 
     * Parameter error. 
     */
    PLVPaylevenParameterError,
    /** 
     * Amount error. 
     */
    PLVPaylevenAmountError,
    /**
     * Currency is set to null when an
     * Empty currency is passed to the SDK
     * Or curreny lenght less than 3. ISO Standards
     */
    PLVPaylevenCurrencyError,
    /**
     * Server returned an error. 
     */
    PLVPaylevenServerError,
    /** 
     * Unexpected server response error. 
     */
    PLVPaylevenUnexpectedServerResponseError,
    /** 
     * Already logged in error. 
     */
    PLVPaylevenAlreadyLoggedInError,
    /** 
     * Payment service provider error. 
     */
    PLVPaylevenPaymentServiceProviderError,
    /**
     * Location services error. 
     */
    PLVPaylevenLocationServicesError,
    /**
     * Internal validation error when
     * a null value is passed to the SDK
     */
    PLVPaylevenRefundNullAmountError,
    /**
     * Negative amount error when a
     * minus value is passed to the SDK
     */
    PLVPaylevenRefundNegativeAmountError,
    /**
     * Decimal amount error when a
     * Amount has 3 or more decimals
     */
    PLVPaylevenRefundInvalidDecimalAmountError,
    /**
     * Currency is set to null when an
     * Empty currency is passed to the SDK
     * Or curreny lenght less than 3. ISO Standards
     */
    PLVPaylevenRefundCurrencyError,
    /**
     * Refund identifier error when a
     * null External_Id is passed to the SDK
     */
    PLVPaylevenRefundExternalIdentifierError,
    /**
     * Refund payment identifier error when a
     * null PaymentId is passed to the SDK
     */
    PLVPaylevenRefundPaymentIdentifierError,
    /**
     * Refund request token is null
     * If nill token is used to launch
     * the request.
     */
    PLVPaylevenRefundTokenError,
    /**
     * Invalis amount error when
     * strings a passed to the SDK
     */
    PLVPaylevenRefundInvalidAmountError,
    /**
     * minimum refundable amount is less
     * than 1 cents
     */
    PLVPaylevenRefundMinimumAmountError,
    /**
     * When External_Id and Payment_Id
     * matches each other.
     */
    PLVPaylevenRefundIdentifersError,
    /**
     * Refund bad request incident error. 
     * 400 handles errors related to validation
     */
    PLVPaylevenRefundBadRequestIncidentError = 1001,
    /**
     * Refund bad request 1202 error
     * Payment not fund by originalExternalId
     * Payment does not belong to transaction
     */
    PLVPaylevenRefundPaymentNotFoundError = 1202,
    /**
     * Refund precondition failure error.
     */
    PLVPaylevenRefundPreconditionFailureError = 1203,
    /**
     * Refund bad request 12001 error
     * Insufficient Payment Balance
     */
    PLVPaylevenRefundInsufficientBalanceError = 12001,
    /**
     * Refund bad request 12002 error
     * Invalid Currency
     */
    PLVPaylevenRefundInvalidCurrencyError = 12002,
    /**
     * Bad request error
     */
    PLVPaylevenServerBadRequestError = 400,
    /**
     * Access is denied for wrong HMAC Validation
     */
    PLVPaylevenServerAccessError = 403,
    /**
     * Precondition Failed
     */
    PLVPaylevenServerPreconditionFailedError = 412
    
};
