using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AsignarMedicamentoC : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Datos.cadena);
    SqlDataReader dr = null;
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarMedicamentos();
            llenarClinica();
        }

    }
    public void llenarMedicamentos()
    {
        medicamentoCodigo.DataSource = (Datos.listarMedicamentos());
        medicamentoCodigo.DataTextField = "nombre";
        medicamentoCodigo.DataValueField = "idMedicamento";
        medicamentoCodigo.DataBind();
    }

    public void llenarClinica()
    {
        clinicaCodigo.DataSource = (Datos.listarClinicas());
        clinicaCodigo.DataTextField = "nombre";
        clinicaCodigo.DataValueField = "idClinica";
        clinicaCodigo.DataBind();
    }


    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCantidad.Text))
        {
            lblEstado.Text = "Escriba la cantidad del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else if (string.IsNullOrEmpty(txtPrecio.Text))
        {
            lblEstado.Text = "Escriba el precio del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else
        {
            string existenciaAnterior = "0";
            cmd = new SqlCommand("select existencia from ExistenciasMedicamentos where idMedicamento='" + medicamentoCodigo.SelectedValue + "' and idClinica='" + clinicaCodigo.SelectedValue + "'", cnn);
            cnn.Open();
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    existenciaAnterior = dr["existencia"].ToString();
                }
                else
                {
                    existenciaAnterior = "0";
                }

            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }


            if (Datos.InsertExistencia(Convert.ToInt32(medicamentoCodigo.SelectedValue), Convert.ToInt32(clinicaCodigo.SelectedValue), Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(existenciaAnterior)))
            {
                lblEstado.Text = "Existencia insertada con exito";
                lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                txtPrecio.Text = "";
                txtCantidad.Text = "";
                llenarMedicamentos();
                llenarClinica();
            }
            else
            {
                lblEstado.Text = "Algo anda mal no se actualizo el registro...";
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
            }
            
        }
    }
}