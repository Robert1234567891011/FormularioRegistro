using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class Pagina : System.Web.UI.Page
    {
        GridView grilla;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Consultar()
        {
            using (PersonaClient cliente=new PersonaClient()) {
                
                grilla.DataSource = cliente.Consultar(); 
                grilla.DataBind();

            }

        }
        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }
    }
}