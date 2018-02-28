#addin "Cake.Powershell"

Task("git-submodule")
  .Does(() =>
{
  StartPowershellScript("git", new PowershellSettings
  {
    LogOutput = true,
    OutputToAppConsole = true,
    Arguments = new ProcessArgumentBuilder()
    .AppendQuoted("submodule")
    .AppendQuoted("update")
    .AppendQuoted("--init")
    .AppendQuoted("--recursive")
  });
});