using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Final_project
{
    public enum EnumCompany { Trek, Speciallized, Cube, Merida, Bianchi}

    public enum EnumType { MT , Road , Cyclocross }


    public class Bike : IComparable<Bike>, IEquatable<Bike>
    {
        public EnumCompany company;
        public EnumType type;
        public string model;
        public int size;
        public double price;
        public static int index;
        public static double minimalPrice;
        public string id_bike;
        public DateTime storingDate;
        private int quantity;

        public EnumCompany Company { get => company; set => company = value; }
        public EnumType Type { get => type; set => type = value; }
        public string Model { get => model; set => model = value; }
        public int Size
        {
            get => size;
            set
            {
                if (Sizing(value))
                {
                    size = value;
                }
            }
        }
        public static int Index { get => index; set => index = value; }

        [Key]
        public string Id_bike { get => id_bike; set => id_bike = value; }
        public double Price
        {
            get => price;
            set
            {
                if (value > MinimalPrice)
                {

                    price = value;

                }
                else
                {
                    throw new InValidDataException("Price should be at least 100 zł");
                }
            }
        }

        public DateTime StoringDate { get => storingDate; set => storingDate = value; }
        public static double MinimalPrice { get => minimalPrice; set => minimalPrice = value; }
        public int Quantity
        {
            get => quantity;
            set
            {

                if (value >= 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new InValidDataException("U cannot enter bike with negative quantity");
                }
            }
        }

        static Bike()
        {
            index = 0;
            MinimalPrice = 100;
        }

        public Bike()
        {
            index++;
        }

        public Bike(EnumCompany company, EnumType type, string model, int size, double price, string storingDate, int quantity) : this()
        {
            Company = company;
            Type = type;
            Model = model;
            Size = size;
            Id_bike = ID();
            Quantity = quantity;


            DateTime newDate;

            if (DateTime.TryParseExact(storingDate, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out newDate))
            {
                StoringDate = newDate;

                Price = Pricing(price);
            }
        }

        public double Pricing(double basePrice)
        {
            double result = basePrice;

            double daysSinceStoring = (DateTime.Today - StoringDate).TotalDays;

            if (daysSinceStoring > 365)
            {
                // If storing date is older than one year, apply a 15% discount
                result = 0.85 * basePrice;
            }

            return result;
        }


        public virtual bool Sizing(int x)
        {
            bool result = false;
            switch (type)
            {
                case EnumType.MT:

                    if (x >= 42 & x < 57)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for MT bikes is from 42 to 56");
                    }
                    break;
                case EnumType.Road:

                    if (x >= 47 & x < 67)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for road bikes is from 47 to 66");
                    }
                    break;

                case EnumType.Cyclocross:


                    if (x >= 47 & x < 64)
                    {
                        result = true;
                    }
                    else
                    {
                        throw new InValidDataException("Size range for cyclocross bikes is from 47 to 63");
                    }
                    break;


            }
            return result;
        }




        public virtual string ID()

        {
            string result = string.Empty;
            switch (Type)
            {
                case EnumType.MT:
                    result = $"ID{Index}MT";
                    break;
                case EnumType.Road:
                    result = $"ID{Index}R";
                    break;
                case EnumType.Cyclocross:
                    result = $"ID{Index}CC";
                    break;
            }

            return result;
        }

        public bool Equals(Bike? other)
        {
            if (other == null) { return false; }

            return Model.Equals(other.Model);
        }

        public int CompareTo(Bike? other)
        {
            if (other == null)
            {
                return 1; // If the other object is null, consider it greater
            }

            int companyComparison = this.Company.CompareTo(other.Company);

            if (companyComparison == 0)
            {
                
                if (Equals(other))
                {
                    return this.Size.CompareTo(other.Size);
                }
                return 1;
            }

            return companyComparison;
        }

        public override string ToString()
        {
            
            return $"{Company} {Model} {Type} Size : {Size}, Actual price : {Price}, Storing Date: {StoringDate:d}, Quantity: {Quantity} Bike's id : {Id_bike}";
        }


        public virtual string ShortString()
        {
            return $"{Company} {Model} {Type} Size : {Size}";
        }

      
    }
}
