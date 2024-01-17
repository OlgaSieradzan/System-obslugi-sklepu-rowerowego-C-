using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project
{
    public class Database_transaction : IDatabase
    {


        [Key]
        public int Db_TranId { get; set; }

        public virtual List<Transaction> Db_tran { get; set; }

        public void Zapiszdobazydanych()
        {
            using var db = new ShopDbContext();

            db.Db_transactions.Add(this);
            db.SaveChanges();


        }

        private Dictionary<string, Transaction> transactions = new Dictionary<string, Transaction>();
        private string databasename;
        private List<Transaction> transactionsList = new List<Transaction>();

        [XmlIgnore]
        public Dictionary<string, Transaction> Transactions { get => transactions; set => transactions = value; }
        public string Databasename { get => databasename; set => databasename = value; }
        public List<Transaction> TransactionsList { get => transactionsList; set => transactionsList = value; }

        public Database_transaction()
        {

        }

        public Database_transaction(string databasename)
        {
            Databasename = databasename;
        }

        public void AddTran(Transaction tran)
        {
            try
            {
                Transactions.Add(tran.Id_tran, tran);
                TransactionsList.Add(tran);
            }
            catch (ArgumentException)
            {
                throw new InValidDataException("This transaction is already in the database");
            }
        }

        public void RemoveTran(Transaction tran)
        {
            try
            {
                Transactions.Remove(tran.Id_tran);
                TransactionsList.Remove(tran);
            }
            catch
            {
                throw new InValidDataException("This transaction does not exist in this database");
            }
        }

        public string GetInfo(string key)
        {
            if (Transactions.ContainsKey(key))
            {
                return Transactions[key].ToString();
            }
            else
            {
                throw new InValidDataException("Key not found");
            }
        }


        public List<Transaction> SearchClient(string clientName)
        {
            List<Transaction> result = new List<Transaction>();

            foreach (var transaction in transactions.Values)
            {
                if (transaction.Client is Company company && company.CompanyName == clientName)
                {
                    result.Add(transaction);
                }
                else if (transaction.Client is Private_person privatePerson &&
                         (privatePerson.Name == clientName || privatePerson.Surname == clientName))
                {
                    result.Add(transaction);
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var kvp in Transactions)
            {
                result.AppendLine($"{kvp.Value.ToString()}");
            }

            return result.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            using StreamWriter sw = new(nazwa);
           XmlSerializer xs = new(typeof(Database_transaction));
           xs.Serialize(sw, this);
        }

        public static Database_transaction? OdczytXml(string nazwa)
        {
            if (!File.Exists(nazwa))
            {
                return null;
            }
            using StreamReader sw = new(nazwa);
            XmlSerializer xs = new(typeof(Database_transaction));
            return xs.Deserialize(sw) as Database_transaction;
        }
























    }
}
