IF EXISTS(SELECT * FROM sys.databases WHERE name='ProjectOrganizer')
DROP DATABASE ProjectOrganizer;
GO

CREATE DATABASE ProjectOrganizer
GO

USE ProjectOrganizer;

CREATE TABLE department (
	department_id BIGINT IDENTITY(1, 1) PRIMARY KEY,
	department_number BIGINT UNIQUE NOT NULL,
	department_name VARCHAR(16) NOT NULL
)

CREATE TABLE employee (
	employee_id BIGINT IDENTITY(1, 1) PRIMARY KEY,
	employee_number BIGINT UNIQUE NOT NULL,
	job_title VARCHAR(32) NOT NULL,
	last_name VARCHAR(16) NOT NULL,
	first_name VARCHAR(16) NOT NULL,
	gender VARCHAR(16) NOT NULL,
	birth_date DATE NOT NULL,
	hire_date DATE NOT NULL,
	department_id BIGINT FOREIGN KEY REFERENCES department(department_id)
)

CREATE TABLE project (
	project_id BIGINT IDENTITY(1, 1) PRIMARY KEY,
	project_number BIGINT UNIQUE NOT NULL,
	start_date DATE
)

CREATE TABLE project_employees (
	project_id BIGINT FOREIGN KEY REFERENCES project(project_id),
	employee_id BIGINT FOREIGN KEY REFERENCES employee(employee_id)
	PRIMARY KEY (project_id, employee_id) -- Join key :P
)


/*
Requirements

All tables are required to have a primary key.
Populate the tables with data for at least four projects, three departments, and eight employees.
Make sure each project has at least one employee assigned to it, and each department has at least two employees.
*/

-- 4 projects :P
INSERT INTO project(project_number, start_date) VALUES (1, '2020-01-01'), (2, '2020-02-02'), (3, '2020-03-03'), (4, '2020-03-03');
-- 3 departments
INSERT INTO department(department_number, department_name)
VALUES (1, 'Engineering'), (2, 'Human Resources'), (3, 'Testing');
-- 8 employees, 3 in 2 of them, 2 in one.
INSERT INTO employee(employee_number, job_title, last_name, first_name, gender, birth_date, hire_date, department_id)
VALUES (1, 'Software Developer', 'Tulloss', 'Adam', 'Male', '2002-07-01', '2020-12-25', (SELECT department_id FROM department WHERE department_name = 'Engineering')),
(2, 'Senior Software Developer', 'Mama', 'Joe', 'Male', '1999-01-01', '2010-05-03', (SELECT department_id FROM department WHERE department_name = 'Engineering')),
(3, 'Computer Scientist', 'Lovelace', 'Ada', 'Female', '1815-12-10', '1852-11-27', (SELECT department_id FROM department WHERE department_name = 'Engineering')),
(4, 'HR Manager', 'Karen', 'Karen', 'Female', '1990', '2012-02-13', (SELECT department_id FROM department WHERE department_name = 'Human Resources')),
(5, 'HR Assistant', 'Edylk', 'Klyde', 'Male', '1995-09-08', '2007-04-25', (SELECT department_id FROM department WHERE department_name = 'Human Resources')),
(6, 'HR Assistant', 'Doe', 'John', 'Male', '1995-09-08', '2007-04-25', (SELECT department_id FROM department WHERE department_name = 'Human Resources')),
(7, 'Tester', 'Doe', 'Jane', 'Female', '1995-09-08', '2007-04-25', (SELECT department_id FROM department WHERE department_name = 'Testing')),
(8, 'Tester', 'Doe', 'Richard', 'Male', '1995-09-08', '2007-04-25', (SELECT department_id FROM department WHERE department_name = 'Testing'))

-- 4 employees assigned to projects, assigned myself to two projects, many to many relationship :P
INSERT INTO project_employees
VALUES (1, (SELECT employee_id FROM employee WHERE first_name + last_name = 'JaneDoe')),
(2, (SELECT employee_id FROM employee WHERE first_name + last_name = 'JohnDoe')),
(3, (SELECT employee_id FROM employee WHERE first_name + last_name = 'AdamTulloss')),
(4, (SELECT employee_id FROM employee WHERE first_name + last_name = 'AdamTulloss')),
(4, (SELECT employee_id FROM employee WHERE first_name + last_name = 'JoeMama'))