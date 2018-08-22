---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerCustomerSubscribedSku

## SYNOPSIS
Gets a list of licenses available to users of the specified customer.

## SYNTAX

```
Get-PartnerCustomerSubscribedSku -CustomerId <String> [-LicenseGroup <LicenseGroupId[]>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of licenses available to users of the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscribedSku -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets a list of licenses available to users of the specified customer.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerSubscribedSku -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group1
```

Gets a list of Azure Active Directory (AAD) licenses available to users of the specified customer.

### Example 3
```powershell
PS C:\> Get-PartnerCustomerSubscribedSku -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group2
```

Gets a list of Minecraft licenses available to users of the specified customer.

### Example 4
```powershell
PS C:\> Get-PartnerCustomerSubscribedSku -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group1,Group2
```

Gets a list of Azure Active Directory (AAD) and Minecraft licenses available to users of the specified customer.

## PARAMETERS

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

### -LicenseGroup
The identifier for the license group.

```yaml
Type: LicenseGroupId[]
Parameter Sets: (All)
Aliases:
Accepted values: Group1, Group2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses.PSSubscribedSku

## NOTES

## RELATED LINKS
