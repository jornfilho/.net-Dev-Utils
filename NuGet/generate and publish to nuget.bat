C:\
F:\
cd .net-Dev-Utils
cd NuGet
nuget pack ../DevUtils/DevUtils/DevUtils.csproj -IncludeReferencedProjects -Prop Configuration=Release
timeout 10
nuget push DevUtils.1.0.0.0.nupkg
pause