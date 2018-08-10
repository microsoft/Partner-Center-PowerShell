<#
.SYNOPSIS
Tests to be performed using the Get-PartnerBillingProfile cmdlet.
#>
function Test-GetPartnerBillingProfile
{
    $profile = Get-PartnerBillingProfile

    Assert-NotNullOrEmpty $profile.CompanyName 'Company name should not be null'    
    Assert-NotNullOrEmpty $profile.PrimaryContact.FirstName 'The first name of the primary contact should not be null'    
    Assert-NotNullOrEmpty $profile.PrimaryContact.LastName 'The last name of the primary contact should not be null'    
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerLegalProfile cmdlet.
#>
function Test-GetPartnerLegalProfile
{
    $profile = Get-PartnerLegalProfile

    Assert-NotNull $profile.Address
    Assert-NotNull $profile.CompanyApproverAddress
    Assert-NotNull $profile.PrimaryContact

    Assert-NotNullOrEmpty $profile.CompanyName
    Assert-NotNullOrEmpty $profile.CompanyApproverEmail
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerSupportProfile cmdlet.
#>
function Test-GetPartnerSupportProfile
{
    $profile = Get-PartnerSupportProfile

    Assert-NotNullOrEmpty $profile.Email
    Assert-NotNullOrEmpty $profile.Website
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerBillingProfile cmdlet.
#>
function Test-SetPartnerBillingProfile
{
    Set-PartnerBillingProfile -AddressLine1 '700 Bellevue Way NE' -City 'Bellevue' -EmailAddress 'jdoe@contoso.com' -FirstName 'Jonathan' -LastName 'Doe' -PhoneNumber '425-555-5555' -PostalCode '98004' -PurchaseOrderNumber '1234' -State 'WA' -TaxId '0123'
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerLegalProfile cmdlet.
#>
function Test-SetPartnerLegalProfile
{
    Set-PartnerLegalProfile -AddressLine1 '700 Bellevue Way NE' -City 'Bellevue' -EmailAddress 'jdoe@lucernepublishing.com' -FirstName 'Jonathan' -LastName 'Doe' -PhoneNumber '425-555-5555' -PostalCode '98004' -State 'WA'
}

<#
.SYNOPSIS
Tests to be performed using the Set-PartnerSupportProfile cmdlet.
#>
function Test-SetPartnerSupportProfile
{
    Set-PartnerSupportProfile -SupportEmail 'support@contoso.com' -SupportPhoneNumber '4255555555' -SupportWebsite 'https://www.microsoft.com'
}