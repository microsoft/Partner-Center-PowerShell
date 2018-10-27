---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# New-PartnerCustomer

## SYNOPSIS
Creates a new customer.

## SYNTAX

```
New-PartnerCustomer [-AssociatedPartnerId <String>] -BillingAddressLine1 <String>
 [-BillingAddressLine2 <String>] [-BillingAddressCity <String>] -BillingAddressCountry <String>
 [-BillingAddressPostalCode <String>] [-BillingAddressRegion <String>] [-BillingAddressState <String>]
 [-ContactEmail <String>] [-ContactFirstName <String>] [-ContactLastName <String>]
 [-ContactPhoneNumber <String>] [-Culture <String>] -Domain <String> -Language <String> -Name <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerCustomer -BillingAddressLine1 '1 Microsoft Way' -BillingAddressCity 'Redmond' -BillingAddressCountry 'US' -BillingAddressPostalCode '98052' -BillingAddressState 'WA' -ContactEmail 'jdoe@customer.com' -ContactFirstName 'Jane' -ContactLastName 'Doe' -Culture 'en-US' -Domain 'newcustomer.onmicrosoft.com' -Language 'en' -Name 'New Customer'
```

Creates a new customer.

## PARAMETERS

### -AssociatedPartnerId
The associated partner identifier. Used if creating a customer for an indirect reseller.

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

Required: True
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

Required: True
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

### -ContactEmail
The email address of the primary contact at the customer.

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

### -ContactFirstName
The first name of the primary contact at the customer.

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

### -ContactLastName
The last name of the primary contact at the customer.

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

### -ContactPhoneNumber
The phone number of the primary contact at the customer.

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

### -Culture
The preferred culture for communication and currency.

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

### -Domain
The customer's domain name, such as contoso.onmicrosoft.com.
27 characters maximum domain prefix + 16 maximum characters suffix for '.onmicrosoft.com'

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

### -Language
The default language.
Two character language codes (e.g., en, fr) are supported.

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

### -Name
The name of the customer to be created.

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

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## NOTES

## RELATED LINKS
