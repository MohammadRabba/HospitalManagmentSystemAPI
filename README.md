# 🏥 Hospital Management System (HMS) — Phase 2

## 📌 Overview
Phase 2 transitions the Hospital Management System (HMS) from a console-based application into a **.NET 8 Web API**.

This phase introduces:
* RESTful API architecture
* Authentication and authorization
* JWT-based security
* Role-based access control
* Dependency Injection (DI)
* Swagger/OpenAPI documentation
* CRUD operations through API controllers

The existing core functionality from Phase 1 will be maintained while adapting the application to a modern web-based architecture.

---

## 🎯 Objectives
The main objectives of Phase 2 are:
* Migrate the console-based application to a RESTful Web API.
* Implement authentication and authorization.
* Implement JWT authentication for secure API access.
* Implement role-based authorization.
* Apply Dependency Injection throughout the application.
* Create controllers for each major HMS entity.
* Document and test the API using Swagger UI.
* Maintain the core functionality implemented in Phase 1.

---

## 📋 Required Tasks

### 1. Convert Console Application to Web API
Migrate the existing console-based functionality into a .NET 8 Web API.

**Requirements:**
* Replace console-based operations with HTTP API endpoints.
* Create separate controllers for each major entity.
* Implement appropriate HTTP methods (`GET`, `POST`, `PUT`, `DELETE`).
* Return appropriate HTTP status codes.
* Follow RESTful API conventions.

**Required Controllers:**
* `AuthController`
* `PatientsController`
* `DoctorsController`
* `AppointmentsController`
* `PrescriptionsController`
* `MedicationsController`
* `BillsController`

---

### 2. Swagger / OpenAPI Documentation
Configure Swagger using Swashbuckle to document the API.

Swagger should allow developers to:
* View all available endpoints.
* View request and response models.
* Test API endpoints directly.
* Authenticate using JWT.
* Understand required parameters and request bodies.

The Swagger UI should provide access to all implemented API endpoints.

---

### 3. Dependency Injection
Implement Dependency Injection (DI) throughout the application. All required services, repositories, managers, and other dependencies should be registered in `Program.cs`.

**Example Architecture:**
```text
Controller ──> Service ──> Repository ──> Database
