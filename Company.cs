using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class Company : Client , IComparable<Company>, ICloneable
    {
        public string companyName;
        public string nip;

        public string CompanyName { get => companyName; set => companyName = value; }
        public string Nip
        {
            get => nip;

            init {
                if(value.Length == 11 || value.Length == 10 )
                {
                    nip = value;
                }
                else
                {
                    throw new InValidDataException("Nip should be 11 or 10 chracters long");
                }
            }
        }

        public Company() : base()
        {

        }

        public Company(string companyName, string nip, string country, string city, string street, string code) : base( country, city, street, code)
        {
            CompanyName = companyName;
            Nip = nip;
            this.Id_client = base.Id_client + "C";
        }

       

        public int CompareTo(Company? other)
        {
            if (other == null) return 1;

            int wynik;

            wynik = this.CompanyName.CompareTo(other.CompanyName);
            if (wynik == 0)
            {
                wynik = this.Country.CompareTo(other.Country);
            }

            return wynik;
        }

        public override string ToString()
        {
            return $"{CompanyName} {Nip}" + base.ToString();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
