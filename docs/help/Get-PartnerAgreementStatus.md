---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementStatus.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAgreementStatus
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementStatus.md
schema: 2.0.0
---

# Get-PartnerAgreementStatus

## SYNOPSIS
Gets the status of acceptance of the Microsoft Partner Agreement for the specified partner.

## SYNTAX

### ByTenantId (Default)
```powershell
Get-PartnerAgreementStatus [-TenantId] <String> [<CommonParameters>]
```

### ByMpnId
```powershell
Get-PartnerAgreementStatus [-MpnId] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the status of acceptance of the Microsoft Partner Agreement for the specified partner.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAgreementStatus -MpnId '999999'
```

Gets the status of acceptance of the Microsoft Partner Agreement for the specified partner.

### Example 2
```powershell
PS C:\> Get-PartnerAgreementStatus -TenantId 'd96a841d-1672-4175-a878-df65b98a8550'
```

Gets the status of acceptance of the Microsoft Partner Agreement for the specified partner.

## PARAMETERS

### -MpnId
The Microsoft Partner Network (MPN) identifier for the partner.

```yaml
Type: String
Parameter Sets: ByMpnId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant identifier for the partner.

```yaml
Type: String
Parameter Sets: ByTenantId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.Models.Compliance.AgreementSignatureStatus

## NOTES

## RELATED LINKS
