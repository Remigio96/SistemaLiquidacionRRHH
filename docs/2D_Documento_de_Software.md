# Documento de Software

## Sistema de Liquidación de Remuneraciones - "Estrategias Profesionales"

---

## 1. Información del Documento

| Campo | Detalle |
|-------|---------|
| **Nombre del sistema** | Sistema de Liquidación de Remuneraciones |
| **Versión** | 1.0 |
| **Cliente** | Empresa "Estrategias Profesionales" |
| **Autor** | Remigio Stocker - Analista Programador |
| **Fecha de elaboración** | Agosto 2025 |
| **Estado** | Finalizado |

---

## 2. Introducción

### 2.1 Propósito

El presente documento describe las especificaciones técnicas y funcionales del Sistema de Liquidación de Remuneraciones desarrollado para la empresa "Estrategias Profesionales". Su objetivo es servir como referencia técnica para el mantenimiento, evolución y comprensión del sistema por parte de desarrolladores, usuarios y stakeholders.

### 2.2 Alcance

El sistema cubre las siguientes áreas funcionales:

- Autenticación de usuarios con diferenciación de roles.
- Gestión de empleados (registro, modificación y eliminación).
- Cálculo de liquidaciones de sueldo (bruto, descuentos AFP/Salud, líquido).
- Listado y filtrado de empleados.
- Historial de liquidaciones con búsqueda.
- Persistencia de datos en memoria y archivo JSON.

### 2.3 Definiciones y Acrónimos

| Término | Definición |
|---------|-----------|
| **AFP** | Administradora de Fondos de Pensiones. Entidad que administra los fondos previsionales de los trabajadores en Chile. |
| **Sueldo Bruto** | Total devengado por el trabajador antes de aplicar descuentos legales. |
| **Sueldo Líquido** | Monto que recibe el trabajador después de aplicar todos los descuentos (AFP y Salud). |
| **RUT** | Rol Único Tributario. Identificador único de personas en Chile. |
| **DTO** | Data Transfer Object. Objeto utilizado para transferir datos entre capas del sistema. |
| **CRUD** | Create, Read, Update, Delete. Operaciones básicas de gestión de datos. |
| **JSON** | JavaScript Object Notation. Formato de archivo para persistencia de datos. |
| **UML** | Unified Modeling Language. Lenguaje estándar para modelado de software. |

### 2.4 Referencias

| Documento | Descripción |
|-----------|-------------|
| Enunciado ENE PRO201 | Evaluación Nacional de Especialidad, Módulo Taller de Programación 2024 |
| 2A_Levantamiento_de_Requerimientos.md | Documento de levantamiento de requerimientos con entrevistas, reunión y cuestionario |
| Diagrama de Clases UML | Diagrama generado en PlantUML con la estructura completa del sistema |

---

## 3. Descripción General del Sistema

### 3.1 Perspectiva del Producto

El sistema es una aplicación de escritorio independiente (standalone) desarrollada en C# con Windows Forms sobre .NET Framework 4.8. No requiere conexión a internet ni a servidores externos. Los datos se almacenan en memoria durante la ejecución y las liquidaciones pueden persistirse en archivo JSON.

### 3.2 Funciones del Producto

El sistema proporciona las siguientes funciones principales:

1. **Autenticación**: Control de acceso mediante usuario y contraseña con dos roles diferenciados.
2. **Gestión de empleados**: Registro, consulta, modificación y eliminación de información de empleados.
3. **Cálculo de liquidaciones**: Cálculo automático de sueldo bruto, descuentos por AFP y salud, y sueldo líquido.
4. **Listado y filtrado**: Visualización de empleados con múltiples filtros (alfabético, por estado de liquidación).
5. **Historial**: Registro y consulta de liquidaciones calculadas con búsqueda en tiempo real.

### 3.3 Características de los Usuarios

| Tipo de usuario | Descripción | Nivel técnico |
|----------------|-------------|---------------|
| Administrador | Personal del área de RRHH encargado de gestionar la información de empleados y calcular liquidaciones | Básico-Intermedio |
| Usuario Normal | Jefes de área que necesitan consultar información de empleados y calcular sueldos | Básico |

### 3.4 Restricciones

- La aplicación funciona únicamente en sistemas operativos Windows (10 o superior).
- Se requiere .NET Framework 4.8 instalado.
- El sistema es monousuario (una instancia a la vez).
- Los datos en memoria se pierden al cerrar la aplicación (excepto liquidaciones guardadas en JSON).
- No se implementa conexión a base de datos en esta versión.

