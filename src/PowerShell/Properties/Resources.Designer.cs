﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Properties
{


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Store.PartnerCenter.PowerShell.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds a new line item to the cart with the identifier of {0}..
        /// </summary>
        internal static string AddPartnerCustomerCartLineItemWhatIf {
            get {
                return ResourceManager.GetString("AddPartnerCustomerCartLineItemWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must be greater than zero.
        /// </summary>
        internal static string AssertNumberPositiveInvalidError {
            get {
                return ResourceManager.GetString("AssertNumberPositiveInvalidError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to number.
        /// </summary>
        internal static string AssertNumberPositiveInvalidPrefix {
            get {
                return ResourceManager.GetString("AssertNumberPositiveInvalidPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not set.
        /// </summary>
        internal static string AssertStringNotEmptyInvalidError {
            get {
                return ResourceManager.GetString("AssertStringNotEmptyInvalidError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to string.
        /// </summary>
        internal static string AssertStringNotEmptyInvalidPrefix {
            get {
                return ResourceManager.GetString("AssertStringNotEmptyInvalidPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Audit records are only available for the past 90 days. Please update the start date parameter and try again..
        /// </summary>
        internal static string AuditRecordDateError {
            get {
                return ResourceManager.GetString("AuditRecordDateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticating using an access token. The following configurations were extracted from the token: Expiration &apos;{0}&apos;, TenantId &apos;{1}&apos;, UniqueName {2}, UserId &apos;{3}&apos;..
        /// </summary>
        internal static string AuthenticateAccessTokenTrace {
            get {
                return ResourceManager.GetString("AuthenticateAccessTokenTrace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticating using an authorization code and the following configurations: ClientId &apos;{0}&apos;, Endpoint &apos;{1}&apos;, RedirectUri &apos;{2}&apos; Resource &apos;{3}&apos;..
        /// </summary>
        internal static string AuthenticateAuthorizationCodeTrace {
            get {
                return ResourceManager.GetString("AuthenticateAuthorizationCodeTrace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticating using a device code and the following configurations: ClientId &apos;{0}&apos;, Resource &apos;{1}&apos;..
        /// </summary>
        internal static string AuthenticateDeviceCodeTrace {
            get {
                return ResourceManager.GetString("AuthenticateDeviceCodeTrace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticating using a service principal and the following configurations: ClientId &apos;{0}&apos;, Endpoint &apos;{1}&apos;, Resource &apos;{2}&apos; TenantId &apos;{3}&apos;..
        /// </summary>
        internal static string AuthenticateServicePrincipalTrace {
            get {
                return ResourceManager.GetString("AuthenticateServicePrincipalTrace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authenticating without asking for user credentials and using the following configurations: ClientId &apos;{0}&apos;, Endpoint &apos;{1}&apos;, Resource &apos;{2}&apos;, UserId &apos;{3}&apos;..
        /// </summary>
        internal static string AuthenticateSilentTrace {
            get {
                return ResourceManager.GetString("AuthenticateSilentTrace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The authentication token has expired..
        /// </summary>
        internal static string AuthenticationTokenExpired {
            get {
                return ResourceManager.GetString("AuthenticationTokenExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have authenticated using {0} authentication. This type of authentication is not supported by this command, only {1} authentication is supported. Please establish a new connection using an alternative means of authentication..
        /// </summary>
        internal static string AuthenticationTypeNotSupportedException {
            get {
                return ResourceManager.GetString("AuthenticationTypeNotSupportedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change description : {0}.
        /// </summary>
        internal static string BreakingChangesAttributesChangeDescriptionMessage {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesChangeDescriptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - {0}
        ///.
        /// </summary>
        internal static string BreakingChangesAttributesDeclarationMessage {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesDeclarationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - Cmdlet : &apos;{0}&apos;
        /// - {1}.
        /// </summary>
        internal static string BreakingChangesAttributesDeclarationMessageWithCmdletName {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesDeclarationMessageWithCmdletName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NOTE : Go to {0} for steps to suppress this breaking change warning, and other information on breaking changes with the Partner Center PowerShell module..
        /// </summary>
        internal static string BreakingChangesAttributesFooterMessage {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesFooterMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Breaking changes in the cmdlet &apos;{0}&apos; :.
        /// </summary>
        internal static string BreakingChangesAttributesHeaderMessage {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesHeaderMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Note : This change will take effect on &apos;{0}&apos;.
        /// </summary>
        internal static string BreakingChangesAttributesInEffectByDateMessage {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesInEffectByDateMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Note: The change is expected to take effect from the version &apos;{0}&apos;
        ///.
        /// </summary>
        internal static string BreakingChangesAttributesInEffectByVersion {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesInEffectByVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cmdlet invocation changes :
        ///	Old Way : {0}
        ///	New Way : {1}.
        /// </summary>
        internal static string BreakingChangesAttributesUsageChangeMessageConsole {
            get {
                return ResourceManager.GetString("BreakingChangesAttributesUsageChangeMessageConsole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checks out the cart with the identifier of {0}..
        /// </summary>
        internal static string CheckoutPartnerCustomerCartWhatIf {
            get {
                return ResourceManager.GetString("CheckoutPartnerCustomerCartWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City is a required feild. Please update the input and try again..
        /// </summary>
        internal static string CityRequiredError {
            get {
                return ResourceManager.GetString("CityRequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connect-PartnerCenter begin processing with ParameterSet &apos;{0}&apos;..
        /// </summary>
        internal static string ConnectPartnerCenterBeginProcess {
            get {
                return ResourceManager.GetString("ConnectPartnerCenterBeginProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disconnects the current session from Partner Center..
        /// </summary>
        internal static string DisconnectWhatIf {
            get {
                return ResourceManager.GetString("DisconnectWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The domain {0} already exists. Please modify the domain value and try again..
        /// </summary>
        internal static string DomainExistsError {
            get {
                return ResourceManager.GetString("DomainExistsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An invalid environment name was specified..
        /// </summary>
        internal static string InvalidEnvironmentException {
            get {
                return ResourceManager.GetString("InvalidEnvironmentException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not a valid phone number format. Please update the input and try again..
        /// </summary>
        internal static string InvalidPhoneFormatError {
            get {
                return ResourceManager.GetString("InvalidPhoneFormatError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The CustomerId parameter must be set or a customer object must be passed from the pipeline..
        /// </summary>
        internal static string InvalidSetCustomerIdentifierException {
            get {
                return ResourceManager.GetString("InvalidSetCustomerIdentifierException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The UserId parameter must be set or a customer user object must be passed from the pipeline..
        /// </summary>
        internal static string InvalidSetCustomerUserIdentifierException {
            get {
                return ResourceManager.GetString("InvalidSetCustomerUserIdentifierException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not valid entry for the state field. The valid values are {1}. Please update the input and try again..
        /// </summary>
        internal static string InvalidStateError {
            get {
                return ResourceManager.GetString("InvalidStateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new cart for the customer with the identifier of {0}..
        /// </summary>
        internal static string NewCartWhatIf {
            get {
                return ResourceManager.GetString("NewCartWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It appears you are using app only authentication and you did not specify the UserId parameter. Please specify the UserId parameter and try again..
        /// </summary>
        internal static string NewCustomerAgreementInvalidOperationMessage {
            get {
                return ResourceManager.GetString("NewCustomerAgreementInvalidOperationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Accepts the specified agreement for the customer..
        /// </summary>
        internal static string NewPartnerCustomerAgreementWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerAgreementWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new line item associated with the specified cart..
        /// </summary>
        internal static string NewPartnerCustomerCartLineItemWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerCartLineItemWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new customer configuration policy..
        /// </summary>
        internal static string NewPartnerCustomerConfigurationPolicyWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerConfigurationPolicyWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a batch of devices with the identifier of {0}..
        /// </summary>
        internal static string NewPartnerCustomerDeviceBatchWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerDeviceBatchWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new customer order line item in memory..
        /// </summary>
        internal static string NewPartnerCustomerOrderLineItemWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerOrderLineItemWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new customer user with the user principal name of {0}..
        /// </summary>
        internal static string NewPartnerCustomerUserWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerUserWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a new {0} as a new customer..
        /// </summary>
        internal static string NewPartnerCustomerWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerCustomerWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new partner service request..
        /// </summary>
        internal static string NewPartnerServiceRequestWhatIf {
            get {
                return ResourceManager.GetString("NewPartnerServiceRequestWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Postal code is a required field. Please update the input and try again..
        /// </summary>
        internal static string PostalCoderequiredError {
            get {
                return ResourceManager.GetString("PostalCoderequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removes the configuration policy with the identifer of {0}..
        /// </summary>
        internal static string RemovePartnerCustomerConfigurationPolicyWhatIf {
            get {
                return ResourceManager.GetString("RemovePartnerCustomerConfigurationPolicyWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deletes the customer user account with the identifier of {0}..
        /// </summary>
        internal static string RemovePartnerCustomerUserWhatIf {
            get {
                return ResourceManager.GetString("RemovePartnerCustomerUserWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removes the relationship between the customer with the identifier of {0} and the partner. This operation will suspend all active subscriptions..
        /// </summary>
        internal static string RemovePartnerResellerRelationshipWhatIf {
            get {
                return ResourceManager.GetString("RemovePartnerResellerRelationshipWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deletes the customer with the identifier of {0} from the integration sandbox..
        /// </summary>
        internal static string RemovePartnerSandboxCustomerWhatIf {
            get {
                return ResourceManager.GetString("RemovePartnerSandboxCustomerWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Restores the customer user account with the identifier of {0}..
        /// </summary>
        internal static string RestorePartnerCustomerUserWhatIf {
            get {
                return ResourceManager.GetString("RestorePartnerCustomerUserWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run Connect-PartnerCenter to login..
        /// </summary>
        internal static string RunConnectPartnerCenter {
            get {
                return ResourceManager.GetString("RunConnectPartnerCenter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the cart with the identifier of {0}..
        /// </summary>
        internal static string SetPartnerCustomerCartWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerCartWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the configuration policy with the identifer of {0}..
        /// </summary>
        internal static string SetPartnerCustomerConfigurationPolicyWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerConfigurationPolicyWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the support contact for the subscription with the identifier of {0}..
        /// </summary>
        internal static string SetPartnerCustomerSubscriptionSupportContactWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerSubscriptionSupportContactWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the subscription {0} that belongs to the customer with the identifier of {1}..
        /// </summary>
        internal static string SetPartnerCustomerSubscriptionWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerSubscriptionWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the license assignment for the user with the identifier of {0}..
        /// </summary>
        internal static string SetPartnerCustomerUserLicenseWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerUserLicenseWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the specified customer user information for a user with the identifier of {0}..
        /// </summary>
        internal static string SetPartnerCustomerUserWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerUserWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the billing profile for {0}..
        /// </summary>
        internal static string SetPartnerCustomerWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerCustomerWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the partner&apos;s legal business profile..
        /// </summary>
        internal static string SetPartnerLegalProfileWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerLegalProfileWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updates the service request with the identifier of {0}..
        /// </summary>
        internal static string SetPartnerServiceRequestWhatIf {
            get {
                return ResourceManager.GetString("SetPartnerServiceRequestWhatIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to State is a required feild. Please update the input and try again..
        /// </summary>
        internal static string StateRequiredError {
            get {
                return ResourceManager.GetString("StateRequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registers the subscription {0} owned by the customer with the identifier of {1}..
        /// </summary>
        internal static string SubscriptionRegistrationWhatIf {
            get {
                return ResourceManager.GetString("SubscriptionRegistrationWhatIf", resourceCulture);
            }
        }
    }
}
