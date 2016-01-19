using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GestoreFile
    {
        public string PathTo;
        public string PathFrom;
        public string Nome;
        public string NomeConEstensione;

        public GestoreFile(string path, string estensione)
        {
            Nome = path;
            NomeConEstensione = path +"." + estensione;
            PathTo = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\RisultatiPerGiorno";
            PathFrom = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\RisultatoPolarityTwitch\Files\";
        }
    }
}
