IF EXIST "$(ProjectDir)$(OutDir)*.nupkg" del "$(ProjectDir)$(OutDir)*.nupkg"
nuget.exe pack "$(ProjectPath)"
IF EXIST "$(ProjectDir)$(OutDir)*.nupkg" xcopy /Y "$(ProjectDir)$(OutDir)*.nupkg" "C:\ProgramData\UiPath\Packages\"

cd /D "D:\DevOps\UIPath\UIPath.Telegram.Activities"

nuget pack  -NoDefaultExcludes

nuget locals -list global-packages

nuget.exe pack "MyBots.Telegram.Activities.csproj" -NoDefaultExcludes