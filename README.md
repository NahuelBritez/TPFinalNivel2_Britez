<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>README - Gestión de Artículos de Catálogo</title>
</head>
<body>
    <h1>📦 TP Final: Gestión de Artículos de Catálogo</h1>
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
    <p>
        La aplicación está conectada a una base de datos local preexistente, y utiliza <strong>ADO.NET</strong> para interactuar con <strong>SQLServer</strong>.
    </p>
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
    <h3>🔗 Nota sobre la Base de Datos</h3>
    <p>
        La base de datos utilizada en este proyecto es local y no se incluye el script de generación de la misma. 
        La aplicación ha sido desarrollada para conectarse a una base de datos preexistente, por lo que se deberá 
        utilizar una base de datos local configurada con la misma estructura para que la aplicación funcione correctamente.
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
