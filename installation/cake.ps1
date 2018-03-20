[CmdletBinding()]
Param(
    [string]$Target = "Default"
)

$startupFolder = Split-Path $MyInvocation.MyCommand.Path -Parent
. $startupFolder\cake-tasks\install-variables.ps1

function InstallCake([string] $Version)
{
    if ($Version -eq "")
    {
        $Version = "latest"
    }

    Write-Host "Using Cake version: $Version"

    if ($Version -eq "latest")
    {
        Remove-Item $cakeVersionFile
    }
    else
    {
        if(!(Test-Path -Path $toolsFolder)){
            New-Item -ItemType directory -Path $toolsFolder | Out-Null
        }

        (Get-Content -Raw -Path $blankCakeVersionFile).Replace("##VERSION##", $Version) | Set-Content $cakeVersionFile
    }
}

$config = Get-Content -Raw -Path $localConfigFile | ConvertFrom-Json
InstallCake($config.CakeVersion)

.\cake-tasks\cake-bootstrap.ps1 --target=$Target