namespace Individual.Exercises.Classes
{
    public class Employee
    {
        public int EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
        public string Department { get; set; }
        public double AnnualSalary { get; private set; }

        public Employee(int employeeId, string firstName, string lastName, double salary)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = salary;
        }

        public void RaiseSalary(double percent)
        {
            percent /= 100;
            percent += 1;
            AnnualSalary *= percent;
        }
        
    }
}
