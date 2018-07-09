using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExistenciasArticulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            gvExistencias.DataSource = Datos.LlenarGridExistencias().Tables[0];
            gvExistencias.DataBind();
        }
        catch
        {
            //Response.Redirect("Usuarios.aspx");
        }
    }
}