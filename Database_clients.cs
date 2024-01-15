using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Final_project
{
    public class Database_clients : IDatabase, ICloneable
    {

        [Key]
        public int Db_ClientsId { get; set; }

        public virtual List<Company> Db_comapnies { get; set; }
        public virtual List<Private_person> Db_persons { get; set; }

        public void Zapiszdobazydanych()
        {
            using var db = new ShopDbContext();

            db.Db_clients.Add(this);
            db.SaveChanges();


        }











        Dictionary<string, Company> companies = new Dictionary<string, Company>();
        Dictionary<string, Private_person> persons = new Dictionary<string, Private_person>();
        public string databaseName;

        public List<Company> companiesList = new List<Company>();
        public List<Private_person> personsList = new List<Private_person>();


        [XmlIgnore]
        public Dictionary<string, Company> Companies { get => companies; set => companies = value; }
        [XmlIgnore]
        public Dictionary<string, Private_person> Persons { get => persons; set => persons = value; }
        public string DatabaseName { get => databaseName; set => databaseName = value; }
        public List<Company> CompaniesList { get => companiesList; set => companiesList = value; }
        public List<Private_person> PersonsList { get => personsList; set => personsList = value; }

        public Database_clients() { }

        public Database_clients(string databaseName) : this()
        {
            DatabaseName = databaseName;
        }

        public void AddObject<T>(T obj) where T : Client
        {

            try
            {
                if (obj is Company)
                {

                    Companies.Add(obj.Id_client, obj as Company);
                    CompaniesList.Add(obj as Company);

                }
                else if (obj is Private_person)
                {

                    Persons.Add(obj.Id_client, obj as Private_person);
                    PersonsList.Add(obj as Private_person);
                }
                else
                {

                    throw new InValidDataException("U can only add objects of classes Company or Private_person");
                }

            }

            catch (ArgumentException)
            {
                Console.WriteLine("This Client is already in the database");
            }
        }


        public void RemoveObject<T>(T obj) where T : Client
        {

            try
            {
                if (obj is Company)
                {

                    Companies.Remove(obj.Id_client);
                    CompaniesList.Remove(obj as Company);

                }
                else if (obj is Private_person)
                {

                    Persons.Remove(obj.Id_client);
                    PersonsList.Remove(obj as Private_person);
                }
                else
                {

                    throw new InValidDataException("U can only remove objects of classes Company or Private_person");
                }

            }

            catch (ArgumentException)
            {
                Console.WriteLine($"Client wit Id : {obj.Id_client} does not exist in this database");
            }
        }

        public string GetInfo(string key) // Funkcja która znajduje w bazie danych po identyfikatorze
        {

            try
            {

                if (Companies.ContainsKey(key))
                {
                    return Companies[key].ToString();
                }
                else if (Persons.ContainsKey(key))
                {
                    return Persons[key].ToString();
                }
                else
                {
                    return $"Client with key '{key}' not found.";
                }

            }

            catch (ArgumentException)
            {
                return $"This client does not exist in this database";

            }

        }

     

        public List<Company> SearchCompanyName(string name) // wyszukiwanie firmy po nazwie
        {
            List<Company> result = new List<Company>();

            foreach (var company in Companies)
            {
                if (company.Value.CompanyName.Equals(name))
                {
                    result.Add(company.Value);
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine($"There are no company {name} in database now");
            }

            return result;
        }

        public List<Private_person> SearchPersonSurname(string name) // Wyszukiwanie osoby po nazwisku
        {
            List < Private_person > result = new List<Private_person> ();

            foreach (var p in Persons)
            {
                if (p.Value.Surname.Equals(name))
                {
                    result.Add(p.Value);
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine($"There are no clients with surname '{name}' in database now");
            }

            return result;
        }

        public void SortPeople()
        {
            List<Private_person> result = new List<Private_person>();

            foreach (var p in Persons)
            {
                result.Add(p.Value);      
            }

            result.Sort();
        }

        public void SortCompanies()
        {
            List<Company> result = new List<Company>();

            foreach (var p in Companies)
            {
                result.Add(p.Value);
            }

            result.Sort();

        }

        public override string ToString()
        {
            string result = string.Empty;

            result += "Companies:" + "\n";

            foreach (KeyValuePair<string, Company> s in Companies)
            {

                result += $"{s.Value}" + "\n";

            }

            result += "Private persons:" + "\n";

            foreach (KeyValuePair<string, Private_person> s in Persons)
            {

                result += $"{s.Value}" + "\n";

            }

            return result;
        }


        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Database_clients));
            xs.Serialize(sw, this);
        }
        public static Database_clients? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Database_clients));
            return xs.Deserialize(sw) as Database_clients;
        }

        public object Clone()
        {
            Database_clients copy = (Database_clients)this.MemberwiseClone();
            return copy;
        }
    }  
}
