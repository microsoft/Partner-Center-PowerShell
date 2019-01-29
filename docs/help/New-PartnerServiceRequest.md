---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerServiceRequest.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerServiceRequest.md
schema: 2.0.0
---

# New-PartnerServiceRequest

## SYNOPSIS
Creates a service request at the partner level.

## SYNTAX

```powershell
New-PartnerServiceRequest [-AgentLocale <String>] -Description <String> -Severity <ServiceRequestSeverity>
 -SupportTopicId <String> -Title <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a service request at the partner level.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerServiceRequestTopic 
PS C:\> New-PartnerServiceRquest -Description 'Please ignore this SR' -Severity -SupportTopicId '32569836' -Title 'Please ignore this SR'
```

Creates a service request at the partner level.

## PARAMETERS

### -AgentLocale
The locale of the organization creating the service request.

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

### -Description
The descripion for the service reuqest.

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

### -Severity
The severity for the service reuqest.

```yaml
Type: ServiceRequestSeverity
Parameter Sets: (All)
Aliases:
Accepted values: Critical, Minimal, Moderate

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTopicId
The support topic identifier for the service reuqest.

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

### -Title
The title for the service reuqest.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceRequests.PSServiceRequest

## NOTES

## RELATED LINKS
