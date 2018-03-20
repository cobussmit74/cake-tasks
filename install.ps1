<#

.SYNOPSIS
This is a Powershell script to install Cake-Tasks

.DESCRIPTION
Installs Cake Tasks into the project

.PARAMETER Version
The version of Cake to install (Validated is known to work with all included tasks)

#>

[CmdletBinding()]
Param(
    [ValidateSet("validated", "latest")]
    [string]$Version = "validated"
)

$cakeTasksFolder = Split-Path $MyInvocation.MyCommand.Path -Parent
$projectFolder = Split-Path $cakeTasksFolder -Parent
$toolsFolder = Join-Path $cakeTasksFolder "tools"
$cakeVersionFile = Join-Path $toolsFolder "packages.config"
$localTasksFolder = Join-Path $projectFolder "local-tasks"
$installationFolder = Join-Path $cakeTasksFolder "installation"
$samplesFolder = Join-Path $installationFolder "samples"
$cakeVersionFolder = Join-Path $installationFolder "cake-version"
$validatedCakeVersionFile = Join-Path $cakeVersionFolder "packages.config"
$cakePowershelFile = Join-Path $installationFolder "cake.ps1"
$localCakePowershelFile = Join-Path $projectFolder "cake.ps1"
$defaultConfigFile = Join-Path $cakeTasksFolder "default-config.json"
$localConfigFile = Join-Path $projectFolder "cake-config.json"

function InstallLatestCake
{
    Write-Host "Installing LATEST version of Cake"
    Remove-Item $cakeVersionFile
}

function InstallValidatedCake
{
    Write-Host "Installing VALIDATED version of Cake"
    Copy-Item -Path $validatedCakeVersionFile -Destination $cakeVersionFile -Force
}

if ($Version -eq "validated") {
    InstallValidatedCake
}
else
{
    InstallLatestCake
}

if (!(Test-Path $localCakePowershelFile -PathType Leaf))
{
    Copy-Item -Path $cakePowershelFile -Destination $localCakePowershelFile
}

if (!(Test-Path $localConfigFile -PathType Leaf))
{
    Copy-Item -Path $defaultConfigFile -Destination $localConfigFile
}

if(!(Test-Path -Path $localTasksFolder)){
    New-Item -ItemType directory -Path $localTasksFolder
}

Copy-Item -Path (Join-Path $samplesFolder "*.cake") -Destination $localTasksFolder