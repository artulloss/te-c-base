-- ORDERING RESULTS

-- Populations of all countries in descending order
SELECT name, population
FROM country
--WHERE
ORDER BY population DESC,name ASC;

--Names of countries and continents in ascending order
SELECT name, continent
FROM country
ORDER BY  continent ASC, name ASC;

-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 name, lifeexpectancy
FROM country
ORDER BY lifeexpectancy DESC


/* DONT USE THIS OFFSET FOR YOUR HOMEWORK, USE TOP!!!! */
--OFFSET - for info only when you do your capstones
--OFFSET n ROWS FETCH NEXT n ROWS ONLY (no TOP)
SELECT name, lifeexpectancy
FROM country 
ORDER BY lifeexpectancy DESC
OFFSET 20 ROWS
FETCH NEXT 10 ROWS ONLY

-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
SELECT (name+', '+district ) as city_state
FROM city
WHERE district IN ('California','Oregon','Washington')
ORDER BY district, name; 

-- AGGREGATE FUNCTIONS (AVG, SUM, COUNT, MIN, MAX)
-- Average Life Expectancy in the World
SELECT AVG(lifeexpectancy) AS average_life_expectancy
FROM country;

-- Total population in Ohio
SELECT SUM(population) AS total_ohio_pop
FROM city
WHERE district = 'Ohio';

-- The surface area of the smallest country in the world
SELECT TOP 1 name, surfacearea
FROM country
ORDER BY surfacearea ASC;

SELECT MIN(surfacearea) AS min_area
FROM country;

-- The 10 largest countries in the world
SELECT TOP 10 name
FROM country 
ORDER BY surfacearea DESC

-- The number of countries who declared independence in 1991
SELECT COUNT(*) AS count_countries
FROM country 
WHERE indepyear = 1991;

-- GROUP BY (between WHERE and ORDER BY)
-- Count the number of countries where each language is spoken, ordered from most countries to least
SELECT language, COUNT(countrycode) AS country_count
FROM countrylanguage
GROUP BY language
ORDER BY country_count DESC;

SELECT language, COUNT(countrycode) 
FROM countrylanguage
GROUP BY language
ORDER BY COUNT(countrycode)  DESC;

/*
SELECT language, countrycode
FROM countrylanguage
ORDER BY language;
*/

-- Average life expectancy of each continent ordered from highest to lowest
--Expected output -ish (I'm not retyping all the decimal places)
-- Europe 75.14
-- North America 72.99
-- ...
SELECT  continent, AVG(lifeexpectancy) AS avg_life_expectancy, COUNT(*) as num_countries
FROM country
GROUP BY continent
ORDER BY avg_life_expectancy DESC;

-- Exclude Antarctica from consideration for average life expectancy
SELECT  continent, AVG(lifeexpectancy) AS avg_life_expectancy, COUNT(*) as num_countries
FROM country
WHERE continent <> 'Antarctica'
GROUP BY continent
ORDER BY avg_life_expectancy DESC;

-- Sum of the population of cities in each state in the USA ordered by state name
SELECT district, SUM(population) as state_pop, COUNT(*) AS num_cities
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district ASC;

-- The average population of cities in each state in the USA ordered by state name
SELECT district, AVG(population) as state_avg_pop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district ASC;

--how many countries have each form of government? order by most popular form of government
--monarchy 15
--democracy 20
SELECT governmentform, COUNT(code) as num_countries
FROM country
GROUP BY governmentform
ORDER BY num_countries DESC;


--how many countries have each form of government? order by most popular form of government 
--that have at least 10 countries with that form of government
--monarchy 15
--democracy 20
SELECT governmentform, COUNT(code) as num_countries
FROM country
GROUP BY governmentform
HAVING COUNT(code)> 10
ORDER BY num_countries DESC;

--select * from country where code  = 'USA'

--average surface area of countries for each continent, round to 2 digits
SELECT continent, ROUND(AVG(surfacearea),2) AS avg_surfacearea
FROM country
GROUP BY continent;


-- Sum of the population of cities in each state for states that have 5 or more major cities in the USA ordered by state name
SELECT district, SUM(population) as state_pop, COUNT(*) AS num_cities
FROM city
WHERE countrycode = 'USA'  
GROUP BY district
HAVING COUNT(*) >=5 
ORDER BY district ASC;

-- SUBQUERIES
-- Find the names of cities under a given government leader - George W. Bush
SELECT name
FROM city
WHERE countrycode IN --USE IN if subquery can return multiple rows, use = if it returns EXACTLY one row
  (SELECT code FROM country WHERE headofstate = 'George W. Bush')

-- Find the names of cities whose country they belong to has not declared independence yet

-- First, find the list of countries that have not declared independence yet
-- Next, find cities in those countries
SELECT code,name
FROM country
WHERE indepyear IS NULL;

SELECT name, countrycode
FROM city
WHERE countrycode IN (SELECT code FROM country WHERE indepyear IS NULL);

-- Additional samples
-- You may alias column and table names to be more descriptive
SELECT c.name, c.countrycode AS code
FROM city c
WHERE countrycode IN (SELECT code FROM country WHERE indepyear IS NULL)

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. 
--In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.
SELECT (name + ' is in the state of '+district) AS city_state
FROM city
WHERE countrycode = 'USA'

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table
SELECT COUNT(*)
FROM city

-- Also counts the number of rows in the city table
SELECT COUNT(population)
FROM city

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.
SELECT  SUM(population) AS sum_pop, AVG(population) as avg_pop, COUNT(*) as numrows
FROM city



-- Gets the MIN population and the MAX population from the city table.
--If your alias has spaces, you must put it in quotes
SELECT MIN(population) AS smallest_pop, MAX(population) AS 'The max population'
FROM city;


-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. 
--For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
SELECT countrycode, MIN(population) AS min_pop, MAX(population) AS max_pop
FROM city
GROUP BY countrycode;