---

## 4. Arquitectura del Sistema

### 4.1 Patrón Arquitectónico

El sistema implementa una **arquitectura en 3 capas** que separa las responsabilidades del sistema en niveles independientes:

```
┌─────────────────────────────────┐
│      CAPA DE PRESENTACIÓN       │
│  (Windows Forms - Interfaz UI)  │
│  LoginForm, MenuForm,           │
│  RegistroEmpleadoForm,          │
│  LiquidacionForm, ListadoForm,  │
│  HistorialLiquidacionesForm     │
├─────────────────────────────────┤
│        CAPA DE NEGOCIO          │
│  (Lógica, Validaciones, DTOs)   │
│  EmpleadoService,               │
│  LiquidacionService,            │
│  ValidacionService,             │
│  RepositorioLiquidaciones,      │
│  EmpleadoDTO, LiquidacionDTO    │
├─────────────────────────────────┤
│        CAPA DE DATOS            │
│  (Entidades y Repositorios)     │
│  Empleado, Liquidacion,         │
│  RepositorioEmpleados           │
└─────────────────────────────────┘
```

### 4.2 Descripción de las Capas

**Capa de Datos (CapaDatos)**

Contiene las entidades del dominio y el repositorio de almacenamiento en memoria. Es la capa más interna y no tiene dependencias con las demás capas.

| Clase | Responsabilidad |
|-------|----------------|
| `Empleado` | Entidad que representa a un trabajador con sus datos personales y valores de hora |
| `Liquidacion` | Entidad que encapsula el cálculo de sueldo bruto, descuentos y sueldo líquido. Contiene los arreglos de AFP y Salud |
| `RepositorioEmpleados` | Clase estática que simula la base de datos almacenando empleados en una lista en memoria |

**Capa de Negocio (CapaNegocio)**

Contiene la lógica de negocio, servicios, validaciones y los objetos de transferencia de datos (DTOs). Depende de la Capa de Datos.

| Clase | Responsabilidad |
|-------|----------------|
| `EmpleadoDTO` | Objeto de transferencia para datos de empleado entre capas |
| `LiquidacionDTO` | Objeto de transferencia para datos de liquidación entre capas |
| `EmpleadoService` | Servicio que expone operaciones CRUD de empleados a la capa de presentación |
| `LiquidacionService` | Servicio que genera liquidaciones y expone los arreglos de AFP/Salud |
| `ValidacionService` | Servicio estático con métodos de validación reutilizables |
| `RepositorioLiquidaciones` | Almacenamiento de liquidaciones con persistencia en JSON |

**Capa de Presentación (CapaPresentacion)**

Contiene los formularios Windows Forms que conforman la interfaz de usuario. Depende de la Capa de Negocio (nunca accede directamente a la Capa de Datos).

| Formulario | Responsabilidad |
|------------|----------------|
| `LoginForm` | Autenticación de usuarios |
| `MenuForm` | Navegación principal con control de permisos por rol |
| `RegistroEmpleadoForm` | Registro y edición de empleados |
| `LiquidacionForm` | Cálculo y guardado de liquidaciones |
| `ListadoForm` | Listado de empleados con filtros |
| `HistorialLiquidacionesForm` | Historial de liquidaciones con búsqueda |
| `Program` | Punto de entrada de la aplicación |

### 4.3 Flujo de Dependencias

```
CapaPresentacion ──> CapaNegocio ──> CapaDatos
```

La Capa de Presentación solo conoce a la Capa de Negocio. La Capa de Negocio conoce a la Capa de Datos. La Capa de Datos no conoce a ninguna otra capa. Esto garantiza bajo acoplamiento y alta cohesión.

---

## 5. Requerimientos Funcionales

### RF-01: Autenticación de usuarios

| Campo | Detalle |
|-------|---------|
| **ID** | RF-01 |
| **Nombre** | Autenticación de usuarios |
| **Descripción** | El sistema debe permitir el ingreso mediante usuario y contraseña, validando las credenciales y asignando el rol correspondiente |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | El sistema debe estar ejecutándose y mostrar el formulario de login |
| **Flujo principal** | 1. El usuario ingresa su nombre de usuario y contraseña. 2. Presiona el botón "Ingresar". 3. El sistema valida las credenciales. 4. Si son correctas, se determina el rol (admin/usuario). 5. Se precargan los datos del sistema. 6. Se abre el menú principal con las opciones correspondientes al rol. |
| **Flujo alternativo** | 3a. Si los campos están vacíos, se muestra mensaje "Debe ingresar usuario y contraseña". 3b. Si las credenciales son incorrectas, se muestra mensaje "Credenciales incorrectas" y se limpia el campo de contraseña. |
| **Postcondición** | El usuario accede al menú principal con los permisos de su rol |
| **Prioridad** | Alta |
| **Formulario** | `LoginForm` |

