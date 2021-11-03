# LetsShop

[![Build status](https://img.shields.io/github/workflow/status/alexalok/dotAPNS/Test)](https://github.com/NemesLaszlo/LetsShop/actions)

LetsShop is a eCommerce site, where you can buy almost everything for a winter adventure, and pay as easily as possible like the most popular shops on the web.

### Tech Stack - Backend

- .NET 5
- Specification Pattern
- Unit of Work
- AutoMapper
- Swagger
- Entity Framework Core
- Identity and Authentication
- Security with JSON Web Token
- MS SQL
- Redis
- Stripe

### Tech Stack - Frontend

- Angular
- Angular Forms
- Bootstrap
- Bootswatch
- Ngx-Bootstrap
- Ngx-Spinner
- Ngx-Toastr
- Xng-Breadcrumb
- Font-Awesome
- Uuid

### Specification Pattern

Specification design pattern allows us to check whether our objects meet certain requirements. Through this design pattern, we can reuse expression specifications and combine those specifications to easily question whether more complex requirements are satisfied or not.

In short, the main benefit of using “specifications” is a possibility to have all the rules for filtering domain model objects in one place, instead of a thousand of lambda expressions spread across an application.

### Unit of Work

The repository and unit of work patterns are intended to create an abstraction layer between the data access layer and the business logic layer of an application. Implementing these patterns can help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development (TDD).

A repository is nothing but a class defined for an entity, with all the operations possible on that specific entity. For example, a repository for an entity Customer, will have basic CRUD operations and any other possible operations related to it.

Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds. To say it in simple words, it means that for a specific user action (say registration on a website), all the transactions like insert/update/delete and so on are done in one single transaction, rather then doing multiple database transactions. This means, one unit of work here involves insert/update/delete operations, all in one single transaction.

### Redis (For basket handling and API Products caching)

Redis is an open source (BSD licensed), in-memory data structure store, used as a database, cache, and message broker. Redis provides data structures such as strings, hashes, lists, sets, sorted sets with range queries, bitmaps, hyperloglogs, geospatial indexes, and streams.

### Stripe

Stripe is an online payment processing and credit card processing platform for businesses.

The implementation of the Stripe is suitable for use in the US, Canada and also in the European Union.

### Endpoints of the Backend

| Entity   | Type   | URL                                                                              | Description                                                                 | Success     | Authorize |
| -------- | ------ | -------------------------------------------------------------------------------- | --------------------------------------------------------------------------- | ----------- | --------- |
| Account  | POST   | /api/account/login                                                               | Login with your account.                                                    | 200 OK      | No        |
|          | POST   | /api/account/register                                                            | Create a account.                                                           | 200 OK      | No        |
|          | GET    | /api/account/emailexists?email={emailToCheck}                                    | Check this email already exists.                                            | 200 OK      | No        |
|          | GET    | /api/account                                                                     | Get the current logged in user information.                                 | 200 OK      | Yes       |
|          | GET    | /api/account/address                                                             | Get the user address.                                                       | 200 OK      | Yes       |
|          | PUT    | /api/account/address                                                             | Update user address.                                                        | 200 OK      | Yes       |
| Product  | GET    | /api/products                                                                    | Get all products.                                                           | 200 OK      | No        |
|          | GET    | /api/products?pageSize={3}&pageIndex={1}                                         | Get all products and set to the {1} page, and the page size is {3}.         | 200 OK      | No        |
|          | GET    | /api/products?sort={priceAsc, priceDesc}                                         | Get the products sorted by the price.                                       | 200 OK      | No        |
|          | GET    | /api/products?brandId={brandId}                                                  | Get all products with this {brandId}.                                       | 200 OK      | No        |
|          | GET    | /api/products?typeId={3}                                                         | Get all products with this {typeId}.                                        | 200 OK      | No        |
|          | GET    | /api/products?typeId={3}&brandId={2}                                             | Get all products with {3} typeId and {2} brandId.                           | 200 OK      | No        |
|          | GET    | /api/products?typeId={3}&brandId={2}&sort={priceDesc}&pageIndex={1}&pageSize={2} | Get all products by Brand and Type Sorted by Price Desc.                    | 200 OK      | No        |
|          | GET    | /api/products?search={blue}&sort={priceDesc}                                     | Get all products by Name (Name contains the "blue" word) and sort by price. | 200 OK      | No        |
|          | GET    | /api/products/{productId}                                                        | Get product by {productId}.                                                 | 200 OK      | No        |
|          | GET    | /api/products/brands                                                             | Get product brands.                                                         | 200 OK      | No        |
|          | GET    | /api/products/types                                                              | Get product types.                                                          | 200 OK      | No        |
| Basket   | GET    | /api/basket?id={basket1}                                                         | Get a basket by id.                                                         | 200 OK      | No        |
|          | POST   | /api/basket                                                                      | Update or Create a basket.                                                  | 200 OK      | No        |
|          | DELETE | /api/basket?id={basket1}                                                         | Delete a basket by id.                                                      | 200 OK      | No        |
| Order    | POST   | /api/orders                                                                      | Checkout a basket / Create order.                                           | 200 OK      | Yes       |
|          | GET    | /api/orders                                                                      | Get orders for logged in user.                                              | 200 OK      | Yes       |
|          | GET    | /api/orders/{orderId}                                                            | Get a order for logged in user by orderId.                                  | 200 OK      | Yes       |
|          | GET    | /api/orders/deliverymethods                                                      | Get delivery methods.                                                       | 200 OK      | Yes       |
|          | DELETE | /api/orders/{orderId}                                                            | Delete order by id.                                                         | 200 OK      | Yes       |
| Payments | POST   | /api/payments/{basket1}                                                          | Create payment intent by {basketId}. (Stripe)                               | 200 OK      | Yes       |
|          | POST   | /api/payments/webhook                                                            | Payment succeeded or Payment failed webhook Stripe.                         | EmptyResult | No        |
