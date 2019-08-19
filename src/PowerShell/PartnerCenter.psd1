﻿#
# Module manifest for module 'PartnerCenter'
#
# Generated by: Microsoft Corporation
#
# Generated on: 08/18/2019
#

@{
    # Script module or binary module file associated with this manifest.
    RootModule = 'Microsoft.Store.PartnerCenter.PowerShell.dll'

    # Version number of this module.
    ModuleVersion = '2.0.1908.1'

    # Supported PSEditions
    CompatiblePSEditions = 'Core', 'Desktop'

    # ID used to uniquely identify this module
    GUID = '70cb9a9e-1491-403a-8a2f-63e1afe7dfee'

    # Author of this module
    Author = 'Microsoft Corporation'

    # Company or vendor of this module
    CompanyName = 'Microsoft Corporation'

    # Copyright statement for this module
    Copyright = 'Microsoft Corporation. All rights reserved.'

    # Description of the functionality provided by this module
    Description = 'Microsoft Partner Center - cmdlets for managing Partner Center resources.'

    # Minimum version of the Windows PowerShell engine required by this module
    PowerShellVersion = '5.1'

    # Name of the Windows PowerShell host required by this module
    # PowerShellHostName = ''

    # Minimum version of the Windows PowerShell host required by this module
    # PowerShellHostVersion = ''

    # Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
    DotNetFrameworkVersion = '4.6.1'

    # Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
    # CLRVersion = '4.0'

    # Processor architecture (None, X86, Amd64) required by this module
    # ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    #RequiredModules = @()

    # Assemblies that must be loaded prior to importing this module
    RequiredAssemblies = '.\Microsoft.Store.PartnerCenter.PowerShell.dll'

    # Script files (.ps1) that are run in the caller's environment prior to importing this module.
    # ScriptsToProcess = @()

    # Type files (.ps1xml) to be loaded when importing this module
    # TypesToProcess = @()

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = 'Microsoft.Store.PartnerCenter.PowerShell.format.ps1xml'

    # Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
    NestedModules = @()

    # Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
    FunctionsToExport = @()

    # Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
    CmdletsToExport = 'Add-PartnerCustomerCartLineItem',
                        'Add-PartnerCustomerUserRoleMember',
                        'Connect-PartnerCenter',
                        'Disconnect-PartnerCenter',
                        'Get-PartnerAgreementDetail',
                        'Get-PartnerAuditRecord',
                        'Get-PartnerAzureRateCard',
                        'Get-PartnerBillingProfile',
                        'Get-PartnerCountryValidation',
                        'Get-PartnerCustomer',
                        'Get-PartnerCustomerAgreement',
                        'Get-PartnerCustomerBillingProfile',
                        'Get-PartnerCustomerCart',
                        'Get-PartnerCustomerCompanyProfile',
                        'Get-PartnerCustomerConfigurationPolicy',
                        'Get-PartnerCustomerDevice',
                        'Get-PartnerCustomerDeviceBatch',
                        'Get-PartnerCustomerEntitlement',
                        'Get-PartnerCustomerLicenseDeploymentInfo',
                        'Get-PartnerCustomerManagedService',
                        'Get-PartnerCustomerOrder',
                        'Get-PartnerCustomerOrderLineItemActivationLink',
                        'Get-PartnerCustomerOrderProvisioningStatus',
                        'Get-PartnerCustomerQualification',
                        'Get-PartnerCustomerServiceCosts',
                        'Get-PartnerCustomerServiceCostsSummary',
                        'Get-PartnerCustomerSubscribedSku',
                        'Get-PartnerCustomerSubscription',
                        'Get-PartnerCustomerSubscriptionAddOn',
                        'Get-PartnerCustomerSubscriptionProvisioningStatus',
                        'Get-PartnerCustomerSubscriptionRegistrationStatus',
                        'Get-PartnerCustomerSubscriptionSupportContact',
                        'Get-PartnerCustomerSubscriptionUpgrades',
                        'Get-PartnerCustomerSubscriptionUsage',
                        'Get-PartnerCustomerSubscriptionUtilization',
                        'Get-PartnerCustomerTrialConversion',
                        'Get-PartnerCustomerUsageSummary',
                        'Get-PartnerCustomerUser',
                        'Get-PartnerCustomerUserLicense',
                        'Get-PartnerCustomerUserRole',
                        'Get-PartnerIndirectReseller',
                        'Get-PartnerInvoice',
                        'Get-PartnerInvoiceLineItem',
                        'Get-PartnerInvoiceSummary',
                        'Get-PartnerInvoiceStatement',
                        'Get-PartnerInvoiceTaxReceiptStatement',
                        'Get-PartnerLegalProfile',
                        'Get-PartnerLicenseDeploymentInfo',
                        'Get-PartnerLicenseUsageInfo',
                        'Get-PartnerMpnProfile',
                        'Get-PartnerOffer',
                        'Get-PartnerOfferAddon',
                        'Get-PartnerOfferCategory',
                        'Get-PartnerOrganizationProfile',
                        'Get-PartnerProduct',
                        'Get-PartnerProductAvailability',
                        'Get-PartnerProductInventory',
                        'Get-PartnerProductSku',
                        'Get-PartnerResellerRequestLink',
                        'Get-PartnerRole',
                        'Get-PartnerRoleMember',
                        'Get-PartnerServiceIncident',
                        'Get-PartnerServiceRequest',
                        'Get-PartnerServiceRequestTopic',
                        'Get-PartnerSupportProfile',
                        'Get-PartnerValidationCode',
                        'New-PartnerAccessToken',
                        'New-PartnerCustomer',
                        'New-PartnerCustomerAgreement',
                        'New-PartnerCustomerApplicationConsent',
                        'New-PartnerCustomerCart',
                        'New-PartnerCustomerConfigurationPolicy',
                        'New-PartnerCustomerDeviceBatch',
                        'New-PartnerCustomerOrder',
                        'New-PartnerCustomerSubscriptionRegistration',
                        'New-PartnerCustomerUser',
                        'New-PartnerServiceRequest',
                        'Remove-PartnerCustomerConfigurationPolicy',
                        'Remove-PartnerCustomerUser',
                        'Remove-PartnerCustomerUserRoleMember',
                        'Remove-PartnerResellerRelationship',
                        'Remove-PartnerSandboxCustomer',
                        'Restore-PartnerCustomerUser',
                        'Set-PartnerBillingProfile',
                        'Set-PartnerCustomer',
                        'Set-PartnerCustomerCart',
                        'Set-PartnerCustomerConfigurationPolicy',
                        'Set-PartnerCustomerQualification',
                        'Set-PartnerCustomerSubscription',
                        'Set-PartnerCustomerSubscriptionSupportContact',
                        'Set-PartnerCustomerUser',
                        'Set-PartnerCustomerUserLicense',
                        'Set-PartnerLegalProfile',
                        'Set-PartnerOrganizationProfile',
                        'Set-PartnerServiceRequest',
                        'Set-PartnerSupportProfile',
                        'Submit-PartnerCustomerCart',
                        'Test-PartnerAddress',
                        'Test-PartnerDomainAvailability'

    # Variables to export from this module
    # VariablesToExport = @()

    # Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
    AliasesToExport = @()

    # DSC resources to export from this module
    # DscResourcesToExport = @()

    # List of all modules packaged with this module
    # ModuleList = @()

    # List of all files packaged with this module
    # FileList = @()

    # Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
    PrivateData = @{
        PSData = @{
            # Tags applied to this module. These help with module discovery in online galleries.
            Tags = 'CSP','PartnerCenter','Azure','Office365'

            # A URL to the license for this module.
            LicenseUri = 'https://raw.githubusercontent.com/Microsoft/Partner-Center-PowerShell/master/LICENSE'

            # A URL to the main website for this project.
            ProjectUri = 'https://github.com/Microsoft/Partner-Center-PowerShell'

            # A URL to an icon representing this module.
            # IconUri = ''

            # ReleaseNotes of this module
            ReleaseNotes = ''

            # Prerelease string of this module
            Prerelease = 'preview'

            # Flag to indicate whether the module requires explicit user acceptance for install/update
            # RequireLicenseAcceptance = $false

            # External dependent modules of this module
            # ExternalModuleDependencies = @()

        } # End of PSData hashtable 
    } # End of PrivateData hashtable

    # HelpInfo URI of this module
    # HelpInfoURI = ''

    # Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
    # DefaultCommandPrefix = ''
}