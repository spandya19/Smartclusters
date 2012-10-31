using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Registration : System.Web.UI.Page
{
        MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=sweta;database=smartclusters");

    public void Page_Load(object sender, EventArgs e)
    {
        //con.Open();
        try
        {
            con.Open();

            Response.Write ("Connecting to MySQL...");
            
        }
        
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO smartclusters.registration (Fname, Lname, Email, Password, ConfirmPassword) VALUES(@Fname,@Lname,@Email,@Password,@ConfirmPassword)";
        cmd.Prepare();

        cmd.Parameters.AddWithValue("@Fname", TextBoxFN .Text);
        cmd.Parameters.AddWithValue("@Lname", TextBoxLN.Text);
        cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
        cmd.Parameters.AddWithValue("@Password", TextBoxPwd.Text);
        cmd.Parameters.AddWithValue("@ConfirmPassword", TextBoxCPwd.Text);
        try
        {
            
           int success=  cmd.ExecuteNonQuery();
            //insertUser.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
            //ex.Message("Unable to create a user.  Please try again later</b>");
            Response.Write(ex.Message);
            Response.Write("Unable to create a user.  Please try again later</b>");
        }
        //cmd.ExecuteNonQuery();

        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
   
}