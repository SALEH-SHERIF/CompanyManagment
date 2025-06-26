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
