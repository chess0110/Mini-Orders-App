# Mini Orders App

## Proyecto realizado: [Mini Orders App URL](https://zingy-malasada-cc1650.netlify.app)
## Documentación en Swagger: [Swagger Documentation](https://mini-order-app-backend.onrender.com/swagger/index.html)
## Imagen del contenedor - Docker Hub: [chess0110/orders-challenge](https://hub.docker.com/r/chess0110/orders-challenge)

## Como correr el Frontend:
### 1.  clona el repositorio:
* ```git clone https://github.com/chess0110/Mini-Orders-App.git```
### 2. sigue los comandos:
```bash
cd Mini-Orders-App/
cd Frontend/
cd Mini_Orders_App/
npm install
npm run dev
```
#### _( Copia la ip local generada: "http://localhost:####/" )_
#### _( Guarda esa ip para configurar Cors en el backend )_

## Como correr el Backend:
#### 1. Abre la terminal en la carpeta del repositorio
```bash
cd Mini-Orders-App/
cd Backend/
cd OrdersChallenge/
dotnet restore OrdersChallenge.sln
dotnet build
```
* **Ve a la carpeta del Proyecto: "OrdersChallenge" que contiene el archivo Program.cs**
* **Abre el archivo " _Program.cs_ "**
* **cambia la ip que tiene por la que te da el Frontend en:**
**```policy => policy.WithOrigins("http://localhost:####")```**
* **Abre la terminal en esa carpeta**
* **Ejecuta el comando: "dotnet run"**

## Agrega la url del backend en el entorno del frontend:
1. **Ve a la carpeta raiz "Mini_Orders_App" que contiene el Frontend**
2. **Crea un archivo llamado " .env "**
3. **Abre el archivo ".env" y pega tu ip del backend en la variable:**
```VITE_API_URL = http://localhost:#### ```

#### **Nota:** Para interactuar con el proyecto inicia el frontend y el backend al mismo tiempo, luego coloca la ip del frontend en el navegador.

## Utilidades:
1. _Organizar cuentas pendientes_
2. _Recordatorio de pagos_
3. _Registro de cobros_

## Ejemplos de uso:
<img width="1919" height="1079" alt="Captura de pantalla 2025-10-08 103624" src="https://github.com/user-attachments/assets/3febab5f-6998-40b4-8c22-fb405c5fbde0" />
<img width="1919" height="106" alt="Captura de pantalla 2025-10-08 103818" src="https://github.com/user-attachments/assets/97671afc-8700-4890-a074-627ce6d30334" />
<img width="1919" height="115" alt="Captura de pantalla 2025-10-08 103809" src="https://github.com/user-attachments/assets/622ed4cf-86a7-4063-9264-bfa96c3c0c50" />
<img width="1919" height="1079" alt="Captura de pantalla 2025-10-08 103521" src="https://github.com/user-attachments/assets/fbbef6b3-49a1-4fa6-8ab1-15d8ad1836b7" />
<img width="1919" height="1079" alt="Captura de pantalla 2025-10-08 103533" src="https://github.com/user-attachments/assets/e96fbe25-4fb8-4ba6-bc0e-432130309912" />



## Reflexión personal:
El proyecto fue muy educativo, tuve que aprender a limpiar una lista cada x tiempo utilizando un servicio de .net, la parte desafiante fue la decision de haber hecho el manejo de estados de los botones con valores booleanos, sincronizando las acciones del usuario con los estados de la interfaz, y así, asignándole una variable (true / false) para activar o desactivar los elementos en lugar de haber utilizado un método mas directo de vue, aunque si utilice directivas en algunos elementos, la mayoría fue manejando estados (true / false) como challenge.
