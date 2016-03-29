using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise2_TwitterClone
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Creates connection to Database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProfileDB.mdf;Integrated Security=True";
            SqlConnection stat = new SqlConnection(connectionString);
            { 
            SqlCommand c = new SqlCommand("Insert into Status(Status) Values(@Status)", stat);
            c.Parameters.AddWithValue("@Status", TextBox1.Text);
            //Opens Connection
            stat.Open();
            c.ExecuteNonQuery();
            //Closes Connection
            stat.Close();

            if (IsPostBack)
            {
                //Sets text box back to blank after button press
                TextBox1.Text = "";
                //Refreshes Grid to show new status entry after button press
                this.GridView1.DataBind();
                }
            }
        }
    }
}