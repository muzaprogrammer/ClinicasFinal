using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ActualizarMedicamento : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Datos.cadena);
    SqlDataReader dr = null;
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarMedicamentos();
        }
    }
    public void llenarMedicamentos()
    {
        medicamentoCodigo.DataSource = (Datos.listarMedicamentos());
        medicamentoCodigo.DataTextField = "nombre";
        medicamentoCodigo.DataValueField = "idMedicamento";
        medicamentoCodigo.DataBind();
    }

    protected void medicamentoCodigo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SELECT nombre,descripcion FROM Medicamentos WHERE idMedicamento = '" + medicamentoCodigo.SelectedValue + "'", cnn);
        cnn.Open();
        try
        {
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                txtNombre.Text = dr["nombre"].ToString();
                txtDescripcion.Text = dr["descripcion"].ToString();
            }

        }
        catch
        {

        }
        finally
        {
            cnn.Close();
        }
        
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            lblEstado.Text = "Escriba el nombre del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else if (string.IsNullOrEmpty(txtDescripcion.Text))
        {
            lblEstado.Text = "Escriba la descripcion del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else
        {
            if (Datos.EditMedicamento(txtNombre.Text, txtDescripcion.Text, Convert.ToInt32(medicamentoCodigo.SelectedValue)))
            {
                lblEstado.Text = "Medicamento actualizado con exito";
                lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                llenarMedicamentos();
            }
            else
            {
                lblEstado.Text = "Algo anda mal no se actualizo el registro...";
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
            }


        }
    }
}