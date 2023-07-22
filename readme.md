# GraphQL API and Client Project

## Overview

This project is a simple demonstration of a GraphQL API using HotChocolate and a client using Refit in .NET. 
It's a simple in-memory CRUD (Create, Read, Update, ~Delete~) application for product management.

**Note:** This is a minimal example, designed for educational purposes. It does not necessarily follow all best 
practices for production-ready software. Please ensure that you follow all best practices when creating production-ready
applications.


## What the Project Does

The project is a product management system. It enables you to:
- Add new products
- Fetch all products
- Fetch a specific product by ID
- Fetch products with ratings above a certain value
- Update existing products

Each product has the following properties:
- Id
- SoldBy
- Name
- Description
- Price
- ProductDesigner
- AddedToStoreAt
- LastShipmentReceivedAt
- SoldSinceAvailable
- IsAvailable
- Rating


## How to Use

Firstly, ensure that you have .NET 6.0 or later installed on your machine.

To run the GraphQL API:

1. Navigate to the GraphQL API directory in your terminal.
2. Run the command `dotnet run`.
3. You can then access the API at `http://localhost:5000/graphql` or run the client program.

To run the client:

1. Navigate to the client directory in your terminal.
2. Run the command `dotnet run`.
3. The client will automatically connect to the API, and you can use the client to send requests to the API.

The client includes methods for adding a product, fetching all products, fetching a specific product by its ID, and 
updating a product. You can use these methods as examples to build your own methods for interacting with the API.


## Best Practices

Remember, while this project serves as a basic demonstration, there are several best practices you should follow in a 
production environment. Here are some key points to consider:

- Use a real database: This project uses an in-memory database for simplicity. In a production environment, you should 
use a persistent database.
- Error Handling: The project has minimal error handling. Be sure to implement comprehensive error handling in 
your production applications.
- Testing: This project has no tests. In a production application, you should implement unit tests, integration tests, 
and possibly UI/end-to-end tests.
- Security: This project doesn't include any form of authentication or authorization. In real-world applications, 
you should secure your API, such as using JWTs or OAuth.
- Performance: Consider performance implications and optimizations for your GraphQL API. For example, use data loaders 
to batch and cache requests where appropriate.


## Conclusion

This is a simple demonstration of a GraphQL API and client in .NET. It provides a basic understanding of how to build 
and interact with a GraphQL API using the HotChocolate library and a client using the Refit library. Make sure to 
follow best practices when building production-ready applications.
