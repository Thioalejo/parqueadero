using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libClases.BaseDatos;

public partial class Pages_LoginFRM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["Rol"] = "Estandar";
    }

    protected void btnIniciarSesion_Click(object sender, EventArgs e)
    {
        LoginUsuario login = new LoginUsuario();

        login.Usuario = txtUsuario.Text;
        login.Contraseña = txtContraseña.Text;
        if(login.Consultar())
        {
            Session["Rol"] = login.Rol;
            Session["Usuario"] = login.Usuario;
            Response.Redirect("~/");

        }
        else
        {
            lblError.Text = login.Error;
        }     
    }
}