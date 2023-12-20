using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_AbdenagoLopez
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  Encuesta"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.clsencuesta.Agregar(tnombre.Text, tedad.Text, tcorreo.Text, tpartido.Text );

            if (resultado > 0)
            {
                alertas("Usuario agregado con exito");
                tnombre.Text = string.Empty;
                tedad.Text = string.Empty;
                tcorreo.Text = string.Empty;
                tpartido.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar encuesta");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.clsencuesta.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("Encuesta ha sido borrada con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar encuesta");

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.clsencuesta.Modificar(int.Parse(tcodigo.Text), tnombre.Text, tedad.Text, tcorreo.Text, tpartido.Text);

            if (resultado > 0)
            {
                alertas("Usuario ha sido modificado con exito");
                tcodigo.Text = string.Empty;
                tnombre.Text = string.Empty;
                tedad.Text = string.Empty;
                tcorreo.Text = string.Empty;
                tpartido.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Encuesta");

            }
        }
    }
}