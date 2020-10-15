-- INSERT

-- 1. Add Klingon as a spoken language in the USA
--INSERT INTO countrylanguage VALUES ('USA','Klingon',0,.5) if you are adding all columns and put in order

INSERT INTO countrylanguage(countrycode,language,isofficial,percentage) 
VALUES ('USA','Klingon',0,.5)

SELECT * FROM countrylanguage where countrycode = 'USA'

-- 2. Add Klingon as a spoken language in Great Britain
SELECT * FROM country WHERE name like '%united kingdom%'

INSERT INTO countrylanguage(countrycode,language,isofficial,percentage) 
VALUES ( (SELECT code FROM country WHERE name like '%united kingdom%'),'Klingon',0,.5)

SELECT * FROM countrylanguage where countrycode = 'GBR'

--Klingon is taking over the world! add a row in countrylanguage for klingon in every country 
/*
INSERT INTO table2
SELECT FROM table1
*/
INSERT INTO countrylanguage (countrycode,language,isofficial,percentage)
SELECT code,'Klingon',0,.5
FROM country

SELECT * FROM countrylanguage WHERE language = 'Klingon'

-- UPDATE
/* UPDATE table_name
   SET column=value
   WHERE column = value
   */
-- 1. Update the capital of the USA to Houston

SELECT id FROM city WHERE name= 'Houston' --3796

UPDATE country
SET capital=3796
WHERE code = 'USA'


--ALL AT ONCE
UPDATE country
SET capital= (SELECT id FROM city WHERE name= 'Houston') --3796
WHERE code = 'USA'

SELECT country.name,city.name
FROM country 
INNER JOIN city ON country.capital = city.id
WHERE code = 'USA'


-- 2. Update the capital of the USA to Washington DC and the head of state
UPDATE country
SET capital=(SELECT id FROM city WHERE name like '%washington%'),
    headofstate = 'Katie Dwyer'
WHERE code = 'USA'

--SELECT * FROM country WHERE code = 'USA'

-- DELETE 

--DELETE FROM table_name WHERE column=value

-- 1. Delete English as a spoken language in the USA
DELETE 
--SELECT * 
FROM countrylanguage
WHERE countrycode = 'USA' AND language = 'English'

-- 2. Delete all occurrences of the Klingon language 
 DELETE 
 --SELECT *
 FROM countrylanguage
 WHERE language = 'Klingon'


-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
INSERT INTO countrylanguage(language) VALUES('Elvish');


-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
INSERT INTO countrylanguage(countrycode,language,isofficial,percentage) 
VALUES ('ZZZ','English',0,.5)

-- 3. Try deleting the country USA. What happens?
DELETE
FROM country
WHERE code = 'USA'


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
INSERT INTO countrylanguage(countrycode,language,isofficial,percentage)
VALUES ('USA','English',1,88)

-- 2. Try again. What happens?
INSERT INTO countrylanguage(countrycode,language,isofficial,percentage)
VALUES ('USA','English',1,88)

-- 3. Let's relocate the USA to the continent - 'Outer Space'
UPDATE country
SET continent = 'Outer Space'
WHERE code = 'USA'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRANSACTION

SELECT COUNT(*) FROM countrylanguage

DELETE
FROM countrylanguage

SELECT COUNT(*) FROM countrylanguage --should be zero

--COMMIT TRANSACTION

ROLLBACK TRANSACTION

SELECT COUNT(*) FROM countrylanguage


-- 2. Try updating all of the cities to be in the USA and roll it back
BEGIN TRANSACTION

SELECT * FROM city

UPDATE city
SET countrycode = 'USA'

SELECT * FROM city

ROLLBACK TRANSACTION

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.

BEGIN TRANSACTION

SELECT * FROM city

UPDATE city
SET countrycode = 'USA'

ROLLBACK TRANSACTION