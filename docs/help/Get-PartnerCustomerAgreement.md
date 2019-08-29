---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerAgreement.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerAgreement
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerAgreement.md
schema: 2.0.0
---

# Get-PartnerCustomerAgreement

## SYNOPSIS
Gets confirmation of customer acceptance provided previously.

## SYNTAX

```powershell
Get-PartnerCustomerAgreement [-AgreementType <String>] -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets confirmation of customer acceptance provided previously. This operation is currently supported by Partner Center in the Microsoft public cloud only.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerAgreement -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets confirmation of customer acceptance provided previously.

## PARAMETERS

### -AgreementType
The type of agreement of being requested.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: MicrosoftCloudAgreement, MicrosoftCustomerAgreement

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerId
The identifier for the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements.PSAgreement

## NOTES

## RELATED LINKS
