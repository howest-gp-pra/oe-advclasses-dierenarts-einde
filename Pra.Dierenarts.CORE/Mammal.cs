using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.Dierenarts.CORE
{
    public class Mammal : Animal
    {
        private int height;
        private bool? sterilized = false;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public bool? Sterilized
        {
            get { return sterilized; }
            set { sterilized = value; }
        }
        public Mammal(string specie, string breed, string name, byte? gender, DateTime? dateOfBirth, int height, bool? sterilized) : base(specie, breed, name, gender, dateOfBirth)
        {
            this.height = height;
            this.sterilized = sterilized;
        }
        public override string Summary()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} is een {Specie} van het ras {Breed}");
            sb.Append(Environment.NewLine);

            if (Gender != null)
            {
                if (Gender == 1)
                {
                    sb.Append($"Geslacht = vrouwelijk");
                }
                else
                {
                    sb.Append($"Geslacht = mannelijk");
                }
            }
            else
            {
                sb.Append($"Geslacht is onbekend");
            }
            sb.Append(Environment.NewLine);

            if (sterilized == null)
                sb.Append("Sterelisatie onbekend");
            else
                sb.Append((bool)sterilized ? "Is gesereliseerd" : "Is niet gestereliseerd");
            sb.Append(Environment.NewLine);

            sb.Append("Schofhoogte = " + height);
            sb.Append(Environment.NewLine);

            if (DateOfBirth != null)
            {
                sb.Append("Geboren op " + ((DateTime)DateOfBirth).ToString("dd/MM/yyyy"));
                sb.Append(Environment.NewLine);
                sb.Append("Leeftijd = " + Age());

            }
            else
                sb.Append("Leeftijd onbekend");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
