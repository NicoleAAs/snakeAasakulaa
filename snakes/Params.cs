using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snakes
{
    public class Params
    {
        private string resourcesFolder;
        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin", StringComparison.Ordinal);
            string binFolder = Directory.GetCurrentDirectory().ToString().ToString().Substring(0, ind).ToString();
            resourcesFolder = binFolder + "resources\\";
        }
        public string GetResourceFolder()
        {
            return resourcesFolder;
        }
    }
}
