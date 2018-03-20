$cakeTasksFolder = Split-Path $MyInvocation.MyCommand.Path -Parent
$projectFolder = Split-Path $cakeTasksFolder -Parent
$toolsFolder = Join-Path $cakeTasksFolder "tools"
$cakeVersionFile = Join-Path $toolsFolder "packages.config"
$localTasksFolder = Join-Path $projectFolder "local-tasks"
$installationFolder = Join-Path $cakeTasksFolder "installation"
$samplesFolder = Join-Path $installationFolder "samples"
$cakeVersionFolder = Join-Path $installationFolder "cake-version"
$blankCakeVersionFile = Join-Path $cakeVersionFolder "packages.config"
$cakePowershelFile = Join-Path $installationFolder "cake.ps1"
$localCakePowershelFile = Join-Path $projectFolder "cake.ps1"
$defaultConfigFile = Join-Path $cakeTasksFolder "default-config.json"
$localConfigFile = Join-Path $projectFolder "cake-config.json"