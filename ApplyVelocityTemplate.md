Use the ApplyVelocityTemplate to generate a Web.config file per environment by separating the common elements of the .config from the properties that differ.

# Introduction #

Managing .config files for multiple environments in a single project can be cumbersome, generally requiring multiple versions that duplicate a large amount of text, or including settings for every environment in a single file. The ApplyVelocityTemplate MsBuild task was built to simplify config generation using the [NVelocity](http://castleproject.org/others/nvelocity/index.html) templating engine, such that the common elements of the .config files can be separated from the properties that change per environment.


# Details #

To include the velocity task in your MsBuild script, simply reference the class from the Ruhe DLL.

```
  <UsingTask TaskName="Ruhe.MsBuild.ApplyVelocityTemplate" AssemblyFile="$(OutputPath)\Ruhe.dll" />
```

Then you can generate files from your build.

```
  <Target Name="UpdateWebConfig">
    <ApplyVelocityTemplate TemplateFile="WebConfig/template.web.config" PropertiesFile="WebConfig/$(Configuration).properties" OutputFile="Web.Config" />
  </Target>
  
  <Target Name="CleanWebConfig">
    <Delete Files="Web.Config" />
  </Target>

  <Target Name="AfterClean" DependsOnTargets="CleanWebConfig"/>  
  <Target Name="AfterBuild" DependsOnTargets="UpdateWebConfig"/>
```