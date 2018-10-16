// -----------------------------------------------------------------------
// <copyright file="SetPartnerCustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Security;
    using System.Text.RegularExpressions;
    using Common;
    using Exceptions;
    using Models.CustomerUsers;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models.Users;
    using Properties;

    /// <summary>
    /// Sets user information for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerCustomerUser", DefaultParameterSetName = "UserId", SupportsShouldProcess = true), OutputType(typeof(PSCustomerUser))]
    public class SetPartnerCustomerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Sets the optional user display name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "User's display name.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "User's display name.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a flag that specifies whether user must change password on next login.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "Forces user to change password during next login.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "Forces user to change password during next login.")]
        public SwitchParameter ForceChangePasswordNextLogin { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "UserObject", Position = 0, HelpMessage = "The identifier for the customer.")]
        [Parameter(Mandatory = true, ParameterSetName = "UserId", Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer user being modified.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "UserObject", ValueFromPipeline = true, HelpMessage = "The customer user object to be modified.")]
        public PSCustomerUser InputObject { get; set; }

        /// <summary>
        /// Sets the optional user first name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "User's first name.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "User's first name.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Sets the optional user last name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "User's last name.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "User's last name.")]
        public string LastName { get; set; }

        /// <summary>
        /// Sets the optional user display name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "User's new password.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "User's new password.")]
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets usage location, the location where user intends to use the license.
        /// </summary>
        [Parameter(HelpMessage = "The usage location, the location where user intends to use the license.", ParameterSetName = "UserId", Mandatory = false)]
        [Parameter(HelpMessage = "The usage location, the location where user intends to use the license.", ParameterSetName = "UserObject", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string UsageLocation { get; set; }

        /// <summary>
        /// Gets or sets the required user identifier.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "UserId", HelpMessage = "The identifier of the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the optional user principal name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "UserObject", HelpMessage = "The user principal name.")]
        [Parameter(Mandatory = false, ParameterSetName = "UserId", HelpMessage = "The user principal name.")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerUser user;
            UserId = (InputObject == null) ? UserId : InputObject.UserId;

            // Get the current user information
            user = Partner.Customers[CustomerId].Users[UserId].Get();

            try
            {
                if (user.Id == UserId)
                {
                    // see what has changed for this user
                    if (UserPrincipalName != null)
                    {
                        user.UserPrincipalName = UserPrincipalName;
                    }

                    if (FirstName != null)
                    {
                        user.FirstName = FirstName;
                    }

                    if (LastName != null)
                    {
                        user.LastName = LastName;
                    }

                    if (DisplayName != null)
                    {
                        user.DisplayName = DisplayName;
                    }

                    if (UsageLocation != null)
                    {
                        user.UsageLocation = UsageLocation;
                    }

                    PasswordProfile profile = null;
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

                        user = Partner.Customers[CustomerId].Users[UserId].Patch(user);

                        WriteObject(new PSCustomerUser(user), true);
                    }
                }
            }
            catch (PartnerException ex)
            {
                throw new PSPartnerException("An error was encountered when communicating with Partner Center.", ex);
            }
        }
    }
}