**Credenciales del sistema:**

| Rol | Usuario | Contraseña |
|-----|---------|------------|
| Administrador | admin | admin123 |
| Usuario Normal | usuario | usuario123 |

---

### RF-02: Menú principal con control de roles

| Campo | Detalle |
|-------|---------|
| **ID** | RF-02 |
| **Nombre** | Menú principal con control de roles |
| **Descripción** | El sistema debe presentar un menú de navegación que muestre u oculte opciones según el rol del usuario autenticado |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | El usuario debe haberse autenticado exitosamente |
| **Flujo principal** | 1. El sistema muestra el menú principal. 2. Se muestran las opciones disponibles según el rol. 3. El usuario selecciona una opción. 4. Se abre el formulario correspondiente. |
| **Postcondición** | El usuario navega al formulario seleccionado |
| **Prioridad** | Alta |
| **Formulario** | `MenuForm` |

**Opciones por rol:**

| Opción | Administrador | Usuario Normal |
|--------|:---:|:---:|
| Registro de Empleados | Visible | Oculto |
| Cálculo de Liquidaciones | Visible | Visible |
| Listado de Empleados | Visible | Visible |
| Salir (volver al login) | Visible | Visible |

---

### RF-03: Registro de empleados

| Campo | Detalle |
|-------|---------|
| **ID** | RF-03 |
| **Nombre** | Registro de empleados |
| **Descripción** | El sistema debe permitir al Administrador registrar nuevos empleados con toda su información personal y valores de hora |
| **Actor** | Administrador |
| **Precondición** | El usuario debe tener rol de Administrador y estar en el formulario de registro |
| **Flujo principal** | 1. El administrador ingresa: RUT, Nombre, Dirección, Teléfono, Valor Hora y Valor Hora Extra. 2. Presiona el botón "Guardar". 3. El sistema valida que todos los campos estén completos. 4. El sistema valida que el nombre contenga solo letras. 5. El sistema valida que los valores numéricos sean enteros válidos. 6. El sistema verifica que el RUT no exista previamente. 7. Se registra el empleado y se muestra mensaje de éxito. 8. Se limpian los campos del formulario. |
| **Flujo alternativo** | 3a. Si hay campos vacíos: mensaje "Todos los campos son obligatorios". 4a. Si el nombre tiene números: mensaje "El nombre debe contener solo letras". 5a. Si los valores no son numéricos: mensaje "Los campos Valor Hora y Valor Hora Extra deben ser numéricos". 6a. Si el RUT ya existe: mensaje "Ya existe un empleado con este RUT". |
| **Postcondición** | El empleado queda registrado en el repositorio del sistema |
| **Prioridad** | Alta |
| **Formulario** | `RegistroEmpleadoForm` |

**Campos del formulario:**

| Campo | Tipo de control | Validación en tiempo real | Validación al guardar |
|-------|----------------|--------------------------|----------------------|
| RUT | TextBox | Ninguna | No vacío, no duplicado |
| Nombre | TextBox | Solo letras y espacios (KeyPress) | No vacío, solo letras |
| Dirección | TextBox | Ninguna | No vacío |
| Teléfono | TextBox | Solo números y símbolo + (KeyPress) | No vacío |
| Valor Hora | TextBox | Solo números (KeyPress) | No vacío, entero válido |
| Valor Hora Extra | TextBox | Solo números (KeyPress) | No vacío, entero válido |

---

### RF-04: Modificación de empleados

| Campo | Detalle |
|-------|---------|
| **ID** | RF-04 |
| **Nombre** | Modificación de empleados |
| **Descripción** | El sistema debe permitir al Administrador modificar los datos de un empleado existente, excepto su RUT |
| **Actor** | Administrador |
| **Precondición** | El empleado debe existir en el sistema. Se accede desde el botón "Modificar" en el listado |
| **Flujo principal** | 1. El administrador selecciona un empleado del listado y presiona "Modificar". 2. Se abre el formulario de registro con los datos precargados. 3. El campo RUT aparece deshabilitado (no editable). 4. El administrador modifica los campos necesarios. 5. Presiona "Guardar". 6. El sistema valida los datos modificados. 7. Se actualiza el empleado y se muestra mensaje de éxito. |
| **Flujo alternativo** | 6a. Si las validaciones fallan, se muestra el mensaje de error correspondiente. 7a. Si no se puede actualizar: mensaje "No se pudo actualizar el empleado". |
| **Postcondición** | Los datos del empleado quedan actualizados en el repositorio |
| **Prioridad** | Alta |
| **Formulario** | `RegistroEmpleadoForm` (modo edición) |

