<#
.SYNOPSIS
Verifies that two given objects are equal.
#>
function Assert-AreEqual
{
	param([object] $expected, [object] $actual, [string] $message)
  
	if (!$message)
	{
		$message = "Assertion failed because expected '$expected' does not match actual '$actual'"
	}
  
	if ($expected -ne $actual) 
	{
		throw $message
	}
  
	return $true
}

<#
.SYNOPSIS
Validates that the given scriptblock returns false.
#>
function Assert-False
{
	param([ScriptBlock]$script, [string]$message)
  
	if (!$message)
	{
		$message = "Assertion failed: " + $script
	}
  
	$result = &$script

	if ($result) 
	{
		throw $message
	}
  
	return $true
}

<#
.SYNOPSIS
Validates a string is not null.
#>
function Assert-NotNull
{
	param($value)

	Assert-False {  $null -eq $value }
}

<#
.SYNOPSIS
Validates a string is not null or empty.
#>
function Assert-NotNullOrEmpty
{
	param([string]$value)

	Assert-False { [string]::IsNullOrEmpty($value) }
}