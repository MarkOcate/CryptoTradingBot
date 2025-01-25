using System.ComponentModel;

namespace CryptoTradingBot.Core.Enums.Binance
{
    public static class BinanceApiErrorDescriptions
    {
        public enum BinanceApiErrorCode
        {
            // General Server or Network Issues
            [Description("An unknown error occurred while processing the request.")]
            Unknown = -1000,

            [Description("Internal error; unable to process your request. Please try again.")]
            Disconnected = -1001,

            [Description("You are not authorized to execute this request.")]
            Unauthorized = -1002,

            [Description("Too many requests queued or too much request weight used.")]
            TooManyRequests = -1003,

            [Description("An unexpected response was received from the message bus. Execution status unknown.")]
            UnexpectedResponse = -1006,

            [Description("Timeout waiting for response from backend server. Send status unknown; execution status unknown.")]
            Timeout = -1007,

            [Description("Server is currently overloaded with other requests. Please try again in a few minutes.")]
            ServerBusy = -1008,

            // Request Issues
            [Description("The request is rejected by the API (e.g., the request didn't reach the Matching Engine.)")]
            InvalidMessage = -1013,

            [Description("Unsupported order combination.")]
            UnknownOrderComposition = -1014,

            [Description("Order cannot be canceled; currently in a final state.")]
            TooLateToCancel = -1015,

            [Description("Order does not exist.")]
            UnknownOrder = -1016,

            [Description("Duplicate order sent.")]
            DuplicateOrder = -1017,

            [Description("Account does not exist.")]
            UnknownAccount = -1018,

            [Description("Account is not active.")]
            AccountInactive = -1020,

            [Description("Account cannot settle.")]
            AccountCannotSettle = -1021,

            // Security Issues
            [Description("API-key format invalid.")]
            InvalidApiKeyFormat = -1100,

            [Description("Signature for this request is not valid.")]
            InvalidSignature = -1101,

            [Description("Illegal characters found in a parameter.")]
            IllegalChars = -1102,

            [Description("Too many parameters sent for this endpoint.")]
            TooManyParameters = -1103,

            [Description("A mandatory parameter was empty or malformed.")]
            MandatoryParamEmptyOrMalformed = -1104,

            [Description("Invalid data sent for a parameter.")]
            InvalidParameter = -1130,

            // New Order Issues
            [Description("New order rejected due to immediately matching and canceling.")]
            OrderWouldImmediatelyMatch = -2010,

            [Description("New order rejected due to immediately canceling.")]
            OrderWouldImmediatelyCancel = -2011,

            [Description("Price quantity exceeds hard limits.")]
            PriceQtyExceedsHardLimits = -2013
        }
    }


    /* USAGE
    // Example usage of the BinanceApiErrorCode enum
    BinanceApiErrorCode errorCode = BinanceApiErrorCode.TooManyRequests;

    // Get the description
    string description = errorCode.GetDescription();

    Console.WriteLine($"Error Code: {(int)errorCode}");
    Console.WriteLine($"Description: {description}");    
    */
}