---

### RF-05: Eliminación de empleados

| Campo | Detalle |
|-------|---------|
| **ID** | RF-05 |
| **Nombre** | Eliminación de empleados |
| **Descripción** | El sistema debe permitir al Administrador eliminar un empleado del sistema, requiriendo confirmación previa |
| **Actor** | Administrador |
| **Precondición** | El empleado debe existir en el sistema. Se accede desde el botón "Eliminar" en el listado |
| **Flujo principal** | 1. El administrador selecciona un empleado del listado y presiona "Eliminar". 2. El sistema muestra un cuadro de confirmación: "¿Estás seguro que deseas eliminar este empleado?". 3. El administrador confirma con "Sí". 4. El sistema elimina al empleado del repositorio. 5. Se muestra mensaje "Empleado eliminado correctamente". 6. Se actualiza el listado automáticamente. |
| **Flujo alternativo** | 3a. Si el administrador presiona "No", se cancela la operación. |
| **Postcondición** | El empleado es removido permanentemente del repositorio |
| **Prioridad** | Alta |
| **Formulario** | `ListadoForm` |

---

### RF-06: Cálculo de liquidación de sueldo

| Campo | Detalle |
|-------|---------|
| **ID** | RF-06 |
| **Nombre** | Cálculo de liquidación de sueldo |
| **Descripción** | El sistema debe calcular automáticamente el sueldo bruto, descuentos por AFP y salud, y el sueldo líquido de un empleado |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | Debe existir al menos un empleado registrado en el sistema |
| **Flujo principal** | 1. El usuario selecciona un empleado del ComboBox. 2. Si el empleado tiene liquidación previa, se cargan automáticamente sus datos. 3. El usuario ingresa o modifica las horas trabajadas y horas extras. 4. Selecciona la AFP y el sistema de salud. 5. Presiona el botón "Calcular". 6. El sistema calcula y muestra el sueldo bruto y sueldo líquido. |
| **Flujo alternativo** | 1a. Si no se selecciona empleado: mensaje "Seleccione un empleado". 3a. Si las horas no son numéricas: mensaje "Ingrese valores numéricos válidos". 4a. Si no se selecciona AFP o Salud: mensaje "Seleccione AFP y Salud". |
| **Postcondición** | Se muestran los resultados del cálculo en los campos de solo lectura |
| **Prioridad** | Alta |
| **Formulario** | `LiquidacionForm` |

**Fórmulas de cálculo:**

| Concepto | Fórmula |
|----------|---------|
| Sueldo Bruto | `(Horas trabajadas x Valor hora) + (Horas extras x Valor hora extra)` |
| Descuento AFP | `Sueldo Bruto x Porcentaje AFP` |
| Descuento Salud | `Sueldo Bruto x Porcentaje Salud` |
| Sueldo Líquido | `Sueldo Bruto - Descuento AFP - Descuento Salud` |

**Tablas de porcentajes (almacenadas en arreglos):**

| AFP | Porcentaje | Índice en arreglo |
|-----|-----------|-------------------|
| CUPRUM | 7% | 0 |
| MODELO | 9% | 1 |
| CAPITAL | 12% | 2 |
| PROVIDA | 13% | 3 |

| Salud | Porcentaje | Índice en arreglo |
|-------|-----------|-------------------|
| FONASA | 12% | 0 |
| CONSALUD | 13% | 1 |
| MASVIDA | 14% | 2 |
| BANMEDICA | 15% | 3 |

**Ejemplo de cálculo:**

| Dato | Valor |
|------|-------|
| Horas trabajadas | 160 |
| Horas extras | 20 |
| Valor hora | $5.000 |
| Valor hora extra | $7.000 |
| AFP | CUPRUM (7%) |
| Salud | FONASA (12%) |
| **Sueldo Bruto** | (160 x 5.000) + (20 x 7.000) = **$940.000** |
| **Descuento AFP** | 940.000 x 0.07 = **$65.800** |
| **Descuento Salud** | 940.000 x 0.12 = **$112.800** |
| **Sueldo Líquido** | 940.000 - 65.800 - 112.800 = **$761.400** |

