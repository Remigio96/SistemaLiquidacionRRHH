# Levantamiento de Requerimientos

## Sistema de Liquidación de Remuneraciones - "Estrategias Profesionales"

---

## 1. Información General del Proyecto

| Campo | Detalle |
|-------|---------|
| **Nombre del Proyecto** | Sistema de Liquidación de Remuneraciones |
| **Cliente** | Empresa "Estrategias Profesionales" |
| **Área solicitante** | Recursos Humanos |
| **Ubicación** | Región Metropolitana, Chile (con presencia nacional) |
| **Analista Programador** | Remigio Stocker |
| **Fecha de levantamiento** | Agosto 2025 |
| **Metodología de recolección** | Entrevistas, reuniones y cuestionarios |

---

## 2. Contexto y Problemática

La empresa "Estrategias Profesionales", dedicada al rubro de Recursos Humanos, actualmente realiza el cálculo de remuneraciones de sus empleados mediante planillas de Microsoft Excel. Este proceso presenta las siguientes problemáticas:

- Los cálculos manuales en Excel son propensos a errores humanos.
- No existe un control centralizado de la información de los empleados.
- El proceso de cálculo es lento y repetitivo, consumiendo tiempo valioso del personal de RRHH.
- No hay trazabilidad ni historial de las liquidaciones generadas.
- Cualquier persona con acceso al archivo Excel puede modificar datos sin restricción.
- No existe diferenciación de roles ni permisos de acceso.

El área de Recursos Humanos, luego de varias reuniones internas, ha decidido reemplazar el proceso manual por un sistema de programación que automatice los cálculos y centralice la información.

---

## 3. Técnicas de Recolección de Información

### 3.1 Entrevista

**Entrevista N.° 1 - Reunión inicial con el cliente**

| Campo | Detalle |
|-------|---------|
| **Fecha** | 05 de agosto de 2025 |
| **Lugar** | Oficinas de Estrategias Profesionales, Santiago Centro |
| **Entrevistador** | Remigio Stocker - Analista Programador |
| **Entrevistado** | Carolina Méndez - Jefa del Área de Recursos Humanos |
| **Duración** | 45 minutos |
| **Modalidad** | Presencial |

**Objetivo de la entrevista:** Comprender la problemática actual del proceso de cálculo de remuneraciones e identificar las necesidades del sistema a desarrollar.

**Transcripción resumida:**

**P: ¿Cuál es el problema principal que enfrentan actualmente con el cálculo de remuneraciones?**

R: "Actualmente todo lo hacemos en Excel. Tenemos una planilla donde ingresamos los datos de cada empleado y calculamos sus sueldos manualmente. El problema es que es muy lento, hay errores frecuentes en las fórmulas y cualquiera puede modificar los datos sin que nos demos cuenta. Necesitamos algo más profesional y seguro."

**P: ¿Qué información manejan de cada empleado?**

R: "De cada empleado necesitamos registrar su RUT, nombre completo, dirección, teléfono, y los valores de hora normal y hora extra. El valor de la hora normal es de $5.000 y la hora extra de $7.000, aunque esto podría variar en el futuro."

**P: ¿Cómo se calcula actualmente el sueldo de un empleado?**

R: "El sueldo bruto se calcula multiplicando las horas trabajadas por el valor de la hora, más las horas extras por el valor de la hora extra. Después se le descuenta la AFP y el sistema de salud que tenga el empleado. Las AFP que manejamos son CUPRUM con un 7%, MODELO con un 9%, CAPITAL con un 12% y PROVIDA con un 13%. En salud tenemos FONASA al 12%, CONSALUD al 13%, MASVIDA al 14% y BANMEDICA al 15%. El sueldo líquido es el bruto menos ambos descuentos."

**P: ¿Quiénes utilizarían el sistema?**

R: "Básicamente dos tipos de personas. Los administradores, que somos nosotros en RRHH, que necesitamos ingresar y gestionar la información de los empleados. Y los usuarios normales, que serían los jefes de área, que solo necesitan consultar y calcular el sueldo de sus empleados usando el RUT."

**P: ¿Qué funcionalidades considera imprescindibles?**

R: "Necesitamos poder registrar empleados, calcular sus sueldos, ver un listado de todos los empleados, y poder modificar o eliminar empleados cuando sea necesario. También sería bueno tener un login para que no cualquiera entre al sistema."

**P: ¿Tienen alguna preferencia sobre el tipo de aplicación?**

