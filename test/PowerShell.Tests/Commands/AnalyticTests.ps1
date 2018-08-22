<#
.SYNOPSIS
Tests to be performed using the Get-PartnerLicenseDeploymentInfo cmdlet.
#>
function Test-GetPartnerLicenseDeploymentInfo
{
    $deploymentInfo = Get-PartnerLicenseDeploymentInfo

    Assert-NotNull $deploymentInfo
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerLicenseUsageInfo cmdlet.
#>
function Test-GetPartnerLicenseUsageInfo
{
    $usageInfo = Get-PartnerLicenseUsageInfo

    Assert-NotNull $usageInfo
}