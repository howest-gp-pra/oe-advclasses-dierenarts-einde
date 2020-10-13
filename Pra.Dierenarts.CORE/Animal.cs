using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.Dierenarts.CORE
{
    public abstract class Animal
    {
        private string specie;
        private byte? gender;  //null=onbekend, 0 = mannelijk, 1 = vrouwelijk
        private DateTime? dateOfBirth;
        private string name;
        private string breed; //bv cocker, duitse herder, maltezer, nvt ...

        protected string Specie
        {
            get { return specie; }
            set { specie = value; }
        }
        protected byte? Gender
        {
            //null = onbekend, O = mannelijk, 1 = vrouwelijk
            get { return gender; }
            set { gender = value; }
        }

        protected DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        protected string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        protected Animal(string specie, string breed, string name, byte? gender, DateTime? dateOfBirth)
        {
            this.specie = specie;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.name = name;
            this.breed = breed;
        }

        protected string Age()
        {
            if (dateOfBirth == null)
                return "onbekend";
            else
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                DateTime vandaag = DateTime.Today;
                TimeSpan ts = vandaag - (DateTime)dateOfBirth;

                int jaren = (zeroTime + ts).Year - 1;
                int maanden = (zeroTime + ts).Month - 1;
                int dagen = (zeroTime + ts).Day;


                return $"{jaren} jaar, {maanden} maanden, {dagen} dagen";
            }
        }

        public override string ToString()
        {
            if (this is Bird)
                return Specie.ToString() + " - " + Name;
            else
                return Specie.ToString() + " - " + Breed + " - " + Name;

        }
        public virtual string Summary()
        {
            return "";
        }
    }
}
