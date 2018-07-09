<%@ Page Title="" Language="C#" MasterPageFile="~/Medicamentos.master" AutoEventWireup="true" CodeFile="EliminarMedicamentoC.aspx.cs" Inherits="EliminarMedicamentoC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
        <form runat="server">
            <div width:100%">
                <br />
                <asp:Label CssClass="TituloForm" ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" Text="ELIMINAR EXISTENCIAS DE CLINICA"></asp:Label>
                <br />
                <br />
                    <asp:Panel CssClass="PanelForm" ID="Panel1" runat="server" Width="95%">
                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Medicamento"></asp:Label>
                        <br />
                        <br />
                        <table>                            
                            <tr>
                                <td align="left"><asp:Label ID="Label3" runat="server" Text="Clinica: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList CssClass="form-control" ID="clinicaCodigo"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="clinicaCodigo_SelectedIndexChanged" >

                                    </asp:DropDownList>                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left"><asp:Label ID="Label2" runat="server" Text="Medicamento: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList CssClass="form-control" ID="medicamentoCodigo"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="medicamentoCodigo_SelectedIndexChanged" >

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label11" runat="server" Text="Cantidad: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Precio: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                        <br />
                    </asp:Panel>
                    <br />
                    <br />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    <br />
                <br />
            </div>
        </form>
    </center>
</asp:Content>








