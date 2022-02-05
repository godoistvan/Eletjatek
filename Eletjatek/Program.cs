using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Eletjatek
{
    class Program
    {
        class EletjatekSzimulator
        {
            public int[,] Matrix { get; private set; }
            public int Oszlopokszama { get; private set; }
            public int Sorokszama { get; private set; }
            public EletjatekSzimulator(int oszlopokszama,int sorokszama)
            {
                Oszlopokszama = oszlopokszama;
                Sorokszama = sorokszama;
                Matrix = new int[Oszlopokszama + 2,Sorokszama+2] ;
                Random r = new Random();
                for (int i = 1; i <= sorokszama; i++)
                {
                    for (int j = 0; j <= oszlopokszama; j++)
                    {

                            Matrix[i, j] = r.Next(0, 2);

                    }
                }
            }
            private void megjelenit()
            {
                for (int i = 0; i <=Sorokszama+1; i++)
                {
                    for (int j = 0; j<= Oszlopokszama+1; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        if (i==0||j==0||i==Sorokszama+1||j==Oszlopokszama+1)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            if (Matrix[i,j]==1)
                            {
                                Console.Write("S");
                            }
                            else
                            {
                                Console.WriteLine(" ");
                            }
                        }
                        
                    }
                }
            }
            private void KovetkezoAllapot()
            {
                int[,] ujmatrix =new int[Sorokszama+2,Oszlopokszama+2];
                int szamolo = 0;
                int ujszamolo = 0;
                for (int i = 1; i <= Sorokszama; i++)
                {
                    for (int j = 1; j <= Oszlopokszama; j++)
                    {
                        if (j<Oszlopokszama-1&&j>1&&i>2)
                        {
                            if (Matrix[i, j] == 1)
                            {
                                if (Matrix[i + 1, j] == 1 || Matrix[i - 1, j] == 1 || Matrix[i + 1, j + 1] == 1 || Matrix[i - 1, j - 1] == 1 || Matrix[i, j + 1] == 1 || Matrix[i - 1, j + 1] == 1 || Matrix[i, j - 1] == 1 || Matrix[i + 1, j - 1] == 1)
                                {
                                    szamolo++;
                                    if (szamolo == 3 || szamolo == 2)
                                    {
                                        ujmatrix[i, j] = 1;
                                    }
                                    if (szamolo == 1)
                                    {
                                        ujmatrix[i, j] = 0;
                                    }
                                }
                            }
                            
                        }
                        if (j < Oszlopokszama - 1 &&j>1&& i >1)
                        {
                            if (Matrix[i, j] == 0)
                            {

                                if (Matrix[i + 1, j] == 1 || Matrix[i - 1, j] == 1 || Matrix[i + 1, j + 1] == 1 || Matrix[i - 1, j - 1] == 1 || Matrix[i, j + 1] == 1 || Matrix[i - 1, j + 1] == 1 || Matrix[i, j -1] == 1|| Matrix[i+1, j - 1] == 1)
                                {
                                    ujszamolo++;
                                    if (ujszamolo == 3)
                                    {
                                        ujmatrix[i, j] = 1;
                                    }
                                }

                            }

                       
                        }
                        
                    }
                    szamolo = 0;
                    ujszamolo = 0;
                }
                Matrix = ujmatrix;
            }
            public void Run()
            {
                megjelenit();
                KovetkezoAllapot();
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            EletjatekSzimulator asd = new EletjatekSzimulator(10,10);
            while (!Console.KeyAvailable)
            {
                asd.Run();
            }
        }
    }
}
