// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Security;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Users;
    using PartnerCenter.Models.Users;
    using Properties;

    /// <summary>
    /// Sets user information for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerCustomerUser", DefaultParameterSetName = "UserId", SupportsShouldProcess = true), OutputType(typeof(PSCustomerUser))]
    public class SetPartnerCustomerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the display name for the user.
        /// </summary>
        [Parameter(HelpMessage = "The display name for the user.", Mandatory = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name for the user.
        /// </summary>
        [Parameter(HelpMessage = "The first name for the user.", Mandatory = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicating whether user must change password on next login.
        /// </summary>
        [Parameter(HelpMessage = "Forces user to change password during next login.", Mandatory = false)]
        public SwitchParameter ForceChangePasswordNextLogin { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true, ParameterSetName = "UserObject", Position = 0)]
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true, ParameterSetName = "UserId", Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer user being modified.
        /// </summary>
        [Parameter(HelpMessage = "The customer user object to be modified.", Mandatory = true, ParameterSetName = "UserObject", ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSCustomerUser InputObject { get; set; }

        /// <summary>
        /// Gets or sets the last name for the user.
        /// </summary>
        [Parameter(HelpMessage = "The last name for the user.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        [Parameter(HelpMessage = "The password for the user.", Mandatory = false)]
        [ValidateNotNull]
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets usage location, the location where user intends to use the license.
        /// </summary>
        [Parameter(HelpMessage = "The usage location, the location where user intends to use the license.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string UsageLocation { get; set; }

        /// <summary>
        /// Gets or sets the required user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the user.", Mandatory = true, ParameterSetName = "UserId")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user principal name.
        /// </summary>
        [Parameter(HelpMessage = "The user principal name.", Mandatory = false)]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerUser user;
            PasswordProfile profile;

            UserId = (InputObject == null) ? UserId : InputObject.UserId;

            user = Partner.Customers[CustomerId].Users[UserId].GetAsync().GetAwaiter().GetResult();

            if (user.Id == UserId)
            {
                if (UserPrincipalName != null)
                {
                    user.UserPrincipalName = UserPrincipalName;
                }

                if (!string.IsNullOrEmpty(FirstName))
                {
                    user.FirstName = FirstName;
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    user.LastName = LastName;
                }

                if (!string.IsNullOrEmpty(DisplayName))
                {
                    user.DisplayName = DisplayName;
                }

                if (!string.IsNullOrEmpty(UsageLocation))
                {
                    user.UsageLocation = UsageLocation;
                }

                if (Password != null && Password.Length > 0)
                {
                    string stringPassword = SecureStringExtensions.ConvertToString(Password);

                    profile = new PasswordProfile
                    {
                        Password = stringPassword,
                        ForceChangePassword = ForceChangePasswordNextLogin.IsPresent
                    };

                    user.PasswordProfile = profile;
                }
                else if (ForceChangePasswordNextLogin.IsPresent)
                {
                    profile = new PasswordProfile
                    {
                        ForceChangePassword = ForceChangePasswordNextLogin.IsPresent
                    };

                    user.PasswordProfile = profile;
                }

                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.SetPartnerCustomerUserWhatIf, UserId)))
                {
                    if (InputObject == null && string.IsNullOrEmpty(UserId))
                    {
                        throw new PSInvalidOperationException(Resources.InvalidSetCustomerUserIdentifierException);
                    }

                    user = Partner.Customers[CustomerId].Users[UserId].PatchAsync(user).GetAwaiter().GetResult();

                    WriteObject(new PSCustomerUser(user), true);
                }
            }
        }
    }
}