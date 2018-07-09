<%@ Page Title="" Language="C#" MasterPageFile="~/Medicamentos.master" AutoEventWireup="true" CodeFile="ActualizarMedicamento.aspx.cs" Inherits="ActualizarMedicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
        <form runat="server">
            <div width:100%">
                <br />
                <asp:Label CssClass="TituloForm" ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" Text="ACTUALIZAR MEDICAMENTO"></asp:Label>
                <br />
                <br />
                    <asp:Panel CssClass="PanelForm" ID="Panel1" runat="server" Width="95%">
                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Medicamento"></asp:Label>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left"><asp:Label ID="Label2" runat="server" Text="Código: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList CssClass="form-control" ID="medicamentoCodigo"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="medicamentoCodigo_SelectedIndexChanged">

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left"><asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <caption>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label11" runat="server" Text="Descripción: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                        <br />
                    </asp:Panel>
                    <br />
                    <br />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    <br />
                <br />
            </div>
        </form>
    </center>
</asp:Content>


