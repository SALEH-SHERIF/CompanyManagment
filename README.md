# 🏢 CompanyManagment

A complete **ASP.NET Core Web API** project for managing employees and departments within a company.  
This system allows secure authentication using **JWT**, full CRUD operations, and role-based access control.

---

## 📌 Features

- ✅ Create, Read, Update, Delete for Departments
- ✅ Create, Read, Update, Delete for Employees
- ✅ One-to-Many relation between Departments and Employees
- ✅ JWT Authentication for secure access
- ✅ Login system for users
- ✅ Layered architecture: Controllers → Services → Repositories → EF

---

## 🧱 Tech Stack

- 🔸 **Backend:** ASP.NET Core Web API
- 🔸 **Database:** SQL Server (with EF Core Code-First)
- 🔸 **Authentication:** JWT (JSON Web Tokens)

---
## 🌐 Live Demo

You can try the API live via Swagger here:

👉 [Live Swagger UI Demo](http://companymanagment.runasp.net/swagger/index.html)

---
## 🗃️ Database Structure

### Department Table
| Column      | Type    | Description                 |
|-------------|---------|-----------------------------|
| Id          | int     | Primary Key                 |
| Name        | string  | Department Name             |
| Description | string  | Short description           |

### Employee Table
| Column        | Type       | Description              |
|---------------|------------|--------------------------|
| Id            | int        | Primary Key              |
| FullName      | string     | Employee full name       |
| Email         | string     | Email address            |
| Phone         | string     | Phone number             |
| DateOfJoining | DateTime   | Joining date             |
| DepartmentId  | int (FK)   | Linked Department        |

### User Table
| Column        | Type         | Description           |
|---------------|--------------|-----------------------|
| Id            | int          | Primary Key           |
| Username      | string       | Login username        |
| PasswordHash  | varbinary    | Hashed password       |
| PasswordSalt  | varbinary    | Salt used for hashing |

---

## 🔐 Authentication

- **Login Endpoint:**
- POST /api/auth/login
- You’ll receive a **JWT Token** to access all protected endpoints:
- `/api/departments`
- `/api/employees`

---
## 🚀 How to Run Locally

```bash
# 1️⃣ Clone the repository
git clone https://github.com/SALEH-SHERIF/CompanyManagment.git
cd CompanyManagment
```

```bash
# 2️⃣ Update your appsettings.json with your own configuration

# Example:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=CompanyDb;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere123!",
    "Issuer": "CompanyAPI"
  }
}
```

```bash
# 3️⃣ Install EF Core CLI (if not already installed)
dotnet tool install --global dotnet-ef
```

```bash
# 4️⃣ Apply migrations to create the database
dotnet ef database update
```

```bash
# 5️⃣ Run the application
dotnet run
```

```bash
# 6️⃣ Open Swagger UI in your browser to test the API
# 👉 https://localhost:5001/swagger
# or
# 👉 http://localhost:5000/swagger

# Use the /api/auth/login endpoint to get a JWT token,
# then authorize to access protected endpoints like:
# /api/employees, /api/departments
```

## 📡 API Endpoints Overview

## 📡 API Endpoints – Actual Controller Methods

### 🔐 AuthController

| Method | Endpoint             | Controller Method  | Description          |
|--------|----------------------|--------------------|----------------------|
| POST   | `/api/auth/login`    | `Login()`          | Login and return JWT |

---

### 🏢 DepartmentsController

| Method | Endpoint                        | Controller Method         | Description                    |
|--------|----------------------------------|----------------------------|--------------------------------|
| GET    | `/api/departments/GetAllDepartments`       | `GetAll()`                 | Get all departments            |
| GET    | `/api/departments/GetDepartmentById/{id}`  | `GetById(int id)`          | Get department by ID           |
| POST   | `/api/departments/CreateDepartments`       | `CreateDepartment(dto)`    | Create a new department        |
| PUT    | `/api/departments/UpdateDepartment/{id}`   | `UpdateDepartment(id, dto)`| Update department              |
| DELETE | `/api/departments/DeleteDepartment/{id}`   | `DeleteDepartment(id)`     | Delete department              |

---

### 👨‍💼 EmployeesController

| Method | Endpoint                          | Controller Method         | Description                    |
|--------|------------------------------------|----------------------------|--------------------------------|
| GET    | `/api/employees/GetAllEmployees`          | `GetAllEmployees()`        | Get all employees              |
| GET    | `/api/employees/GetEmployeeById/{id}`     | `GetById(int id)`          | Get employee by ID             |
| POST   | `/api/employees/CreateEmployee`           | `CreateEmployee(dto)`      | Create new employee            |
| PUT    | `/api/employees/UpdateEmployee/{id}`      | `UpdateEmployee(id, dto)`  | Update employee                |
| DELETE | `/api/employees/DeleteEmployee/{id}`      | `DeleteEmployee(id)`       | Delete employee                |

## 📁 Project Structure – CompanyManagement (.NET 6 Web API)

```
CompanyManagment/
│
├── Controllers/                    # API Controllers
│   ├── AuthController.cs
│   ├── DepartmentsController.cs
│   └── EmployeesController.cs
│
├── Models/                         # Database Models
│   ├── Department.cs
│   ├── Employee.cs
│   └── User.cs
│
├── Models/Dtos/                   # Data Transfer Objects (DTOs)
│   ├── DepartmrntDtos/
│   │   └── CreateDepartment.cs
│   ├── EmployeeDtos/
│   │   ├── CreateEmployeeDto.cs
│   │   └── EmployeeDetailsDto.cs
│   └── UserDtos/
│       └── LoginDto.cs
│
├── Repositiors/                   # Data Access Layer
│   ├── ApplicationDbContext.cs
│   ├── DepartmentRepository.cs
│   ├── EmployeeRepository.cs
│   ├── UserRepository.cs
│   └── Interfaces/
│       ├── IDepartmentRepository.cs
│       ├── IEmployeeRepository.cs
│       ├── IUserRepository.cs
│       └── IAuthService.cs
│
├── Services/                      # Business Logic Layer
│   ├── DepartmentService.cs
│   ├── EmployeeService.cs
│   ├── AuthService.cs
│   └── Interfaces/
│       ├── IDepartmentService.cs
│       └── IEmployeeService.cs
│
├── Migrations/                    # EF Core Migrations
│   └── [Timestamp]_Initial.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs                     # Entry point
├── appsettings.json               # Configuration settings
├── CompanyManagment.csproj        # Project file
└── CompanyManagment.sln           # Solution file
```
---
## 🙋‍♂️ Contact

Developed by [Saleh Sherif](https://github.com/SALEH-SHERIF)  
If you have any questions or want to collaborate, feel free to reach out!


