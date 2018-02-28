# cake-tasks
A starter pack to get your C# project build pipeline up and running quickly

## Prerequisites
- Powershell scripting needs to be enabled. As Administrator, run ```Set-ExecutionPolicy RemoteSigned```

## Installation
1. Initialise this repo as a submodule in your root of your project. ```git submodule add https://github.com/cobussmit74/cake-tasks.git```
2. Run the install script. ```.\cake-tasks\install.ps1```
3. Modify the *cake-config.json* file in your project root to suit your needs and project structure.

## Usage
Just execute the *cake.ps1* script in your project root.
```
.\cake
```
### Running Single Tasks
The *cake.ps1* script takes a single argument and execute only the task name that matches.
```
.\cake watch-javascript
```

## Included Tasks
- Purge
- Git Submodule Update
- NPM Install
- Nuget Restore
- MSBuild
- NUnit Test Runner
- OpenCover Test Coverage
- Karma Single Run
- Karma Continuous Run
- OpenCover HTML Report generator
- OpenCover To Cobertura converter

To see a list off all tasks, including ones you have added:
```
.\cake list-tasks
```