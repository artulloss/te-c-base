--Subquery Review--


--what's the pop of the biggest city in barbados?

--whats the country code for barbados - country
--what's the MAX(pop) in cities table where the country is barbados

SELECT MAX(population)
FROM city
WHERE countrycode = (
	SELECT code
	FROM country
	WHERE name = 'Barbados'
	)

--list of countries that have more than one city bigger than a million people
SELECT countrycode
FROM city
WHERE population > 1000000 
GROUP BY countrycode
HAVING count(*) > 1

-- now use subqueries to give me the name of the country

SELECT name
FROM country
WHERE code IN (
	SELECT countrycode
	FROM city
	WHERE population > 1000000 
	GROUP BY countrycode
	HAVING count(*) > 1
	)
