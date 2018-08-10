$ContosoCustomerId = "46a62ece-10ad-42e5-b3f1-b2ed53e6fc08"
$ContosoUserId = "6e668259-1f09-479d-bcb8-d9b03e826b8d"
$ContosoUserPrincipalName = "admin@dtdemocspcustomer005.onmicrosoft.com"
$p = "P@rtn34C3nt3rT3st" | ConvertTo-SecureString -AsPlainText -Force

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomer cmdlet.
#>
function Test-GetPartnerCustomer
{
    $customers = Get-PartnerCustomer
    Assert-NotNull $customers

    $customer = Get-PartnerCustomer -CustomerId $ContosoCustomerId
    Assert-NotNullOrEmpty $customer.CustomerId 'CustomerId should not be null'    
    Assert-NotNullOrEmpty $customer.Domain 'Domain should not be null'    
    Assert-NotNullOrEmpty $customer.Name 'Name should not be null'    
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerEntitlement cmdlet.
#>
function Test-GetPartnerCustomerEntitlement
{
    $entitlement = Get-PartnerCustomerEntitlement -CustomerId $ContosoCustomerId
    Assert-NotNull $entitlement
    Assert-NotNullOrEmpty $entitlement[0].ProductId
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerManagedService cmdlet.
#>

function Test-GetPartnerCustomerManagedService
{
    $links = Get-PartnerCustomerManagedService $ContosoCustomerId
    Assert-NotNull $links
    Assert-NotNullOrEmpty $links[0].ManagedServiceId
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerSubscription cmdlet.
#>
function Test-GetPartnerCustomerSubscription
{
    $customer = Get-PartnerCustomer -CustomerId $ContosoCustomerId
    $subscriptions = $customer | Get-PartnerCustomerSubscription 
    Assert-NotNull $subscriptions
    Assert-NotNullOrEmpty $subscriptions[0].FriendlyName
}

<#
.SYNOPSIS
Tests to be performed using the New-PartnerCustomer cmdlet.
#>
function Test-NewPartnerCustomer
{
    $newCustomer = New-PartnerCustomer -BillingAddressLine1 "12012 Sunset Hills Rd" `
        -BillingAddressCity "Reston" `
        -BillingAddressCountry "US" `
        -BillingAddressPostalCode "20190" `
        -BillingAddressState "VA" `
        -ContactEmail "hugh@tailspintoys.com" `
        -ContactFirstName "Hugh" `
        -ContactLastName "Williams" `
        -ContactPhoneNumber "703-673-7676" `
        -Culture "en-US" `
        -Domain "tailspintoys.onmicrosoft.com" `
        -Language "en" `
        -Name "TailSpin Toys" 

        Assert-NotNull $newCustomer
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerCustomer cmdlet.
#>
function Test-SetPartnerCustomer
{
    $customer = Get-PartnerCustomer -CustomerId $ContosoCustomerId
    $customer | Set-PartnerCustomer -BillingAddressLine1 "123" -BillingAddressLine2 "456"
    Set-PartnerCustomer -BillingAddressLine1 "123" -BillingAddressLine2 "456" -CustomerId $ContosoCustomerId
}


<#
.SYNOPSIS
Tests to be performed using the Set-PartnerCustomerDeviceBatch cmdlet.
#>
function Test-GetPartnerCustomerDeviceBatch
{
    $customer = Get-PartnerCustomer -CustomerId $ContosoCustomerId
    
    $DeviceBatch = Get-PartnerCustomerDeviceBatch $ContosoCustomerId
    Assert-NotNull $DeviceBatch
    Assert-NotNullOrEmpty $DeviceBatch[0].BatchId 'BatchId should not be null'    
    Assert-NotNullOrEmpty $DeviceBatch[0].DevicesCount 'DevicesCount should not be null' 
    Assert-NotNullOrEmpty $DeviceBatch[0].CreationDate 'CreationDate should not be null' 
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerCustomerDevice cmdlet.
#>
function Test-GetPartnerCustomerDevice
{
    $DeviceBatch = Get-PartnerCustomerDeviceBatch $ContosoCustomerId
    $Device = Get-PartnerCustomerDevice -CustomerId $ContosoCustomerId -BatchId $DeviceBatch[0].BatchId
    Assert-NotNull $Device
    Assert-NotNullOrEmpty $Device[0].SerialNumber 'SerialNumber should not be null'    
    Assert-NotNullOrEmpty $Device[0].ProductKey 'ProductKey should not be null'    
    Assert-NotNullOrEmpty $Device[0].OemManufacturerName 'OemManufacturerName should not be null'    
    Assert-NotNullOrEmpty $Device[0].UploadedDate 'UploadedDate should not be null' 
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerLicense cmdlet.
#>
function Test-GetPartnerCustomerLicense
{
    $Licenses = Get-PartnerCustomerLicense -CustomerId $ContosoCustomerId -LicenseGroupId "Group1"
    Assert-NotNull $Licenses
    Assert-NotNullOrEmpty $Licenses[0].ProductSku.Id 'ProductSku.Id should not be null'

    $Licenses = Get-PartnerCustomerLicense -CustomerId $ContosoCustomerId -UserId $ContosoUserId
    Assert-NotNull $Licenses
    Assert-NotNullOrEmpty $Licenses[0].ProductSku.Id 'ProductSku.Id should not be null'
    Assert-NotNullOrEmpty $Licenses[0].ServicePlans.DisplayName[0] 'ServicePlans should not be null'
    Assert-NotNullOrEmpty $Licenses[0].Name 'Name should not be null'
    Assert-NotNullOrEmpty $Licenses[0].LicenseGroupId 'LicenseGroupId should not be null'
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerUser cmdlet.
#>
function Test-GetPartnerCustomerUser
{
    $Users = Get-PartnerCustomerUser -CustomerId $ContosoCustomerId
    Assert-NotNull $Users
    Assert-NotNullOrEmpty $Users[0].UserId 'UserId should not be null'

    $UserUpn = $Users[0].UserPrincipalName
    $DeletedUser = Get-PartnerCustomerUser -CustomerId $ContosoCustomerId -ReturnDeletedUsers
    Assert-NotNull $DeletedUser
    Assert-NotNullOrEmpty $DeletedUser[0].UserId 'UserId should not be null'
    
    $SpecificUser = Get-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserId $ContosoUserId
    Assert-NotNull $SpecificUser
    Assert-NotNull $SpecificUser[0].UserId "UserId should not be null"

    $SpecificUpnUser = Get-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserPrincipalName admin@dtdemocspcustomer005.onmicrosoft.com
    Assert-NotNull $SpecificUpnUser
    Assert-NotNullOrEmpty $SpecificUpnUser[0].UserId 'UserId should not be null'
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerCustomerUser cmdlet.
#>
function Test-SetPartnerCustomerUser
{
    $SpecificUser = Get-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserId $ContosoUserId
    Assert-NotNull $SpecificUser
   
    $UpdatedUser = Set-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserId $ContosoUserId -UserPrincipalName admin@dtdemocspcustomer005.onmicrosoft.com -LastName "Smith"

    $SpecificUser | Set-PartnerCustomerUser -CustomerId $ContosoCustomerId -FirstName "Testing"
}

<#
.SYNOPSIS
Tests to be performed using the Remove-PartnerCustomerUser cmdlet.
#>
function Test-RemovePartnerCustomerUser
{
    Remove-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserId $ContosoUserId
    Remove-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserPrincipalName $ContosoUserPrincipalName
}

<#
.SYNOPSIS
Tests to be performed using the Restore-PartnerCustomerUser cmdlet.
#>
function Test-RestorePartnerCustomerUser
{
    Restore-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserId $ContosoUserId
    Restore-PartnerCustomerUser -CustomerId $ContosoCustomerId -UserPrincipalName $ContosoUserPrincipalName
}

<#
.SYNOPSIS
Tests to be performed using the New-PartnerCustomerUser cmdlet.
#>
function Test-NewPartnerCustomerUser
{
    $newCustomerUser = New-PartnerCustomerUser -FirstName "Tester" `
        -LastName "Testerson" `
        -DisplayName "Tester Testerson" `
        -Password $p `
        -UserPrincipalName "tester@tailspintoys.onmicrosoft.com" `
        -UsageLocation "US" `
        -CustomerId $ContosoCustomerId

        Assert-NotNull $newCustomerUser
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerUserRole cmdlet.
#>
function Test-GetPartnerCustomerUserRole
{
   $OneUserRole = Get-PartnerCustomerUserRole -CustomerId $ContosoCustomerId -UserId $ContosoUserId
   Assert-NotNull $OneUserRole

   $AllUserRoles = Get-PartnerCustomerUserRole -CustomerId $ContosoCustomerId 
   Assert-NotNull $AllUserRoles
}

<#
.SYNOPSIS
Tests to be performed using the Add-PartnerCustomerUserRoleMember cmdlet.
#>
function Test-AddPartnerCustomerUserRoleMember
{
    $AddSuccess = Add-PartnerCustomerUserRoleMember -CustomerId $ContosoCustomerId -UserId $ContosoUserId -RoleId 55c7ddb0-ee68-4535-b5d3-851c3dffd266
    Assert-AreEqual $AddSuccess $true
}

<#
.SYNOPSIS
Tests to be performed using the Remove-PartnerCustomerUserRoleMember cmdlet.
#>
function Test-RemovePartnerCustomerUserRoleMember
{
    $RemSuccess = Remove-PartnerCustomerUserRoleMember -CustomerId $ContosoCustomerId -UserId $ContosoUserId -RoleId 55c7ddb0-ee68-4535-b5d3-851c3dffd266
    Assert-AreEqual $RemSuccess $true
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerCustomerConfigurationPolicy cmdlet.
#>
function Test-GetPartnerCustomerConfigurationPolicy
{
    $ConfigPolicies = Get-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId
    Assert-NotNull $ConfigPolicies
    
    $ConfigPolicy = Get-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId -PolicyId 56edf752-ee77-4fd8-b7f5-df1f74a3a9ac
    Assert-NotNull $ConfigPolicy
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerCustomerConfigurationPolicy cmdlet.
#>
function Test-SetPartnerCustomerConfigurationPolicy
{
    Set-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId -PolicyId 56edf752-ee77-4fd8-b7f5-df1f74a3a9ac -Name "New Policy Name"
    Set-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId -PolicyId 56edf752-ee77-4fd8-b7f5-df1f74a3a9ac -SkipEula $true
}

<#
.SYNOPSIS
Tests to be performed using the New-PartnerCustomerConfigurationPolicy cmdlet.
#>
function Test-NewPartnerCustomerConfigurationPolicy
{
   $newPolicy = New-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId -Name "New Policy Name" -OobeUserNotLocalAdmin $true
   Assert-NotNullOrEmpty $newPolicy
}

<#
.SYNOPSIS
Tests to be performed using the New-PartnerCustomerConfigurationPolicy cmdlet.
#>
function Test-RemovePartnerCustomerConfigurationPolicy
{
   $remPolicy = Remove-PartnerCustomerConfigurationPolicy -CustomerId $ContosoCustomerId -PolicyId 56edf752-ee77-4fd8-b7f5-df1f74a3a9a
}

<#
.SYNOPSIS
Tests to be performed using the Remove-PartnerSandboxCustomer cmdlet.
#>
function Test-RemovePartnerSandboxCustomer
{
    $removed = Remove-PartnerSandboxCustomer $ContosoCustomerId -Confirm:$false
    Assert-AreEqual $removed $true

    Remove-PartnerSandboxCustomer -CustomerId $ContosoCustomerId -Confirm:$false
    Assert-AreEqual $removed $true
}