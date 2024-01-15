using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project
{
    public class Database_bikes : IDatabase
    {
        [Key]
        public int Db_BikesId { get; set; }

        public virtual List<Bike> Db_bikes { get; set; }
        public virtual List<KidsBike> Db_KidsBikes { get; set; }

        public void Zapiszdobazydanych()
        {
            using var db = new ShopDbContext();

            db.Db_bikes.Add(this);
            db.SaveChanges();


        }




        

        string databasename;
        Dictionary<string, Bike> bikes = new Dictionary<string, Bike>();
        Dictionary<string, KidsBike> kidsbikes = new Dictionary<string, KidsBike>();
        List<Bike> bikesList = new List<Bike>();
        List<KidsBike> kidsbikesList = new List<KidsBike>();

        public string Databasename { get => databasename; set => databasename = value; }
        [XmlIgnore]
        public Dictionary<string, Bike> Bikes { get => bikes; set => bikes = value; }
        [XmlIgnore]
        public Dictionary<string, KidsBike> Kidsbikes { get => kidsbikes; set => kidsbikes = value; }
        public List<Bike> BikesList { get => bikesList; set => bikesList = value; }
        public List<KidsBike> KidsbikesList { get => kidsbikesList; set => kidsbikesList = value; }

        public Database_bikes() { }

        public Database_bikes(string databasename)
        {
            Databasename = databasename;
        }

        public void AddObject<T>(T obj) where T : Bike
        {

            try
            {
                if (obj is Bike)
                {
                 
                        Bikes.Add(obj.Id_bike, obj);
                    BikesList.Add(obj);
                    
                }

                else if (obj is KidsBike)
                {
                    
                        Kidsbikes.Add(obj.Id_bike, obj as KidsBike);
                    KidsbikesList.Add(obj as KidsBike);

                }

                else
                {
                    throw new InValidDataException("U can only add objects of classes Kidsbike or Bike");
                }

            }

            catch (ArgumentException)
            {
                Console.WriteLine("This Bike is already in the database");
            }
        }

        public void RemoveObject<T>(T obj) where T : Bike
        {

            try
            {
                if (obj is Bike)
                {

                    Bikes.Remove(obj.Id_bike);
                    BikesList.Remove(obj);  

                }
                else if (obj is KidsBike)
                {

                    Kidsbikes.Remove(obj.Id_bike);
                    KidsbikesList.Remove(obj as KidsBike);
                }
                else
                {

                    throw new InValidDataException("U can only remove objects of classes Kidsbike or Bike");
                }

            }

            catch (ArgumentException)
            {
                Console.WriteLine($"Client wit Id : {obj.Id_bike} does not exist in this database");
            }
        }

        public bool SellBike(string key) 
        {
            if (Bikes.ContainsKey(key) & Bikes[key].Quantity > 0)
            {
                Bikes[key].Quantity--;
                return true;
            }

            if (Kidsbikes.ContainsKey(key) & Kidsbikes[key].Quantity > 0)
            {
                Kidsbikes[key].Quantity--;
                return true;
            }

            else
            {
                Console.WriteLine($" This bike is not available.");
                return false;
            }
        }

        public string GetInfo(string key)
        {
            try
            {

                if (Bikes.ContainsKey(key))
                {
                    return Bikes[key].ToString();
                }
                else if (Kidsbikes.ContainsKey(key))
                {
                    return Kidsbikes[key].ToString();
                }
                else
                {
                    return $"Bike with key '{key}' not found.";
                }

            }

            catch (ArgumentException)
            {
                return $"Bike with key '{key}' not found";

            }
        }

        public List<Bike> SearchBikeName(EnumCompany name) 
        {
            List<Bike> result = new List<Bike>();

            foreach (var b in Bikes)
            {
                if (b.Value.Company.Equals(name))
                {
                    result.Add(b.Value);
                }
            }

            foreach (var bk in Kidsbikes)
            {
                if (bk.Value.Company.Equals(name))
                {
                    result.Add(bk.Value);
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine($"There are no bikes from company {name} in store now");
            }

            return result;
        }

        public List<Bike> SearchBikeSize(int size) 
        {
            List<Bike> result = new List<Bike>();

            foreach (var b in Bikes)
            {
                if (b.Value.Size.Equals(size))
                {
                    result.Add(b.Value);
                }
            }

            foreach (var bk in Kidsbikes)
            {
                if (bk.Value.Size.Equals(size))
                {
                    result.Add(bk.Value);
                }
            }

            if ( result.Count == 0 ) {
                Console.WriteLine($"There are no bikes size {size} in store now");
            }

            return result;
        }

        public override string ToString()
        {
            string result = string.Empty;

            

            foreach (KeyValuePair<string, Bike> s in Bikes)
            {

                result += $"{s.Value}" + "\n";

            }

            

            foreach (KeyValuePair<string, KidsBike> s in Kidsbikes)
            {

                result += $"{s.Value}" + "\n";

            }

            return result;
        }

        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Database_bikes));
            xs.Serialize(sw, this);
        }

        public static Database_bikes? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Database_bikes));
            return xs.Deserialize(sw) as Database_bikes;
        }
    }
}
