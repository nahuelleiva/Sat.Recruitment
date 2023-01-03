# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.

## Refactoring

* Se separo la aplicación en capas de Controlador, Lógica de Negocio y Datos
  * DataService se encarga de persistir y obtener la lista de los usuarios
  * DomainManager administra la lógica de negocio de la aplicacin
  * UsersController gestiona las peticiones HTTP
* Se desacoplaron interfaces e implementaciones. Ahora se inyectan por dependencia
* Se agregaron DTOs para transferir la información desde la API a la capa de dominio
* Se agregó un mapeador de objetos para convertir DTOs en modelos de la capa de negocio
* Se agregan clases con valores constantes para administrar los roles y mensajes de error de la aplicación
* Se agregan logs utilizando Serilog

### API
Se siguió el standard OpenApi para la creacion de los endpoints y los codigos de respuesta

Endpoints:
* POST /users

### Gifts
* La lógica de asignación de premio monetario se incluyó como parte del mapeador de objetos para ser calculado en base al Rol del Usuario
* De esta forma se puede manipular y entender fácilmente. También puede ser parte del modelo del Usuario, o bien ser configurable

### Tests
Se actualizaron los tests acorde a los cambios introducidos

### Otras mejoras posibles
Teniendo en cuenta que es un caso de prueba básico, no se profundizó en demasía la implementación a modo de no agregar complejidad innecesaria. Dependiendo de la complejidad, crecimiento del proyecto y/o cambios en el alcance se podrían implementar otros enfoques y utilizar otras herrammientas, como por ejemplo:

* Utilizar la libreria MediatR: de esta manera permite implementar el patrón CQRS para desacoplar la lectura (queries) y escritura (commands) de los datos.
* Rescribir los métodos para que sean asíncronos
* Agregar logs en la capa de dominio/lógica de negocio para persistir los mensajes propios de la capa
* Implementar un manejador de excepciones
