# 🏢 Company Management System (Web API & MVC Consumer)

A comprehensive enterprise-level management solution designed using **ASP.NET Core Web API** and consumed via an **ASP.NET Core MVC Application**. This project demonstrates full CRUD operations, secure authentication using JWT, and modern architectural patterns like DTOs.

## 🔗 Related Repositories

| Component | Description | Link |
|---|---|---|
| 🔌 **Web API** | ASP.NET Core Web API backend (this repo) | [Company-Management-Using-API](https://github.com/gehadahmed23/Company-Management-Using-API) |
| 🖥️ **MVC Consumer** | ASP.NET Core MVC client consuming the API | [Company-Management-Client](https://github.com/gehadahmed23/Company-Management-Client) |

---

## Applied Architecture & Key Topics

### 1. Robust Web API (Full CRUD Operations)
The core backend delivers structured endpoints enforcing RESTful principles:
* **HTTP Methods:** Full integration of `GET`, `POST`, `PUT`, and `DELETE`.
* **Advanced Fetching:** Implemented targeted query logic including `GetByID` and custom `GetByName` endpoints.
* **Custom Binding:** Applied explicit data binding attributes (`[FromRoute]`, `[FromQuery]`, `[FromBody]`) to control parameter parsing safely.
* **Routing Design:** Leveraged attribute routing with a mix of dynamic parameters and **Literal Routes** for clean, readable URLs.
* **CORS Configuration:** Configured **Cross-Origin Resource Sharing (CORS)** policies to securely allow seamless communication with external consumers.
* **Data Transfer Objects (DTOs):** Utilized DTOs to decouple database entities from API contracts, ensuring optimal security and preventing over-posting vulnerabilities.

### 2. Advanced Security & Authentication (JWT Token)
Secured backend resources against unauthorized access:
* **Token Generation:** Implemented a robust Token Service that signs and generates **JWT (JSON Web Tokens)** upon successful user login.
* **Strict Token Validation:** Wired up JWT Bearer Authentication inside the `Program.cs` class to validate issuer, audience, signing keys, and token lifetime on every restricted request.

### 3. MVC Consumer Application
A fully detached front-end consumer built using ASP.NET Core MVC (see the [Company-Management-Client](https://github.com/gehadahmed23/Company-Management-Client) repo):
* **HttpClient Integration:** Consumes the secure Web API endpoints asynchronously.
* **Client-Side CRUD:** Implemented fully responsive Views and Controllers to handle Management actions (Create, Read, Update, Delete) smoothly based on API responses.

---

## Tech Stack & Tools Used
* **Backend Framework:** .NET Core (ASP.NET Core Web API)
* **Frontend Consumer:** ASP.NET Core MVC
* **Database & ORM:** Entity Framework Core & MS SQL Server
* **Security:** JWT Bearer Authentication (Microsoft.AspNetCore.Authentication.JwtBearer)
* **API Documentation:** Swagger / OpenAPI

---

## Project Structure Overview

```text
Company-Management-Using-API/
│
├── API/                       # ASP.NET Core Web API Project
│   ├── Context/               # Database Context & Migrations
│   ├── Controllers/           # Secure API Controllers (JWT + CORS)
│   ├── Models/                # Database Entities (Employee, Company, etc.)
│   ├── DTOs/                  # Data Transfer Objects for Request/Response
│   └── Program.cs             # Services Configuration (JWT Validation, CORS)
│
└── MVC_Consumer/              # ASP.NET Core MVC Web Application
    ├── Controllers/           # Controllers consuming API via HttpClient
    ├── Models/                # ViewModels mapped to API DTOs
    └── Views/                 # Razor Views for Management Interface
```

> 💡 **Note:** The MVC Consumer is also maintained as a standalone repository here: [Company-Management-Client](https://github.com/gehadahmed23/Company-Management-Client).
