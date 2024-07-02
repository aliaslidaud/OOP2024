namespace ShoppingSpree
{
    public class Product
    {
        public Product(string Name, decimal cost)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Name cannot be empty");
            }
            if (cost < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.Name = Name;
            this.Cost = cost;
        }

        public string Name { get; }
        public decimal Cost { get; }

    }
}
