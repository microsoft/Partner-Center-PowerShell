# Microsoft Partner Center PowerShell Documentation Guide

The Microsoft Partner Center PowerShell Documentation Guide was created to help with the documentation of Partner Center PowerShell cmdlets. This guide contains information on how to set up your environment, generate the help files, and more.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Environment Setup](#environment-setup)

## Prerequisites

- Install [Visual Studio Code](https://code.visualstudio.com/)
- Install the latest version of [Git](https://git-scm.com/downloads)
- Install the [Docs Authoring Pack](https://marketplace.visualstudio.com/items?itemName=docsmsft.docs-authoring-pack) extension for Visual Studio Code
- Install the [VS Live Share](https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare) extension for Visual Studio Code
- Install the [`platyPS` module](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/help-generation.md#installing-platyps)
- Set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:
  - `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
  - `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`

## Environment Setup

Perform the following tasks to clone the Partner Center PowerShell repository, switch to the dev branch, and then create a new branch.

1. Open Visual Studio Code
2. Open the command palette by pressing Ctrl+Shift+P
3. Run **Git: Clone** to clone the repository. When prompted for the repository URL specify <https://partnercenter.visualstudio.com/powershell/_git/Partner-Center-PowerShell>
4. When prompted select the folder where you would like the repository to stored locally

Perform the following task to checkout the dev branch.

1. Open the command palette by pressing Ctrl+Shift+P
2. Run **Git: Checkout too..** to checkout the *dev* branch
3. When prompted click the *dev* branch. This will checkout the branch

Create a new branch

1. Open the command palette by pressing Ctrl+Shift+P
2. Run **Git: Create Branch...** to create a new branch
3. When prompted specify an appropriate name for the new branch
4. Press enter to complete the creation of the branch

It is recommended that the name of your branch reflect the work you are performing.
