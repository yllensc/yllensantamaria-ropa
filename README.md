# ClothingStore

## Comenzando 🚀

La empresa safe clothing desea realizar un backend que le permita llevar el control, registro y seguimiento de la producción de prendas de seguridad industrial, la empresa cuenta con diferentes tipos de prendas entre las cuales están las prendas resistentes al fuego (Ignifugas), resistentes a altos voltajes (Arco eléctrico). La empresa lo contrata a usted como experto backend para que cumpla con los siguientes requerimientos de desarrollo.

- Implementar restricción de peticiones haciendo uso de limitaciones de peticiones por IP.
- Implementar protección a los endPoints haciendo uso de JWT y roles de usuario.
- Implementar esquema de versionado de Api que facilite el proceso de implementación de nuevos endpoints sin afectar el funcionamiento de las aplicaciones externas que consumen los servicios del Api.
- Implementar endpoints que permitan realizar el proceso de CRUD en cada uno de los controladores del backend.
- Debido al gran volumen de información que la empresa procesa diariamente se requiere que los endpoints encargados de consultar el contenido de las tablas implementen sistema de paginación.

## EndPoints requeridos
1. Listar los proveedores que sean persona natural.
2. Listar las prendas de una orden de producción cuyo estado sea en producción. El usuario debe ingresar el número de orden de producción.
3. Listar las prendas agrupadas por el tipo de protección.
4. Listar las ordenes de producción que pertenecen a un cliente especifico. El usuario debe ingresar el IdCliente y debe obtener la siguiente información:
   - IdCliente, Nombre, Municipio donde se encuentra ubicado.
   - Nro de orden de producción, fecha y el estado de la orden de producción (Se debe mostrar la descripción del estado, código del estado, valor total de la orden de producción.
   - Detalle de orden: Nombre de la prenda, Código de la prenda, Cantidad, Valor total en pesos y en dólares.
5. Listar los insumos de una prenda y calcular cuanto cuesta producir una prenda especifica. El costo de la prenda dependerá de la cantidad de insumos que sean necesarios para la producción de la misma. El usuario debe ingresar en Id de la prenda.
6. Listar los insumos que son vendidos por un determinado proveedor. El usuario debe ingresar el Nit de proveedor.
7. Listar las ventas realizadas por un empleado especifico. El usuario debe ingresar el Id del empleado y mostrar la siguiente información.
   - Id Empleado
   - Nombre del empleado
   - Fecturas : Nro Factura, fecha y total de la factura.
### Pre-requisitos 📋

- .NET 7.0
- MySQL
### Estrucutra de la base de datos utilizada
![image](https://github.com/yllensc/yllensantamaria-ropa/assets/117176562/bcf876dd-7e22-45ec-bbd2-eab3b8882070)


### Instalación 🔧

Migración de la base de datos (code-first migration):
Ejecuta los comandos:
```
1. dotnet ef migrations add ¨[nombreDeLaMigracion] --project ./Persistence --startup-project API --output-dir ./Data/Migrations
2. dotnet ef database update --project ./Infrastructure --startup-project ./API
```

Ejecución de la WebApi (desde la ruta del proyecto):
Ejecuta los comandos:
```
1. cd API
2. dotnet run
```
## Ejecutando las pruebas ⚙️
### Ojito 👀:
El proyecto tiene una colección de postman con la petición del token que caduca cada 2 minutos, los 12 endpoints del requerimiento y un CRUD de prueba para Appointment.
Aquí ➡️: [CollectionPostman]([https://github.com/yllensc/veterinaria-4capas-csharp/blob/main/VeterinarianEndpoints.postman_collection](https://github.com/yllensc/yllensantamaria-ropa/blob/main/CampusFiltroYllenSantamaria.postman_collection.json))
### User 👨‍💻💁‍♂️💁‍♀️:
#### 1. Register <br>
Endpoint: ```http://localhost:5223/api/User/register```

Método: ```POST```
<br>
Body:
```{"Email": "v2@gmail.com","UserName": "empleado2","Password": "1234","IdenNumber": "123423344678"}```

#### 2. Token <br>
Endpoint: ```http://localhost:5223/api/User/token```

Método: ```POST```
<br>
Body: 
```{"UserName": "usuario8","Password": "1234"}```

#### 3. Refresh token <br>
Endpoint: ```http://localhost:5223/api/veterinaria/refresh-token```

Método: ```POST```
<br>
Body:
```{"RefreshToken":"9YIa9WNUKqobsKEr4R9z/dsUFr5Dm0x9fjj0IBXkYMw="}```

## Autenticación y autorización
Para este ejercicio, creé 3 roles, Admi, Empleado, SinRolAasignado. Casi todas las peticiones HTTP autorizan a los usuarios, y hay peticiones en particular con restricciones por role. Por ejemplo, los empleados no tienen acceso a sus propios datos.

## Cruds
Las entidades que lo requieren tienen la implementación del CRUD, accediento a cada controller a través del nombre de la entidad y claramente de acuerdo a la solicitud cambian los parámetros de los POST.

## Versionado y paginado
La implementación de versión está en los CRUD, pero totalmente funcional en Empleado. en el postman está la consulta.

## RateLimit
El ratelimit define la cantidad de peticiones permitidas en el tiempo y sobrepasar el límite se refleja de esta manera:
![image](https://github.com/yllensc/veterinaria-4capas-csharp/assets/117176562/f9f831e4-1564-4db6-9172-1f22f0673b0c)

## Endpoints ✌️🤘🆗😺🦝🐶🦄
Los endpoints son de tipo GET, por lo que todos cuentan con su versión 1.0 y 1.1, para los ejemplos, las consultas se van a presentar con diferentes versiones:
1. ``` http://localhost:5223/api/Proveedor/getTipoPersonanatural ``` <br>

2. ``` http://localhost:5223/api/Prenda/prendasEnProduccionconNumOrden1 ``` <br>
3. ``` http://localhost:5223/api/Prenda/prendasConTipoDeProteccion ``` <br>
4. ```  ``` <br>
5. ```   ``` <br>
6. ```  ``` <br>
7. ``` ``` <br>



















## Construido con 🛠️

* [ASP.NET Core]([http://www.dropwizard.io/1.0.2/docs/](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)) - El framework web usado
* [MySql]([https://maven.apache.org/](https://dev.mysql.com/doc/workbench/en/wb-mysql-utilities.html)) - Base de datos


## Autor✒️

* **Yllen Santamaría** - [Yllensc](https://github.com/yllensc)
