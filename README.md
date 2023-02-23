# Project-SQLClientCRUD

This C# console application interacts with the Chinook database, which models the iTunes database of customers purchasing songs. The application uses the SQL Client library to create a repository that provides various functionalities related to customers in the database.

To use the application, follow these steps:

The application provides the following functionalities for customers in the database:

Read all the customers in the database, displaying their Id, first name, last name, country, postal code, phone number, and email.
Read a specific customer from the database (by Id), displaying all information listed in point 1.
Read a specific customer by name. The LIKE keyword can be used for partial matches.
Return a page of customers from the database. This takes in limit and offset as parameters and makes use of the SQL limit and offset keywords to get a subset of the customer data.
Add a new customer to the database, adding only the fields listed in point 1.
Update an existing customer.
Return the number of customers in each country, ordered descending (high to low).
Return the customers who are the highest spenders (total in invoice table is the largest), ordered descending.
For a given customer, return their most popular genre (in the case of a tie, display both). Most popular in this context means the genre that corresponds to the most tracks from invoices associated with that customer.
The application includes several model classes, which are placed in the Models folder. These classes are Customer, CustomerCountry, CustomerSpender, and CustomerGenre.
