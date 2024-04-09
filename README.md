# AvilesaBusManagementSystem: Sistema de Gestión de Autobuses

## Descripción

AvilesaBusManagementSystem es una aplicación desarrollada en C# con .NET y WPF, diseñada para facilitar la gestión integral de una empresa de autobuses. Este sistema permite la administración eficiente de líneas de autobús, itinerarios, y la generación de informes, ofreciendo una solución completa para la planificación y operación de servicios de transporte.

## Características Principales

- **Gestión de Líneas de Autobús:**
  - Permite crear, eliminar, modificar y consultar líneas de autobús, con información detallada como número de línea, municipios de origen y destino, y horarios de salida.

- **Gestión de Itinerarios:**
  - Administra los itinerarios de las líneas, incluyendo todas las paradas excepto la de salida, con detalles sobre los municipios y los intervalos de tiempo.

- **Persistencia de Datos:**
  - Almacena la información en archivos CSV, facilitando la serialización y recuperación de datos para una gestión eficaz.

- **Informes:**
  - Genera informes detallados utilizando JasperReports, como listados de líneas por hora de salida, líneas por municipio de origen e itinerarios completos por número de línea.

- **Instalador Personalizado:**
  - Incluye un instalador para la aplicación que permite opciones personalizadas, como la selección del directorio de instalación.

## Tecnologías Utilizadas

- **C# y .NET:**
	- Base del desarrollo para construir una aplicación robusta y escalable.
- **WPF (Windows Presentation Foundation):**
	- Utilizado para desarrollar la interfaz gráfica, asegurando una experiencia de usuario interactiva y atractiva.
- **Patrón MVVM (Model-View-ViewModel):** 
	- Adoptado para estructurar la aplicación, promoviendo una clara separación entre la lógica de presentación y la lógica de negocio, facilitando el mantenimiento y la prueba de la aplicación.
- **Patrón Command:** 
	- Utilizado para encapsular la lógica de los comandos de la interfaz de usuario, permitiendo una gestión centralizada de las acciones y eventos.
- **JasperReports:**
	- Empleado para la creación de informes basados en los datos de la aplicación.
- **CSV para Persistencia de Datos:**
	- Formato elegido para la serialización de datos, compatible con la generación de informes.

## Instalación

Para instalar BusManagementSystem en tu sistema:

1. Descarga el instalador desde la sección de lanzamientos del repositorio.
2. Ejecuta el instalador y sigue las instrucciones en pantalla, eligiendo tu directorio de instalación preferido si deseas cambiarlo del predeterminado.

## Uso

Tras la instalación, podrás:

1. Acceder a la pantalla principal para gestionar líneas e itinerarios.
2. Utilizar las opciones proporcionadas para agregar, modificar o eliminar líneas e itinerarios.
3. Generar y consultar informes a través de la interfaz de usuario.

## Contribución

Si estás interesado en contribuir al proyecto BusManagementSystem:

1. Haz un fork del repositorio.
2. Clona tu fork y crea una nueva rama para tus cambios.
3. Implementa tus mejoras o correcciones.
4. Envía un pull request para su revisión.

## Pruebas

Para garantizar la calidad y funcionalidad del sistema, se han implementado pruebas unitarias sobre métodos clave de la aplicación. Estos casos de prueba están documentados y pueden ser ejecutados para verificar la integridad de las funcionalidades implementadas.

## Licencia

BusManagementSystem es un proyecto de código abierto licenciado bajo la [Licencia Creative Commons 4.0](LICENSE.md).

## Contacto

Para más información, preguntas o colaboraciones, no dudes en contactar al equipo de desarrollo a través de [samuelalthaus@gmail.com](mailto:samuelalthaus@gmail.com).
