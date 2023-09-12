# Online Book Store Implementation with RabbitMQ and Docker.

# Design Decision
In this documentation, my design decision is to implement two microservices, namely InventoryService and OrderService, using the microservices architecture. These services will communicate with each other via RabbitMQ. When an order request is created. The publisher in this case OrderService publishes a message to the RabbitMQ System which then create an order queue. This order message will be received, processed, and stored in an MSSQL database by the subscriber in this case InventoryService. Additionally, Docker will be used to containerize and run the application.

# Table of Contents
Introduction
Architecture Overview
Pre-Requisites
Microservice Implementation
Setting Up RabbitMQ
Containerization with Docker
Testing
Conclusion

