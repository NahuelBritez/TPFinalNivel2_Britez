<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <h1>📦 TP Final: Gestor de Árticulos</h1>
    <h2>📝 Descripción del Proyecto</h2>
    <p>
        Este proyecto es una aplicación de escritorio desarrollada para la gestión de artículos en el catálogo de un comercio. 
        La aplicación es genérica y adaptable a cualquier tipo de comercio, permitiendo gestionar información que podría ser utilizada 
        en diversos canales como webs, e-commerces, apps móviles, entre otros.
    </p>
    <h3>✨ Funcionalidades Principales</h3>
    <ul>
        <li><strong>Listado de Artículos:</strong> Muestra todos los artículos disponibles en la base de datos.</li>
        <li><strong>Búsqueda por Criterios:</strong> Permite filtrar artículos por distintos criterios.</li>
        <li><strong>Agregar Artículos:</strong> Función para agregar nuevos artículos al catálogo.</li>
        <li><strong>Modificar Artículos:</strong> Opción para actualizar la información de un artículo existente.</li>
        <li><strong>Eliminar Artículos:</strong> Permite eliminar artículos del catálogo.</li>
        <li><strong>Ver Detalle de Artículo:</strong> Visualiza la información completa de un artículo seleccionado.</li>
    </ul>
    <h2>🏗️ Arquitectura</h2>
    <p>
        El proyecto sigue una <strong>arquitectura en capas</strong>, distribuyendo las responsabilidades entre las siguientes capas:
    </p>
    <ul>
        <li><strong>Capa de Presentación:</strong> Implementada en WinForms para gestionar la interfaz de usuario.</li>
        <li><strong>Capa de Lógica de Negocio:</strong> Contiene las reglas y validaciones que controlan el comportamiento de la aplicación.</li>
        <li><strong>Capa de Acceso a Datos:</strong> Responsable de la interacción con la base de datos a través de <strong>ADO.NET</strong>.</li>
    </ul>
    <h2>📚 Temario Aplicado</h2>
    <p>Este proyecto abarca múltiples conceptos estudiados a lo largo del curso, incluyendo:</p>
    <ul>
        <li><strong>Unidad 1:</strong> Creación de un proyecto en WinForms y configuración de Visual Studio.</li>
        <li><strong>Unidad 2:</strong> Manejo de controles (TextBox, Buttons, Labels) y eventos, además de gestión de excepciones.</li>
        <li><strong>Unidad 3:</strong> Implementación de Programación Orientada a Objetos (POO) con clases, objetos, propiedades y métodos.</li>
        <li><strong>Unidad 4 y 5:</strong> Aplicación de herencia, interfaces, composición, agregación y polimorfismo para organizar las clases del sistema.</li>
        <li><strong>Unidad 6 y 8:</strong> Conexión a una base de datos local usando <strong>ADO.NET</strong> y SQLServer, implementando inserciones, ediciones, eliminaciones y consultas.</li>
        <li><strong>Unidad 7:</strong> Implementación de arquitectura en capas para separar la lógica de negocio, la presentación y el acceso a datos.</li>
    </ul>
    <h2>💻 Requerimientos</h2>
    <ul>
        <li><strong>Visual Studio 2022 o superior.</strong></li>
        <li><strong>SQL Server</strong> instalado y configurado.</li>
    </ul>
    <h3>📂 Incluir el Archivo SQL</h3>
    <p>
        En este repositorio se incluye el archivo <code>catalogo_db_setup.sql</code>, que contiene el script para generar la base de datos <strong>CATALOGO_DB</strong>.
        Debes ejecutar este archivo antes de utilizar la aplicación para que las tablas y los datos necesarios estén disponibles en tu instancia local de SQL Server.
    </p>
    <h3>🔧 Configuración de la Base de Datos</h3>
    <ol>
        <li>Descarga o clona este repositorio.</li>
        <li>Localiza el archivo <code>catalogo_db_setup.sql</code> en la carpeta <strong>scripts/</strong> del proyecto.</li>
        <li>Abre SQL Server Management Studio o cualquier otra herramienta de administración de SQL Server.</li>
        <li>Conéctate a tu instancia local de SQL Server.</li>
        <li>Ejecuta el script <code>catalogo_db_setup.sql</code> para crear la base de datos y las tablas.</li>
    </ol>
    <h3>🔗 Nota sobre la Cadena de Conexión</h3>
    <p>
        Una vez creada la base de datos, asegúrate de configurar la cadena de conexión correctamente en el archivo <strong>ArticuloDatos</strong> para que la aplicación se conecte a tu instancia local de SQL Server.
    </p>
    <h2>🚀 Instrucciones de Uso</h2>
    <ol>
        <li>Descargar o clonar este repositorio.</li>
        <li>Abrir la solución en Visual Studio.</li>
        <li>Configurar la cadena de conexión en el archivo de configuración para apuntar a su instancia local de SQL Server.</li>
        <li>Ejecutar la aplicación desde Visual Studio.</li>
    </ol>
</body>
</html>
