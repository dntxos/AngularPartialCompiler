using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularPartialCompiler.Properties;
using System.Diagnostics;
using System.IO;

namespace AngularPartialCompiler
{
    public class ApcTool
    {

        public static void header()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            Console.WriteLine("AngularPartialCompiler / " + assemblyName.Name + " - Ver.:" + version.ToString()+" by geraBytes (http://gerabytes.com.br)");
        }

        public static void Run()
        {
            header();
            Console.WriteLine(Resources.help);
            Console.WriteLine("\r\nPress any key to continue...");
            Console.Read();
        }

        public static void Run(string _output,string _path=".\\",string _filter = "view*.html",string _classname="_apc",string _module="App")
        {
            header();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;

            var _apc = new Apc(_path, _filter);
            var _tsData = "module "+_module+"{\r\n export class "+_classname+" {\r\n public static ver:string=\""+version.ToString()+"\";\r\n";
            foreach (var partial in _apc.Partials)
            {
                var _partialData = partial.PartialHtml.Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
                _tsData += "\r\n\r\n/** \r\n* Preview.Content:";
                _tsData += "\r\n*\""+ _partialData.PadRight(200,' ').Substring(0,200)+"\"...";
                _tsData += "\r\n**/";
                _tsData += "\r\npublic static " + partial.PartialName.Replace(".", "_").Replace(" ", "_")+":string=\"";
                _tsData += _partialData  +"\";";
            }
            _tsData += "\r\n} \r\n};";

            File.WriteAllText(_output, _tsData);
        }



    }
}
