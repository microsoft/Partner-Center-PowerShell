---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrderLineItemActivationLink.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerOrderLineItemActivationLink
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrderLineItemActivationLink.md
schema: 2.0.0
---

# Get-PartnerCustomerOrderLineItemActivationLink

## SYNOPSIS
Gets the activation link for the specified order line item.

## SYNTAX

```powershell
Get-PartnerCustomerOrderLineItemActivationLink -CustomerId <String> -OrderId <String>
 -OrderLineItemNumber <Int32> [<CommonParameters>]
```

## DESCRIPTION
Gets the activation link for the specified order line item.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerOrderLineItemActivationLink -CustomerId '2ca7de6c-c05c-46b5-b689-32e53573a97a' -OrderId 'kyTs4y7jRu99MyeIudk6Q1G_aeUdT_tu1' -OrderLineItemNumber 0
```

Gets the activation link for the specified order line item.

## PARAMETERS

### -CustomerId
The identifier of the customer.

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

### -OrderLineItemNumber
The order line item number.

```yaml
Type: Int32
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

### Microsoft.Store.PartnerCenter.Models.Orders.OrderLineItemActivationLink

## NOTES

## RELATED LINKS
