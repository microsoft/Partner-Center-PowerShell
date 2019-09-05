---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerContext.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerContext
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerContext.md
schema: 2.0.0
---

# Get-PartnerContext

## SYNOPSIS
Gets the metadata used to authenticate Partner Center requests.

## SYNTAX

```powershell
Get-PartnerContext [<CommonParameters>]
```

## DESCRIPTION
The Get-PartnerContext cmdlet gets the current metadata used to authenticate Partner Center requests.

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-PartnerCenter
PS C:\> Get-PartnerContext
```

In this example we are logging into our partner account using Connect-PartnerCenter, and then we are getting the context of the current session by calling Get-PartnerContext.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication.PartnerContext

## NOTES

## RELATED LINKS
