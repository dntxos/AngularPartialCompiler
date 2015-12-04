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
            Console.WriteLine("AngularPartialCompiler / " + assemblyName.Name + " - Ver.:" + version.ToString());
        }

        public static void Run()
        {
            header();
            Console.WriteLine(Resources.help);
            Console.WriteLine("\r\nPress any key to continue...");
            Console.Read();
        }

        public static void Run(string _output,string _path=".\\",string _filter = "view*.html",string _classname="_apc")
        {
            header();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;

            var _apc = new Apc(_path, _filter);
            var _tsData = "export class _apc {\r\n public static ver:string=\""+version.ToString()+"\";\r\n";
            foreach (var partial in _apc.Partials)
            {
                _tsData += "\r\n\r\n public static " + partial.PartialName.Replace(".", "_").Replace(" ", "_")+":string=\"";
                _tsData += partial.PartialHtml.Replace("\"", "\\\"").Replace("\r","\\r").Replace("\n","\\n")  +"\";";
            }
            _tsData += "}";

            File.WriteAllText(_output, _tsData);
        }



    }
}
