---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceRequest.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerServiceRequest
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceRequest.md
schema: 2.0.0
---

# Get-PartnerServiceRequest

## SYNOPSIS
Gets the specified customer's service requests.

## SYNTAX

### ByStatus (Default)
```
Get-PartnerServiceRequest [-Status <ServiceRequestStatus>] [-Severity <ServiceRequestSeverity>]
 [<CommonParameters>]
```

### BySeverity
```
Get-PartnerServiceRequest [-Status <ServiceRequestStatus>] [-Severity <ServiceRequestSeverity>]
 [<CommonParameters>]
```

### ByCustomerId
```
Get-PartnerServiceRequest [-Status <ServiceRequestStatus>] [-Severity <ServiceRequestSeverity>]
 -CustomerId <String> [<CommonParameters>]
```

### ByRequestId
```
Get-PartnerServiceRequest -CustomerId <String> [-RequestId <String>] [<CommonParameters>]
```

## DESCRIPTION

Gets the specified customer's service requests.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerServiceRequest -CustomerId <Customer ID> -Severity "Critical" -Status "Open"
```

Gets the service requests for the specified customer that are critical in severity and have a status of open.

## PARAMETERS

### -CustomerId
The identifier of the customer.

```yaml
Type: String
Parameter Sets: ByCustomerId, ByRequestId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestId
The identifier of the service request.

```yaml
Type: String
Parameter Sets: ByRequestId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
The status of the support request.

```yaml
Type: ServiceRequestSeverity
Parameter Sets: ByStatus, BySeverity, ByCustomerId
Aliases:
Accepted values: Critical, Minimal, Moderate, Unknown

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status of the support request.

```yaml
Type: ServiceRequestStatus
Parameter Sets: ByStatus, BySeverity, ByCustomerId
Aliases:
Accepted values: AttentionNeeded, Closed, None, Open

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
