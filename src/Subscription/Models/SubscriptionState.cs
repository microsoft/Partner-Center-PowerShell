// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Profiles.Subscription.Models
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines values for SubscriptionState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubscriptionState
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Warned")]
        Warned,
        [EnumMember(Value = "PastDue")]
        PastDue,
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Deleted")]
        Deleted
    }
    internal static class SubscriptionStateEnumExtension
    {
        internal static string ToSerializedValue(this SubscriptionState? value)
        {
            return value == null ? null : ((SubscriptionState)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this SubscriptionState value)
        {
            switch( value )
            {
                case SubscriptionState.Enabled:
                    return "Enabled";
                case SubscriptionState.Warned:
                    return "Warned";
                case SubscriptionState.PastDue:
                    return "PastDue";
                case SubscriptionState.Disabled:
                    return "Disabled";
                case SubscriptionState.Deleted:
                    return "Deleted";
            }
            return null;
        }

        internal static SubscriptionState? ParseSubscriptionState(this string value)
        {
            switch( value )
            {
                case "Enabled":
                    return SubscriptionState.Enabled;
                case "Warned":
                    return SubscriptionState.Warned;
                case "PastDue":
                    return SubscriptionState.PastDue;
                case "Disabled":
                    return SubscriptionState.Disabled;
                case "Deleted":
                    return SubscriptionState.Deleted;
            }
            return null;
        }
    }
}
