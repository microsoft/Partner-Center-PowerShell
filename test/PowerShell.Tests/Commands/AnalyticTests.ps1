<#
.SYNOPSIS
Tests to be performed using the Get-PartnerLicenseDeploymentInformation cmdlet.
#>
function Test-GetPartnerLicenseDeploymentInformation
{
    $deploymentInfo = Get-PartnerLicenseDeploymentInfo

    Assert-NotNull $deploymentInfo
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerLicenseUsageInformation cmdlet.
#>
function Test-GetPartnerLicenseUsageInformation
{
    $usageInfo = Get-PartnerLicenseUsageInfo

    Assert-NotNull $usageInfo
}