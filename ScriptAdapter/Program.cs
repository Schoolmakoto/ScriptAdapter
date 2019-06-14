using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
 
namespace ScriptAdapter
{
    class Program
    {
        static int Main(string[] args)
        {
            string textFile;
            string dbNameOld = " wynk\\.";
            string dbnameOldbrackets = " \\[wynk\\]\\.";
            string dbnameNew;

            string dbnameNewAuth;
            string dbNameOldAuth = " wynk_auth.";
            string dbnameOldAuthBrackets = " \\[wynk_auth\\].";

            if (args.Length == 0 || !File.Exists(args[2]))
            {
                System.Console.WriteLine("Entre com os parâmetros [Nome novo Wynk] [Nome novo Wynk_auth] [Caminho do Arquivo]");
                return 0;
            }
            else {

                textFile = args[2];
                dbnameNew = " [" + args[0] + "].";
                dbnameNewAuth = " [" + args[1] + "].";
            }
            try
            {
                var content = string.Empty;
                using (StreamReader reader = new StreamReader(textFile, Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }

              content = Regex.Replace(content, dbNameOld, dbnameNew);
              content = Regex.Replace(content, dbnameOldbrackets, dbnameNew);

              content = Regex.Replace(content, dbNameOldAuth, dbnameNewAuth, RegexOptions.Singleline); 
              content = Regex.Replace(content, dbnameOldAuthBrackets, dbnameNewAuth, RegexOptions.Singleline);
                

                using (StreamWriter writer = new StreamWriter(textFile,false,Encoding.UTF8))
                {
                    writer.Write(content);
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return 1;
        }
    }
}
