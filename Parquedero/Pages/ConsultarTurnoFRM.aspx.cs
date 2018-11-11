using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ConsultarTurnoFRM : System.Web.UI.Page
{
    DataTable table = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    int FechaIncial=0;
    int FechaFinal = 0;
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaIncial.Text = Calendar1.SelectedDate.ToLongDateString();
        Calendar1.Visible = false;
        lblError.Text = "Usted no tiene turnos asignados en este rango de fechas.";

        //FechaIncial = Convert.ToInt32(Calendar1.TodaysDate.Date);     

        //if (FechaFinal < FechaIncial)
        //{
        //    lblError.Text = "La fecha inicial debe ser menor a la fecha final";
        //    Calendar1.Visible = true;
        //}
        //else
        //{
        //    txtFechaFinal.Text = Calendar1.SelectedDate.ToLongDateString();
        //    Calendar1.Visible = false;
        //}
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = true;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaFinal.Text = Calendar2.SelectedDate.ToLongDateString();
        Calendar2.Visible = false;
        // FechaFinal = Convert.ToInt32(Calendar2.SelectedDate.ToLongDateString());

        //if (FechaFinal < FechaIncial)
        //{
        //    lblError.Text = "La fecha inicial debe ser menor a la fecha final";
        //    Calendar2.Visible = true;
        //}else
        //{
        //    txtFechaFinal.Text = Calendar2.SelectedDate.ToLongDateString();
        //    Calendar2.Visible = false;
        //}

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Calendar2.Visible = true;
    }
    protected void btnConsultarTurno_Click(object sender, EventArgs e)
    {
        ConsultarTurno();
    }

    private void ConsultarTurno()
    {
        table.Columns.Add("Fecha", typeof(string));
        table.Columns.Add("Dia", typeof(string));

        table.Rows.Add("26/10/2018", "Viernes");
        table.Rows.Add("29/10/2018", "Lunes");
        table.Rows.Add("30/10/2018", "Martes");
        table.Rows.Add("31/10/2018", "Miercoles");
        table.Rows.Add("01/11/2018", "Jueves");
        table.Rows.Add("02/11/2018", "Viernes");
        table.Rows.Add("03/11/2018", "Sabado");





        GridView1.DataSource = table;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        table.Columns.Add("Fecha", typeof(string));
        table.Rows.Add("10/08/2018");
        table.Columns.Add("Dia", typeof(string));
        table.Rows.Add("Miercoles");
    }
}