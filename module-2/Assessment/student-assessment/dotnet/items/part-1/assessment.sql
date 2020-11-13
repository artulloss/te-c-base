USE assessment;
GO

-- Select all columns from users where the user's role is admin

SELECT * FROM users WHERE role = 'admin';

-- Select name and description from items that were created after Sept. 20, 2019 and the description isn't null

SELECT name, description FROM items WHERE description IS NOT NULL AND created > CONVERT(datetime, '2019-09-20');

-- Select first_name and last_name from users and order by when they were created, latest first

SELECT first_name, last_name FROM users ORDER BY created DESC;

-- Select finished and a count all the items that are finished/not finished

SELECT finished, COUNT(*) AS count FROM items GROUP BY finished;

-- Select a user's first_name and last_name and the item's name for every finished item

SELECT first_name, last_name, name FROM users u
INNER JOIN items i ON i.user_id = u.id;
-- This will work as well, just more specific, unnecessary because no overlapping column names
SELECT u.first_name, u.last_name, i.name FROM users u
INNER JOIN items i ON i.user_id = u.id;