<%@ Page Title="" Language="C#" MasterPageFile="~/Medicamentos.master" AutoEventWireup="true" CodeFile="ExistenciasArticulos.aspx.cs" Inherits="ExistenciasArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form runat="server">        
        <center>      
            <asp:Label ID="lbl1" runat="server" Text="Existencias de Articulos en Clinicas" Font-Size="XX-Large"></asp:Label>
            <asp:GridView ID="gvExistencias" runat="server" BackColor="White" BorderColor="#dedfde"
                BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="true"
                ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#cccc99" />
                <HeaderStyle BackColor="#6b696b" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right"/>
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#ce5d5a" Font-Bold="true" ForeColor="White" />
            </asp:GridView>
        </center>        
    </form>
</asp:Content>