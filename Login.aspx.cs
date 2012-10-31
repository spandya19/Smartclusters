using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=sweta;database=smartclusters");
        con.Open();
        string cmdstr = "Select count(*) from Registration where Email = '" + TextBoxEmail.Text + "'";

        MySqlCommand checkuser = new MySqlCommand(cmdstr, con);
        int temp =  Convert.ToInt32(checkuser.ExecuteScalar().ToString());
       
        if (temp == 1)
        {
            string cmdstr2 = "Select Password from Registration where Email='" + TextBoxEmail.Text + "'";
            MySqlCommand pass = new MySqlCommand(cmdstr2, con);
            
            string password = pass.ExecuteScalar().ToString();
            if (password == TextBoxPwd.Text)
            {
                Session["New"] = TextBoxPwd.Text;
                Response.Write ("Welcome");
                //Response.Write("User Name Already exists<br/>.  Please choose another User Name");

            }
            else
            {
                Response .Write ("Invalid Password.Please try again");
            }
        }
        else
        {
            Response.Write ("Invalid UserName.Please try again");
        }

        
        
    }
}