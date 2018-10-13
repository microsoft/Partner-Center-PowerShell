---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Set-PartnerCustomer

## SYNOPSIS
Updates a customer's billing profile, including the address associated with the profile.

## SYNTAX

### Customer (Default)
```
Set-PartnerCustomer [-BillingAddressLine1 <String>] [-BillingAddressLine2 <String>]
 [-BillingAddressCity <String>] [-BillingAddressCountry <String>] [-BillingAddressPhoneNumber <String>]
 [-BillingAddressPostalCode <String>] [-BillingAddressRegion <String>] [-BillingAddressState <String>]
 -CustomerId <String> [-Email <String>] [-Name <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CustomerObject
```
Set-PartnerCustomer -InputObject <PSCustomer> [-BillingAddressLine1 <String>] [-BillingAddressLine2 <String>]
 [-BillingAddressCity <String>] [-BillingAddressCountry <String>] [-BillingAddressPhoneNumber <String>]
 [-BillingAddressPostalCode <String>] [-BillingAddressRegion <String>] [-BillingAddressState <String>]
 [-Email <String>] [-Name <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a customer's billing profile.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PartnerCustomer -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -BillingAddressLine1 '700 Bellevue Way' -BillingAddressCity 'Bellevue' -BillingAddressPostalCode '98004'
```

Updates the billing address for the customer, with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08, to 700 Bellevue Way NE, Bellevue, WA 98004.

### Example 2
```powershell
PS C:\> $customer = Get-PartnerCustomer 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08
PS C:\> $customer | Set-PartnerCustomer -BillingAddressLine1 '700 Bellevue Way' -BillingAddressCity 'Bellevue' -BillingAddressPostalCode '98004'
```

Updates the billing address for the customer, with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08, to 700 Bellevue Way NE, Bellevue, WA 98004.

## PARAMETERS

### -BillingAddressCity
The city of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressCountry
The country of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressLine1
The first line of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressLine2
The second line of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressPhoneNumber
The phone number of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressPostalCode
The postal code of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressRegion
The region of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingAddressState
The state of the customer's billing address.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerId
Identifier of the customer being modified.

```yaml
Type: String
Parameter Sets: Customer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Email
Email address of the contact at the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The customer object to be modified.

```yaml
Type: PSCustomer
Parameter Sets: CustomerObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## NOTES

## RELATED LINKS