R: "Nos gustaría una aplicación de escritorio, que se instale en los computadores de la oficina. No necesitamos algo web por ahora. Usamos Windows en todas las estaciones de trabajo."

---

**Entrevista N.° 2 - Profundización en reglas de negocio**

| Campo | Detalle |
|-------|---------|
| **Fecha** | 08 de agosto de 2025 |
| **Lugar** | Sala de reuniones, Estrategias Profesionales |
| **Entrevistador** | Remigio Stocker - Analista Programador |
| **Entrevistado** | Andrés Figueroa - Encargado de Remuneraciones |
| **Duración** | 30 minutos |
| **Modalidad** | Presencial |

**Objetivo de la entrevista:** Detallar las reglas de negocio para los cálculos de remuneraciones y validaciones de datos.

**Transcripción resumida:**

**P: ¿El valor de la hora y la hora extra son siempre fijos para todos los empleados?**

R: "Sí, por ahora son $5.000 la hora normal y $7.000 la hora extra para todos. Pero sería bueno que el sistema permita configurarlos por empleado, por si en el futuro cambian."

**P: ¿Cada empleado puede elegir libremente su AFP y su sistema de salud?**

R: "Sí, cada empleado elige una AFP y un sistema de salud. No pueden tener dos AFP ni dos sistemas de salud a la vez. Es una selección única para cada uno."

**P: ¿Qué validaciones consideran importantes al ingresar datos?**

R: "El RUT no se puede repetir, eso es fundamental. El nombre debería ser solo texto, sin números. El teléfono solo números y el símbolo +56 al inicio. Las horas trabajadas y extras deben ser números enteros positivos. Y por supuesto, ningún campo puede quedar vacío."

**P: ¿Necesitan guardar un historial de las liquidaciones calculadas?**

R: "Sería ideal. Así podríamos consultar las liquidaciones anteriores de cada empleado y tener un registro. Si se puede guardar en algún archivo, mejor."

**P: ¿Cuántos empleados manejan aproximadamente?**

R: "Actualmente tenemos alrededor de 50 empleados activos, pero la empresa está en crecimiento. El sistema debería poder manejar al menos 100 empleados sin problemas."

---

### 3.2 Reunión de Trabajo

**Acta de Reunión N.° 1 - Definición de alcance y funcionalidades**

| Campo | Detalle |
|-------|---------|
| **Fecha** | 12 de agosto de 2025 |
| **Lugar** | Sala de reuniones principal, Estrategias Profesionales |
| **Hora inicio** | 10:00 hrs |
| **Hora término** | 11:30 hrs |
| **Moderador** | Remigio Stocker - Analista Programador |

**Asistentes:**

| Nombre | Cargo | Firma |
|--------|-------|-------|
| Carolina Méndez | Jefa de Recursos Humanos | _____________ |
| Andrés Figueroa | Encargado de Remuneraciones | _____________ |
| Patricia Soto | Jefa de Operaciones | _____________ |
| Remigio Stocker | Analista Programador | _____________ |

**Temas tratados:**

1. Revisión de los requerimientos recopilados en las entrevistas previas.
2. Definición de los roles de usuario y sus permisos.
3. Validación de las reglas de cálculo de remuneraciones.
4. Revisión y aprobación de los bosquejos de interfaces.
5. Definición de la arquitectura del sistema.

**Acuerdos alcanzados:**

| N.° | Acuerdo | Responsable | Plazo |
|-----|---------|-------------|-------|
| 1 | El sistema tendrá dos roles: Administrador y Usuario Normal | Remigio Stocker | - |
| 2 | El Administrador podrá registrar, modificar y eliminar empleados | Remigio Stocker | - |
| 3 | El Usuario Normal solo podrá consultar y calcular liquidaciones | Remigio Stocker | - |
| 4 | Se aprobaron los 3 bosquejos de interfaces presentados (Login, Registro Sueldo, Listado) | Todos | - |
| 5 | Se utilizará arquitectura en 3 capas (Datos, Negocio, Presentación) | Remigio Stocker | - |
| 6 | La aplicación será de escritorio en Windows Forms con C# | Remigio Stocker | - |
| 7 | Se implementará persistencia en archivo JSON para las liquidaciones | Remigio Stocker | - |
| 8 | Se agregará un formulario de menú principal para la navegación | Remigio Stocker | - |
| 9 | El listado de empleados tendrá filtros por rango alfabético y por estado de liquidación | Remigio Stocker | - |
| 10 | Se incluirá un historial de liquidaciones con búsqueda por nombre | Remigio Stocker | - |

