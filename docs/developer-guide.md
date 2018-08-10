# Microsoft Partner Center PowerShell Developer Guide

The Microsoft Partner Center PowerShell Developer Guide was created to help with the development and testing of Partner Center PowerShell cmdlets. This guide contains information on how to set up your environment, implement cmdlets, develop tests, and more.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Environment Setup](#environment-setup)
  - [Documentation Basics](#documentation-basics)
  - [Building the Environment](#building-the-environment)
  - [Running Tests](#running-tests)

## Prerequisites

The following prerequisites should be completed before contributing to the source code the Partner Center PowerShell repository:

- Install [Visual Studio 2017](https://www.visualstudio.com/downloads/)
- Install the latest version of [Git](https://git-scm.com/downloads)
- Install the [`platyPS` module](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/help-generation.md#installing-platyps)
- Set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:
  - `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
  - `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`