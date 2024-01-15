using Final_project;
using System.IO;

namespace Database_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingNewObject()
        {
            // Arrange
            Database_bikes database_Bikes = new Database_bikes();
            Database_clients database_Clients = new Database_clients();
            Database_transaction database_Transaction = new Database_transaction();

            Bike bike = new Bike(EnumCompany.Bianchi, EnumType.Cyclocross, "Lavera", 48, 8000, "2002/11/12", 100);
            Company company = new Company("Brown", "0777790979", "Slovakia", "Bratyslawa", "Hatlava", "85-187");
            Transaction transaction = new Transaction(company, false, "2023/12/09");

            int b = database_Bikes.BikesList.Count;
            int c = database_Clients.Companies.Count;
            int t = database_Transaction.Transactions.Count;

            // Act

            database_Bikes.AddObject(bike);
            database_Clients.AddObject(company);
            database_Transaction.AddTran(transaction);

            // Assert

            Assert.AreEqual(b + 1, database_Bikes.BikesList.Count);
            Assert.AreEqual(c + 1, database_Clients.Companies.Count);
            Assert.AreEqual(t+1, database_Transaction.Transactions.Count);  



        }


        [TestMethod]
        public void RemovingObject()
        {
            // Arrange

            Database_bikes database_Bikes = new Database_bikes();
            Database_clients database_Clients = new Database_clients();
            Database_transaction database_Transaction = new Database_transaction();

            Bike bike = new Bike(EnumCompany.Bianchi, EnumType.Cyclocross, "Lavera", 48, 8000, "2002/11/12", 100);
            Company company = new Company("Brown", "0777790979", "Slovakia", "Bratyslawa", "Hatlava", "85-187");
            Transaction transaction = new Transaction(company, false, "2023/12/09");

            database_Bikes.AddObject(bike);
            database_Clients.AddObject(company);
            database_Transaction.AddTran(transaction);

            int b = database_Bikes.BikesList.Count;
            int c = database_Clients.Companies.Count;
            int t = database_Transaction.Transactions.Count;

            
            // Act 

            database_Bikes.RemoveObject(bike);
            database_Clients.RemoveObject(company);
            database_Transaction.RemoveTran(transaction);

            // Assert

            Assert.AreEqual(b - 1, database_Bikes.BikesList.Count);
            Assert.AreEqual(c - 1, database_Clients.Companies.Count);
            Assert.AreEqual(t - 1, database_Transaction.Transactions.Count);




        }

       
    }
}