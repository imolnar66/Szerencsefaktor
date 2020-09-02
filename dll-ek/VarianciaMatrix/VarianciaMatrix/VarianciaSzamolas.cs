using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarianciaMatrix
{

     public struct tolIg
    {
        private int tol;
        private int ig;
        public int Tol
        {
            get => tol;
            set
            {
                if (value > 0)
                {
                    tol = value;
                }
                else
                {
                    throw new ArgumentException("A kezdőérték nem lehet ulla!");
                }
            }
        }
        public int Ig
        {
            get => ig;
            set
            {
                if (value > 0 && tol <= value)
                {
                    ig = value;
                }
                else
                {
                    throw new ArgumentException("Az 'ig' értéke nem lehet nulla, vagy kisebb mint a 'tól' értéke!");
                }
            }
        }
        public tolIg(int tol, int ig) : this()
        {
            Tol = tol;
            Ig = ig;
        }
        public override string ToString()
        {
            return $"{Tol} - {Ig}";
        }
    }
    public class VarianciaSzamolas
    {

        private List<tolIg> ertekHatarok;
        private int sorokSzama;
        
        private List<int> elemSzamLIsta;
        private List<int> elemSzamSzorzatLista;
        private List<List<int>> kombinaciokListaja;

        public VarianciaSzamolas(List<tolIg> ertekHatarok)
        {
            elemSzamLIsta = new List<int>();            //hány eleme (tól - ig) van a paraméterként átadott listának
            elemSzamSzorzatLista = new List<int>();     //egy adott oszlopban hányszor ismétlődik egy elem
            sorokSzama = 1;                             //hány kombinációs sor van           
            this.ertekHatarok = ertekHatarok;
            foreach (tolIg item in this.ertekHatarok)   //az egyes elemek értéktartományát adja meg
            {
                elemSzamLIsta.Add(item.Ig - item.Tol + 1);
            }
            
            kombinaciokListaja = new List<List<int>>();

            foreach (int item in elemSzamLIsta) //hány sor van a listában
            {
                sorokSzama *= item;
            }

            elemSzamSzorzatLista.Add(1); //az utolsó oszlopban csak egyszer fordulak elő az adatok

            for (int i = elemSzamLIsta.Count - 1; i >= 1; i--)
            {
                elemSzamSzorzatLista.Add(elemSzamSzorzatLista.Last() * elemSzamLIsta[i]);
            }

            for (int i = 0; i < sorokSzama; i++)
            {
                kombinaciokListaja.Add(new List<int>()); //megvannak a sorok és az oszlopok is
            }
            ColumnsUploadWithData();
        }

        private void ColumnsUploadWithData()
        {
            //mivel az elemSzamSzorzatLista jelenleg fordított sorrendben tartalmazza a ciklusváltozókat, ezért 
            //megfordítom a sorrendet
            List<int> atmenetilIsta = new List<int>();
            for (int i = elemSzamSzorzatLista.Count() - 1; i >= 0; i--)
            {
                atmenetilIsta.Add(elemSzamSzorzatLista[i]);
            }
            elemSzamSzorzatLista = atmenetilIsta;

            for (int i = 0; i < elemSzamLIsta.Count(); i++) //annyiszor megy végig ahány oszlopom van
            {
                int ciklus = elemSzamSzorzatLista[i];

                int tol = ertekHatarok[i].Tol;
                int y = tol;
                int ig = ertekHatarok[i].Ig;

                for (int j = 1; j <= sorokSzama; j++) //az oszlopokon belül annyiszor fut le ahány sor van
                {

                    kombinaciokListaja[j - 1].Add(y);

                    if (j % ciklus == 0)
                    {
                        if (y < ig)
                        {
                            y++;
                        }
                        else
                        {
                            y = tol;
                        }
                    }
                }
            }
        }
        public List<List<int>> GetKombinaltAdatSorok()
        {
            return kombinaciokListaja;
        }
    }
}
