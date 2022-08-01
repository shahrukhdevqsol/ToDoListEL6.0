using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALClassLibrary;
using EntityClassLibrary;

namespace BALClassLibrary
{
    public static class ListTableBAL
    {
        public static void InsertListTable(ListTable ListTableObj)
        {
            ListTableDAL.InsertListTable(ListTableObj);
        }
        public static List<ListTable> GetAllProducts()
        {
            return ListTableDAL.GetAllList();
        }
        /*public static List<Category> GetAllCategory()
        {
            //return ListTableDAL.GetAllCategoryList();
        }*/
    }
}