**Observaciones:**
- La Sra. Patricia Soto solicitó que el sistema sea intuitivo y fácil de usar, ya que no todo el personal tiene experiencia con software complejo.
- Se acordó que la primera versión no requerirá conexión a base de datos; se utilizará almacenamiento en memoria con opción de exportar a JSON.
- Se evaluará en una segunda fase la migración a base de datos SQL Server.

---

### 3.3 Cuestionario

**Cuestionario de Requerimientos - Sistema de Liquidación de Remuneraciones**

Dirigido al personal del área de Recursos Humanos de la empresa "Estrategias Profesionales".

**Fecha de envío:** 10 de agosto de 2025
**Fecha de recepción:** 13 de agosto de 2025
**Respondido por:** Carolina Méndez (Jefa RRHH) y Andrés Figueroa (Encargado de Remuneraciones)

---

**Sección 1: Información General**

**1.1 ¿Cuántas personas utilizarán el sistema de forma regular?**

> Aproximadamente 5 personas: 2 administradores del área de RRHH y 3 jefes de área como usuarios normales.

**1.2 ¿El sistema será utilizado en una sola sede o en múltiples ubicaciones?**

> Por ahora solo en la sede central de Santiago, en la oficina de Recursos Humanos.

**1.3 ¿Existe algún sistema actual que deba ser reemplazado o con el que deba integrarse?**

> Se reemplazará la planilla Excel que usamos actualmente. No hay otro sistema con el cual integrarse.

---

**Sección 2: Gestión de Empleados**

**2.1 ¿Qué datos son obligatorios al registrar un empleado? Marque con X:**

| Dato | Obligatorio |
|------|-------------|
| RUT | [X] |
| Nombre completo | [X] |
| Dirección | [X] |
| Teléfono | [X] |
| Valor hora | [X] |
| Valor hora extra | [X] |
| Correo electrónico | [ ] |
| Fecha de nacimiento | [ ] |
| Cargo | [ ] |

**2.2 ¿El RUT de un empleado puede repetirse en el sistema?**

> No, cada RUT debe ser único. No puede haber dos empleados con el mismo RUT.

**2.3 ¿Se debe poder modificar la información de un empleado después de registrado?**

> Sí, el administrador debe poder modificar todos los campos excepto el RUT.

**2.4 ¿Se debe poder eliminar un empleado del sistema?**

> Sí, pero solo el administrador debería poder hacerlo, y con una confirmación previa para evitar eliminaciones accidentales.

---

**Sección 3: Cálculo de Remuneraciones**

**3.1 Confirme las fórmulas de cálculo:**

| Concepto | Fórmula | Confirmado |
|----------|---------|------------|
| Sueldo Bruto | (Horas trabajadas x Valor hora) + (Horas extras x Valor hora extra) | [X] |
| Descuento AFP | Sueldo Bruto x Porcentaje AFP seleccionada | [X] |
| Descuento Salud | Sueldo Bruto x Porcentaje Salud seleccionada | [X] |
| Sueldo Líquido | Sueldo Bruto - Descuento AFP - Descuento Salud | [X] |

**3.2 Confirme los porcentajes de AFP:**

| AFP | Porcentaje | Confirmado |
|-----|-----------|------------|
| CUPRUM | 7% | [X] |
| MODELO | 9% | [X] |
| CAPITAL | 12% | [X] |
| PROVIDA | 13% | [X] |

**3.3 Confirme los porcentajes de Salud:**

| Sistema de Salud | Porcentaje | Confirmado |
|-----------------|-----------|------------|
| FONASA | 12% | [X] |
| CONSALUD | 13% | [X] |
| MASVIDA | 14% | [X] |
| BANMEDICA | 15% | [X] |

**3.4 ¿Desean que el sistema guarde un historial de las liquidaciones calculadas?**

> Sí, necesitamos poder consultar liquidaciones anteriores y tener un registro de los cálculos realizados.

---

**Sección 4: Seguridad y Acceso**

**4.1 ¿Qué tipo de autenticación prefieren?**

> [X] Usuario y contraseña
> [ ] Integración con Active Directory
> [ ] Sin autenticación

**4.2 ¿Qué permisos debe tener cada rol?**

| Funcionalidad | Administrador | Usuario Normal |
|---------------|:---:|:---:|
| Iniciar sesión | X | X |
| Registrar empleados | X | |
| Modificar empleados | X | |
| Eliminar empleados | X | |
| Calcular liquidaciones | X | X |
| Ver listado de empleados | X | X |
| Ver historial de liquidaciones | X | X |

