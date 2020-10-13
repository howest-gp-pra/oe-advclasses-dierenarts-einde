using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.Dierenarts.CORE
{
    public class Bird : Animal
    {
        private int width;
        private bool? canFly;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public bool? CanFly
        {
            get { return canFly; }
            set { canFly = value; }
        }


        public Bird(string specie, string name, byte? gender, DateTime? dateOfBirth, int width, bool? canFly) : base(specie, "", name, gender, dateOfBirth)
        {
            this.Width = width;
            this.CanFly = canFly;
        }
        public override string Summary()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} is een {Specie}");
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
            if (canFly != null)
                sb.Append((bool)canFly ? "Kan vliegen" : "Kan niet vliegen");
            else
                sb.Append("Vliegvaardigheid onbekend");
            sb.Append(Environment.NewLine);
            sb.Append("Spanwijdte = " + width);
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
