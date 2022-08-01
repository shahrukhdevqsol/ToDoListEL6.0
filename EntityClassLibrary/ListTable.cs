using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityClassLibrary
{
    public class ListTable
    {
        public Int32? ListItemId { get; set; }
        public string Description { get; set; }
        public int IsDone { get; set; }
        public int ItemPosition { get; set; }

        public int ListColor { get; set; }
        public DateTime CreateDt { get; set; }
    }

}
