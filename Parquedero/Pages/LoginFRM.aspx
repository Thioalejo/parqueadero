<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoginFRM.aspx.cs" Inherits="Pages_LoginFRM" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <table class="nav-justified">
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px; height: 19px">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
        </td>
        <td style="height: 19px">
            <asp:TextBox ID="txtUsuario" runat="server">OParqueadero</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password">alejo</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" colspan="2">
            <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" Text="Iniciar sesión" class="btn btn-primary" />
        </td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-justify" style="width: 153px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>


</asp:Content>