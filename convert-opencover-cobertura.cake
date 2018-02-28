#load "config.cake"
#tool "nuget:?package=OpenCoverToCoberturaConverter"

Task("convert-opencover-cobertura")
  .Does(() =>
{
  var nugetPath = Context.Tools.Resolve("OpenCoverToCoberturaConverter.exe");
  StartProcess(nugetPath, new ProcessSettings {
    Arguments = new ProcessArgumentBuilder()
      .AppendQuoted("-input:" + config.OpenCoverOutputFile)
      .AppendQuoted("-output:" + config.CoberturaOutputFile)
      .AppendQuoted("-sources:" + config.SourceFolder)
  });
});