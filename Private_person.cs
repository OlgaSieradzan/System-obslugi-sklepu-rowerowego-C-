using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public enum EnumGender { F, M, D }
    public class Private_person : Client , IComparable<Private_person>, ICloneable
    {
        public string name;
        public string surname;
        public  EnumGender gender;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public EnumGender Gender { get => gender; set => gender = value; }

        public Private_person() : base()
        {
            
        }

        public Private_person(string name, string surname, EnumGender gender,string country, string city, string street, string code) : base(country, city ,street ,code)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            this.Id_client = base.Id_client + "P";
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Gender}" + base.ToString();
        }

        public int CompareTo(Private_person? other)
        {

                if (other == null) return 1; 

                int wynik;

                wynik = this.Surname.CompareTo(other.Surname);
                if (wynik == 0)
                {
                    wynik = this.Name.CompareTo(other.Name);
                }

                return wynik;
            
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
