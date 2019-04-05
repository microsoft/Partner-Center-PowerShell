---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerAgreement.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerAgreement
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerAgreement.md
schema: 2.0.0
---

# New-PartnerCustomerAgreement

## SYNOPSIS
Confirms the customer acceptance of the Microsoft Cloud agreement.

## SYNTAX

```powershell
New-PartnerCustomerAgreement -AgreementType <AgreementType> -ContactEmail <String> -ContactFirstName <String>
 -ContactLastName <String> [-ContactPhoneNumber <String>] -CustomerId <String> [-DateAgreed <DateTime>]
 -TemplateId <String> [-UserId <String>] [<CommonParameters>]
```

## DESCRIPTION
Confirms the customer acceptance of the Microsoft Cloud agreement.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerCustomerAgreement -AgreementType MicrosoftCloudAgreement -ContactEmail 'jdoe@customer.com' -ContactFirstName 'Jane' -ContactLastName 'Doe' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -TemplateId '998b88de-aa99-4388-a42c-1b3517d49490'
```

Confirms the customer acceptance of the Microsoft Cloud agreement.

## PARAMETERS

### -AgreementType
The type of agreement being accepted.

```yaml
Type: AgreementType
Parameter Sets: (All)
Aliases:
Accepted values: MicrosoftCloudAgreement

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactEmail
The email address of the primary contact of the customer.

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

### -ContactFirstName
The first name of the primary contact of the customer.

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

### -ContactLastName
The last name of the primary contact of the customer.

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

### -ContactPhoneNumber
The phone number of the primary contact of the customer.

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

### -DateAgreed
The date the agreement was signed.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateId
The identifier for the template.

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

### -UserId
The identifier of the user in the partner tenant who is providing confirmation on behalf of the customer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements.PSAgreement

## NOTES

## RELATED LINKS
