---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Resolve-PartnerError.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Resolve-PartnerError
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Resolve-PartnerError.md
schema: 2.0.0
---

# Resolve-PartnerError

## SYNOPSIS
Display detailed information about PowerShell errors, with extended details for Partner Center PowerShell errors.

## SYNTAX

### AnyErrorParameterSet
```powershell
Resolve-PartnerError [[-Error] <ErrorRecord[]>] [<CommonParameters>]
```

### LastErrorParameterSet
```powershell
Resolve-PartnerError [-Last] [<CommonParameters>]
```

## DESCRIPTION
Resolves and displays detailed information about errors in the current PowerShell session, including where the error occurred in script, stack trace, and all inner and aggregate exceptions. For Partner Center PowerShell errors provides additional detail in debugging service issues, including complete detail about the request and server response that caused the error.

## EXAMPLES

### Example 1: Resolve the last error
```powershell
PS C:\> Resolve-PartnerError -Last
```

Get the details of the last error.

### Example 2: Resolve all errors in the session
```powershell
PS C:\> Resolve-PartnerError
```

Get details of all errors that have occurred in the current session.

### Example 3: Resolve a specific error
```powershell
PS C:\> Resolve-PartnerError $Error[0]
```

Get the details of the specified error.

## PARAMETERS

### -Error
The error records to resolve

```yaml
Type: ErrorRecord[]
Parameter Sets: AnyErrorParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Last
The last error

```yaml
Type: SwitchParameter
Parameter Sets: LastErrorParameterSet
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

### System.Management.Automation.ErrorRecord[]

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Errors.PartnerErrorRecord

### Microsoft.Store.PartnerCenter.PowerShell.Models.Errors.PartnerExceptionRecord

### Microsoft.Store.PartnerCenter.PowerShell.Models.Errors.PartnerRestExceptionRecord

## NOTES

## RELATED LINKS
