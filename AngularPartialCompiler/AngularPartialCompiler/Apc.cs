using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularPartialCompiler
{
    public class Apc
    {
        public List<cPartial> Partials { get; set; }

        public Apc(string rootPath="",string filter="")
        {
            if (String.IsNullOrEmpty(rootPath))
            {
                rootPath = ".";
            }
            if (String.IsNullOrEmpty(filter))
            {
                filter = "iview*.html";
            }

            var _dRoot = new DirectoryInfo(rootPath);
            var _fPartials=_dRoot.GetFiles(filter, SearchOption.AllDirectories);

            this.Partials = new List<cPartial>();
            foreach (var _fPartial in _fPartials)
            {
                this.Partials.Add(cPartial.CreateFromFile(_fPartial));
            }
        }

    }
}
