# ProyectoParcialPA
Proyecto académico en C# con metodología SDD y apoyo de inteligencia artificial.

## CI y resultados de pruebas

La configuración de GitHub Actions queda en `.github/workflows/ci.yml`.

- Se ejecuta en `push` y en `pull_request` hacia `main`.
- Compila la solución `ProyectoParcialPA.slnx` con configuración `Debug`.
- Ejecuta las pruebas del proyecto `ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj` con VSTest.
- Guarda los resultados TRX como artefacto para consultar en la pestaña "Actions" del repositorio.

Para revisar los resultados:

1. Abre la pestaña `Actions` en GitHub.
2. Selecciona la ejecución del workflow.
3. Revisa el job `Build and test` y descarga el artefacto `rayao-test-results` si hace falta.
