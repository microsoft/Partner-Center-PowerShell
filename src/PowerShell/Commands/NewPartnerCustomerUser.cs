// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Security;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Authentication;
    using Models.Users;
    using PartnerCenter.Models.Users;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerUser", SupportsShouldProcess = true), OutputType(typeof(PSCustomerUser))]
    public class NewPartnerCustomerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer user.
        /// </summary>
        [Parameter(HelpMessage = "The first name for the new customer user.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name for the customer user.
        /// </summary>
        [Parameter(HelpMessage = "The last name for the new customer user.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the display name for the customer user.
        /// </summary>
        [Parameter(HelpMessage = "The display name for the new customer user.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the user pricipal name for the customer user.
        /// </summary>
        [Parameter(HelpMessage = "The user principal name (UPN) for the new customer user, including the onmicrosoft.com domain name.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Gets or sets the password for the customer user.
        /// </summary>
        [Parameter(HelpMessage = "The password for the new custom user as a secure string", Mandatory = true)]
        [ValidateNotNull]
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets the force password change at next login for the new customer user.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces user to change password during next login.")]
        public SwitchParameter ForceChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the customer user region.
        /// </summary>
        [Parameter(HelpMessage = "The location where the customer user will use software and services. Service availability varies by region.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string UsageLocation { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerUser newUser;
            string country;
            CustomerId.AssertNotEmpty(nameof(CustomerId));

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewPartnerCustomerUserWhatIf, UserPrincipalName)))
            {
                country = (string.IsNullOrEmpty(UsageLocation)) ? PartnerSession.Instance.Context.CountryCode : UsageLocation;
                string stringPassword = SecureStringExtensions.ConvertToString(Password);

                newUser = new CustomerUser
                {
                    PasswordProfile = new PasswordProfile()
                    {
                        ForceChangePassword = ForceChangePassword.IsPresent,
                        Password = stringPassword
                    },
                    DisplayName = DisplayName,
                    FirstName = FirstName,
                    LastName = LastName,
                    UsageLocation = country,
                    UserPrincipalName = UserPrincipalName
                };
                CustomerUser createdUser = Partner.Customers[CustomerId].Users.CreateAsync(newUser).GetAwaiter().GetResult();
                WriteObject(new PSCustomerUser(createdUser));
            }
        }
    }
}