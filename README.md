# 📊 FinOps Core - Financial Management and Reconciliation System

<p align="center">

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet)
![C%23](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular)
![Tailwind](https://img.shields.io/badge/Tailwind_v4-38B2AC?style=for-the-badge&logo=tailwind-css)
![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-6DB33F?style=for-the-badge)
![Dapper](https://img.shields.io/badge/Dapper-00599C?style=for-the-badge)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker)
![Kubernetes](https://img.shields.io/badge/Kubernetes-326CE5?style=for-the-badge&logo=kubernetes)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?style=for-the-badge&logo=githubactions)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

</p>

<p align="center">

![Architecture](https://img.shields.io/badge/Clean%20Architecture-✓-0A66C2?style=flat-square)
![DDD](https://img.shields.io/badge/DDD-Domain--Driven%20Design-orange?style=flat-square)
![CQRS](https://img.shields.io/badge/CQRS-Command%20%2F%20Query-blue?style=flat-square)
![MediatR](https://img.shields.io/badge/MediatR-Pattern-purple?style=flat-square)
![Result Pattern](https://img.shields.io/badge/Result-Pattern-success?style=flat-square)
![Unit of Work](https://img.shields.io/badge/Unit%20of%20Work-Pattern-lightgrey?style=flat-square)

</p>

> Corporate application developed to demonstrate advanced architectural patterns, financial data integrity, and high-performance read operations using CQRS.

---

# 🏛️ Architecture

The solution follows **Clean Architecture** and **Domain-Driven Design (DDD)**, keeping business rules completely isolated from infrastructure and frameworks.

To support scalability and high throughput, the application adopts **CQRS (Command Query Responsibility Segregation)**.

## ✍️ Command Side (Write)

- Entity Framework Core
- Unit of Work
- Rich Domain Model (Validations inside the Entity)
- Optimistic Concurrency (RowVersion tracking)
- ACID Transactions
- MediatR

Business operations pass through the domain layer, ensuring consistency and protecting financial transactions without throwing costly exceptions, using the Result Pattern.

---

## 📖 Query Side (Read)

- Dapper
- Native SQL (Oracle Syntax)
- Lightweight DTOs
- Optimized Queries

Read operations bypass ORM tracking, opening direct connections to deliver significantly faster dashboard and reporting performance.

---

## 🧩 Design Patterns

| Pattern | Purpose |
|----------|----------|
| ✅ Clean Architecture | Separation of concerns |
| ✅ Domain-Driven Design | Rich business domain |
| ✅ CQRS | Read/Write segregation |
| ✅ Unit of Work | Transaction management |
| ✅ Repository Pattern | Persistence abstraction |
| ✅ MediatR | Decoupled application layer |
| ✅ Result Pattern | Business validation without exceptions |
| ✅ Dependency Injection | Loose coupling via Extension Methods |

---

# 🚀 Tech Stack

## Backend

| Technology | Description |
|------------|-------------|
| .NET 8 | Backend Framework |
| C# 12 | Programming Language |
| Entity Framework Core | Relational ORM for Commands |
| Oracle.EntityFrameworkCore | Official Oracle Provider |
| Dapper | Micro ORM for High-performance Queries |
| MediatR | Mediator Pattern for CQRS |
| xUnit / Moq | Unit Tests & Mocking (Planned) |

---

## Frontend

| Technology | Description |
|------------|-------------|
| Angular 19+ | Single Page Application (SPA) |
| TypeScript | Strongly Typed Language |
| Tailwind CSS v4 | Utility-first CSS Framework (Native CSS) |
| RxJS | Reactive Programming |

---

## Infrastructure

| Technology | Description |
|------------|-------------|
| Oracle Database | Relational Database (Dockerized XE) |
| Docker | Containers |
| Docker Compose | Local Environment Orchestration |
| Kubernetes | Deployment (Planned) |
| GitHub Actions | CI/CD (Planned) |

---

# 📂 Project Structure

```text
src
├── FinOpsCore.Domain
│   ├── Entities          # Rich Models (e.g., Transaction)
│   ├── Common            # Shared constructs (e.g., Result Pattern)
│   ├── Enums             # Domain Enumerators
│   └── Interfaces        # IUnitOfWork, ITransactionRepository
│
├── FinOpsCore.Application
│   ├── Transactions
│   │   ├── Commands      # Create, Liquidar (Write ops)
│   │   └── Queries       # GetCashFlow (Read ops / DTOs)
│   └── Interfaces        # ISqlConnectionFactory
│
├── FinOpsCore.Infrastructure
│   ├── Data
│   │   ├── Context       # AppDbContext (EF Core)
│   │   ├── Mappings      # Fluent API (TransactionConfiguration)
│   │   └── Connections   # OracleConnectionFactory (Dapper)
│   └── Repositories      # TransactionRepository implementation
│
└── FinOpsCore.API
    ├── Controllers       # REST Endpoints via MediatR
    ├── Extensions        # DependencyInjection (IoC Setup)
    └── appsettings.json  # DB Connection Strings

frontend
└── finops-app            # Angular + Tailwind Application

k8s
└── deployment            # Kubernetes Manifests

```

---

# ⚡ Running Locally

## Requirements

* Docker Desktop
* .NET SDK 8.0
* Node.js (v20+)
* Angular CLI

---

### Clone Repository

```bash
git clone [https://github.com/gabrielcamposdeveloper/finops-core.git](https://github.com/gabrielcamposdeveloper/finops-core.git)
cd finops-core

```

---

### Start Oracle Database

```bash
docker compose up -d db

```

*(Wait 1-2 minutes for the Oracle XE container to fully initialize).*

---

### Apply Migrations and Run API

```bash
cd src/FinOpsCore.API
dotnet ef database update
dotnet run

```

Swagger will be available at:

```
https://localhost:5001/swagger

```

---

### Run Angular Frontend

Open a new terminal window:

```bash
cd frontend/finops-app
npm install
ng serve

```

The application will be available at:

```
http://localhost:4200

```

---

# 👨‍💻 Author

**Gabriel Campos**

---

# 📄 License

Licensed under the MIT License.
