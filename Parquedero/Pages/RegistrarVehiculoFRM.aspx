<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="RegistrarVehiculoFRM.aspx.cs" Inherits="Pages_RegistrarVehiculoFRM_" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
   
   
    <table class="nav-justified">
          <tr>
            <td class="text-center" colspan="2"><strong>
                <asp:Label ID="lblTitulo" runat="server" style="font-size: large" Text="Registrar Vehículos"></asp:Label>
                </strong></td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Label ID="Label5" runat="server" Text="Buscar cliente:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDocumentoCliente" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Imagenes/loupe.png" Width="21px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>
                <asp:Label ID="lblCliente" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Label ID="Label1" runat="server" Text="Marca:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Label ID="Label2" runat="server" Text="Color:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Label ID="Label3" runat="server" Text="Modelo:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Label ID="Label4" runat="server" Text="Placa:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">
                <asp:Button CssClass="btn btn-primary" ID="btnRegistrarVehiculo" runat="server" Text="Registrar vehículo" OnClick="btnRegistrarVehiculo_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

   
   
   
</asp:Content>


