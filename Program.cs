using System.Xml.Linq;

namespace Final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company1 = new Company("Mix", "0909090979", "Poland","Kielce", "Pakosz", "25-125");
            Company company2 = new Company("Yellow", "7654090979", "Netherland", "Kopenhaga", "Popular", "88-998");
            Company company3 = new Company("Brown", "0777790979", "Slovakia", "Bratyslawa", "Hatlava", "85-187");
            Company company4 = new Company("Dark", "0934210979", "Poland", "Kraków", "Warszawska", "09-025");
            Company company5 = new Company("Magenta", "7869090979", "Poland", "Gdynia", "Zlota", "25-787");

            Private_person person1 = new Private_person("Anna", "Potter", EnumGender.F, "England", "London", "Bakerstreet", "09-099");
            Private_person person2 = new Private_person("Peater", "Parkerr", EnumGender.M, "Poland", "Kraków", "Vet", "99-099");
            Private_person person3 = new Private_person("Alex", "Sati", EnumGender.D, "Germany", "Berlin", "Furtownt", "09-878");
            Private_person person4 = new Private_person("Alexi", "Zottar", EnumGender.M, "England", "London", "Bakerstreet", "09-099");
            Private_person person5 = new Private_person("Suzzane", "Potter", EnumGender.F, "England", "London", "Abbey Road", "09-864");

            Bike bike1 = new Bike(EnumCompany.Bianchi, EnumType.Cyclocross, "Lavera",48, 8000,"2002/11/12", 100);
            Bike bike2 = new Bike(EnumCompany.Bianchi, EnumType.Road, "Multi", 49, 8900, "2023/11/12", 98);
            Bike bike3 = new Bike(EnumCompany.Trek, EnumType.MT, "Tamac", 56, 2000, "2022/12/29", 7);
            Bike bike4 = new Bike(EnumCompany.Trek, EnumType.Cyclocross, "Tamac_Supra", 51, 5500, "2022/11/12", 12);
            Bike bike5 = new Bike(EnumCompany.Speciallized, EnumType.Road, "Spartacus", 49, 1650, "2023/11/12", 87);
            Bike bike6 = new Bike(EnumCompany.Speciallized, EnumType.MT, "MT-90", 48, 2300, "2022/12/12",15);
            Bike bike7 = new Bike(EnumCompany.Merida, EnumType.Cyclocross, "Diuna", 50, 8000, "2002/11/12", 8);
            Bike bike8 = new Bike(EnumCompany.Cube, EnumType.MT, "Lavera", 48, 1780, "2022/11/12", 87);

            KidsBike kbike1 = new KidsBike(EnumCompany.Cube, EnumType.Road, "Merol", 42,700,"2023/09/01", 76);
            KidsBike kbike2 = new KidsBike(EnumCompany.Merida, EnumType.MT, "Salvador", 38, 550, "2023/08/01", 20);
            KidsBike kbike3 = new KidsBike(EnumCompany.Cube, EnumType.Road, "Kurtoza", 43, 1000, "2023/11/01", 7);
            KidsBike kbike4 = new KidsBike(EnumCompany.Cube, EnumType.Cyclocross, "Skewness", 42, 870, "2022/12/01", 54);

            Transaction t1 = new Transaction(person1,false,"2023/12/09");
            Transaction t2 = new Transaction(person2, true, "2023/12/15");
            Transaction t3 = new Transaction(person3, false, "2023/12/17");
            Transaction t4 = new Transaction(person4, false, "2023/12/18");
            Transaction t5 = new Transaction(person5, false, "2023/12/14");
            Transaction t6 = new Transaction(company1, false, "2023/12/26");
            Transaction t7 = new Transaction(company2, true, "2023/12/11");
            Transaction t8 = new Transaction(company3, true, "2023/12/14");
            Transaction t9 = new Transaction(company4, true, "2023/12/01");
            Transaction t10 = new Transaction(company5, true, "2023/12/15");
            Transaction t11 = new Transaction(company1, true, "2023/12/02");

            Database_clients client = new Database_clients("Clients01");

            Database_bikes product = new Database_bikes("Bikes01");

            Database_transaction transaction = new Database_transaction("Transactions01");



            // Console.WriteLine(company1.ToString());

            // Console.WriteLine(person1.ToString());

            // Console.WriteLine(bike1.ToString());

            // Console.WriteLine(kbike1.ToString());

           


            client.AddObject(person1);
            client.AddObject(person2);
            client.AddObject(person3);
            client.AddObject(person4);
            client.AddObject(person5);
              
            client.AddObject(company1);
            client.AddObject(company3);
            client.AddObject(company2);
            client.AddObject(company4);
            client.AddObject(company5);
            
                        product.AddObject(bike1);
                        product.AddObject(bike2);
                        product.AddObject(bike3);
                        product.AddObject(bike4);
                        product.AddObject(bike5);
                        product.AddObject(bike6);
                        product.AddObject(bike7);
                        product.AddObject(bike8);

                        product.AddObject(kbike1);
                        product.AddObject(kbike2);
                        product.AddObject(kbike3);
                        product.AddObject(kbike4);

                        //Console.WriteLine(product.ToString());

                        t1.AddProduct(bike1, product);
                        t1.AddProduct(bike3, product);
                        t2.AddProduct(kbike4, product);
                        t3.AddProduct(kbike2, product);
                        t4.AddProduct(bike6, product);
                        t4.AddProduct(bike7, product);
                        t5.AddProduct(bike8, product);
                        t5.AddProduct(bike8, product);
                        t5.AddProduct(bike8 , product);
                        t6.AddProduct(kbike1, product);
                        t7.AddProduct(kbike1, product);
                        t8.AddProduct(bike1, product);
                        t9.AddProduct(kbike3, product);
                        t10.AddProduct(kbike2, product);
                        t10.AddProduct(bike8, product);
                        t11.AddProduct(bike3, product);

                        transaction.AddTran(t1);
                        transaction.AddTran(t2);
                        transaction.AddTran(t3);
                        transaction.AddTran(t4);
                        transaction.AddTran(t5);
                        transaction.AddTran(t6);
                        transaction.AddTran(t7);
                        transaction.AddTran(t8);
                        transaction.AddTran(t9);
                        transaction.AddTran(t10);
                        transaction.AddTran(t11);

            //Console.WriteLine(transaction.ToString());

            // Console.WriteLine(product.ToString());

            //Console.WriteLine(product.ListToString(product.SearchBikeName(EnumCompany.Trek)));

            //Console.WriteLine(product.ListToString(product.SearchBikeSize(48)));

            // Console.WriteLine(client.ToString());

            //client.RemoveObject(person1);
            // client.RemoveObject(company2);
            /*
             Console.WriteLine(client.ToString());

             Console.WriteLine(client.GetInfo("IC"));

             Console.WriteLine(client.SearchCompanyName("Mix"));

             Console.WriteLine(client.SearchPersonSurname("Potter"));

             Console.WriteLine(client.DictionarieToString(client.Companies));

             Console.WriteLine(client.ListToString(client.SearchCompanyName("Mix")));
            */


            // client.ZapiszXML("Serialized_clients");
            //  product.ZapiszXML("Serialized_bikes");

            // transaction.ZapiszXML("Serialized_transactions");

            client.Zapiszdobazydanych();

        }
    }
}