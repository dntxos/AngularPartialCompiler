using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularPartialCompiler
{
    public class cPartial
    {
        public string PartialName { get; set; }
        public string PartialPath { get; set; }
        public string PartialHtml { get; set; }

        public static cPartial CreateFromFile(FileInfo partialFile)
        {
            cPartial ret = new cPartial
            {
                PartialHtml = File.ReadAllText(partialFile.FullName),
                PartialName = partialFile.Name.Replace(".", ""),
                PartialPath=partialFile.FullName
            };
            return ret;
        }
    }
}
