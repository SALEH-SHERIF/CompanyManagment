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

### 🔐 Auth
| Method | Endpoint            | Description        |
|--------|---------------------|--------------------|
| POST   | /api/auth/login     | Login and get JWT  |

### 🏢 Departments
| Method | Endpoint                | Description             |
|--------|-------------------------|-------------------------|
| GET    | /api/departments        | Get all departments     |
| GET    | /api/departments/{id}   | Get department by ID    |
| POST   | /api/departments        | Create new department   |
| PUT    | /api/departments/{id}   | Update department       |
| DELETE | /api/departments/{id}   | Delete department       |

### 👨‍💼 Employees
| Method | Endpoint                | Description             |
|--------|-------------------------|-------------------------|
| GET    | /api/employees          | Get all employees       |
| GET    | /api/employees/{id}     | Get employee by ID      |
| POST   | /api/employees          | Create new employee     |
| PUT    | /api/employees/{id}     | Update employee         |
| DELETE | /api/employees/{id}     | Delete employee         |

## 🧠 Project Structure

CompanyManagment/
│
├── Controllers/
├── Models/
│   └── Dtos/
├── Repositories/
│   └── Interfaces/
├── Services/
│   └── Interfaces/
├── Program.cs
├── appsettings.json
└── README.md

## 🙋‍♂️ Contact

Developed by [Saleh Sherif](https://github.com/SALEH-SHERIF)  
If you have any questions or want to collaborate, feel free to reach out!


