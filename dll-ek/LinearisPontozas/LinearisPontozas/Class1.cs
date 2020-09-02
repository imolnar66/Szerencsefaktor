using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearisPontozas
{
    enum PontozasIranya
    {
        Felfele = 1,
        Lefele = -1
    }
    struct Ertektartomany
    {
        private double tolErtek;
        private double igErtek;

        public double TolErtek { get; private set; }
        public double IgErtek { get; private set; }

        public Ertektartomany(double tolErtek, double igErtek) : this()
        {
            TolErtek = tolErtek;
            IgErtek = igErtek;
        }

        public override string ToString()
        {
            return $"Tol : {tolErtek} - Ig : {igErtek}";
        }
    }
    struct PontErtekTartomany
    {
        private double pontErtekTol;
        private double pontErtekIg;

        public double PontErtekTol { get => pontErtekTol; private set => pontErtekTol = value; }
        public double PontErtekIg { get => pontErtekIg; private set => pontErtekIg = value; }

        public PontErtekTartomany(double pontErtekIg, double pontErtekTol) : this()
        {
            PontErtekIg = pontErtekIg;
            PontErtekTol = pontErtekTol;
        }
        public override string ToString()
        {
            return $"Pontérték tól :{pontErtekTol} - Pontérték ig :{pontErtekIg}";
        }
    }

    public class Class1 : ICloneable
    {

        internal Ertektartomany ErtekTolIg { get; private set; }          //az értéktartomány
        internal PontErtekTartomany PontokTolIg { get; private set; }    //A pontszámok tartománya tól -ig
        internal PontozasIranya PontozasIr { get; private set; }          //pontozás iránya Felfelé -> növekszik a pontszám, Lefelé -> növekszik a pontszám
        public double AdottPontszam { get; set; }                      //az aktuális értékre adott pontszám élrtéke
        public double PontozniAkartErtek { get; set; }                 //Az értékét amit pontozni akarok
        internal Class1(Ertektartomany ertekTolIg, PontErtekTartomany pontokTolIg, PontozasIranya pontozasIranya)
        {
            ErtekTolIg = ertekTolIg;
            PontokTolIg = pontokTolIg;
            PontozasIr = pontozasIranya;
        }
        public void Pontkiosztas()
        {            
            if (PontozasIr == PontozasIranya.Felfele)
            {
                //Emelkedő
                AdottPontszam = (((PontozniAkartErtek - ErtekTolIg.TolErtek) / (ErtekTolIg.IgErtek - ErtekTolIg.TolErtek)) * (PontokTolIg.PontErtekIg - PontokTolIg.PontErtekTol)) + PontokTolIg.PontErtekTol;
            }
            else
            {
                //csökkenő             
                AdottPontszam = (((ErtekTolIg.IgErtek - PontozniAkartErtek) / (ErtekTolIg.IgErtek - ErtekTolIg.TolErtek)) * (PontokTolIg.PontErtekIg - PontokTolIg.PontErtekTol)) + PontokTolIg.PontErtekTol;
            }
        }

        //A klónozás azért kell, hogy csak az aktuális, pontozni akafrt értékrt krlljrn mindig mrgadni.
        public object Clone()
        {
            return new Class1(this.ErtekTolIg, this.PontokTolIg, this.PontozasIr);
        }
    }
}
