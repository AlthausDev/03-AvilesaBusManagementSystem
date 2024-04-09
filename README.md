# AvilesaBusManagementSystem: Sistema de Gesti�n de Autobuses

## Descripci�n

AvilesaBusManagementSystem es una aplicaci�n desarrollada en C# con .NET y WPF, dise�ada para facilitar la gesti�n integral de una empresa de autobuses. Este sistema permite la administraci�n eficiente de l�neas de autob�s, itinerarios, y la generaci�n de informes, ofreciendo una soluci�n completa para la planificaci�n y operaci�n de servicios de transporte.

## Caracter�sticas Principales

- **Gesti�n de L�neas de Autob�s:**
  - Permite crear, eliminar, modificar y consultar l�neas de autob�s, con informaci�n detallada como n�mero de l�nea, municipios de origen y destino, y horarios de salida.

- **Gesti�n de Itinerarios:**
  - Administra los itinerarios de las l�neas, incluyendo todas las paradas excepto la de salida, con detalles sobre los municipios y los intervalos de tiempo.

- **Persistencia de Datos:**
  - Almacena la informaci�n en archivos CSV, facilitando la serializaci�n y recuperaci�n de datos para una gesti�n eficaz.

- **Informes:**
  - Genera informes detallados utilizando JasperReports, como listados de l�neas por hora de salida, l�neas por municipio de origen e itinerarios completos por n�mero de l�nea.

- **Instalador Personalizado:**
  - Incluye un instalador para la aplicaci�n que permite opciones personalizadas, como la selecci�n del directorio de instalaci�n.

## Tecnolog�as Utilizadas

- **C# y .NET:**
	- Base del desarrollo para construir una aplicaci�n robusta y escalable.
- **WPF (Windows Presentation Foundation):**
	- Utilizado para desarrollar la interfaz gr�fica, asegurando una experiencia de usuario interactiva y atractiva.
- **Patr�n MVVM (Model-View-ViewModel):** 
	- Adoptado para estructurar la aplicaci�n, promoviendo una clara separaci�n entre la l�gica de presentaci�n y la l�gica de negocio, facilitando el mantenimiento y la prueba de la aplicaci�n.
- **Patr�n Command:** 
	- Utilizado para encapsular la l�gica de los comandos de la interfaz de usuario, permitiendo una gesti�n centralizada de las acciones y eventos.
- **JasperReports:**
	- Empleado para la creaci�n de informes basados en los datos de la aplicaci�n.
- **CSV para Persistencia de Datos:**
	- Formato elegido para la serializaci�n de datos, compatible con la generaci�n de informes.

## Instalaci�n

Para instalar BusManagementSystem en tu sistema:

1. Descarga el instalador desde la secci�n de lanzamientos del repositorio.
2. Ejecuta el instalador y sigue las instrucciones en pantalla, eligiendo tu directorio de instalaci�n preferido si deseas cambiarlo del predeterminado.

## Uso

Tras la instalaci�n, podr�s:

1. Acceder a la pantalla principal para gestionar l�neas e itinerarios.
2. Utilizar las opciones proporcionadas para agregar, modificar o eliminar l�neas e itinerarios.
3. Generar y consultar informes a trav�s de la interfaz de usuario.

## Contribuci�n

Si est�s interesado en contribuir al proyecto BusManagementSystem:

1. Haz un fork del repositorio.
2. Clona tu fork y crea una nueva rama para tus cambios.
3. Implementa tus mejoras o correcciones.
4. Env�a un pull request para su revisi�n.

## Pruebas

Para garantizar la calidad y funcionalidad del sistema, se han implementado pruebas unitarias sobre m�todos clave de la aplicaci�n. Estos casos de prueba est�n documentados y pueden ser ejecutados para verificar la integridad de las funcionalidades implementadas.

## Licencia

BusManagementSystem es un proyecto de c�digo abierto licenciado bajo la [Licencia Creative Commons 4.0](LICENSE.md).

## Contacto

Para m�s informaci�n, preguntas o colaboraciones, no dudes en contactar al equipo de desarrollo a trav�s de [samuelalthaus@gmail.com](mailto:samuelalthaus@gmail.com).
