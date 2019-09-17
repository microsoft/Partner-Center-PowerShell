#Requires -Modules platyPS

[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,
    [Parameter()]
    [Switch]$GenerateMamlHelp,
    [Parameter()]
    [string]$BuildConfig
)

Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    $SuppressedExceptionsPath = "$PSScriptRoot\StaticAnalysis\Exceptions"

    if (!(Test-Path -Path $SuppressedExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "Exceptions" -ItemType Directory
    }

    $NewExceptionsPath = "$PSScriptRoot\..\artifacts\StaticAnalysisResults"

    if (!(Test-Path -Path $NewExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "StaticAnalysisResults" -ItemType Directory
    }
    
    Copy-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\ValidateHelpIssues.csv" -Destination $SuppressedExceptionsPath
    New-Item -Path $NewExceptionsPath -Name ValidateHelpIssues.csv -ItemType File -Force | Out-Null
    Add-Content "$NewExceptionsPath\ValidateHelpIssues.csv" "Target,Description"

    Test-PartnerCenterMarkdownHelp "$PSScriptRoot\..\docs\help" $SuppressedExceptionsPath $NewExceptionsPath

    $Exceptions = Import-Csv "$NewExceptionsPath\ValidateHelpIssues.csv"
    
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | ft
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }
    else
    {
        New-Item -Path $NewExceptionsPath -Name NoHelpIssues -ItemType File -Force | Out-Null
        Remove-Item -Path "$SuppressedExceptionsPath\ValidateHelpIssues.csv" -Force
        Remove-Item -Path "$NewExceptionsPath\ValidateHelpIssues.csv" -Force
    }
}

if ($GenerateMamlHelp)
{
    New-PartnerCenterMamlHelp -HelpFolderPath "$PSScriptRoot\..\docs\help" -OutputPath "$PSScriptRoot\..\artifacts\$BuildConfig"
}