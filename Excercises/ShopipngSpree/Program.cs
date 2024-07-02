namespace ShoppingSpree
{
    public static class Program
    {
         public static void Main(string[] args)
        {
            Dictionary<string,Person> peopleDict = new Dictionary<string,Person>();
            List<Person> peopleInOrder = new List<Person>();
            string[] peopleInput = Console.ReadLine()
                .Split(";",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] peopleTockens = peopleInput[i].Split("=");
                string currentName = peopleTockens[0];
                decimal currentMoney = decimal.Parse(peopleTockens[1]);
                try
                {
                    Person person = new Person(currentName,
                                    currentMoney);
                    peopleDict[person.Name] = person;
                    peopleInOrder.Add(person); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                
            }
            Dictionary<string, Product> productsDict = new Dictionary<string, Product>();
            string[] productInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productInput.Length; i++)
            {
                string[] productsTockens = productInput[i].Split("=");
                string productName = productsTockens[0];
                decimal productPrice = decimal.Parse(productsTockens[1]);
                try
                {
                    Product product = new Product(productName,
                        productPrice);
                    productsDict[product.Name] = product;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }

            string command = string.Empty;
            while((command = Console.ReadLine()) != "END")
            {
                string[] tockens = command.Split(" ");
                string name = tockens[0];
                string productName = tockens[1];

                Person person = peopleDict[name];
                Product product = productsDict[tockens[1]];

                if(!person.CanPurchase(product))
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }
            
            foreach (Person people in peopleInOrder)
            {
                Console.WriteLine(people.ToString());
            }
        }
    }
}
