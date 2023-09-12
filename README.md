# Online Book Store Implementation with RabbitMQ and Docker.

# Design Decision
In this documentation, my design decision is to implement two microservices, namely InventoryService and OrderService, using the microservices architecture. These services will communicate with each other via RabbitMQ. When an order request is created. The publisher in this case OrderService publishes a message to the RabbitMQ System which then create an order queue. This order message will be received, processed, and stored in an MSSQL database by the subscriber in this case InventoryService. Additionally, Docker will be used to containerize and run the application.

# Table of Contents
- Introduction
- Architecture Overview
- Pre-Requisites
- Microservice Implementation
- Setting Up RabbitMQ
- Containerization with Docker
- Testing/Run
- Conclusion

# 1. Introduction
Microservices architecture is an approach to building scalable and maintainable software systems by breaking them down into smaller, loosely coupled services. This documentation focuses on implementing two microservices: OrderService responsible for creating orders, and InventoryService responsible for managing inventory based on orders received from OrderService.

# 2. Architecture Overview
Microservices Architecture

OrderService: Accepts and processes order requests, then publishes order messages to the RabbitMQ queue.
RabbitMQ: Acts as a message broker for communication between services.
InventoryService: Subscribes to order messages, processes them, and updates the inventory in the MSSQL database.

# 3. Pre-Requisites
.NET Core SDK (for developing .NET Core applications)
Docker (for containerization)
RabbitMQ (for message queuing)
MSSQL Server (for database storage)
Visual Studio 2022 code editor

# 4. Microservice Implementation
Order Service and Inventory Services were created with ASP.NET Core Web API.



