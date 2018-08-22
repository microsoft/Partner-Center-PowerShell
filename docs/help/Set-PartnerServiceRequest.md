---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Set-PartnerServiceRequest

## SYNOPSIS
Updates a service request at the partner level.

## SYNTAX

```
Set-PartnerServiceRequest [-NewNote <String>] [-ServiceRequestId] <String> [-Status <ServiceRequestStatus>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a service request at the partner level.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PartnerServiceRequest -NewNote 'Closing this SR' -ServiceRequestId '618000000000000' -Status Closed
```

Updates the status for the specified service request to closed.

## PARAMETERS

### -NewNote
The text of the new note that will be added to the service request.

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

### -ServiceRequestId
The identifier for the service request.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status for the service request.

```yaml
Type: ServiceRequestStatus
Parameter Sets: (All)
Aliases:
Accepted values: AttentionNeeded, Closed, Open

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

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceRequests.PSServiceRequest

## NOTES

## RELATED LINKS
