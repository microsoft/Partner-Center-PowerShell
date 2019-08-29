---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerEnvironment.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerEnvironment
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerEnvironment.md
schema: 2.0.0
---

# Get-PartnerEnvironment

## SYNOPSIS
Get endpoints and metadata for an instance of Partner Center.

## SYNTAX

```powershell
Get-PartnerEnvironment [[-Name] <String>] [<CommonParameters>]
```

## DESCRIPTION
Get endpoints and metadata for an instance of Partner Center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerEnvironment
```

Get endpoints and metadata for an instance of Partner Center.

## PARAMETERS

### -Name
The name of the environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: AzureChinaCloud, AzureCloud, AzureGermanCloud, AzurePPE, AzureUSGovernment

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication.PSPartnerEnvironment

## NOTES

## RELATED LINKS
