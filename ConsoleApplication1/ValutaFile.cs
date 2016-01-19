using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ValutaFile
    {
        private string FileDaProcessare;
        private string FileOutput;
        private int skip;

        public ValutaFile(string path, int skipRighe)
        {
            FileDaProcessare = path;
            FileOutput = path + @".controllato";
            skip = skipRighe;
        }

        public void ProcessaFile()
        {
            string[] righe = File.ReadAllLines(FileDaProcessare);
            Console.WriteLine("Lunghezza file: " + righe.Count());
            using (var f = File.AppendText(FileOutput))
            {
                bool exit = false;
                for (int i = skip; i < righe.Count(); i++)
                {
                    var splits = righe[i].Split('\t');
                    Console.Clear();
                    Console.WriteLine(string.Format("{0}/{1}", i, righe.Count()));
                    Console.WriteLine(splits[1]);
                    var tasto = Console.ReadKey();
                    switch (tasto.KeyChar)
                    {
                        case 'a':
                            f.WriteLine("1 " + righe[i]);
                            break;
                        case 'e':
                            f.WriteLine("-1 " + righe[i]);
                            break;
                        case 'o':
                            f.WriteLine("0 " + righe[i]);
                            break;
                        default:
                            Console.WriteLine("Salvataggio.");
                            exit = true;
                            break;
                    }
                    if (exit)
                        break;
                }
            }
        }
    }
}
