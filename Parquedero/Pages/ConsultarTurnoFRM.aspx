<%@ Page Title="Consultar turno" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConsultarTurnoFRM.aspx.cs" Inherits="Pages_ConsultarTurnoFRM" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    <table class="nav-justified">
        <tr>
            <td class="text-center" colspan="2"><strong>
                <asp:Label ID="lblTitulo" runat="server" style="font-size: large" Text="Consultar turno"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td style="width: 183px">
                <asp:Label ID="lblCedula" runat="server" Text="Cedula:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 183px">
                <asp:Label ID="Label2" runat="server" Text="Fecha de inicio:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaIncial" runat="server" Enabled="False"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="17px" ImageUrl="~/Imagenes/calendar.png" OnClick="ImageButton1_Click" Width="19px" />
            </td>
        </tr>
        <tr>
            <td style="width: 183px">&nbsp;</td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td style="width: 183px">
                <asp:Label ID="Label1" runat="server" Text="Fecha de final:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="17px" ImageUrl="~/Imagenes/calendar.png" OnClick="ImageButton2_Click" Width="19px" />
            </td>
        </tr>
        <tr>
            <td style="width: 183px">&nbsp;</td>
            <td>
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td style="width: 183px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 183px">&nbsp;</td>
            <td>
                <asp:Button ID="btnConsultarTurno" class="btn btn-primary" runat="server" OnClick="btnConsultarTurno_Click" Text="Consultar turno" />
            </td>
        </tr>
        <tr>
            <td style="width: 183px; height: 20px;"></td>
            <td style="height: 20px">
                <asp:Label ID="lblError" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="Turnos asignados"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="763px" style="margin-right: 2px">
                    <EditRowStyle Width="100px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 183px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

   
</asp:Content>
