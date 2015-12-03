//
//  PLVRefundRequest.h
//  PaylevenSDK
//
//  Created by Bob Obi on 7/22/15.
//  Copyright (c) 2015 payleven Holding GmbH. All rights reserved.
//

#import <Foundation/Foundation.h>
/**
  @brief PLVRefundRequest is used to create or generate the PLVRefundRequest for refunds.
  It implements a NSCopying protocol and the mandatory properties are made readonly.
  Contains a refundDescription property that can be set later or assigned before the
  start of the actual task PLVRefundTask.
 */
@interface PLVRefundRequest : NSObject<NSCopying>

/**
 * Refund Identifier.
 *
 * Used to identify the specific refund within a transaction
 */
@property(nonatomic, readonly, nonnull) NSString *identifier;

/**
 * Payment Identifier.
 *
 * The original payment identifier from which refund could be deducted
 */
@property(nonatomic, readonly, nonnull) NSString *paymentIdentifier;

/**
 * Refund Amount.
 *
 * The value can be fractional, maximum two fraction digits are allowed.
 *
 * When creating `NSDecimalNumber` from `NSString`, don't forget to take the current locale and the decimal separator
 * into account.
 */
@property(nonatomic, readonly, nonnull) NSDecimalNumber *amount;

/**
 * Three-letter ISO 4217 currency code. For example, EUR.
 */
@property(nonatomic, readonly, nonnull) NSString *currency;

/**
 * Refund Description
 *
 * Description that can be added by the client.
 *
 * The value is restricted to 140 characters
 */
@property(nonatomic, nullable) NSString *refundDescription;

/**
 * Initializer. With the specified identifier, paymentIdentifier, amount, currency and refundDescription
 * refundDescription could be nil and it is seen as optional in swift
 *
 * @param identifier Refund identifier.
 * @param paymentIdentifier identifier.
 * @param amount Payment amount. The value can be fractional, maximum two fraction digits are allowed. When creating
 *               `NSDecimalNumber` from `NSString`, don't forget to take the current locale and the decimal separator
 *               into account.
 * @param currency Three-letter ISO 4217 currency code. For example, EUR.
 * @param refundDescription a description that can be added by the client limited to 140 characters.
 */
- (nonnull instancetype)initWithIdentifier:(nonnull NSString *)identifier
                 paymentIdentifier:(nonnull NSString *)paymentIdentifier
                            amount:(nonnull NSDecimalNumber *)amount
                          currency:(nonnull NSString *)currency
                 refundDescription:(nullable NSString *)refundDescription NS_DESIGNATED_INITIALIZER;

@end

