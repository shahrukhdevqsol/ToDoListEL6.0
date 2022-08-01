using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityClassLibrary;
using BALClassLibrary;

namespace ProductCatalog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                BindCategory();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtProductName.Text.ToString()))
            {
                ListTable ListTableObj = new ListTable();
                ListTableObj.Description = txtProductName.Text.ToString();
                ListTableObj.ItemPosition = 1;
                ListTableObj.IsDone = 1;
                ListTableObj.ListColor = 1;
                ListTableObj.CreateDt = System.DateTime.Now;
                try
                {
                    ListTableBAL.InsertListTable(ListTableObj);
                    lblMesg.Text = "Insert SucessFully";
                    BindGrid();
                }catch(Exception ex)
                {
                    lblMesg.Text = ex.Message.ToString();
                }
               
            }
        }
        public void BindGrid()
        {
            grdData.DataSource = ListTableBAL.GetAllProducts();
            grdData.DataBind();
        }
        public void BindCategory()
        {

            //ddlCategory.DataSource = ListTableBAL.GetAllCategory();
            //ddlCategory.DataValueField = "CategoryID";
            //ddlCategory.DataTextField = "CategoryName";
            //ddlCategory.DataBind();
        }

    }
}