---

### RF-07: Guardar liquidación

| Campo | Detalle |
|-------|---------|
| **ID** | RF-07 |
| **Nombre** | Guardar liquidación |
| **Descripción** | El sistema debe permitir guardar la liquidación calculada en el repositorio y en archivo JSON |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | Se debe haber calculado una liquidación previamente (campos de sueldo bruto y líquido no vacíos) |
| **Flujo principal** | 1. El usuario presiona el botón "Guardar" después de calcular. 2. El sistema almacena la liquidación completa en el repositorio en memoria. 3. El sistema persiste los datos en el archivo `liquidaciones.json`. 4. Se muestra mensaje "Liquidación guardada correctamente". |
| **Flujo alternativo** | 1a. Si no se ha calculado previamente: mensaje "Debe calcular la liquidación antes de guardar". |
| **Postcondición** | La liquidación queda registrada en memoria y en archivo JSON |
| **Prioridad** | Media |
| **Formulario** | `LiquidacionForm` |

**Datos almacenados por liquidación:**

| Campo | Tipo | Descripción |
|-------|------|-------------|
| RutEmpleado | string | RUT del empleado |
| NombreEmpleado | string | Nombre completo |
| HorasTrabajadas | int | Cantidad de horas normales |
| HorasExtras | int | Cantidad de horas extras |
| AFP | string | Nombre de la AFP seleccionada |
| Salud | string | Nombre del sistema de salud seleccionado |
| SueldoBruto | int | Resultado del cálculo de sueldo bruto |
| DescuentoAFP | double | Monto del descuento por AFP |
| DescuentoSalud | double | Monto del descuento por salud |
| SueldoLiquido | double | Resultado del sueldo líquido |

---

### RF-08: Listado de empleados con filtros

| Campo | Detalle |
|-------|---------|
| **ID** | RF-08 |
| **Nombre** | Listado de empleados con filtros |
| **Descripción** | El sistema debe mostrar un listado de todos los empleados registrados con opción de filtrar por distintos criterios |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | Debe existir al menos un empleado registrado |
| **Flujo principal** | 1. El usuario accede al listado desde el menú. 2. Se muestra una tabla con columnas: RUT, Nombre, Dirección y Sueldo Líquido. 3. El sueldo líquido muestra el valor de la última liquidación o "—" si no tiene. 4. El usuario puede seleccionar un filtro del ComboBox. 5. La tabla se actualiza mostrando solo los empleados que cumplen el filtro. |
| **Postcondición** | Se visualiza el listado filtrado de empleados |
| **Prioridad** | Alta |
| **Formulario** | `ListadoForm` |

**Filtros disponibles:**

| Filtro | Descripción |
|--------|------------|
| TODOS | Muestra todos los empleados registrados |
| CON SUELDO | Muestra solo empleados que tienen al menos una liquidación registrada |
| SIN SUELDO | Muestra solo empleados que no tienen liquidación registrada |
| "A - F" | Empleados cuyo primer nombre inicia con letra entre A y F |
| "G - L" | Empleados cuyo primer nombre inicia con letra entre G y L |
| "M - R" | Empleados cuyo primer nombre inicia con letra entre M y R |
| "S - Z" | Empleados cuyo primer nombre inicia con letra entre S y Z |

**Controles visibles por rol:**

| Control | Administrador | Usuario Normal |
|---------|:---:|:---:|
| DataGridView (tabla) | Visible | Visible |
| ComboBox de filtro | Visible | Visible |
| Botón Modificar | Visible | Oculto |
| Botón Eliminar | Visible | Oculto |
| Botón Volver | Visible | Visible |

---

### RF-09: Historial de liquidaciones con búsqueda

| Campo | Detalle |
|-------|---------|
| **ID** | RF-09 |
| **Nombre** | Historial de liquidaciones con búsqueda |
| **Descripción** | El sistema debe mostrar un historial de todas las liquidaciones calculadas en una tabla estructurada con capacidad de búsqueda en tiempo real |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | Debe existir al menos una liquidación guardada |
| **Flujo principal** | 1. El usuario presiona el botón "Listar" en el formulario de liquidaciones. 2. Se abre una ventana modal con el historial completo. 3. Se muestra una tabla con columnas: Nombre, RUT, Sueldo Bruto, AFP, Salud, Sueldo Líquido. 4. El usuario puede escribir en la barra de búsqueda para filtrar por nombre. 5. La tabla se actualiza en tiempo real mientras el usuario escribe. 6. La búsqueda es insensible a tildes (ej: "maria" encuentra "María"). |
| **Flujo alternativo** | 1a. Si no hay liquidaciones: mensaje "No hay liquidaciones registradas". |
| **Postcondición** | El usuario visualiza las liquidaciones filtradas |
| **Prioridad** | Media |
| **Formulario** | `HistorialLiquidacionesForm` |

