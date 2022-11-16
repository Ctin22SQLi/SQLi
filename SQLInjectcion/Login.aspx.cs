using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SQLInjectcion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = usuario.Value, pass = password.Value;
            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conDefault"].ConnectionString.ToString()))
            {
                cn.Open();

                string query = @"SELECT * FROM USERS WHERE USER = '" + user + "' AND PASSWORD = '" + pass + "';";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ///////////////////
                //string query = @"SELECT * FROM USERS WHERE USER = @user AND PASSWORD = @pass;";
                //SqlCommand cmd = new SqlCommand(query, cn);
                //cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                //cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

                //SqlDataReader dr = cmd.ExecuteReader();
                /////////////////


                //SqlCommand cmd = new SqlCommand("sp_Login", cn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter paramUsuario = new SqlParameter();
                //SqlParameter paramPassword = new SqlParameter();

                //paramUsuario = cmd.Parameters.Add("@user", SqlDbType.VarChar, 50);
                //paramUsuario.Direction = ParameterDirection.Input;
                //paramUsuario.Value = user;

                //paramPassword = cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
                //paramPassword.Direction = ParameterDirection.Input;
                //paramPassword.Value = pass;

                //SqlDataReader dr = cmd.ExecuteReader();

                bool userExist = false;

                if (dr.Read())
                {
                    userExist = true;
                }

                if (userExist)
                {
                    Response.Redirect("Index.aspx", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
             "alert",
             "alert('Usuario o password incorrectos.');",
             true);
                    return;
                }
                cn.Close();
            }
        }
    }
}