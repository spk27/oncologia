### Oncología - Nexos Software

Solución al requerimiento de Oncología.

## Recordatorios para miembros y/o colaboradores

# LINEAMIENTOS
* Seguir los lineamientos de desarrollo planteados en la oficina.
# BASE DE DATOS
* Se trabajará sobre una sóla base de datos compartida.
  - Persistencia (lecturas, escrituras, actualizaciones, eliminaciones o modificaciones al esquema) será únicamente a través de EF Code-First a través de migraciones.
  - Cambios en el esquema, tabla o atributos deben ser previamente notificados debido a que pueden tener efectos secunarios en el desarrollo de otros miembros del equipo.
  - Se trabajará lo menos posible con Scripts y/o Funciones a no ser que sea estrictamente necesario, entonces conversarlo con el equipo.
# GIT
* Manejar buenas practicas en GIT:
  - Trabajar sobre su propia rama de desarrollo para el requerimiento asignado.
  - Una vez finalizado el requerimiento, se notifica al equipo para comenzar el proceso del merge.
  - Manejar los conceptos de ADD, STAGE, COMMIT, PUSH, PULL, MERGE.
# CODIFICACIÓN
  * Declarar variables temporales o auxiliares en cualquier idioma.
  * Declarar namespaces, carpetas, subcarpetas y terminaciones todo en Ingles. Ej:
    - Domain, Application, Infrastructure (namespaces)
    - GetPacienteCommand (carpeta)
    - PacienteViewModel (clase)
    - Entities (carpeta)
  * Declarar los nombres de las entidades y sus atributos en Español. Ej:
    - Paciente (clase)
    - Historial (clase)
    - Nombre (atributo de clase)
    - Direccion (atributo de clase)
  * Evitar (no) usar declaraciones cortas o no identificables. Ej: 
    - Mal uso: 'var x' 'int count'
    - Buen uso: 'var auxTemporal' 'int contadorDeXCosa'
    - El código puede ser mantenido por otros colaboradores y esto facilita su comprensión.
    - El nombre que le des a las clases, variabes, metodos, etc pueden ser tan largos como sea necesario.
    - Si son nombres de métodos puede utilizar verbos en el nombre para identificar la acción que realiza.