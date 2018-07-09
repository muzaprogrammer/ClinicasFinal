using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Datos
/// </summary>
public static class Datos
{
    static public string cadena = "Data Source=PROGRAMMERPC;Initial Catalog=clinica;Integrated Security=True";
    static private string consulta = "";
    static string consult = "";
    static private SqlConnection cn = new SqlConnection(cadena);
    static private SqlCommand cmd;
    private static DataSet ds;
    private static DataTable da;
    private static SqlDataAdapter dap;

    public static bool InsertMedicamento(string nombre, string descripcion)
    {
        bool result; 
        consult = "insert into Medicamentos (nombre,descripcion) values (@nombre, @descripcion)";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@descripcion", descripcion);
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }

    public static bool EditMedicamento(string nombre, string descripcion, int idMedicamento)
    {
        bool result;
        consult = "update Medicamentos set nombre = @nombre, descripcion = @descripcion where idMedicamento = @idMedicamento";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@descripcion", descripcion);
        cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }

    public static bool DeleteMedicamento(int idMedicamento)
    {
        bool result;
        consult = "delete from Medicamentos where idMedicamento = @idMedicamento";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }

    public static bool InsertExistencia(int medicamento, int clinica, int cantidad, double precio, int existencia)
    {
        bool result = false;
        int num = 0;
        consult = "select count(*) from ExistenciasMedicamentos where idMedicamento=@idMedicamento and idClinica=@idClinica";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
        cmd.Parameters.AddWithValue("@idClinica", clinica);
        try
        {
            cn.Open();
            num = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();            
            if (num == 0)
            {
                consult = "insert ExistenciasMedicamentos (idMedicamento, idClinica, existencia, precio) values (@idMedicamento, @idClinica, @existencia, @precio)";
                cmd = new SqlCommand(consult, cn);
                cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
                cmd.Parameters.AddWithValue("@idClinica", clinica);
                cmd.Parameters.AddWithValue("@existencia", cantidad);
                cmd.Parameters.AddWithValue("@precio", precio);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }

                
            }
            else if (num == 1)
            {
                consult = "update ExistenciasMedicamentos set existencia = @existencia, precio = @precio where idMedicamento=@idMedicamento and idClinica=@idClinica";
                cmd = new SqlCommand(consult, cn);
                cmd.Parameters.AddWithValue("@existencia", cantidad + existencia);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
                cmd.Parameters.AddWithValue("@idClinica", clinica);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }

            consult = "insert DistribucionMedicamentos (idMedicamento, idClinica, cantidad, precio) values (@idMedicamento, @idClinica, @existencia, @precio)";
            cmd = new SqlCommand(consult, cn);
            cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
            cmd.Parameters.AddWithValue("@idClinica", clinica);
            cmd.Parameters.AddWithValue("@existencia", cantidad);
            cmd.Parameters.AddWithValue("@precio", precio);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
        }
        catch
        {
            result = false;
        }

                
        return result;
    }

    public static bool UpdateExistencia(int medicamento, int clinica, int cantidad, double precio)
    {
        bool result = false;
        consult = "update ExistenciasMedicamentos set existencia = @existencia, precio = @precio where idMedicamento=@idMedicamento and idClinica=@idClinica";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@existencia", cantidad);
        cmd.Parameters.AddWithValue("@precio", precio);
        cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
        cmd.Parameters.AddWithValue("@idClinica", clinica);
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }


        return result;
    }

    public static bool DeleteExistencia(int medicamento, int clinica)
    {
        bool result = false;
        consult = "delete from ExistenciasMedicamentos where idMedicamento=@idMedicamento and idClinica=@idClinica";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@idMedicamento", medicamento);
        cmd.Parameters.AddWithValue("@idClinica", clinica);
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }


        return result;
    }


    public static DataSet listarMedicamentos()
    {
        cn = new SqlConnection(cadena);
        string consult = "select idMedicamento, concat('Codigo: ', idMedicamento,' // Medicamento: ',nombre) as nombre from Medicamentos order by nombre asc ";
        cmd = new SqlCommand(consult, cn);
        dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        ds = new DataSet();
        cn.Open();
        dap.Fill(ds);
        cn.Close();
        return ds;

    }

    public static DataSet listarMedicamentos2(int clinica)
    {
        cn = new SqlConnection(cadena);
        string consult = "select Medicamentos.idMedicamento, concat('Codigo: ', Medicamentos.idMedicamento,' // Medicamento: ',nombre) as nombre from Medicamentos inner join ExistenciasMedicamentos on Medicamentos.idMedicamento = ExistenciasMedicamentos.idMedicamento where idClinica = @idClinica order by nombre asc ";
        cmd = new SqlCommand(consult, cn);
        cmd.Parameters.AddWithValue("@idClinica", clinica);
        dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        ds = new DataSet();
        cn.Open();
        dap.Fill(ds);
        cn.Close();
        return ds;

    }

    public static DataSet listarClinicas()
    {
        cn = new SqlConnection(cadena);
        string consult = "select idClinica, nombre from Clinica order by nombre asc ";
        cmd = new SqlCommand(consult, cn);
        dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        ds = new DataSet();
        cn.Open();
        dap.Fill(ds);
        cn.Close();
        return ds;

    }

    public static DataSet LlenarGridMedicamentos()
    {
        consulta = "select idMedicamento as Codigo, nombre as Nombre, descripcion as Descripcion, fechaRegistro as Fecha_Ingresado from Medicamentos";
        SqlDataAdapter da = new SqlDataAdapter();
        cmd = new SqlCommand(consulta, cn);
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        cn.Open();
        da.Fill(ds);
        cn.Close();
        return ds;
    }

    public static DataSet LlenarGridExistencias()
    {
        consulta = "select Clinica.nombre as Clinica, Medicamentos.nombre as Medicamento, descripcion as Descripcion, ExistenciasMedicamentos.existencia as Existencia, ExistenciasMedicamentos.precio as Precio, ExistenciasMedicamentos.fechaRegistro as Fecha_Ingresado from Medicamentos inner join ExistenciasMedicamentos on Medicamentos.idMedicamento = ExistenciasMedicamentos.idMedicamento inner join Clinica on ExistenciasMedicamentos.idClinica = Clinica.idClinica order by Clinica.nombre asc";
        SqlDataAdapter da = new SqlDataAdapter();
        cmd = new SqlCommand(consulta, cn);
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        cn.Open();
        da.Fill(ds);
        cn.Close();
        return ds;
    }

}