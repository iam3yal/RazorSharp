$projectDir = "$PSScriptRoot/RazorSharp.Tests.E2E"
[xml]$content = Get-Content -Path "$projectDir/RazorSharp.Tests.E2E.csproj"
$target = $content.Project.PropertyGroup.TargetFramework

Start-Process -FilePath "$projectDir/bin/Debug/$target/playwright.ps1" -ArgumentList $args -NoNewWindow