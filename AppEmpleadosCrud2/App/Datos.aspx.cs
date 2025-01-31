﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleadosCrud2.App
{
    public partial class Datos : System.Web.UI.Page
    {
        // Crear el objeto para gestionar datos
        
        GestionDatos datos = new GestionDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Empleado> listaEmpleados = datos.LeerTodos();
                // Volcamos la lista a nuestro gv
                gvEmpleados.DataSource = listaEmpleados;
                gvEmpleados.DataBind();
            }
        }

        protected void btnListarTodo_Click(object sender, EventArgs e)
        {
            //En un a lista invocamos el objeto para listar los empleados
            List<Empleado> listaEmpleados = datos.LeerTodos();
            // Volcamos la lista a nuestro gv
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            List<Empleado> listaEmpleados = datos.LeerTodos();

            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (datos.ExisteEmpleado(txtBuscarCodigo.Text))
            {
                Response.Redirect("Formulario.aspx?id=" + txtBuscarCodigo.Text);
            }
            else
            {
                LabelBuscar.Text = "No existe el código en la BD";
            }
        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(gvEmpleados.DataKeys[index].Value);
                Response.Redirect("Formulario.aspx?id=" + valor);
            }
        }
    }
}