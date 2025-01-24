# Key features

- CQRS
- Mediator Pattern
- DI In Aspnet Core
- Minimal Api And Routing
- ORM Pattern

## :rocket: Architecture

**Veticla slice Architecture**

> vertical slice architecture aims to organize code around **features** or **use cases** instead of **technical concerns**. <br />
> feature are implemented **across all layers** of software form the user interface to the database. <br />
> And is suitable for complex and feature-rich applications <br />
> divide application into **distinct feature** or **functionalities**

### Characteristict of vertical slice architecture

> [!TIP]
> Benefits:
> - Each slice is self-contained and independent.
> - The application is divided into feature-base slices.
> - There are **reduced dependencies** between different parts of application .
> - The architecture supports **scalability** and **maintainability**
> - Every microservices handels a specific piece of functionality and comunicate to other services through well-defined interfaces.

> [!WARNING]
> Challendges and considerations: <br />
> Design of each slice requires careful and consideration to keep the feature independent and maintainable <br />
> Duplication of code across slices, paricularly for common functionalities.
