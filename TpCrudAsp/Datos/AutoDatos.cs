using TpCrudAsp.Models;
using System.Data.SqlClient;
using System.Data;

namespace TpCrudAsp.Datos;


public class AutoDatos
{
    //Read}
    public List<ModelAutos> Listar()
    {
        var oLista = new List<ModelAutos>(); //creo el modelo Lista

        var cn = new Conexion(); //instancio la conexion
        using (var conexion = new SqlConnection(cn.GetCadenaSql())) // le agregamos la conexion por parametro
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand("ListarAutos", conexion); // traemos el StoreProcedure Listar
            cmd.CommandType = CommandType.StoredProcedure; //ejecutamos el SP

            using (var dr = cmd.ExecuteReader()) // traemos todos los datos
            {
                while (dr.Read()) // leemos todos los datos de la base de datos
                {
                    oLista.Add(new ModelAutos() // agregamos a la lista ModelCliente
                    {
                        idAuto = Convert.ToInt32(dr["idAuto"]), // convertimos los datos a string para mostrar en la vista
                        marca = dr["marca"].ToString(),
                        modelo = dr["modelo"].ToString(),
                        patente = dr["patente"].ToString(),
                        precio = dr["precio"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        img = dr["img"].ToString()
                    });
                }
            }
            conexion.Close(); // cerramos la conexion
        }
        return oLista; // retornamos la lista
    }
    //Read by
    public ModelAutos Obtener(int id)
    {
        var oAuto = new ModelAutos();
        var cn = new Conexion();

        using (var conexion = new SqlConnection(cn.GetCadenaSql()))
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand("ObtenerAutos", conexion);
            cmd.Parameters.AddWithValue("idAuto", id);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oAuto.idAuto = Convert.ToInt32(dr["idAuto"]);
                    oAuto.marca = dr["marca"].ToString();
                    oAuto.modelo = dr["modelo"].ToString();
                    oAuto.patente = dr["patente"].ToString();
                    oAuto.precio = dr["precio"].ToString();
                    oAuto.descripcion = dr["descripcion"].ToString();
                    oAuto.img = dr["img"].ToString();

                }
            }
            conexion.Close();
        }
        return oAuto;
    }    

    public bool Guardar(ModelAutos oAuto)
    {
        bool respuesta;

        try
        {
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("GuardarAutos", conexion);

                //cmd.Parameters.AddWithValue("idAuto",oAuto.idAuto);
                cmd.Parameters.AddWithValue("marca", oAuto.marca);
                cmd.Parameters.AddWithValue("modelo", oAuto.modelo);
                cmd.Parameters.AddWithValue("patente", oAuto.patente);
                cmd.Parameters.AddWithValue("precio", oAuto.precio);
                cmd.Parameters.AddWithValue("descripcion", oAuto.descripcion);
                cmd.Parameters.AddWithValue("img", oAuto.img);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conexion.Close();
            }
            respuesta = true;

        }
        catch (Exception e)
        {

            string error = e.Message;
            respuesta = false;

        }
        return respuesta;
    }

    public bool Editar(ModelAutos oAuto)
    {
        bool respuesta;
        try
        {
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("EditarAutos", conexion);

                cmd.Parameters.AddWithValue("idAuto", oAuto.idAuto);
                cmd.Parameters.AddWithValue("marca", oAuto.marca);
                cmd.Parameters.AddWithValue("modelo", oAuto.modelo);
                cmd.Parameters.AddWithValue("patente", oAuto.patente);
                cmd.Parameters.AddWithValue("precio", oAuto.precio);
                cmd.Parameters.AddWithValue("descripcion", oAuto.descripcion);
                cmd.Parameters.AddWithValue("img", oAuto.img);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            respuesta = true;
        }
        catch (Exception e)
        {
            string error = e.Message;
            respuesta = false;
        }
        return respuesta;
    }

    public bool Eliminar(int id)
    {
        bool respuesta;
        try
        {
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("EliminarAutos", conexion);

                cmd.Parameters.AddWithValue("idAuto", id);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                conexion.Close();
            }
            respuesta = true;
        }
        catch (Exception e)
        {

            string error = e.Message;
            respuesta = false;
        }
        return respuesta;
    }

    public List<ModelAutos> BuscarAuto(string buscar)
    {
        var oLista = new List<ModelAutos>(); 


        var cn = new Conexion(); 
        using (var conexion = new SqlConnection(cn.GetCadenaSql())) 
        {
            conexion.Open();
           
            SqlCommand cmd = new SqlCommand("BuscarAuto", conexion);
            cmd.Parameters.AddWithValue("@marca", buscar);
            cmd.CommandType = CommandType.StoredProcedure;
            
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLista.Add(new ModelAutos()
                    {
                        idAuto = Convert.ToInt32(dr["idAuto"]),
                        marca = dr["marca"].ToString(),
                        modelo = dr["modelo"].ToString(),
                        patente = dr["patente"].ToString(),
                        precio = dr["precio"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        img = dr["img"].ToString()
                    });
                }
            }
            conexion.Close(); 
        }
        return oLista; 
    }

}
