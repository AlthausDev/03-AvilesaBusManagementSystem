# Avilesa Bus Management System

Aplicación de escritorio en **C#/.NET con WPF** para gestionar líneas de autobús, itinerarios e informes dentro de un ejercicio de arquitectura MVVM.

## Funcionalidades

- Alta, modificación, consulta y eliminación de líneas.
- Gestión de itinerarios y paradas.
- Persistencia en CSV.
- Generación de informes con JasperReports.
- Instalador personalizado.
- Pruebas unitarias sobre lógica relevante.

## Arquitectura y stack

- C# / .NET
- WPF
- MVVM
- Patrón Command
- CSV para persistencia
- JasperReports para reporting

La aplicación separa presentación, estado de vista y lógica de dominio para mantener una estructura razonablemente limpia dentro de una aplicación de escritorio.

## Puntos de diseño

El proyecto resulta útil como referencia de una aplicación WPF clásica donde la UI no concentra toda la lógica: los `ViewModel`, comandos y servicios permiten mantener responsabilidades diferenciadas y facilitan las pruebas.

La persistencia en CSV y la integración con JasperReports muestran además cómo conectar componentes externos sin convertir la capa de presentación en el centro del sistema.

## Estado

Proyecto histórico de formación, mantenido como referencia de WPF, MVVM y generación de informes. El repositorio incluye código fuente y recursos del instalador utilizado durante el desarrollo original.

## Licencia

Publicado bajo **Creative Commons Attribution-NonCommercial 4.0 International**. Consulta [`LICENSE.md`](LICENSE.md).

Si reutilizas código o material original del proyecto, conserva la atribución a **Sam Althaus / AlthausDev** conforme a la licencia.
