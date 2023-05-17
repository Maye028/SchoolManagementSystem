﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
   
    public partial class AddClass : System.Web.UI.Page
    {
        private CommonFnx fn = new CommonFnx();
        private object lblMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetClass();
            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select Row_Number() over(Order by (Select 1)) as [Sr.No], ClassId,ClassName from Class");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("Select * from Class where ClassName='"+txtClass.Text.Trim()+"' ");
                if (dt.Rows.Count == 0) 
                {
                    string query = "Insert into Class Values('" + txtClass.Text.Trim() + "')";
                    fn.Query(query);
                    lblmsg.Text = "inserted Succesfully!";
                    lblmsg.CssClass = "alert alert-success";
                    txtClass.Text = string.Empty;
                    GetClass();
                }
                else
                {                   
                    lblmsg.Text = "Entered Class already!";
                    lblmsg.CssClass = "alert alert-danger";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message+"');</script>");
            }
            

           

        }
    }
}