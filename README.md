# 📎 SistemaLiquidacionRRHH

Aplicación de escritorio desarrollada en C# con arquitectura por capas (CapaDatos, CapaNegocio, CapaPresentacion), orientada al cálculo de liquidaciones de sueldo para empleados. Proyecto correspondiente a la Evaluación Nacional de Especialidad (ENE) del módulo PRO201 - Taller de Programación.

---

## 🛠️ Tecnologías y Herramientas

- 🖥️ .NET Framework 4.8
- 💻 C#
- 🎨 Windows Forms
- 🛆 Arquitectura en Capas (3 capas)
- 🧪 Validación y cálculo de datos
- 📋 Diseño de formularios en Visual Studio

---

## 📚 Funcionalidades principales

✅ Registro de empleados con RUT, nombre, dirección, teléfono, valor hora y valor hora extra  
✅ Cálculo automático de sueldo bruto, descuentos por AFP y salud, y sueldo líquido  
✅ Listado de empleados con opción de filtrar, modificar y eliminar  
✅ Interfaz intuitiva con navegación desde un menú principal  
✅ Validaciones de entrada mediante capa lógica intermedia  
✅ Simulación de almacenamiento mediante lista en memoria (`RepositorioEmpleados`)

---

## 🧹 Estructura del proyecto

```
SolucionEvaENE
├── CapaDatos
│   └── Empleado.cs
│   └── Liquidacion.cs
│   └── RepositorioEmpleados.cs
├── CapaNegocio
│   └── LiquidacionService.cs
│   └── ValidacionService.cs
├── CapaPresentacion
│   └── RegistroEmpleadoForm.cs
│   └── LiquidacionForm.cs
│   └── ListadoForm.cs
│   └── MenuForm.cs
│   └── LoginForm.cs
```

---

## 🧠 Autenticación

- Acceso mediante formulario de login.
- Tipos de usuario: administrador y usuario normal (estructurado visualmente, sin conexión a base de datos).

---

## 🧪 Estado del proyecto

✅ Diseño de formularios completo  
✅ Capa lógica y de datos implementada  
❌ (Opcional) Persistencia en base de datos (simulada con lista en memoria)

---

## 📦 Uso recomendado

Este sistema es ideal como base para proyectos académicos, evaluación de habilidades en programación orientada a objetos o como prototipo para sistemas de recursos humanos.

---

## 📁 Autor

Desarrollado por **Remigio Stocker**  
Para Evaluación Nacional de Especialidad – PRO201, Taller de Programación 2024