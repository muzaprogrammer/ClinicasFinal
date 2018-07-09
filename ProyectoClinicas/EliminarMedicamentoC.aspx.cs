using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EliminarMedicamentoC : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Datos.cadena);
    SqlDataReader dr = null;
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarClinica();
            llenarMedicamentos();
        }
    }

    protected void clinicaCodigo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarMedicamentos();
        datosMedicamento();
    }

    protected void medicamentoCodigo_SelectedIndexChanged(object sender, EventArgs e)
    {
        datosMedicamento();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (Datos.DeleteExistencia(Convert.ToInt32(medicamentoCodigo.SelectedValue), Convert.ToInt32(clinicaCodigo.SelectedValue)))
        {
            lblEstado.Text = "Existencia eliminada con exito";
            lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            llenarMedicamentos();
            llenarClinica();
        }
        else
        {
            lblEstado.Text = "Algo anda mal no se elimino el registro...";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
    }
    public void llenarClinica()
    {
        clinicaCodigo.DataSource = (Datos.listarClinicas());
        clinicaCodigo.DataTextField = "nombre";
        clinicaCodigo.DataValueField = "idClinica";
        clinicaCodigo.DataBind();
    }

    public void llenarMedicamentos()
    {
        medicamentoCodigo.DataSource = (Datos.listarMedicamentos2(Convert.ToInt32(clinicaCodigo.SelectedValue)));
        medicamentoCodigo.DataTextField = "nombre";
        medicamentoCodigo.DataValueField = "idMedicamento";
        medicamentoCodigo.DataBind();
    }

    public void datosMedicamento()
    {
        cmd = new SqlCommand("select existencia,precio from ExistenciasMedicamentos where idMedicamento='" + medicamentoCodigo.SelectedValue + "' and idClinica='" + clinicaCodigo.SelectedValue + "'", cnn);
        cnn.Open();
        try
        {
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                txtCantidad.Text = dr["existencia"].ToString();
                txtPrecio.Text = dr["precio"].ToString();
            }
            else
            {

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

}