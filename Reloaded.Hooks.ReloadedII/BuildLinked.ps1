# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/reloaded.sharedlib.hooks/*" -Force -Recurse
dotnet publish "./Reloaded.Hooks.ReloadedII.csproj" -c Release -o "$env:RELOADEDIIMODS/reloaded.sharedlib.hooks" /p:OutputPath="./bin/Release" /p:RobustILLink="true" -bl

# Restore Working Directory
Pop-Location