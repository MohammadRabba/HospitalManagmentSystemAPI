Hospital Management System (HMS) - Phase 2 
Overview 
In Phase 2, we are transitioning the Hospital Management System (HMS) from a console application to a .NET 8 Web API. This phase introduces authentication, authorization, and dependency injection while maintaining the same core functionalities. 
Objectives: 
● Migrate from a console-based interface to a RESTful API. 
● Implement authentication and authorization. 
● Use dependency injection for better maintainability. 
Required Tasks 
1. Convert Console Application to Web API 
o Migrate all console-based operations to an API endpoints. 
o Implement controllers for each entity (Patients, Doctors, Appointments, Prescriptions, Medications, Billing). 
2. Use Swagger for API Documentation 
o Configure Swagger (Swashbuckle) to document API endpoints. 
o Ensure all endpoints are visible and testable through Swagger UI. 
3. Implement Dependency Injection (DI) 
o Apply DI to all classes instances (to all compositions). 
o Register the classes in Program.cs to follow best practices. 
4. Implement Authentication & Authorization 
o Use JWT Authentication for secure API access. 
o Implement role-based authorization (Admin, Doctor, Patient).
o Secure endpoints based on user roles. 
Core Features & Endpoints 
Each module from Phase 1 is implemented as a controller with CRUD operations. 1. Authentication & Authorization 
● Register Users: POST /api/auth/register 
● Login: POST /api/auth/login 
● JWT-based Authorization with role-based access control (Admin, Doctor, Patient) 2. Patient Management 
● Register a Patient: POST /api/patients 
● View All Patients: GET /api/patients 
● View Single Patient: GET /api/patients/{id} 
● Update Patient Info: PUT /api/patients/{id} 
● Delete Patient Record: DELETE /api/patients/{id} 
3. Doctor Management 
● Add a Doctor: POST /api/doctors 
● View All Doctors: GET /api/doctors 
● View Single Doctor: GET /api/doctors/{id} 
● Update Doctor Info: PUT /api/doctors/{id} 
● Delete Doctor Record: DELETE /api/doctors/{id} 
4. Appointment Management 
● Schedule an Appointment: POST /api/appointments 
● View Appointments by Patient/Doctor: GET /api/appointments?patientId=123 or GET /api/appointments?doctorId=456 
● Cancel an Appointment: DELETE /api/appointments/{id} 
5. Prescription Management
● Issue a Prescription: POST /api/prescriptions 
● View Prescriptions: GET /api/prescriptions 
● View Prescription by ID: GET /api/prescriptions/{id} 
● Update Prescription Details: PUT /api/prescriptions/{id} 
6. Medication Management 
● Add New Medication: POST /api/medications 
● View Medications: GET /api/medications 
● Update Medication Details: PUT /api/medications/{id} 
● Delete Medication Record: DELETE /api/medications/{id} 
7. Billing Management 
● View All Bills: GET /api/bills 
● View Bills by Patient: GET /api/bills?patientId=789 
● Update Billing Status: PUT /api/bills/{id} 
Security & Authentication 
● User Roles: Admin, Doctor, Patient 
● JWT Authentication 
● Authorization Middleware ensures that only authorized users can access specific endpoints. 
User Roles & Permissions 
Admin 
● Manage all patients, doctors, appointments, prescriptions, medications, and bills. ● Add, update, and delete doctors and patients. 
● Assign roles and permissions to users. 
Doctor 
● View and manage the patients (Add, update, and delete).
● Schedule, update, and cancel appointments. ● Issue prescriptions. 
● View billing details. 
Patient 
● View their own profile and update personal details. ● Schedule and cancel appointments. 
● View prescriptions and bills. 
Deliverables 
you should submit the following: 
1. Source Code: The complete .NET web application
