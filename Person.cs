namespace PersonsInfo
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get => this._firstName;
            
            private set
            { 
                if(value ==  null || value.Length < 3)
                {
                    throw new ArgumentException
                        ("First name cannot contain fewer than 3 symbols!");
                }
                this._firstName = value;
            } 
        }
        public string LastName 
        { 
            get => this._lastName;
            private set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException
                        ("Last name cannot contain fewer than 3 symbols!");
                }
                this._lastName = value;
            }
        }
        public int Age
        {
            get => this._age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Age cannot be zero or a negative integer!");
                }
                this._age = value;
            }
        }
        public decimal Salary
        {
            get => this._salary;
            private set
            {
                if(value < 650m)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this._salary = value;
            }
        }
        public void IncreaseSalary(decimal percentage)
        { 
            if(Age >= 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 2 / 100;
            }
        }


        public override string ToString()
        {
            return $"{this.FirstName} {LastName} receives {this.Salary:f2} leva.";
        }
    }
}
