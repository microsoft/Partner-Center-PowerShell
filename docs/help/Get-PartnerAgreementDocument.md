---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementDocument.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenterGet-PartnerAgreementDocument
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementDocument.md
schema: 2.0.0
---

# Get-PartnerAgreementDocument

## SYNOPSIS
Gets the links to download or view the Microsoft Customer Agreement template.

## SYNTAX

```powershell
Get-PartnerAgreementDocument [-Country <String>] [-Language <String>] -TemplateId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the links to download or view the Microsoft Customer Agreement template.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAgreementDocument -TemplateId '<TemplateId>'
```

Gets the links to download or view the Microsoft Customer Agreement template.

## PARAMETERS

### -Country
The country of the agreement document.

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

### -Language
The language and locale of the agreement document.

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

### -TemplateId
The unique identifier of the agreement type.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements.PSAgreementDocument

## NOTES

## RELATED LINKS
