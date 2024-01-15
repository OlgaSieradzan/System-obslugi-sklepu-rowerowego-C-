using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class KidsBike : Bike, IComparable<KidsBike>
    {
        public KidsBike() { }

        public KidsBike(EnumCompany company, EnumType type, string model, int size, double price, string storingDate, int quantity) : base( company, type,model,size, price , storingDate, quantity)
        {
            Id_bike = ID();

        }

        public override string ID()
        {
            return base.ID() + "K";
        }

        public override bool Sizing(int x)
        {
            bool result = false;

            switch (type) {
                case EnumType.MT:

                    if (x >= 38 & x < 41)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for kid's MT bikes is from 38 to 40");
                    }
                    break;
                case EnumType.Road:

                    if (x >= 42 & x < 47)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for kid'sroad bikes is from 42 to 47");
                    }
                    break;

                case EnumType.Cyclocross:


                    if (x >= 42 & x < 46)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for kid's cyclocross bikes is from 42 to 45");
                    }
                    break;


            }
            

            return result;
        }


        public int CompareTo(KidsBike? other)
        {
            if (other == null)
            {
                return 1; // If the other object is null, consider it greater
            }

            int companyComparison = this.Company.CompareTo(other.Company);

            if (companyComparison == 0)
            {
                int modelComparison = string.Compare(this.Model, other.Model, StringComparison.Ordinal);
                if (modelComparison == 0)
                {
                    return this.Size.CompareTo(other.Size);
                }
                return modelComparison;
            }

            return companyComparison;
        }

        public override string ShortString()
        {
            return "Kid's model: " + base.ShortString();
        }

        public override string ToString()
        {
            return "Kid's model: " + base.ToString();
        }
    }
}
