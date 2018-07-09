using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearMedicamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text)){
            lblEstado.Text = "Escriba el nombre del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else if (string.IsNullOrEmpty(txtDescripcion.Text)){
            lblEstado.Text = "Escriba la descripcion del medicamento";
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }
        else{
            if (Datos.InsertMedicamento(txtNombre.Text, txtDescripcion.Text)){
                lblEstado.Text ="Medicamento ingresado con exito";
                lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                txtNombre.Text = "";
                txtDescripcion.Text = "";
            }
            else{
                lblEstado.Text = "Algo anda mal no se guardo el registro...";
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
            }
            

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
}