-- Display all the films and their language
SELECT film.title, language.name
FROM film
INNER JOIN language ON film.language_id = language.language_id

-- Display all the films and in English
SELECT film.title, language.name
FROM film
INNER JOIN language ON film.language_id = language.language_id
WHERE language.name = 'English'

-- Display all the films with their category

-- Display all the films with a category of Horror

-- Display all the films with a category of Horror and title that begins with the letter F

-- Who acted in what together?

-- How many times have two actors appeared together?
SELECT COUNT(*) AS num_films, a1.actor_id, a2.actor_id, a1.last_name AS actor1, a2.last_name AS actor2
FROM film f
INNER JOIN film_actor fa1 on f.film_id = fa1.film_id
INNER JOIN film_actor fa2 ON f.film_id = fa2.film_id AND fa1.actor_id <> fa2.actor_id
INNER JOIN actor a1 ON a1.actor_id = fa1.actor_id
INNER JOIN actor a2 ON a2.actor_id = fa2.actor_id
GROUP BY a1.actor_id, a2.actor_id, a1.last_name, a2.last_name


SELECT actor.actor_id,film.title FROM film
INNER JOIN film_actor ON film.film_id = film_actor.film_id
INNER JOIN actor ON actor.actor_id = film_actor.actor_id
WHERE actor.actor_id = 4 OR actor.actor_id = 1

-- What movies did the two most often acted together actors appear in together?


SELECT TOP 1 COUNT(*) AS num_films, a1.actor_id AS a1_id, a2.actor_id AS a2_id, a1.last_name AS actor1, a2.last_name AS actor2
FROM film f
INNER JOIN film_actor fa1 on f.film_id = fa1.film_id
INNER JOIN film_actor fa2 ON f.film_id = fa2.film_id AND fa1.actor_id <> fa2.actor_id
INNER JOIN actor a1 ON a1.actor_id = fa1.actor_id
INNER JOIN actor a2 ON a2.actor_id = fa2.actor_id
GROUP BY a1.actor_id, a2.actor_id, a1.last_name, a2.last_name
ORDER BY num_films DESC

--actor 60 and 27
WITH actor1Movies AS (
 SELECT film_actor.film_id
 FROM actor
 JOIN film_actor ON actor.actor_id = film_actor.actor_id
 WHERE film_actor.actor_id = 60
 )
 SELECT film_actor.film_id, film.title
 FROM actor
 JOIN film_actor ON actor.actor_id = film_actor.actor_id
 JOIN actor1Movies ON actor1Movies.film_id = film_actor.film_id
 JOIN film ON film_actor.film_id = film.film_id
 WHERE film_actor.actor_id = 27 
   

