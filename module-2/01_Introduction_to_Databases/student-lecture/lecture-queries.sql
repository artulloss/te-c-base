-- SELECT ... FROM
-- Selecting the names for all countries
<<<<<<< HEAD
SELECT name
FROM country;

-- Selecting the name and population of all countries
SELECT name, population
FROM country 
ORDER BY population DESC;

-- Selecting all columns from the city table
SELECT * FROM city

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
SELECT name
FROM city
WHERE district = 'Ohio';

-- Selecting countries that gained independence in the year 1776
SELECT * FROM country
WHERE indepyear = 1776;

-- Selecting countries not in Asia
SELECT name FROM country WHERE continent <> 'Asia';

-- Selecting countries that do not have an independence year
SELECT * FROM country
WHERE indepyear IS NULL;

-- Selecting countries that do have an independence year
SELECT * FROM country
WHERE indepyear IS NOT NULL;

-- Selecting countries that have a population greater than 5 million
SELECT * FROM country
WHERE population > 5000000;

-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
SELECT name, district, population
FROM city
WHERE district = 'Ohio' AND population > 400000;
-- Selecting country names on the continent North America or South America
SELECT name, continent
FROM country
WHERE continent LIKE '%America';
=======


-- Selecting the name and population of all countries


-- Selecting all columns from the city table


-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio


-- Selecting countries that gained independence in the year 1776


-- Selecting countries not in Asia


-- Selecting countries that do not have an independence year

-- Selecting countries that do have an independence year


-- Selecting countries that have a population greater than 5 million



-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000

-- Selecting country names on the continent North America or South America



>>>>>>> 3ec7083588c8c9c60fe85b981d23ca2d7f6f65df

-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword

<<<<<<< HEAD
SELECT population, lifeexpectancy, population / surfacearea AS populationperarea
FROM country;

-- Select all countries with 5 to 10 million residents 
SELECT name, population FROM country WHERE population BETWEEN 5000000 AND 10000000;
=======


>>>>>>> 3ec7083588c8c9c60fe85b981d23ca2d7f6f65df
