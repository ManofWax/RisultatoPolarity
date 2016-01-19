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
        static GestoreFile Input = new GestoreFile("1_7_massansc", "txt");
        static GestoreFile InputLess4 = new GestoreFile(Input.NomeConEstensione, "less4");
        static GestoreFile InputRnnlm = new GestoreFile("TESTRES", "txt");
        static GestoreFile InputBOW = new GestoreFile("BOW", "txt");
        //static string OUTPUT_PATH = PATH + @"output.txt";
        //static string BASELINE_PATH = PATH + @"baseline.txt";
        //static string TEST_PATH = PATH + @"TESTRES.txt";
        static GestoreFile OutputXLS = new GestoreFile(Input.Nome, "xlsx");

        static void Main(string[] args)
        {
            ProcessaRes pRes = new ProcessaRes();
            ProcessaRes baseLineRes = new ProcessaRes();
            ProcessaRes bowRes = new ProcessaRes();

            //pRes.SeparaGiorni();
            //Calcolo test + cbow
            string[] lines = File.ReadAllLines(InputRnnlm.PathFrom);
            pRes.Process(lines);
            lines = File.ReadAllLines(InputLess4.PathFrom);
            pRes.Cbow(lines);

            //Calcolo BOW
            lines = File.ReadAllLines(InputBOW.PathFrom);
            bowRes.ProcessBow(lines);

            //Calcolo baseline
            lines = File.ReadAllLines(Input.PathFrom);
            baseLineRes.Cbow(lines);
            lines = File.ReadAllLines(InputLess4.PathFrom);
            baseLineRes.Cbow(lines);
            //Sposta Directory

            StampaExcel stampa = new StampaExcel();
            stampa.CreaExcel(pRes.giornata, baseLineRes.giornata, bowRes.giornata, OutputXLS.PathFrom);
            //Sposta i files
            //if(!Directory.Exists(PATH_RISULTATI_DIR))
            //{
            //    Directory.CreateDirectory(PATH_RISULTATI_DIR);
            //}
            //SpostaFile(TEST_PATH, PATH_RISULTATI_DIR + "")
            
            //string path = PATH + NOMEFILE
            Console.ReadKey();
        }

        static void SpostaFile(string pathFrom, string pathTo)
        {
            if (File.Exists(pathTo))
                File.Delete(pathTo);
            File.Move(pathFrom, pathTo);
        }
        static void ContaOccorenze()
        {
            ProcessaRes pRes = new ProcessaRes();
            string[] lines = File.ReadAllLines(Input.PathFrom);
            pRes.ContaEmoticons(lines);
            Console.WriteLine("Emoticons positive {0} Negative {1} righe totali {2}", pRes.numPos, pRes.numNeg, pRes.numRighe);
            //baseLineRes.Cbow(lines);
            lines = File.ReadAllLines(InputLess4.PathFrom);
            pRes.ContaEmoticons(lines);
            Console.WriteLine("Emoticons positive {0} Negative {1} righe totali {2}", pRes.numPos, pRes.numNeg, pRes.numRighe);
        }
    }
}
