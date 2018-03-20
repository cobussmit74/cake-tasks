$startupFolder = Split-Path $MyInvocation.MyCommand.Path -Parent
. $startupFolder\install-variables.ps1

if (!(Test-Path $localCakePowershelFile -PathType Leaf))
{
    Copy-Item -Path $cakePowershelFile -Destination $localCakePowershelFile
}

if (!(Test-Path $localConfigFile -PathType Leaf))
{
    Copy-Item -Path $defaultConfigFile -Destination $localConfigFile
}

if(!(Test-Path -Path $localTasksFolder)){
    New-Item -ItemType directory -Path $localTasksFolder | Out-Null
}

Copy-Item -Path (Join-Path $samplesFolder "*.cake") -Destination $localTasksFolder