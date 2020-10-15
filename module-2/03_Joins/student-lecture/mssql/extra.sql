-- Display all the films and their language
SELECT f.title, l.name
FROM film f
INNER JOIN language l ON l.language_id = f.language_id;
-- Display all the films and in English
SELECT f.title, l.name
FROM film f
INNER JOIN language l ON l.language_id = f.language_id
WHERE l.name = 'English';
-- Display all the films with their category
SELECT title, name AS category
FROM film f
INNER JOIN film_category fc ON f.film_id = fc.film_id
INNER JOIN category c ON fc.category_id = c.category_id;
-- Display all the films with a category of Horror

-- Display all the films with a category of Horror and title that begins with the letter F

-- Who acted in what together?

-- How many times have two actors appeared together?
SELECT COUNT(*) AS num_films, a1.actor_id, a2.actor_id, a1.first_name
+ ' ' + a1.last_name AS actor1, a2.first_name + ' ' + a2.last_name AS actor2
FROM film f
INNER JOIN film_actor fa1 ON fa1.film_id = f.film_id
INNER JOIN film_actor fa2 ON fa2.film_id = f.film_id AND fa1.actor_id <> fa2.actor_id
INNER JOIN actor a1 ON a1.actor_id = fa1.actor_id
INNER JOIN actor a2 ON a2.actor_id = fa2.actor_id
GROUP BY a1.actor_id, a2.actor_id, a1.first_name, a1.last_name, a2.first_name, a2.last_name
ORDER BY num_films DESC;
-- What movies did the two most often acted together actors appear in together?
