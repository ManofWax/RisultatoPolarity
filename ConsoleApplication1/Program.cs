using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static string NOMEFILE = @"1_6_amazhs.txt";
        static string NOMEFILELESS = NOMEFILE + @"less4";
        static string OUTPUT_PATH = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\output.txt";
        static string BASELINE_PATH = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\baseline.txt";
        static string PATH = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\";

        static void Main(string[] args)
        {
            ProcessaRes pRes = new ProcessaRes();
            ProcessaRes baseLineRes = new ProcessaRes();

            //pRes.SeparaGiorni();
            string[] lines = File.ReadAllLines(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\TESTRES.txt");
            pRes.Process(lines);
            lines = File.ReadAllLines(PATH + NOMEFILELESS);
            pRes.Cbow(lines);
            pRes.StampaRisultato(OUTPUT_PATH);

            //Calcolo baseline
            lines = File.ReadAllLines( PATH + NOMEFILE);
            baseLineRes.Cbow(lines);
            lines = File.ReadAllLines(PATH + NOMEFILELESS);
            baseLineRes.Cbow(lines);
            baseLineRes.StampaRisultato(BASELINE_PATH);
            //Sposta Directory

            //Termina
            Console.ReadKey();
        }

        static void ContaOccorenze()
        {
            ProcessaRes pRes = new ProcessaRes();
            string[] lines = File.ReadAllLines(PATH + NOMEFILE + @".txt");
            pRes.ContaEmoticons(lines);
            Console.WriteLine("Emoticons positive {0} Negative {1} righe totali {2}", pRes.numPos, pRes.numNeg, pRes.numRighe);
            //baseLineRes.Cbow(lines);
            lines = File.ReadAllLines(PATH + NOMEFILE + @".txt.less4");
            pRes.ContaEmoticons(lines);
            Console.WriteLine("Emoticons positive {0} Negative {1} righe totali {2}", pRes.numPos, pRes.numNeg, pRes.numRighe);
        }
    }
}
