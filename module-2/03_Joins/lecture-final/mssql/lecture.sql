-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
SELECT * 
FROM payment
WHERE payment_id = 16666;

SELECT * 
FROM customer
WHERE customer_id = 204;

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
SELECT *
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
WHERE payment_id=16666;

--use table aliases
SELECT *
FROM payment p
INNER JOIN customer c ON p.customer_id = c.customer_id
WHERE payment_id=16666;

-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
SELECT payment.*, customer.first_name, customer.last_name
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
WHERE payment_id=16666;


-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.

SELECT payment.*, customer.first_name, customer.last_name, rental.rental_date
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
INNER JOIN rental ON rental.rental_id = payment.rental_id
WHERE payment_id=16666;

/* This doesn't product good data because the customer can have many rentals
so when i join customer to rental, i get a row for each and every oen of the customers
rentals
SELECT payment.*, customer.first_name, customer.last_name, rental.rental_date
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
INNER JOIN rental ON rental.customer_id = customer.customer_id
WHERE payment_id=16666;
*/

SELECT * from customer 
INNER JOIN rental ON customer.customer_id = rental.customer_id
WHERE customer.customer_id = 204;

-- What did they rent? Film id can be gotten through inventory.
SELECT payment.*, customer.first_name, customer.last_name, rental.rental_date, film.title
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
INNER JOIN rental ON rental.rental_id = payment.rental_id
INNER JOIN inventory ON  rental.inventory_id = inventory.inventory_id
INNER JOIN film ON film.film_id = inventory.film_id
WHERE payment_id=16666;


-- What if we wanted to know who acted in that film?
/* give me a new row for every actor in the file
SELECT payment.*, customer.first_name, customer.last_name, rental.rental_date, film.title, (actor.first_name + ' ' +actor.last_name)  as actor
FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id
INNER JOIN rental ON rental.rental_id = payment.rental_id
INNER JOIN inventory ON  rental.inventory_id = inventory.inventory_id
INNER JOIN film ON film.film_id = inventory.film_id
INNER JOIN film_actor on film_actor.film_id = film.film_id
INNER JOIN actor ON actor.actor_id = film_actor.actor_id
WHERE payment_id=16666;
*/
SELECT actor.first_name, actor.last_name
FROM actor
INNER JOIN film_actor on actor.actor_id = film_actor.actor_id
WHERE film_id = 948; 

-- What if we wanted a list of all the films and their categories ordered by film title
SELECT film.title AS Title, category.name AS Category
FROM film 
INNER JOIN film_category ON film.film_id = film_category.film_id
INNER JOIN category ON category.category_id = film_category.category_id
ORDER BY film.title

-- Show all the 'Comedy' films ordered by film title
SELECT film.title AS Title, category.name AS Category
FROM film 
INNER JOIN film_category ON film.film_id = film_category.film_id
INNER JOIN category ON category.category_id = film_category.category_id
WHERE category.name = 'Comedy'
ORDER BY film.title

-- Finally, let's count the number of films under each category
SELECT category.name, COUNT(*) AS num_films
FROM film 
INNER JOIN film_category ON film.film_id = film_category.film_id
INNER JOIN category ON category.category_id = film_category.category_id
GROUP BY category.name

-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.
SELECT country.name, city.name
FROM country
INNER JOIN city ON country.capital = city.id

SELECT COUNT(*) FROM country
-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. 
--If we want to show data FROM the left side table everytime, we can use a different join:
SELECT country.name, city.name
FROM country 
LEFT JOIN city ON country.capital = city.id

/* This is exactly the same. Left join keeps everything from the FROM, right join keeps everything from the table after the JOIN*/
SELECT country.name, city.name
FROM city 
RIGHT JOIN country ON country.capital = city.id

--does every country have an official language

--how many countries don't have a  language
SELECT COUNT(distinct country.name)--, countrylanguage.language
FROM country
LEFT JOIN countrylanguage ON country.code = countrylanguage.countrycode
WHERE language IS NULL
--ORDER BY language


-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates
SELECT  first_name
FROM actor
UNION
SELECT  first_name
FROM customer

--Find the duplicate first names between actors and customers
SELECT COUNT(*)
FROM actor
INNER JOIN customer ON actor.first_name = customer.first_name

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
SELECT  first_name, 'A' AS source
FROM actor
UNION
SELECT  first_name,  'C' AS source
FROM customer

--EXCEPT
--what customers don't have an actor with the same first name
SELECT first_name FROM customer
EXCEPT
SELECT first_name FROM actor