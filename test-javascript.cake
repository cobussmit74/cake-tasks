#load "config.cake"
#addin "Cake.Powershell"

string CommandToCheckOfKarmaFailed()
{
  return "if ($lastexitcode -ne 0) { throw \"Karma test run failed\" }";
}

ProcessArgumentBuilder AppendKarmaArguments(bool singleRun)
{
  var args = new ProcessArgumentBuilder();
  args.AppendQuoted(config.KarmaPath);
  args.Append("start");
  args.AppendQuoted(config.KarmaConfigPath);
  if (singleRun)
  {
    args.Append("--single-run");
  }
  args.Append(";");
  args.Append(CommandToCheckOfKarmaFailed());
  return args;
}

void StartKarma(bool singleRun)
{
  StartPowershellScript(
    "& node", 
    new PowershellSettings
      {
        Arguments = AppendKarmaArguments(singleRun),
        FormatOutput = true
      });
}

Task("test-javascript")
  .Does(() =>
{
  StartKarma(true);
});

Task("watch-javascript")
  .Does(() =>
{
  StartKarma(false);
});