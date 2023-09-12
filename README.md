# Online Book Store with RabbitMQ and Docker.

# Design Decision
My decision is to implement a microservice architectured web app is suitable for real-world applications. This architecture enables the development of scalable and maintainable software systems that can handle complex tasks effectively.

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
- .NET Core SDK (for developing .NET Core applications)
- Docker (for containerization)
- RabbitMQ (for message queuing)
- MSSQL Server (for database storage)
- Visual Studio 2022 code editor

# 4. Microservice Implementation
Order Service and Inventory Services were created with ASP.NET Core Web API.

# 5. Setting Up RabbitMQ
Install and configure RabbitMQ as message broker.
Created a queue named "orders" for communication between services.
Ensured that both OrderService and InventoryService are configured to connect to RabbitMQ.

# 6. Containerization with Docker
Created Dockerfiles for both services to containerize them.
Use Docker Compose to manage the containers and define the required environment variables, such as connection strings for RabbitMQ and MSSQL.

# 7. Testing / Run
Build and run the Docker containers using ```
docker-compose up.
```
Access the OrderService API at http://localhost:5000/api/orders.
Create an order, and it will be published to RabbitMQ.
InventoryService will receive the order message, process it, and store it in the MSSQL database.
Access the InventoryService API at http://localhost:5001/api/inventory to verify the stored orders.

# 8. Conclusion
The Online Book Store was completed using the microservices architecture with RabbitMQ for communication. Docker containerization allows for easy deployment and scalability, making it suitable for real-world applications.