---

### RF-10: Limpiar campos del formulario

| Campo | Detalle |
|-------|---------|
| **ID** | RF-10 |
| **Nombre** | Limpiar campos del formulario |
| **Descripción** | El sistema debe permitir limpiar todos los campos de un formulario para reiniciar la entrada de datos |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | El usuario debe estar en el formulario de registro o de liquidación |
| **Flujo principal** | 1. El usuario presiona el botón "Limpiar". 2. Todos los campos de texto se vacían. 3. Los ComboBox se deseleccionan. 4. El foco se posiciona en el primer campo. |
| **Postcondición** | Todos los campos del formulario quedan vacíos |
| **Prioridad** | Baja |
| **Formularios** | `RegistroEmpleadoForm`, `LiquidacionForm` |

---

### RF-11: Carga automática de liquidación existente

| Campo | Detalle |
|-------|---------|
| **ID** | RF-11 |
| **Nombre** | Carga automática de liquidación existente |
| **Descripción** | Al seleccionar un empleado en el formulario de liquidación, si tiene una liquidación previa, el sistema debe cargar automáticamente los datos de su última liquidación |
| **Actor** | Administrador, Usuario Normal |
| **Precondición** | El empleado seleccionado debe tener al menos una liquidación guardada |
| **Flujo principal** | 1. El usuario selecciona un empleado del ComboBox. 2. El sistema busca la última liquidación del empleado. 3. Si existe, se rellenan automáticamente: horas trabajadas, horas extras, AFP, salud, sueldo bruto y sueldo líquido. |
| **Flujo alternativo** | 2a. Si el empleado no tiene liquidación previa, los campos quedan vacíos. |
| **Postcondición** | Los campos muestran los datos de la última liquidación o quedan vacíos |
| **Prioridad** | Baja |
| **Formulario** | `LiquidacionForm` |

---

## 6. Validaciones del Sistema

### 6.1 Servicio de Validación (ValidacionService)

El sistema centraliza las validaciones a través de la clase `ValidacionService` en la Capa de Negocio:

| Método | Descripción | Uso |
|--------|-------------|-----|
| `EstaVacio(string)` | Verifica si un campo está vacío o contiene solo espacios | Todos los campos obligatorios |
| `EsEnteroValido(string)` | Verifica si el texto es un número entero válido | Valor hora, horas trabajadas |
| `SeleccionValida(string)` | Verifica si se seleccionó una opción válida en un ComboBox | AFP, Salud |
| `ContieneSoloLetras(string)` | Verifica si el texto solo contiene letras y espacios (incluye acentos y ñ) | Nombre del empleado |
| `EsMayorOIgualACero(string)` | Verifica si el número es mayor o igual a cero | Valores numéricos |

### 6.2 Validaciones en Tiempo Real (KeyPress)

| Formulario | Campo | Restricción |
|------------|-------|-------------|
| RegistroEmpleadoForm | txtNombre | Solo letras, espacios y teclas de control |
| RegistroEmpleadoForm | txtTelefono | Solo dígitos, símbolo + y teclas de control |
| RegistroEmpleadoForm | txtValorHora | Solo dígitos y teclas de control |
| RegistroEmpleadoForm | txtValorExtra | Solo dígitos y teclas de control |
| LiquidacionForm | txtHorasTrabajadas | Solo dígitos y teclas de control |
| LiquidacionForm | txtHorasExtras | Solo dígitos y teclas de control |

### 6.3 Campos de Solo Lectura

| Formulario | Campo | Motivo |
|------------|-------|--------|
| LiquidacionForm | txtSueldoBruto | Es un resultado calculado, no debe ser modificado manualmente |
| LiquidacionForm | txtSueldoLiquido | Es un resultado calculado, no debe ser modificado manualmente |
| RegistroEmpleadoForm (edición) | txtRut | El RUT es la clave primaria y no debe cambiar |

---

## 7. Modelo de Datos

### 7.1 Entidad Empleado

