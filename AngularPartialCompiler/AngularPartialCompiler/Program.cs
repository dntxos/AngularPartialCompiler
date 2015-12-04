using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularPartialCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    ApcTool.Run(args[0]);
                    break;
                case 2:
                    ApcTool.Run(args[0], args[1]);
                    break;
                case 3:
                    ApcTool.Run(args[0], args[1], args[2]);
                    break;
                case 4:
                    ApcTool.Run(args[0], args[1], args[2],args[3]);
                    break;
                case 5:
                    ApcTool.Run(args[0], args[1], args[2], args[3],args[4]);
                    break;
                default:
                    ApcTool.Run();
                    break;
            }
        }
    }
}
