---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementTemplate.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenterGet-PartnerAgreementTemplate
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAgreementTemplate.md
schema: 2.0.0
---

# Get-PartnerAgreementTemplate

## SYNOPSIS
Gets the links to download or view the Microsoft Customer Agreement template.

## SYNTAX

```powershell
Get-PartnerAgreementTemplate -TemplateId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the links to download or view the Microsoft Customer Agreement template.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAgreementTemplate -TemplateId '<TemplateId>'
```

Gets the links to download or view the Microsoft Customer Agreement template.

## PARAMETERS

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Agreements.PSAgreementTemplate

## NOTES

## RELATED LINKS