**4.3 ¿Se requiere registro de auditoría (quién hizo qué y cuándo)?**

> No es necesario para esta primera versión.

---

**Sección 5: Interfaz y Usabilidad**

**5.1 ¿Tienen preferencia sobre el diseño visual de la aplicación?**

> Preferimos un diseño limpio y sencillo. Se proporcionaron bosquejos de 3 pantallas principales: Login, Registro de Sueldo y Listado de Trabajadores.

**5.2 ¿Qué funcionalidades son prioritarias en el listado de empleados?**

> [X] Filtrar por nombre (rango alfabético)
> [X] Filtrar por estado de liquidación (con sueldo / sin sueldo)
> [X] Modificar empleado desde el listado
> [X] Eliminar empleado desde el listado
> [ ] Exportar listado a Excel
> [ ] Imprimir listado

**5.3 ¿Consideran necesario un menú principal de navegación?**

> Sí, un menú que permita acceder a las distintas funcionalidades según el rol del usuario.

---

## 4. Requerimientos Identificados

### 4.1 Requerimientos Funcionales

| ID | Requerimiento | Prioridad | Fuente |
|----|---------------|-----------|--------|
| RF-01 | El sistema debe permitir la autenticación de usuarios mediante usuario y contraseña | Alta | Entrevista 1, Cuestionario 4.1 |
| RF-02 | El sistema debe diferenciar dos roles de usuario: Administrador y Usuario Normal | Alta | Entrevista 1, Reunión Acuerdo 1 |
| RF-03 | El Administrador debe poder registrar empleados con los campos: RUT, Nombre, Dirección, Teléfono, Valor Hora y Valor Hora Extra | Alta | Entrevista 1, Cuestionario 2.1 |
| RF-04 | El sistema no debe permitir registrar dos empleados con el mismo RUT | Alta | Entrevista 2, Cuestionario 2.2 |
| RF-05 | El Administrador debe poder modificar los datos de un empleado (excepto el RUT) | Alta | Cuestionario 2.3, Reunión Acuerdo 2 |
| RF-06 | El Administrador debe poder eliminar un empleado con confirmación previa | Alta | Cuestionario 2.4, Reunión Acuerdo 2 |
| RF-07 | El sistema debe calcular el Sueldo Bruto como: (Horas trabajadas x Valor hora) + (Horas extras x Valor hora extra) | Alta | Entrevista 1, Cuestionario 3.1 |
| RF-08 | El sistema debe calcular el Descuento AFP según la AFP seleccionada y su porcentaje correspondiente | Alta | Entrevista 1, Cuestionario 3.2 |
| RF-09 | El sistema debe calcular el Descuento de Salud según el sistema de salud seleccionado y su porcentaje correspondiente | Alta | Entrevista 1, Cuestionario 3.3 |
| RF-10 | El sistema debe calcular el Sueldo Líquido como: Sueldo Bruto - Descuento AFP - Descuento Salud | Alta | Entrevista 1, Cuestionario 3.1 |
| RF-11 | El sistema debe permitir listar todos los empleados registrados con su RUT, Nombre, Dirección y Sueldo Líquido | Alta | Reunión Acuerdo 9 |
| RF-12 | El listado de empleados debe permitir filtrar por rango alfabético (A-F, G-L, M-R, S-Z) y por estado de liquidación (con sueldo / sin sueldo) | Media | Reunión Acuerdo 9, Cuestionario 5.2 |
| RF-13 | El sistema debe guardar un historial de las liquidaciones calculadas | Media | Entrevista 2, Cuestionario 3.4 |
| RF-14 | El historial de liquidaciones debe permitir búsqueda por nombre del empleado | Media | Reunión Acuerdo 10 |
| RF-15 | El sistema debe persistir las liquidaciones en archivo JSON | Media | Reunión Acuerdo 7 |
| RF-16 | El sistema debe incluir un menú principal de navegación diferenciado por rol | Alta | Cuestionario 5.3, Reunión Acuerdo 8 |
| RF-17 | El Usuario Normal solo debe poder consultar el listado y calcular liquidaciones, sin acceso a funciones de gestión de empleados | Alta | Reunión Acuerdo 3 |
| RF-18 | Al seleccionar un empleado con liquidación existente, el sistema debe cargar automáticamente sus datos de última liquidación | Baja | Reunión Acuerdo 10 |

