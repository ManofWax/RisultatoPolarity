using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class StampaExcel
    {
        static string BASELINE = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\";

        public void CreaExcel(Dictionary<TimeSpan, Res> algoritmoRes, Dictionary<TimeSpan, Res> baselineRes, string outputFile)
        {
            using (SLDocument exl = new SLDocument(BASELINE + "template.xlsx"))
            {
                foreach (var sheet in new string[] { "Algoritmo", "Emoticons" })
                {
                    var valori = (sheet == "Algoritmo") ? algoritmoRes : baselineRes;
                    exl.SelectWorksheet(sheet);
                    int i = 2;
                    foreach (var g in valori)
                    {
                        exl.SetCellValue("A" + i, g.Key.ToString());
                        exl.SetCellValue("B" + i, g.Value.Pos);
                        exl.SetCellValue("C" + i, g.Value.Neg);
                        exl.SetCellValue("D" + i, g.Value.Neu);
                        exl.SetCellValue("E" + i, g.Value.Totale);
                        exl.SetCellValue("F" + i, g.Value.Pos - g.Value.Neg);
                        i++;
                    }
                }
                exl.SaveAs(outputFile);
            }
        }
    }
}