| Atributo | Tipo | Obligatorio | Descripción |
|----------|------|:-----------:|-------------|
| Rut | string | Sí | Identificador único del empleado (clave primaria) |
| Nombre | string | Sí | Nombre completo del empleado |
| Direccion | string | Sí | Dirección del empleado |
| Telefono | string | Sí | Número de teléfono con formato +56XXXXXXXXX |
| ValorHora | int | Sí | Valor en pesos de la hora normal de trabajo |
| ValorHoraExtra | int | Sí | Valor en pesos de la hora extra de trabajo |

### 7.2 Entidad Liquidacion

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| Empleado | Empleado | Referencia al empleado asociado (composición) |
| HorasTrabajadas | int | Cantidad de horas normales trabajadas |
| HorasExtras | int | Cantidad de horas extras trabajadas |
| AFP | string | Nombre de la AFP seleccionada |
| Salud | string | Nombre del sistema de salud seleccionado |
| NombresAFP | string[] | Arreglo estático con los nombres de las AFP disponibles |
| PorcentajesAFP | double[] | Arreglo estático con los porcentajes de descuento de cada AFP |
| NombresSalud | string[] | Arreglo estático con los nombres de los sistemas de salud |
| PorcentajesSalud | double[] | Arreglo estático con los porcentajes de descuento de cada sistema |

### 7.3 DTO LiquidacionDTO

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| RutEmpleado | string | RUT del empleado |
| NombreEmpleado | string | Nombre del empleado |
| HorasTrabajadas | int | Horas normales ingresadas |
| HorasExtras | int | Horas extras ingresadas |
| AFP | string | AFP seleccionada |
| Salud | string | Sistema de salud seleccionado |
| SueldoBruto | int | Resultado del cálculo de sueldo bruto |
| DescuentoAFP | double | Monto descontado por AFP |
| DescuentoSalud | double | Monto descontado por salud |
| SueldoLiquido | double | Sueldo líquido final |

---

## 8. Estructura de Archivos del Proyecto

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
├── CapaPresentacion/
│   ├── LoginForm.cs / .Designer.cs / .resx
│   ├── MenuForm.cs / .Designer.cs / .resx
│   ├── RegistroEmpleadoForm.cs / .Designer.cs / .resx
│   ├── LiquidacionForm.cs / .Designer.cs / .resx
│   ├── ListadoForm.cs / .Designer.cs / .resx
│   ├── HistorialLiquidacionesForm.cs
│   └── Program.cs
├── docs/
│   ├── 2A_Levantamiento_de_Requerimientos.md
│   └── 2D_Documento_de_Software.md
├── SolucionEvaENE.sln
└── README.md
```

---

## 9. Persistencia de Datos

### 9.1 Almacenamiento en Memoria

Los empleados se almacenan en una `List<Empleado>` estática dentro de `RepositorioEmpleados`. Los datos se precargan al iniciar sesión con 50 empleados de prueba y se pierden al cerrar la aplicación.

### 9.2 Persistencia en JSON

Las liquidaciones pueden guardarse en un archivo `liquidaciones.json` mediante la serialización con `Newtonsoft.Json`. El archivo se genera en el directorio de ejecución de la aplicación.

**Formato del archivo JSON:**

```json
[
  {
    "SueldoBruto": 940000,
    "DescuentoAFP": 65800.0,
    "DescuentoSalud": 112800.0,
    "SueldoLiquido": 761400.0,
    "RutEmpleado": "19.595.224-4",
    "NombreEmpleado": "Ana Ríos",
    "HorasTrabajadas": 160,
    "HorasExtras": 20,
    "AFP": "CUPRUM",
    "Salud": "FONASA"
  }
]
```

---

## 10. Manejo de Excepciones

El sistema implementa manejo de excepciones en todos los formularios mediante bloques `try-catch`:

| Formulario | Evento | Tipo de excepción controlada |
|------------|--------|------------------------------|
| LoginForm | btnIngresar_Click | `Exception` general |
| RegistroEmpleadoForm | btnGuardar_Click | `Exception` general, `ArgumentException` (RUT duplicado, campos vacíos) |
| LiquidacionForm | btnCalcular_Click | `Exception` general |
| LiquidacionForm | btnGuardar_Click | `Exception` general |

Todas las excepciones se capturan y se presentan al usuario mediante `MessageBox` con el mensaje de error correspondiente, evitando que la aplicación se cierre inesperadamente.

---

## 11. Navegación del Sistema

```
LoginForm
  │
  ├── [Credenciales correctas] ──> MenuForm
  │                                    │
  │                                    ├── Registro Empleados ──> RegistroEmpleadoForm
  │                                    │                              └── [Volver] ──> MenuForm
  │                                    │
  │                                    ├── Liquidaciones ──> LiquidacionForm
  │                                    │                        ├── [Listar] ──> HistorialLiquidacionesForm
  │                                    │                        │                    └── [Cerrar] ──> LiquidacionForm
  │                                    │                        └── [Volver] ──> MenuForm
  │                                    │
  │                                    ├── Listado ──> ListadoForm
  │                                    │                  ├── [Modificar] ──> RegistroEmpleadoForm (edición)
  │                                    │                  └── [Volver] ──> MenuForm
  │                                    │
  │                                    └── Salir ──> LoginForm
  │
  └── [Botón Salir] ──> Cierre de aplicación
