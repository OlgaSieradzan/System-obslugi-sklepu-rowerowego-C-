using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Final_project
{
    public delegate string Output();


    [XmlInclude(typeof(Private_person))]
    [XmlInclude(typeof(Company))]
    [XmlInclude(typeof(Bike))]
    [XmlInclude(typeof(KidsBike))]
    public class Transaction
    {
        private static int index;
        private string id_tran;
        private Client client;
        private List<object> products = new List<object>();
        private bool invoice;
        private DateTime date;

        public static int Index { get => index; set => index = value; }

        [Key]
        public string Id_tran { get => id_tran; set => id_tran = value; }
        public Client Client { get => client; set => client = value; }
        public List<object> Products { get => products; set => products = value; }
        public bool Invoice { get => invoice; set => invoice = value; }
        public DateTime Date { get => date; set => date = value; }

        static Transaction()
        {
            index = 100;
        }

        public Transaction() 
        { 
           index++;
        
        }

        public Transaction(Client client, bool invoice, string date) : this ()
        {
            Client = client;
            Invoice = invoice;
            Id_tran = $"IDT{index}";

            DateTime newDate;

            if (DateTime.TryParseExact(date, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out newDate))
            {
                Date = newDate;
            
            }
        }

        
        public void AddProduct(object product, Database_bikes dataset)
        {
            try {
                if (product is Bike bike)
                {
                    
                    if (dataset.SellBike(bike.Id_bike) && bike.StoringDate < Date)
                    {
                        
                        Products.Add(product);
                    }
                }

                if (product is KidsBike kbike)
                {
                    
                    if (dataset.SellBike(kbike.Id_bike) && kbike.StoringDate < Date)
                    {
                        Products.Add(product);
                    }
                }

            } 
            catch (ArgumentException) 
            {
                Console.WriteLine("This bike doesn't exist in database, it's quantity is 0" +
                    " or StoringDate is younger than sellingdate which is imposible, first add it to database or update quantity");
            }
            
        }

        public double SumT()
        {

            double sum = 0;

            foreach (var item in Products)
            {
                if (item is Bike)
                {
                    Bike bike = (Bike)item;
                    sum += bike.Price;

                }
                else if (item is KidsBike)
                {
                    KidsBike kidsBike = (KidsBike)item;

                    sum += kidsBike.Price;

                }
            }

            return sum;
        }

        

        public  string Document()
        {
            return invoice ? "Invoice" : "Receipt"; 
        }

       

        public string ClientToString()
        {
            if (Client is Company company)
            {
                return $" Company '{company.CompanyName}'";

            }

            if (Client is Private_person person)
            {
                return $"{person.Name} {person.Surname}";
            }

            return "";
        }

        public string GenerateOutput()
        {
            Output outputDelegate = () =>
            {
                return $" Transaction Id: {Id_tran}, Client: {ClientToString()}, Document: {Document()},\nProducts:\n{Products.ProductsToString()}Sum: {SumT()} zlotys, Date: {Date:d}";
            };

            return outputDelegate.Invoke();
        }



        public override string ToString()
        {
            return GenerateOutput();
        }



    }

    public static class ExtensionMethods
    {
        public static string ProductsToString(this List<object> Products)
        {
            var groupedProducts = Products
                .GroupBy(p => p)
                .Select(g => new
                {
                    Product = g.Key,
                    Count = g.Count()
                });

            StringBuilder result = new StringBuilder();

            foreach (var groupedProduct in groupedProducts)
            {
                if (groupedProduct.Count > 1)
                {
                    result.AppendLine($"{groupedProduct.Count} x" +
                        $" {((dynamic)groupedProduct.Product).ShortString()}");
                }
                else
                {
                    result.AppendLine(((dynamic)groupedProduct.Product).ShortString());
                }
            }

            return result.ToString();
        }

        
    }
}
