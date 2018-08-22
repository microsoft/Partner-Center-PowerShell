---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerCustomerServiceCosts

## SYNOPSIS
Gets a customer's service cost line items for the specified billing period.

## SYNTAX

```
Get-PartnerCustomerServiceCosts -BillingPeriod <ServiceCostsBillingPeriod> -CustomerId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Gets a customer's service cost line items for the specified billing period.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerServiceCosts -BillingPeriod MostRecent -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets a customer's service cost line items for the specified billing period.

## PARAMETERS

### -BillingPeriod
An indicator that represents the billing period.

```yaml
Type: ServiceCostsBillingPeriod
Parameter Sets: (All)
Aliases:
Accepted values: Current, MostRecent

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceCosts.PSServiceCostLineItem

## NOTES

## RELATED LINKS