```

---

## 12. Datos de Prueba Precargados

### 12.1 Empleados (50 registros)

El sistema precarga 50 empleados ficticios al iniciar sesión. Todos con Valor Hora = $5.000 y Valor Hora Extra = $7.000. Ejemplos:

| RUT | Nombre | Dirección | Teléfono |
|-----|--------|-----------|----------|
| 19.595.224-4 | Ana Ríos | Los Olmos 123, Macul | +56912345678 |
| 18.461.837-k | Luis Soto | Av. Providencia 456, Providencia | +56987654321 |
| 13.218.530-0 | Ignacio Paredes | Av. Matta 123, Santiago | +56947851236 |
| 10.172.930-4 | Camila Rojas | Calle Los Pinos 456, Puente Alto | +56974125698 |
| 12.820.418-1 | Tomás Herrera | Av. España 234, Ñuñoa | +56932548714 |

### 12.2 Liquidaciones (10 registros)

Se precargan 10 liquidaciones de ejemplo para demostrar el funcionamiento de los filtros y el historial:

| Empleado | Horas | Extras | AFP | Salud | Sueldo Líquido |
|----------|:-----:|:------:|-----|-------|---------------:|
| Ana Ríos | 160 | 20 | CUPRUM | FONASA | $761.400 |
| Luis Soto | 180 | 10 | MODELO | CONSALUD | $756.600 |
| Ignacio Paredes | 200 | 30 | CAPITAL | MASVIDA | $895.400 |
| Camila Rojas | 150 | 5 | PROVIDA | BANMEDICA | $565.200 |
| Tomás Herrera | 170 | 15 | CUPRUM | FONASA | $773.550 |
| Cristina Leiva | 160 | 0 | MODELO | CONSALUD | $624.000 |
| Luis González | 190 | 25 | CAPITAL | MASVIDA | $832.500 |
| María Díaz | 140 | 10 | PROVIDA | BANMEDICA | $554.400 |
| Sebastián Vega | 160 | 40 | CUPRUM | FONASA | $874.800 |
| Valentina Fuentes | 175 | 8 | MODELO | CONSALUD | $726.180 |

---

## 13. Tecnologías Utilizadas

| Componente | Tecnología | Versión |
|-----------|-----------|---------|
| Lenguaje | C# | 7.3 |
| Framework | .NET Framework | 4.8 |
| Interfaz gráfica | Windows Forms | - |
| IDE | Visual Studio | 2022 |
| Serialización JSON | Newtonsoft.Json | - |
| Sistema operativo objetivo | Windows | 10+ |

---

## 14. Mejoras Futuras (Fuera de alcance v1.0)

Las siguientes funcionalidades han sido identificadas como deseables para futuras versiones:

| N.° | Mejora | Prioridad estimada |
|-----|--------|-------------------|
| 1 | Migración a base de datos SQL Server | Alta |
| 2 | Exportación de listados a Excel/PDF | Media |
| 3 | Registro de auditoría (log de acciones) | Media |
| 4 | Integración con Active Directory para autenticación | Baja |
| 5 | Impresión de liquidaciones individuales | Baja |
| 6 | Dashboard con estadísticas de remuneraciones | Baja |

---

## 15. Aprobación del Documento

| Rol | Nombre | Firma | Fecha |
|-----|--------|-------|-------|
| Jefa de Recursos Humanos | Carolina Méndez | _____________ | __/__/2025 |
| Encargado de Remuneraciones | Andrés Figueroa | _____________ | __/__/2025 |
| Analista Programador | Remigio Stocker | _____________ | __/__/2025 |

---

*Documento elaborado por Remigio Stocker - Analista Programador*
*Proyecto ENE PRO201 - Taller de Programación 2024*
*Instituto Profesional AIEP*
