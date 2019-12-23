---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementDetail.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAgreementDetail
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementDetail.md
schema: 2.0.0
---

# Get-PartnerAgreementDetail

## SYNOPSIS
Gets the agreement metadata for the Microsoft Cloud Agreement.

## SYNTAX

```powershell
Get-PartnerAgreementDetail [-AgreementType <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets the agreement metadata for the  Microsoft Cloud Agreement. This operation is currently supported by Partner Center in the Microsoft public cloud only.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAgreementDetail
```

Gets the agreement metadata for the Microsoft Cloud Agreement.

## PARAMETERS

### -AgreementType
The type of agreement of being requested.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: All, MicrosoftCloudAgreement, MicrosoftCustomerAgreement

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements.PSAgreementMetaData

## NOTES

## RELATED LINKS
