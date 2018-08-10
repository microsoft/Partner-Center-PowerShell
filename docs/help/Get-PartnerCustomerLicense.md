---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerCustomerLicense

## SYNOPSIS
Get a list of licenses available for a customer that are assigned or can be assigned to a user.

## SYNTAX

### ByCustomerId (Default)
```
Get-PartnerCustomerLicense -CustomerId <String> [-LicenseGroupId <LicenseGroupId>] [<CommonParameters>]
```

### ByUserId
```
Get-PartnerCustomerLicense -CustomerId <String> [-UserId <String>] [<CommonParameters>]
```

## DESCRIPTION
The Get-PartnerCustomerLicense cmdlet returns a list of subscribed skus (licenses) that a customer has subscribed to and can be filtered by a LicenseGroupId (Group1: License group for AAD, Group2: License group for Minecraft, None: Both AAD and minecraft skus). Alternatively, you can get a list of licenses assigned to a specific user by specifying the user id.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerLicense -CustomerId c4f6bf3c-60de-432e-a3ec-20bcc5b26ec2
```

Return a list a available licenses for the specified customer.

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

### -LicenseGroupId
The identifier for the license group.

```yaml
Type: LicenseGroupId
Parameter Sets: ByCustomerId
Aliases:
Accepted values: None, Group1, Group2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The identifier for the user.

```yaml
Type: String
Parameter Sets: ByUserId
Aliases:

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
