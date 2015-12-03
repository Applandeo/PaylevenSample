//
//  PLVRefund.h
//  PaylevenSDK
//
//  Created by Bob Obi on 7/23/15.
//  Copyright (c) 2015 payleven Holding GmbH. All rights reserved.
//

@import Foundation;
/**
 @brief PLVRefund represents a refund object. That contans the merchantIdentifier which is the merchant Id
 refundIdentifier which represents the refund Id provided in PLVRefundRequest. The refundedAmount is a 
 NSDecimalNumber of the refundedAmount. The paymentAmount is an NSDecimalNumber that holds the original
 Payment given in the PLVPaymentRequest at payment time. NSDecimalNumber remainingAmount is residual amount
 in case of partial refunds. The currency is Three-letter ISO 4217 currency code. For example, EUR. The
 refundDate represents the date of execution. The refundDescription represents the refund desc.  
  */
@interface PLVRefund : NSObject<NSCopying>
/**
 * The merchant identifier
 */
@property(nonatomic, readonly) NSString *merchantIdentifier;
/**
 * The refund identifier
 */
@property(nonatomic, readonly) NSString *refundIdentifier;
/**
 * The payment identifier
 */
@property(nonatomic, readonly) NSString *paymentIdentifier;
/**
 * The refunded amount.
 */
@property(nonatomic, readonly) NSDecimalNumber *refundedAmount;
/**
 * The original payment amount
 */
@property(nonatomic, readonly) NSDecimalNumber *paymentAmount;
/**
 * The remaining amount
 */
@property(nonatomic, readonly) NSDecimalNumber *remainingAmount;
/**
 * The currency.
 */
@property(nonatomic, readonly) NSString *currency;
/**
 * The refund date.
 */
@property(nonatomic, readonly) NSDate *refundDate;
/**
 * The refund description.
 */
@property(nonatomic, readonly) NSString *refundDescription;

@end
