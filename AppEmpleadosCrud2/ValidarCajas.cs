﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace AppEmpleadosCrud2
{
    public class ValidarCajas
    {
        //---------------------- mis metodos de validacion 

        //  validar si es vacio 
        public Boolean Vacio(TextBox caja, Label error, string mensajeError)
        {
            if (caja.Text == "")
            {
                error.Text = mensajeError;
                caja.Focus();
                return true;
            }
            else
            {
                error.Text = "";
                return false;
            }
        }
        //-------Validar tipo Texto---//
        public Boolean TipoTexto(TextBox caja, Label error, string mensajeError)
        {
            Regex formatoTexto = new Regex("^[a-zA-Z ]*$");
            // instanciamos la clase Regex y creamos un objeto 
            //para asignar la expresión o asignar la regla que debe cumplir 
            if (!formatoTexto.IsMatch(caja.Text))
            {
                error.Text = mensajeError;
                caja.Focus();
                return false;
            }
            else
            {
                error.Text = "";
                return true;
            }
        }
        // validar que sea tipo numero 
        public Boolean TipoNumero(TextBox caja, Label error, string mensajeError)
        {
            Regex formato = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");
            if (!formato.IsMatch(caja.Text))

            {
                error.Text = mensajeError;
                caja.Focus();
                return false;
            }
            else
            {
                error.Text = "";
                return true;
            }
        }
        //-------------------------------------------------
    }
}