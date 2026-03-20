# SistemaLiquidacionRRHH

Aplicación de escritorio desarrollada en C# con arquitectura por capas (CapaDatos, CapaNegocio, CapaPresentacion), orientada al cálculo de liquidaciones de sueldo para empleados. Proyecto correspondiente a la Evaluación Nacional de Especialidad (ENE) del módulo PRO201 - Taller de Programación.

---

## Tecnologías y Herramientas

- .NET Framework 4.8
- C#
- Windows Forms
- Arquitectura en 3 Capas
- Persistencia en memoria y archivo JSON
- Visual Studio 2022

---

## Funcionalidades principales

- Registro de empleados con RUT, nombre, dirección, teléfono, valor hora y valor hora extra
- Cálculo automático de sueldo bruto, descuentos por AFP y salud, y sueldo líquido
- Listado de empleados con filtros (Todos, Con Sueldo, Sin Sueldo, por rango alfabético)
- Historial de liquidaciones con búsqueda en tiempo real por nombre
- Validaciones en tiempo real (solo letras para nombre, solo números para valores numéricos, etc.)
- Sistema de autenticación con roles diferenciados
- Precarga de 50 empleados y 10 liquidaciones de prueba
- Persistencia de liquidaciones en archivo JSON

---

## Estructura del proyecto

```
SolucionEvaENE/
├── CapaDatos/
│   ├── Empleado.cs
│   ├── Liquidacion.cs
│   └── RepositorioEmpleados.cs
├── CapaNegocio/
│   ├── EmpleadoDTO.cs
│   ├── EmpleadoService.cs
│   ├── LiquidacionDTO.cs
│   ├── LiquidacionService.cs
│   ├── RepositorioLiquidaciones.cs
│   └── ValidacionService.cs
└── CapaPresentacion/
    ├── LoginForm.cs
    ├── MenuForm.cs
    ├── RegistroEmpleadoForm.cs
    ├── LiquidacionForm.cs
    ├── ListadoForm.cs
    ├── HistorialLiquidacionesForm.cs
    └── Program.cs
```



---

## Autenticación y roles

| Usuario   | Contraseña    | Permisos                                                  |
|-----------|---------------|-----------------------------------------------------------|
| admin     | admin123      | Registrar, modificar y eliminar empleados. Calcular sueldos. |
| usuario   | usuario123    | Consultar listado y calcular sueldos.                     |

---

## Estado del proyecto

- [x] Diseño de formularios completo
- [x] Capa lógica y de datos implementada
- [x] Validaciones integradas con ValidacionService
- [x] Permisos diferenciados por rol
- [x] Persistencia parcial en JSON (liquidaciones)
- [ ] Persistencia en base de datos (simulada con lista en memoria)

---

## Autor

Desarrollado por **Remigio Stocker**
Evaluación Nacional de Especialidad - PRO201, Taller de Programación 2026
