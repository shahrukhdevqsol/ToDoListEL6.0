using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using EntityClassLibrary;
using UtilityClassLibrary;
using System.Data.Common;
using System.Data;

namespace DALClassLibrary
{
    public static class ListTableDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListTableObj"></param>
        public static void InsertListTable(ListTable ListTableObj)
        {
            Database database = null;
            DbCommand dbCommand = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                database = factory.Create(DataBaseConstat.ConnectionString);
                dbCommand = database.GetStoredProcCommand(DataBaseConstat.UspInsertList);
                database.AddInParameter(dbCommand,DataBaseConstat.Description,DbType.String, ListTableObj.Description);
                database.AddInParameter(dbCommand, DataBaseConstat.IsDone, DbType.Int32, ListTableObj.IsDone);
                database.AddInParameter(dbCommand, DataBaseConstat.ItemPosition, DbType.Int32, ListTableObj.ItemPosition);
                database.AddInParameter(dbCommand, DataBaseConstat.ListColor, DbType.Int32, ListTableObj.ListColor);
                database.AddInParameter(dbCommand, DataBaseConstat.CreateDt, DbType.DateTime, ListTableObj.CreateDt);

                database.ExecuteNonQuery(dbCommand);
            }catch(Exception ex)
            {
                throw ex;
            }finally
            {
                database = null;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ListTable> GetAllList()
        {
            Database database;
            DbCommand dbCommand;
            List<ListTable> ListTable = null;
            ListTable = new List<ListTable>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            database = factory.Create(DataBaseConstat.ConnectionString);
            dbCommand = database.GetStoredProcCommand(DataBaseConstat.UspSelectList);
            using (IDataReader objReader = database.ExecuteReader(dbCommand))
            {
                ListTable = CreateListTable(objReader);
            }
            if (ListTable == null)
                return null;
            else
                return ListTable;
        }
        private static List<ListTable> CreateListTable(IDataReader objReader)
        {
            List<ListTable> productList = new List<ListTable>();
            ListTable listTable;
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                listTable = new ListTable();
                listTable.ListItemId = objReader[DataBaseConstat.ListItemID] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.ListItemID]) : listTable.ListItemId = null;
                listTable.Description = objReader[DataBaseConstat.Description] != DBNull.Value ?
                Convert.ToString(objReader[DataBaseConstat.Description]) : listTable.Description = null;
                listTable.IsDone = objReader[DataBaseConstat.IsDone] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.IsDone]) : listTable.IsDone = 0;
                listTable.ItemPosition = objReader[DataBaseConstat.ItemPosition] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.ItemPosition]) : listTable.ItemPosition = 1;
                //listTable.ListColor = objReader[DataBaseConstat.ListColor] != DBNull.Value ?
                //Convert.ToInt32(objReader[DataBaseConstat.ListColor]) : listTable.ListColor = 1;
                listTable.CreateDt = objReader[DataBaseConstat.CreateDt] != DBNull.Value ?
                Convert.ToDateTime(objReader[DataBaseConstat.CreateDt]) : listTable.CreateDt = System.DateTime.Now;


                productList.Add(listTable);

            }
            if (isnull) return null;
            else return productList;
        }
        public static ListTable ListTableDetail()
        {
            Database database;
            DbCommand dbCommand;
            ListTable ListTableDetail = null;

            ListTableDetail = new ListTable();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            database = factory.Create(DataBaseConstat.ConnectionString);
            dbCommand = database.GetStoredProcCommand(DataBaseConstat.UspSelectList);
            using (IDataReader objReader = database.ExecuteReader(dbCommand))
            {
                ListTableDetail = CreateListTableDetail(objReader);
            }
            if (ListTableDetail == null)
                return null;
            else
                return ListTableDetail;
        }
        private static ListTable CreateListTableDetail(IDataReader objReader)
        {

            ListTable listTable =null;
            bool isnull = true;
            while (objReader.Read())
            {
                isnull = false;
                listTable = new ListTable();
                listTable.ListItemId = objReader[DataBaseConstat.ListItemID] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.ListItemID]) : listTable.ListItemId = null;
                listTable.Description = objReader[DataBaseConstat.Description] != DBNull.Value ?
                Convert.ToString(objReader[DataBaseConstat.Description]) : listTable.Description = null;
                listTable.IsDone = objReader[DataBaseConstat.IsDone] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.IsDone]) : listTable.IsDone = 0;
                listTable.ItemPosition = objReader[DataBaseConstat.ItemPosition] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.ItemPosition]) : listTable.ItemPosition = 1;
                listTable.ListColor = objReader[DataBaseConstat.ListColor] != DBNull.Value ?
                Convert.ToInt32(objReader[DataBaseConstat.ListColor]) : listTable.ListColor = 1;
                listTable.CreateDt = objReader[DataBaseConstat.CreateDt] != DBNull.Value ?
                Convert.ToDateTime(objReader[DataBaseConstat.CreateDt]) : listTable.CreateDt = System.DateTime.Now;
            }
            if (isnull) return null;
            else return listTable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
    }
}
