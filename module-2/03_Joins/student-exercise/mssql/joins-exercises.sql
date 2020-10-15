-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
SELECT
  f.*,
  a.first_name + ' ' + a.last_name AS actor
FROM film f
INNER JOIN film_actor fa
  ON f.film_id = fa.film_id
INNER JOIN actor a
  ON fa.actor_id = a.actor_id
WHERE a.first_name + ' ' + a.last_name = 'Nick Stallone';
-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
SELECT
  f.*,
  a.first_name + ' ' + a.last_name AS actor
FROM film f
INNER JOIN film_actor fa
  ON f.film_id = fa.film_id
INNER JOIN actor a
  ON fa.actor_id = a.actor_id
WHERE a.first_name + ' ' + a.last_name = 'Rita Reynolds';
-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
SELECT
  f.*,
  a.first_name + ' ' + a.last_name AS actor
FROM film f
INNER JOIN film_actor fa
  ON f.film_id = fa.film_id
INNER JOIN actor a
  ON fa.actor_id = a.actor_id
WHERE a.first_name + ' ' + a.last_name = 'Judy Dean'
OR a.first_name + ' ' + a.last_name = 'River Dean';
-- 4. All of the the ‘Documentary’ films
-- (68 rows)
SELECT
  f.title,
  c.name AS category
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.category_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Documentary';
-- 5. All of the ‘Comedy’ films
-- (58 rows)
SELECT
  f.title,
  c.name AS category
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.category_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Comedy';
-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
SELECT
  f.title,
  c.name AS category -- Got zero rows, am confused as query seems okay, 'G' does exist as a film.rating :/
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.category_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Children'
AND f.rating = 'G';
-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
SELECT
  f.title,
  c.name AS category -- Got zero rows, am confused as query seems okay, 'G' does exist as a film.rating :/
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.category_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Family'
AND f.rating = 'G'
AND f.length < 120;
-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
SELECT
  f.title
FROM film f
INNER JOIN film_actor fa
  ON f.film_id = fa.film_id
INNER JOIN actor a
  ON fa.actor_id = a.actor_id
WHERE a.first_name + ' ' + a.last_name = 'Matthew Leigh'
AND f.rating = 'G';
-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
SELECT
  f.title,
  f.release_year,
  c.name
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.film_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Sci-Fi'
AND f.release_year = 2006;
-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
SELECT
  f.title,
  f.release_year,
  c.name
FROM film f
INNER JOIN film_category fc
  ON f.film_id = fc.film_id
INNER JOIN category c
  ON fc.category_id = c.category_id
INNER JOIN film_actor fa
  ON f.film_id = fa.film_id
INNER JOIN actor a
  ON fa.actor_id = a.actor_id
WHERE c.name = 'Action'
AND a.first_name + ' ' + a.last_name = 'Nick Stallone';
-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
SELECT
  s.store_id,
  a.address,
  ci.city,
  a.district,
  co.country
FROM store s
INNER JOIN address a
  ON s.address_id = a.address_id
INNER JOIN city ci
  ON a.city_id = ci.city_id
INNER JOIN country co
  ON ci.country_id = co.country_id;
-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
SELECT
  store.store_id,
  a.address,
  a.district,
  staff.first_name + ' ' + staff.last_name AS manager_name
FROM store
INNER JOIN address a
  ON store.address_id = a.address_id
INNER JOIN staff
  ON store.manager_staff_id = staff.staff_id
-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
SELECT TOP 10
  c.first_name,
  c.last_name,
  COUNT(*) AS rental_count
FROM customer c
INNER JOIN payment p
  ON c.customer_id = p.customer_id
INNER JOIN rental r
  ON p.rental_id = r.rental_id
GROUP BY c.first_name,
         c.last_name
ORDER BY rental_count DESC;
-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
SELECT
  c.first_name,
  c.last_name,
  SUM(p.amount) AS payment_sum
FROM customer c
INNER JOIN payment p
  ON c.customer_id = p.customer_id
INNER JOIN rental r
  ON p.rental_id = r.rental_id
GROUP BY c.first_name,
         c.last_name
ORDER BY payment_sum DESC;

-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that an employee may work at multiple stores.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals) -- Query seems fine but numbers are a bit off :P
SELECT
  s.store_id,
  a.address,
  COUNT(DISTINCT r.rental_id) AS total_rentals,
  AVG(p.amount) AS average_sale
FROM store s
INNER JOIN address a
  ON s.address_id = a.address_id
INNER JOIN customer c
  ON c.store_id = s.store_id
INNER JOIN inventory i
  ON s.store_id = i.store_id
INNER JOIN rental r
  ON c.customer_id = r.customer_id
INNER JOIN payment p
  ON r.customer_id = p.customer_id
GROUP BY s.store_id,
         a.address;



-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
SELECT TOP 10
  f.title,
  COUNT(*) AS rentals
FROM film f
INNER JOIN inventory i
  ON f.film_id = i.film_id
INNER JOIN rental r
  ON i.inventory_id = r.inventory_id
GROUP BY f.title
ORDER BY rentals DESC;
-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
SELECT TOP 5
  c.name,
  COUNT(*) AS rentals
FROM film f
INNER JOIN inventory i
  ON f.film_id = i.film_id
INNER JOIN rental r
  ON i.inventory_id = r.inventory_id
INNER JOIN film_category fc
  ON f.film_id = fc.film_id
INNER JOIN category c
  ON fc.category_id = c.category_id
GROUP BY c.name
ORDER BY rentals DESC;
-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
SELECT TOP 5
  f.title,
  COUNT(*) AS rentals
FROM film f
INNER JOIN inventory i
  ON f.film_id = i.film_id
INNER JOIN rental r
  ON i.inventory_id = r.inventory_id
INNER JOIN film_category fc
  ON f.film_id = fc.film_id
INNER JOIN category c
  ON fc.category_id = c.category_id
WHERE c.name = 'Action'
GROUP BY f.title
ORDER BY rentals DESC;
-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
-- Okay so I have GINA DEGENERES with 753 and SEAN with 599 but I have SUSAN DAVIS with 825, 
-- I have it set to 11 to show SEAN... not to mention i used this as a base for the next query and it worked
SELECT TOP 11
  a.first_name + ' ' + a.last_name AS actor_name,
  COUNT(*) AS film_rentals
FROM actor a
INNER JOIN film_actor fa
  ON a.actor_id = fa.actor_id
INNER JOIN film f
  ON fa.film_id = f.film_id
INNER JOIN inventory i
  ON f.film_id = i.film_id
INNER JOIN rental r
  ON i.inventory_id = r.inventory_id
GROUP BY a.first_name,
         a.last_name
ORDER BY film_rentals DESC;
-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
SELECT TOP 5
  a.first_name + ' ' + a.last_name AS actor_name,
  COUNT(*) AS film_rentals
FROM actor a
INNER JOIN film_actor fa
  ON a.actor_id = fa.actor_id
INNER JOIN film f
  ON fa.film_id = f.film_id
INNER JOIN inventory i
  ON f.film_id = i.film_id
INNER JOIN rental r
  ON i.inventory_id = r.inventory_id
INNER JOIN film_category fc
  ON fc.film_id = f.film_id
INNER JOIN category c
  ON c.category_id = fc.category_id
WHERE c.name = 'Comedy'
GROUP BY a.first_name,
         a.last_name
ORDER BY film_rentals DESC;