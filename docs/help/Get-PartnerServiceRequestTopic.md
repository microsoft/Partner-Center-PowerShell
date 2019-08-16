---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceRequestTopic.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerServiceRequestTopic
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceRequestTopic.md
schema: 2.0.0
---

# Get-PartnerServiceRequestTopic

## SYNOPSIS
Gets a list of service request topics.

## SYNTAX

```powershell
Get-PartnerServiceRequestTopic [-SupportTopicId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a collection of items representing valid topics for service requests.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerServiceRequestTopic -SupportTopicId <Support Topic ID>
```

Gets a specific support topic based on the specified support topic identifier.

### Example 2
```powershell
PS C:\> Get-PartnerServiceRequestTopic
```

Gets all of the available support topics.

## PARAMETERS

### -SupportTopicId
The identifier of the support topic.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceRequests.PSSupportTopic

## NOTES

## RELATED LINKS
