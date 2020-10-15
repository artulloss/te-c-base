-- INSERT

-- 1. Add Klingon as a spoken language in the USA
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 0, 0.5);
-- 2. Add Klingon as a spoken language in Great Britain
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('GBR', 'Klingon', 0, 0.5);
-- UPDATE

-- 1. Update the capital of the USA to Houston
-- 2. Update the capital of the USA to Washington DC and the head of state
UPDATE country
SET capital = (SELECT id FROM city WHERE name = 'Houston') -- 3796
WHERE code = 'USA'

UPDATE country
SET capital = (SELECT id FROM city WHERE name = 'Washington DC'), headofstate = 'Joe Mama'
WHERE code = 'USA';

SELECT * FROM country WHERE code = 'USA';

-- DELETE

-- 1. Delete English as a spoken language in the USA
-- 2. Delete all occurrences of the Klingon language 

DELETE
FROM countrylanguage
WHERE countrycode = 'USA' AND language = 'English';
SELECT * FROM countrylanguage WHERE countrycode = 'USA' ORDER BY percentage DESC;
INSERT INTO countrylanguage VALUES ('USA', 'English', 1, '88');
SELECT * FROM countrylanguage WHERE countrycode = 'USA' ORDER BY percentage DESC;
-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
INSERT INTO countrylanguage(language) VALUES('Elvish');
-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
INSERT INTO countrylanguage(countrycode, language, isofficial, percentage)
VALUES ('ZZZ', 'English', 0, 0.5);
-- 3. Try deleting the country USA. What happens?
DELETE
FROM country
WHERE code = 'USA';

-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
INSERT INTO countrylanguage
VALUES ('USA', 'English', 1, 88);
-- 2. Try again. What happens?
-- Violated PK constraint
-- 3. Let's relocate the USA to the continent - 'Outer Space'
UPDATE country
SET continent = 'Outer Space';

-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRANSACTION

COMMIT TRANSACTION

ROLLBACK TRANSACTION
-- 2. Try updating all of the cities to be in the USA and roll it back
BEGIN TRANSACTION

SELECT * FROM city;

UPDATE city
SET countrycode = 'USA';

SELECT * FROM city;

ROLLBACK TRANSACTION
-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.