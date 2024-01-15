using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public abstract class Client 
    {
       
        public string id_client;
        public string country;
        public string city;
        public string street;
        public string code;
        private string pattern = "^\\d{2}-\\d{3}";

        private static int index;

        [Key]
        public string Id_client { get => id_client; init => id_client = value; }
        public static int Index { get => index; set => index = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string Code { get => code; set => code = value; }
        public string Country { get => country; set => country = value; }

        public bool CheckCode(string code, string sPattern)
        {
            bool result;
            if (System.Text.RegularExpressions.Regex.IsMatch(code, sPattern))
            {
                result = true;
            }
            else
            {
                result = false;

            }
            return result;
        }


        static Client()
        {
            Index = 1;
        }

        public Client()
        {
            Index++;
            Id_client = string.Empty;
        }

        public Client(string country,string city, string street, string code) : this()
        {
            Country = country;

            City = city;

            Street = street;
            if (CheckCode(code, pattern))
            {
                Code = code;
            }
            else
            {
                throw new InValidDataException("Post code must be inscribe according to this pattern: {00}-{000} , where zeros reprezents numbers");
            }

            Id_client = $"ID{Index}";

        }

        

        public override string ToString()
        {
            return $" {Country} {City} {Street} {Code}, client's ID: {Id_client} ";
        }

       

        
    }
}
