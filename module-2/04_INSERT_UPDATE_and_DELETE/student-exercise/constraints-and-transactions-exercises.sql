-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
--SELECT * FROM actor ORDER BY actor_id DESC;
INSERT INTO actor (first_name, last_name)
VALUES ('Hampton', 'Avenue'), ('Lisa', 'Byway');
--SELECT * FROM actor ORDER BY actor_id DESC;

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
--SELECT * FROM film ORDER BY film.film_id DESC;
INSERT INTO film (title, description, release_year, language_id, original_language_id, rental_duration, rental_rate, length, replacement_cost, rating)
VALUES ('Euclidean PI',  'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 
(SELECT l.language_id FROM language l WHERE l.name = 'English'), NULL, 6, 4.99, 3 * 60 + 18, 19.99, 'PG');
--SELECT * FROM film ORDER BY film.film_id DESC;
-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
 --SELECT * FROM film_actor ORDER BY actor_id DESC;
INSERT INTO film_actor
VALUES (
  (SELECT a.actor_id FROM actor a WHERE a.first_name + a.last_name = 'HamptonAvenue'),
  (SELECT f.film_id FROM film f WHERE f.title = 'Euclidean PI')
), (
  (SELECT a.actor_id FROM actor a WHERE a.first_name + a.last_name = 'LisaByway'),
  (SELECT f.film_id FROM film f WHERE f.title = 'Euclidean PI')
);
--SELECT * FROM film_actor INNER JOIN film ON film.film_id = film_actor.film_id ORDER BY actor_id DESC;
-- 4. Add Mathmagical to the category table.
--SELECT * FROM category ORDER BY category_id DESC;
INSERT INTO category (name) VALUES ('Mathmagical')
--SELECT * FROM category ORDER BY category_id DESC;
-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
--SELECT * FROM film_category WHERE film_id IN (SELECT film_id FROM film WHERE title IN ('Euclidean PI', 'EGG IGBY', 'KARATE MOON', 'RANDOM GO', 'YOUNG LANGUAGE'));
UPDATE film_category
SET category_id = (SELECT category_id FROM category WHERE name = 'Mathmagical')
WHERE film_id IN (SELECT film_id FROM film WHERE title IN ('Euclidean PI', 'EGG IGBY', 'KARATE MOON', 'RANDOM GO', 'YOUNG LANGUAGE'));
--SELECT * FROM film_category WHERE film_id IN (SELECT film_id FROM film WHERE title IN ('Euclidean PI', 'EGG IGBY', 'KARATE MOON', 'RANDOM GO', 'YOUNG LANGUAGE'));
-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
--SELECT * FROM film WHERE film_id IN (SELECT film_id FROM film_category fc INNER JOIN category c ON fc.category_id = c.category_id WHERE c.name = 'Mathmagical');
UPDATE film
SET rating = 'G'
WHERE film_id IN (SELECT film_id FROM film_category fc INNER JOIN category c ON fc.category_id = c.category_id WHERE c.name = 'Mathmagical');
--SELECT * FROM film WHERE film_id IN (SELECT film_id FROM film_category fc INNER JOIN category c ON fc.category_id = c.category_id WHERE c.name = 'Mathmagical');
-- 7. Add a copy of "Euclidean PI" to all the stores.
--SELECT * FROM store;
--SELECT * FROM inventory;
INSERT INTO inventory
SELECT f.film_id, s.store_id
FROM film f
FULL OUTER JOIN store s ON 1 = 1
WHERE f.title = 'Euclidean PI'
-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- Failed. There are actors in the film_actor table that are in the film and refrence the film_id
DELETE FROM film
WHERE title = 'Euclidean PI';
-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- Failed. film_category refrences the category_id of the Mathmagical category
DELETE FROM category
WHERE name = 'Mathmagical';
-- 10. Delete all links to Mathmagical in the film_category tale.
-- Works because film_category is a joint table of the primary keys of two tables
-- It relys on the film and category tables, not the other way around.
DELETE FROM film_category
WHERE category_id = (SELECT category_id FROM category WHERE name = 'Mathmagical');
-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- Mathmagical one worked because we removed all references
-- Euclidean PI failed because we did not remove any of the references
-- <YOUR ANSWER HERE>
--SELECT * FROM category;
BEGIN TRAN;
DELETE FROM category
WHERE name = 'Mathmagical';
DELETE FROM film
WHERE title = 'Euclidean PI';
--SELECT * FROM category;
ROLLBACK TRAN;
--SELECT * FROM category;
-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
-- We need to remove all the actors of the film in film_actor
-- We need to remove all the film_ids of the film from the inventory table
