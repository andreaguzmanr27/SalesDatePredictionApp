# Sales Date Prediction

Este proyecto es una aplicación full-stack desarrollada con **Angular 19** y **.NET Core**, que permite crear órdenes y predecir cuándo ocurrirá la próxima orden por cliente de acuerdo con los registros almacenados en la base de datos.

## 📌 Tecnologías
- **Backend:** .NET Core, Entity Framework Core, SQL Server
- **Frontend:** Angular 19, TypeScript
- **Base de datos:** SQL Server
- **Librerías adicionales:** ngx-pagination

---

## 📥 Instalación y configuración

### 1️⃣ Configuración del Backend (.NET Core API)
1. Clonar el repositorio:
   ```sh
   git clone <URL_DEL_REPOSITORIO>
   cd SalesDatePredictionApp
   ```
2. Instalar los paquetes de Entity Framework Core:
   ```sh
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```
3. Configurar la base de datos en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=ELMAQUINON;Database=StoreSample;User Id=antirio1;Password=leia2020;TrustServerCertificate=True"
   }
   ```
4. Ejecutar la migración y actualizar la base de datos:
   ```sh
   dotnet ef migrations add CreateOrderPredictionTable
   dotnet ef database update
   ```
5. Ejecutar el servidor:
   ```sh
   dotnet run
   ```

---

### 2️⃣ Configuración del Frontend (Angular 17+)
1. Ir a la carpeta del frontend:
   ```sh
   cd SalesDatePredictionApp.client
   ```
2. Instalar las dependencias:
   ```sh
   npm install
   ```
3. Instalar la librería para la paginación:
   ```sh
   npm install ngx-pagination
   ```
4. Ejecutar la aplicación:
   ```sh
   ng serve
   ```
5. Abrir el navegador en `http://localhost:4200`

---

## 🔹 Funcionalidades Implementadas
### **Backend - API REST (.NET Core)**
- Listar clientes con fecha de última orden y fecha de posible orden.
- Listar órdenes por cliente.
- Listar todos los empleados.
- Listar todos los shippers.
- Listar todos los productos.
- Crear una nueva orden con un producto.

### **Frontend - SPA (Angular 19)**
  - Lista de clientes con su nombre, fecha de última orden y fecha de posible siguiente orden (Home).
  - Paginación y ordenamiento en la tabla por cualquiera de sus colunmas.
  - Campo de búsqueda para filtrar por nombre del cliente (consulta al servidor).
  - Botón `VIEW ORDERS` que abre un modal con las órdenes del cliente seleccionado.
  - Botón `NEW ORDER` que abre un modal para crear una nueva orden del cliente seleccionado.
