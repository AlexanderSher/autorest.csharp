param($AutorestCSharpVersion, $CadlEmitterVersion, $SdkRepoRoot)

Import-Module "$PSScriptRoot\UpdateGeneratorMetadata.psm1" -DisableNameChecking -Force;

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

UpdateGeneratorMetaData($AutorestCSharpVersion, $CadlEmitterVersion, $SdkRepoRoot)

Write-Host "Generating Azure SDK Codes..."
dotnet msbuild /restore /t:GenerateCode "$SdkRepoRoot\eng\service.proj"
