-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
SELECT * 
FROM payment WHERE payment_id = 16666;

SELECT *
FROM customer
WHERE customer_id = 204;

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
SELECT *&
FROM payment p
INNER JOIN customer c ON c.customer_id = p.customer_id
WHERE payment_id = 16666;
-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
SELECT c.customer_id, (c.first_name + ' ' + c.last_name) AS full_name
FROM payment p
INNER JOIN customer c ON c.customer_id = p.customer_id
WHERE payment_id = 16666;
-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
SELECT *
FROM customer c
INNER JOIN rental r ON c.customer_id = r.customer_id
WHERE c.customer_id = 204;
-- What did they rent? Film id can be gotten through inventory.
SELECT *
FROM payment p
INNER JOIN customer c ON p.customer_id = c.customer_id
INNER JOIN rental r ON r.rental_id = p.rental_id
INNER JOIN inventory i ON r.inventory_id = i.inventory_id
INNER JOIN film f ON f.film_id = i.film_id
WHERE payment_id = 16666;
-- What if we wanted to know who acted in that film?
--SELECT p.*, c.first_name, c.last_name, r.rental_date, f.title, (a.first_name + ' ' + a.last_name) as actor
--FROM payment p
--INNER JOIN customer c ON p.customer_id = c.customer_id
--INNER JOIN rental r ON r.rental_id = p.rental_id
--INNER JOIN inventory i ON r.inventory_id = i.inventory_id
--INNER JOIN film f ON f.film_id = i.film_id
--INNER JOIN actor a ON a.actor_id;
-- What if we wanted a list of all the films and their categories ordered by film title
SELECT f.title, c.name AS category
FROM film f
INNER JOIN film_category fc ON f.film_id = fc.film_id
INNER JOIN category c ON c.category_id = fc.category_id
ORDER BY f.title;
-- Show all the 'Comedy' films ordered by film title
SELECT f.title, c.name AS category
FROM film f
INNER JOIN film_category fc ON f.film_id = fc.film_id
INNER JOIN category c ON c.category_id = fc.category_id
WHERE c.name = 'Comedy'
ORDER BY f.title;
-- Finally, let's count the number of films under each category
SELECT c.name AS category, COUNT(*) AS num_films
FROM film f
INNER JOIN film_category fc ON f.film_id = fc.film_id
INNER JOIN category c ON c.category_id = fc.category_id
GROUP BY c.name
ORDER BY num_films DESC;
-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.
SELECT country.name, city.name
FROM country
INNER JOIN city ON country.capital = city.id;
-- Only 232 rows
-- But we’re missing entries:
SELECT country.name, city.name -- Selects every country because it is on the left of the left join
FROM country
LEFT JOIN city ON country.capital = city.id;

-- How many countries don't have an official language

SELECT COUNT(*)
FROM country
LEFT JOIN countrylanguage ON country.code = countrylanguage.countrycode
WHERE countrylanguage.language IS NULL;

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

SELECT first_name
FROM actor
UNION
SELECT first_name
FROM customer;

-- Find the duplicates
SELECT COUNT(*)
FROM actor
INNER JOIN customer ON actor.first_name = customer.first_name;
-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
SELECT first_name, 'A'
FROM actor
UNION
SELECT first_name, 'C'
FROM customer;

-- Except
-- What customers don't have an actor with the same first name
SELECT first_name FROM customer
EXCEPT
SELECT first_name FROM actor;

SELECT first_name FROM customer
EXCEPT -- Removes what is in the second selection from the first
SELECT first_name FROM customer -- Outputs 0 data because we removed it
