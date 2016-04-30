using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsftLibaryCrawler
{

    public class SubItem
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string ToolTip { get; set; }
        public Extendedattributes ExtendedAttributes { get; set; }
    }

    public class Extendedattributes
    {
        public string datatochassubtree { get; set; }
        public string datamtpsaliasid { get; set; }
        public string datamtpsassetid { get; set; }
        public string datamtpsshortid { get; set; }
    }

}
