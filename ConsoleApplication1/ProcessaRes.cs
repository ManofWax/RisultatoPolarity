using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ProcessaRes
    {
        public Dictionary<TimeSpan, Res> giornata = new Dictionary<TimeSpan, Res>();
        public int numRighe { get; set; }
        public int numPos { get; set; }
        public int numNeg { get; set; }

        public ProcessaRes()
        {
            //Inizializzo il vettore dei risultati
            for (TimeSpan i = new TimeSpan(0, 0, 0); i < new TimeSpan(23, 59, 59); i = i.Add(new TimeSpan(0, 5, 0)))
            {
                giornata[i] = new Res();
            }
        }

        internal void Cbow(string[] lines)
        {
            List<string> p = new List<string>{ "kappa", "4head", "elegiggle", "kappapride", "kreygasm", "heyguys", "anele" };
            List<string> n = new List<string>{ "residentsleeper", "pjsalt","wutface","notlikethis","failfish","biblethump", "dansgame","babyrage" };
            foreach(var l in lines)
            {
                string[] splits = l.Split(' ');
                TimeSpan tempo = GetTimeSpan(FromUNIX(splits[0]));
                    int tmp = 0;
                foreach(var i in p)
                {
                    if (l.Contains(i))
                        tmp++;
                }
                foreach(var i in n)
                {
                    if (l.Contains(i))
                        tmp--;
                }
                if (tmp >= 1)
                {
                    giornata[tempo].Pos++;
                }
                else if(tmp == 0)
                {
                    giornata[tempo].Neu++;
                }
                else
                {
                    giornata[tempo].Neg++;
                }
            }
        }

        public DateTime FromUNIX(string seconds)
        {
            DateTime date = new DateTime(1970, 1, 1).AddSeconds(int.Parse(seconds));
            return date;
        }

        public TimeSpan GetTimeSpan(DateTime date)
        {
            int minutiApprossimati = date.Minute / 5;
            return new TimeSpan(date.Hour, minutiApprossimati * 5, 0);
        }

        public void Process(string[] lines)
        {
            foreach (var l in lines)
            {
                string[] splits = l.Split('\t');
                TimeSpan tempo = GetTimeSpan(FromUNIX(splits[0]));
                int res = int.Parse(splits[1]);
                if (res == 1)
                {
                    giornata[tempo].Pos++;
                }
                else
                {
                    giornata[tempo].Neg++;
                }
            }
        }

        public void StampaRisultato(string path)
        {
            using (var f = new StreamWriter(path))
            {
                foreach (var g in giornata)
                {
                    f.WriteLine(g.Key.ToString() + ";" + g.Value.ToString());
                }
            }
        }

        public void SeparaGiorni()
        {
            //kripp
            separaGiorni(@"kripp.txt");
            //amazhs
            separaGiorni(@"amazhs.txt");
            //destiny
            separaGiorni(@"destiny.txt");
            //massansc
            separaGiorni(@"massansc.txt");
        }

        private void separaGiorni(string fileName)
        {
            Dictionary<DateTime, string> filePerGiorno = new Dictionary<DateTime, string>();
            string path = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\";

            //kripp
            string[] lines = File.ReadAllLines(path + fileName);
            foreach (var l in lines)
            {
                string data = l.Substring(0,10);
                DateTime t = FromUNIX(data);
                if (filePerGiorno.ContainsKey(t.Date))
                {
                    filePerGiorno[t.Date] += l + Environment.NewLine;
                }
                else
                {
                    Console.WriteLine("Processo giorno " + t.Date.ToString() + " per " + fileName);
                    filePerGiorno.Add(t.Date, l+Environment.NewLine);
                }
            }

            foreach(var f in filePerGiorno)
            {
                File.WriteAllText(path + f.Key.Date.Month + @"_" + f.Key.Date.Day + @"_" + fileName, f.Value);
            }
        }

        public void ContaEmoticons(string[] lines)
        {
            List<string> p = new List<string> { "kappa", "4head", "elegiggle", "kappapride", "kreygasm", "heyguys", "anele" };
            List<string> n = new List<string> { "residentsleeper", "pjsalt", "wutface", "notlikethis", "failfish", "biblethump", "dansgame", "babyrage" };
            foreach (var l in lines)
            {
                foreach (var i in p)
                {
                    if (l.Contains(i))
                    {
                        numPos++;
                        continue;
                    }

                }
                foreach (var i in n)
                {
                    if (l.Contains(i))
                    {
                        numNeg++;
                        continue;
                    }
                }
            }
            numRighe += lines.Count();
        }
    }
}
