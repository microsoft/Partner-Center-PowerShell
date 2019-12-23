---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrderProvisioningStatus.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerOrderProvisioningStatus
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrderProvisioningStatus.md
schema: 2.0.0
---

# Get-PartnerCustomerOrderProvisioningStatus

## SYNOPSIS
Gets the provisioning status for a customer order.

## SYNTAX

```powershell
Get-PartnerCustomerOrderProvisioningStatus -CustomerId <String> -OrderId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the provisioning status for a customer order.

## EXAMPLES

### Example 1
```powershell
PS C:> Get-PartnerCustomerOrderProvisioningStatus -CustomerId '2ca7de6c-c05c-46b5-b689-32e53573a97a' -OrderId 'kyTs4y7jRu99MyeIudk6Q1G_aeUdT_tu1'
```

Gets the provisioning status for a customer order.

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

### -OrderId
The identifier for the order.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrderLineItemProvisioningStatus

## NOTES

## RELATED LINKS
