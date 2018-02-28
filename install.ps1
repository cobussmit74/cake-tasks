$cakeTasksFolder = Split-Path $MyInvocation.MyCommand.Path -Parent
$projectFolder = Split-Path $cakeTasksFolder -Parent
$localTasksFolder = Join-Path $projectFolder "local-tasks"
$installationFolder = Join-Path $cakeTasksFolder "installation"
$samplesFolder = Join-Path $installationFolder "samples"
$cakePowershelFile = Join-Path $installationFolder "cake.ps1"
$localCakePowershelFile = Join-Path $projectFolder "cake.ps1"
$defaultConfigFile = Join-Path $cakeTasksFolder "default-config.json"
$localConfigFile = Join-Path $projectFolder "cake-config.json"

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