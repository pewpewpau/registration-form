# registration-form
api registration form


# README.md

````md id="6t9p42"
# Registration API - ASP.NET Core Web API

A RESTful Registration API built using ASP.NET Core Web API, Entity Framework Core, and PostgreSQL.

The API manages:
- Personal Information
- Residential Address
- Postal Address

It supports full CRUD operations:
- Create
- Read
- Update
- Delete

---

# Tech Stack

## Backend
- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL

## Tools & Packages
- Npgsql.EntityFrameworkCore.PostgreSQL
- Swagger (Swashbuckle)
- Entity Framework Core Tools

---

# Project Structure

```bash
RegistrationAPI/
├── Controllers/
│   └── RegistrationController.cs
│
├── Models/
│   ├── Registration.cs
│   └── ApiResponse.cs
│
├── DTOs/
│   └── RegistrationDto.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── appsettings.json
├── Program.cs
└── RegistrationAPI.csproj
````

---

# Features

* Create new registrations
* Retrieve all registrations
* Retrieve registration by ID
* Update registration
* Delete registration
* PostgreSQL database integration
* Entity Framework Core ORM
* Swagger API documentation
* Model validation
* Unique email validation

---

# Prerequisites

Install the following before running the project:

* .NET SDK 8+
* PostgreSQL
* Git

Recommended:

* Visual Studio
* Visual Studio Code
* Postman

---

# 1. Clone the Repository

```bash id="t4s2qd"
https://github.com/
git clone https://github.com/pewpewpau/registration-form.git
cd RegistrationAPI
```

---

# 2. Create the ASP.NET Web API Project

```bash id="q7m1vz"
dotnet new webapi -n RegistrationAPI
cd RegistrationAPI
```

---

# 3. Install Required Packages

```bash id="u9f4kj"
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

---

# 4. PostgreSQL Database Setup

Open PostgreSQL terminal:

```bash id="p3x8wr"
psql -U postgres
```

Create database:

```sql id="n5j2ty"
CREATE DATABASE registration_csharp_db;
```

Connect to database:

```sql id="v8m6kp"
\c registration_csharp_db
```

Create the table:

```sql id="b1r4hs"
CREATE TABLE registrations (
  id               SERIAL PRIMARY KEY,
  created_at       TIMESTAMPTZ DEFAULT NOW(),

  -- Personal Info
  first_name       VARCHAR(100) NOT NULL,
  last_name        VARCHAR(100) NOT NULL,
  email            VARCHAR(255) UNIQUE NOT NULL,
  phone            VARCHAR(20),
  date_of_birth    DATE,

  -- Residential Address
  res_city         VARCHAR(255),
  res_street       VARCHAR(100),
  res_erf          VARCHAR(100),
  res_country      VARCHAR(100),

  -- Postal Address
  post_address     VARCHAR(255),
  post_city        VARCHAR(100),
  post_country     VARCHAR(100)
);
```

---

# 5. Configure Database Connection

Open:

```text id="r2d9ql"
appsettings.json
```

Update the PostgreSQL connection string:

```json id="f6v8me"
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=registration_csharp_db;Username=postgres;Password=your_password"
  }
}
```

Replace:

* `your_password` with your PostgreSQL password.

---

# 6. Run the API

Start the application:

```bash id="x4t7zn"
dotnet run
```

If successful, you should see output similar to:

```bash id="m8k2qp"
Now listening on: https://localhost:5076
```

---

# 7. Open Swagger UI

Open your browser:

```text id="s5n3uw"
https://localhost:5076/swagger
```

Swagger provides interactive API testing and documentation

---

# API Endpoints

## Create Registration

### POST `/api/registration`

```bash id="c1j7yr"
curl -X POST https://localhost:5076/api/registration \
  -H "Content-Type: application/json" \
  -k -d '{
    "firstName": "Paul",
    "lastName": "Kashi",
    "email": "pk@gmail.com",
    "phone": "+264811234567",
    "dateOfBirth": "2002-06-13",

    "resCity": "Windhoek",
    "resStreet": "Kabeljou",
    "resErf": "789",
    "resCountry": "Namibia",

    "postAddress": "P.O.Box_7534",
    "postCity": "Windhoek",
    "postCountry": "Namibia"
  }'
```

---

## Get All Registrations

### GET `/api/registration`

```bash id="y9w5fx"
curl -k https://localhost:5076/api/registration
```

---

## Get Registration By ID

### GET `/api/registration/{id}`

Example:

```bash id="j4r8pd"
curl -k https://localhost:5076/api/registration/1
```

---

## Update Registration

### PUT `/api/registration/{id}`

Example:

```bash id="u3n6kb"
curl -X PUT -k https://localhost:5001/api/registration/1 \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Paul",
    "lastName": "Kashi",
    "email": "pk@gmail.com"
  }'
```

---

## Delete Registration

### DELETE `/api/registration/{id}`

Example:

```bash id="g7t2qm"
curl -X DELETE -k https://localhost:5076/api/registration/1
```

---

# API Response Format

Example successful response:

```json id="l2p5we"
{
  "success": true,
  "message": "Registration successful.",
  "data": {
    "id": 1,
    "firstName": "Paul",
    "lastName": "Kashi",
    "email": "pk@gmail.com"
  }
}
```

Example error response:

```json id="k8d1vc"
{
  "success": false,
  "message": "Email is already registered."
}
```

---

# Validation Rules

The API validates:

* Required fields
* Email format
* Maximum field lengths
* Duplicate emails

---

# Common Issues

## PostgreSQL Connection Errors

Check:

* PostgreSQL service is running
* Database exists
* Username/password are correct
* Port is `5432`

---

## SSL Certificate Warning

When using HTTPS locally, browsers may show a certificate warning.

Click:

* Advanced
* Continue to localhost

---

## Port Already In Use

Change the port in:

```text id="v6p4ry"
Properties/launchSettings.json
```

or stop the conflicting application.


---

# Author

Paulus Kashimbode.

---

# License

This project is for internship assessment purposes. The End

```
```
