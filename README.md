# NPVCalculation 🧮

**NPVCalculation** is a Microservices .NET 8 Web API project integrated with MongoDB and RabbitMQ to calculate Net Present Value (NPV) over a range of discount rates. It follows clean architecture principles and demonstrates modern patterns like domain events, value objects, and event-driven communication.

---

## 🛠️ Stack

- ASP.NET Core 8 Web API
- MongoDB (NoSQL storage for NPV results)
- RabbitMQ (via MassTransit)
- CQRS pattern with MediatR
- Entity Framework Core (SQL optional, used for future extensibility)
- Angular frontend (in `/frontend`)
- Docker + Docker Compose for infrastructure

---

## 📐 Architecture

- **Domain Layer**: Value objects (`DiscountRates`, `NpvCalculationElement`), aggregate roots, and base classes.
- **Application Layer**: CQRS handlers, commands, and services.
- **Infrastructure Layer**: MongoDB + EF Core repositories.
- **API Layer**: Minimal controller triggering domain logic and publishing domain events.

---

## 🔁 NPV Calculation Logic

Given a list of cash flows, an increment, and a discount rate range, the NPV is calculated for each rate and saved to MongoDB. A domain event is raised and published to RabbitMQ.

Example logic:
NPV = ∑ (CashFlow_t / (1 + rate)^t)

---

## 🛠️ Prerequisites

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

---

## 📦 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/ace333/CompanyAPI.git
cd CompanyAPI
```

### 2. Build and Run with Docker Compose

```bash
docker-compose up --build
```

This will:

- Build backend and frontend apps
- Start SQL Server
- Execute the database migration script
- Serve the Angular frontend via Nginx

### 3. Access the application

🧑‍💻 Frontend: http://localhost:4200
