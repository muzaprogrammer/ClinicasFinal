using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CatalogoMedicamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            gvMedicamentos.DataSource = Datos.LlenarGridMedicamentos().Tables[0];
            gvMedicamentos.DataBind();
        }
        catch
        {
            //Response.Redirect("Usuarios.aspx");
        }
    }

    
}