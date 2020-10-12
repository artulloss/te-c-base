-- SELECT ... FROM
--SELECT list of columns
--FROM name of table
--WHERE some way to filter the rows

-- Selecting the names for all countries
SELECT name
FROM country;


-- Selecting the name and population of all countries
SELECT name, population 
FROM country;


-- Selecting all columns from the city table
SELECT *
FROM city;


-- SELECT ... FROM ... WHERE
--WHERE can use =, <>, !=, >, >=, <, <=, IN (values), NOT IN(values)
-- BETWEEN value1 AND value2, IS NULL, IS NOT NULL, LIKE '%student%'

-- Selecting the cities in Ohio
SELECT name
FROM city
WHERE district = 'Ohio' ;

--is this case sensitive
SELECT name
FROM city
WHERE district = 'OHIO' ;

-- Selecting countries that gained independence in the year 1776
SELECT name, indepyear
FROM country
WHERE indepyear=1776;


-- Selecting countries not in Asia
SELECT name, continent
FROM country
WHERE continent != 'Asia';

-- Selecting countries that do not have an independence year
SELECT name, indepyear
FROM country
WHERE indepyear IS NULL;

-- Selecting countries that do have an independence year
SELECT name, indepyear
FROM country
WHERE indepyear IS NOT NULL;



-- Selecting countries that have a population greater than 5 million
SELECT name, population
FROM country
WHERE population > 5000000;


-- SELECT ... FROM ... WHERE ... AND/OR
-- (A AND B) OR C
-- Selecting cities in Ohio and Population greater than 400,000
SELECT name, district, population
FROM city
WHERE district = 'Ohio' 
  AND population > 400000;

-- Selecting country names on the continent North America or South America

SELECT name, continent
FROM country
--WHERE continent='North America' OR continent='South America'
--WHERE continent IN ('North America','South America')
WHERE continent LIKE '%America';

-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword

SELECT name, population, lifeexpectancy, (population/surfacearea) AS density
FROM country;

--what continents are represented in your database?
SELECT distinct continent
FROM country;

--select all countries with population > 1 million and < 2 million
SELECT name, population
FROM country
WHERE population BETWEEN 1000000 AND 2000000;
