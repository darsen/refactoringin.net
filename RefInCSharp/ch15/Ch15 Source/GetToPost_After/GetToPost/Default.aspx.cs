using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GetToPost
{
    public class Product {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
    }

    public partial class _Default : System.Web.UI.Page
    {
        //Create ad-hoc data model - for illustration only
        List<Product> products = new List<Product> {
            new Product {Id = 1, Name = 
                "Juan Valdez Decaff",  Price = 14 },
            new Product {Id = 2, Name = 
                "Starbucks Special Blend", Price = 11 },
            new Product {Id = 3, Name = 
                "Colombia Narino Supreme", Price = 12 }
         };

        public ICollection<Product> ListAllProducts() { 

             return products;
        }

        public void LinkButton_Command(Object sender, 
            CommandEventArgs command)
        {
            //Display order confirmation message
            OrderConfirmation.Text = "You ordered: " +
                    products[Convert.ToInt32(command.CommandArgument) 
                    - 1].Name;
        }


    }
}
