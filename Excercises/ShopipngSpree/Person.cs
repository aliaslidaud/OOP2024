using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        
        private readonly List<Product> allProduct;
        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
                
            }
            if (money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
                
            }
            this.Name = name;
            this.Money = money;
            this.allProduct = new List<Product>();
            this.AllProducts = this.allProduct.AsReadOnly();
        }

        public string Name 
        {
            get;
        }
        public decimal Money 
        {
            get;
            private set;            
        }
        public IReadOnlyCollection<Product> AllProducts { get;  }

        public bool CanPurchase (Product product)
        {
            if(product.Cost > this.Money)
            {
                return false;
            }
            else
            {
                this.Money -= product.Cost;
                this.allProduct.Add(product);
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Name);
            stringBuilder.Append(" - ");
            if(this.AllProducts.Count == 0)
            {
                stringBuilder.Append("Nothing bought");
            }
            else
            {
                stringBuilder.Append(string.Join(", ", 
                    this.AllProducts.Select(P=> P.Name)));
            }

            return stringBuilder.ToString();    
        }

    }
}
