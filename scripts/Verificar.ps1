param([string]$Configuracion = "Debug")
$ErrorActionPreference = "Stop"
$rayaoRepo = Split-Path -Parent $PSScriptRoot
$rayaoSolucion = Join-Path $rayaoRepo "ProyectoParcialPA.slnx"
$rayaoPruebas = Join-Path $rayaoRepo "ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj"
$rayaoResultados = Join-Path $rayaoRepo "TestResults/Verificacion"
$rayaoMsbuildComando = Get-Command msbuild.exe -ErrorAction SilentlyContinue
if ($null -ne $rayaoMsbuildComando) { $rayaoMsbuild = $rayaoMsbuildComando.Source }
else {
    $rayaoVswhere = Join-Path ${env:ProgramFiles(x86)} "Microsoft Visual Studio/Installer/vswhere.exe"
    if (!(Test-Path -LiteralPath $rayaoVswhere)) { throw "Abre Developer PowerShell de Visual Studio y ejecuta este archivo de nuevo." }
    $rayaoMsbuild = (& $rayaoVswhere -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild/**/Bin/MSBuild.exe' | Select-Object -First 1)
    if ([string]::IsNullOrWhiteSpace($rayaoMsbuild)) { throw "No se encontró MSBuild de Visual Studio." }
}
Push-Location $rayaoRepo
try {
    & $rayaoMsbuild $rayaoSolucion /t:Restore /p:Configuration=$Configuracion /p:RestorePackagesConfig=true /verbosity:minimal
    if ($LASTEXITCODE -ne 0) { throw "Falló la restauración de paquetes." }
    & $rayaoMsbuild $rayaoSolucion /t:Build /p:Configuration=$Configuracion /verbosity:minimal
    if ($LASTEXITCODE -ne 0) { throw "La solución no compiló." }
    New-Item -ItemType Directory -Force -Path $rayaoResultados | Out-Null
    Get-ChildItem -LiteralPath $rayaoResultados -Filter '*.trx' | Remove-Item -Force
    dotnet test $rayaoPruebas --configuration $Configuracion --no-build --no-restore --logger "trx;LogFileName=RAYAO-final.trx" --results-directory $rayaoResultados --verbosity minimal
    if ($LASTEXITCODE -ne 0) { throw "Hay pruebas fallidas." }
    $rayaoTrx = Join-Path $rayaoResultados "RAYAO-final.trx"
    if (!(Test-Path -LiteralPath $rayaoTrx)) { throw "No se generó el TRX." }
    [xml]$rayaoXml = Get-Content -LiteralPath $rayaoTrx -Raw
    $rayaoContador = $rayaoXml.SelectSingleNode("//*[local-name()='ResultSummary']/*[local-name()='Counters']")
    if ($null -eq $rayaoContador -or [int]$rayaoContador.executed -eq 0) { throw "No se ejecutaron pruebas." }
    if ([int]$rayaoContador.failed -gt 0) { throw "El TRX contiene pruebas fallidas." }
    Write-Host ("Verificación correcta. Ejecutadas: " + $rayaoContador.executed + "; superadas: " + $rayaoContador.passed) -ForegroundColor Green
    Write-Host ("TRX: " + $rayaoTrx)
}
finally { Pop-Location }
