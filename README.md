# README

---

## English Version

### 1. Create the Database
- Create a new database using your preferred SQL management tool (e.g., MySQL Workbench, pgAdmin).
- Ensure the database is accessible with the correct credentials.

### 2. Configure the Database Connection
- Update the connection string in the `appsettings.json` file (for .NET):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OrderDB;User=your_user;Password=your_password;"
}
```

- **Note:** If needed, modify the `applicationUrl` parameter in the project.

### 3. Apply Database Migrations
- For .NET, open a terminal and run the following commands to create and apply migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application
- Execute the command:

```bash
dotnet run
```

### 5. Configure the API URL for the Angular Application
- If needed, update the `apiBaseUrl` in the Angular environment configuration file (`environment.ts`):

```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'http://localhost:5091/api' // Specify your API URL
};
```

### 6. Run the Angular Application
- Navigate to the root folder of the Angular application and execute the command:

```bash
ng serve
```

- Open the application in a browser at: `http://localhost:4200` (or the specified port).

---

## Русская версия

### 1. Создайте базу данных
- Создайте новую базу данных с помощью вашего предпочтительного инструмента управления SQL (например, MySQL Workbench, pgAdmin).
- Убедитесь, что база данных доступна с корректными учетными данными.

### 2. Настройте подключение к базе данных
- Обновите строку подключения в файле `appsettings.json` (для .NET):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OrderDB;User=your_user;Password=your_password;"
}
```

- **Примечание:** Если необходимо, измените параметр `applicationUrl` в проекте.

### 3. Примените миграции базы данных
- Для .NET откройте терминал и выполните следующие команды для создания и применения миграций:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Запустите приложение
- Выполните команду:

```bash
dotnet run
```

### 5. Настройте URL API для Angular приложения
- Если необходимо, измените `apiBaseUrl` в файле настроек окружения Angular приложения (`environment.ts`):

```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'http://localhost:5091/api' // Укажите ваш URL API
};
```

### 6. Запустите Angular приложение
- Перейдите в корневую папку Angular приложения и выполните команду:

```bash
ng serve
```

- Откройте приложение в браузере по адресу: `http://localhost:4200` (или другому указанному порту).