### 4.2 Requerimientos No Funcionales

| ID | Requerimiento | Prioridad | Fuente |
|----|---------------|-----------|--------|
| RNF-01 | La aplicación debe ser de escritorio, desarrollada en Windows Forms con C# | Alta | Entrevista 1, Reunión Acuerdo 6 |
| RNF-02 | La aplicación debe ejecutarse sobre .NET Framework 4.8 en sistemas operativos Windows | Alta | Reunión Acuerdo 6 |
| RNF-03 | La arquitectura debe ser en 3 capas: Capa de Datos, Capa de Negocio y Capa de Presentación | Alta | Reunión Acuerdo 5 |
| RNF-04 | La interfaz debe ser intuitiva y fácil de usar para personal sin experiencia técnica | Alta | Reunión - Observación de Patricia Soto |
| RNF-05 | El sistema debe soportar al menos 100 empleados registrados sin degradación de rendimiento | Media | Entrevista 2 |
| RNF-06 | Las validaciones de entrada deben realizarse tanto en tiempo real (al escribir) como al enviar formularios | Media | Entrevista 2 |
| RNF-07 | Los campos numéricos deben restringir la entrada a solo números; los campos de texto a solo letras donde corresponda | Media | Entrevista 2 |
| RNF-08 | La contraseña debe mostrarse enmascarada (con asteriscos) en el formulario de login | Baja | Buena práctica de seguridad |
| RNF-09 | Los campos de resultado (Sueldo Bruto y Sueldo Líquido) deben ser de solo lectura | Baja | Buena práctica de usabilidad |

---

## 5. Reglas de Negocio

| ID | Regla | Detalle |
|----|-------|---------|
| RN-01 | Cálculo de Sueldo Bruto | Sueldo Bruto = (Horas trabajadas x $5.000) + (Horas extras x $7.000) |
| RN-02 | Descuento AFP CUPRUM | 7% del Sueldo Bruto |
| RN-03 | Descuento AFP MODELO | 9% del Sueldo Bruto |
| RN-04 | Descuento AFP CAPITAL | 12% del Sueldo Bruto |
| RN-05 | Descuento AFP PROVIDA | 13% del Sueldo Bruto |
| RN-06 | Descuento Salud FONASA | 12% del Sueldo Bruto |
| RN-07 | Descuento Salud CONSALUD | 13% del Sueldo Bruto |
| RN-08 | Descuento Salud MASVIDA | 14% del Sueldo Bruto |
| RN-09 | Descuento Salud BANMEDICA | 15% del Sueldo Bruto |
| RN-10 | Cálculo de Sueldo Líquido | Sueldo Líquido = Sueldo Bruto - Descuento AFP - Descuento Salud |
| RN-11 | Unicidad de RUT | No pueden existir dos empleados con el mismo RUT en el sistema |
| RN-12 | Selección de AFP y Salud | Cada empleado debe tener exactamente una AFP y un sistema de salud seleccionado |
| RN-13 | Permisos de Administrador | Puede registrar, modificar y eliminar empleados, y calcular liquidaciones |
| RN-14 | Permisos de Usuario Normal | Solo puede consultar el listado de empleados y calcular liquidaciones |

---

## 6. Restricciones del Proyecto

| N.° | Restricción |
|-----|------------|
| 1 | El desarrollo debe realizarse en C# con Windows Forms sobre .NET Framework 4.8 |
| 2 | No se utilizará base de datos en la primera versión; los datos se almacenan en memoria con persistencia opcional en JSON |
| 3 | El sistema es monousuario (no requiere acceso concurrente desde múltiples estaciones) |
| 4 | La aplicación debe funcionar en equipos con Windows 10 o superior |
| 5 | Los bosquejos de interfaz proporcionados por el cliente deben respetarse como base del diseño visual |

---

## 7. Aprobación del Documento

| Rol | Nombre | Firma | Fecha |
|-----|--------|-------|-------|
| Jefa de Recursos Humanos | Carolina Méndez | _____________ | __/__/2025 |
| Encargado de Remuneraciones | Andrés Figueroa | _____________ | __/__/2025 |
| Jefa de Operaciones | Patricia Soto | _____________ | __/__/2025 |
| Analista Programador | Remigio Stocker | _____________ | __/__/2025 |

---

*Documento elaborado por Remigio Stocker - Analista Programador*
*Proyecto ENE PRO201 - Taller de Programación 2024*
*Instituto Profesional AIEP*
