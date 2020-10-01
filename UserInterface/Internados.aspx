<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Internados.aspx.cs" Inherits="UserInterface.Internados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <section class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-6">
                                <h1 class="text-bold"><i class="fas fa-procedures nav-icon" style="padding-right: 5px;"></i>PACIENTES INTERNADOS</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-icon fas fa-copy" style="padding-right: 5px;"></i>Internamiento</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-procedures nav-icon" style="padding-right: 5px;"></i>Pacientes Internados</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </section>
                <div class="row">
                    <div class="col-md-8">
                        <div class="card card-secondary">
                            <div class="card-header">
                                <h3 class="card-title">LISTA DE PACIENTES INTERNADOS</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                                </div>
                            </div>

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box box-primary text-uppercase" style="text-align: center">
                                            <asp:GridView enableEventValidation="true" ID="GridInternados" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AutoGenerateColumns="False" DataKeyNames="idInternamiento" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="5">
                                                <Columns>
                                                    <asp:BoundField DataField="idDoctor" HeaderText="" SortExpression="idDoctor" ReadOnly="True">
                                                        <ControlStyle BackColor="White" ForeColor="White" />
                                                        <ItemStyle ForeColor="White" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="idInternamiento" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="idInternamiento" />
                                                    <asp:BoundField DataField="namePatient" HeaderText="Paciente" SortExpression="namePatient" ReadOnly="True" />
                                                    <asp:BoundField DataField="nameDoctor" HeaderText="Doctor" SortExpression="nameDoctor" />
                                                    <asp:BoundField DataField="nameService" HeaderText="Servicio" SortExpression="nameService" ReadOnly="True" />
                                                    <asp:BoundField DataField="paciente" Visible="false" HeaderText="paciente" SortExpression="paciente" />
                                                    <asp:BoundField DataField="servicio" Visible="false" HeaderText="servicio" SortExpression="servicio" />
                                                    <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha ingreso" SortExpression="fecha_ingreso" ReadOnly="True" />
                                                    <%--<asp:BoundField DataField="fecha_salida" HeaderText="Fecha salida" SortExpression="fecha_salida" ReadOnly="True" />--%>
                                                    <%--<asp:BoundField DataField="informe" HeaderText="Informe" SortExpression="informe" />--%>

                                                    <asp:TemplateField HeaderText="ACCIONES">
                                                        <ItemTemplate>
                                                            <asp:Button ID="BtnInternado" runat="server" Text="Seleccionar" CssClass="btn btn-secondary" OnClick="BtnClick" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_ACCESSLOGIN" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTINTERNADO" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTINTERNADO" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEINTERNADO" UpdateCommandType="StoredProcedure">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="email" Type="String" />
                                                    <asp:Parameter Name="password" Type="String" />
                                                </DeleteParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="paciente" Type="Int32" />
                                                    <asp:Parameter Name="servicio" Type="Int32" />
                                                    <asp:Parameter Name="fechaIngreso" Type="DateTime" />
                                                </InsertParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="idInternamiento" Type="Int32" />
                                                    <asp:Parameter Name="paciente" Type="Int32" />
                                                    <asp:Parameter Name="servicio" Type="Int32" />
                                                    <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                                    <asp:Parameter Name="fecha_salida" Type="DateTime" />
                                                </UpdateParameters>
                                            </asp:SqlDataSource>
                                        </div>

                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl text-center"  AutoGenerateColumns="False" DataKeyNames="idInternamiento,idDoctor" DataSourceID="NUEVOSOURCE" AllowPaging="True" AllowSorting="True">
                                            <Columns>
                                                <asp:BoundField DataField="idInternamiento" Visible="false" HeaderText="idInternamiento" InsertVisible="False" ReadOnly="True" SortExpression="idInternamiento" />
                                                <asp:BoundField DataField="paciente" HeaderText="paciente" Visible="false" SortExpression="paciente" />
                                                <asp:BoundField DataField="servicio" HeaderText="servicio" Visible="false" SortExpression="servicio" />
                                                <asp:BoundField DataField="fecha_ingreso" HeaderText="fecha_ingreso" Visible="false" SortExpression="fecha_ingreso" />
                                                <asp:BoundField DataField="fecha_salida" HeaderText="fecha_salida" Visible="false" SortExpression="fecha_salida" />
                                                <asp:BoundField DataField="namePatient" HeaderText="Paciente" SortExpression="namePatient" />
                                                <asp:BoundField DataField="nameService" HeaderText="Servicio" SortExpression="nameService" />
                                                <asp:BoundField DataField="idDoctor" HeaderText="idDoctor" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="idDoctor" />
                                                <asp:BoundField DataField="nameDoctor" HeaderText="nameDoctor" Visible="false" SortExpression="nameDoctor" />
                                                <asp:BoundField DataField="informe" HeaderText="Informe" SortExpression="informe" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="NUEVOSOURCE" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" SelectCommand="SP_LISTINTERNADODIAGNOSTICO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card card-secondary">

                            <div class="card-header">
                                <h3 class="card-title">DIAGNÓSTICO DE PACIENTES</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                                </div>
                            </div>

                            <div class="card-body">
                                <div class="col-md-12">
                                    <div class="box box-primary" style="text-align: center">

                                        <%--VENTANAS MODALES--%>
                                        <div id="divModalDiagnostico" runat="server" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">PACIENTE SELECCIONADO</h5>
                                                    </div>

                                                    <div id="divSuccess" class="alert alert-success alert-dismissible" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                        <h6><em class="icon fa fa-check"></em>¡Éxito!</h6>
                                                        <asp:Label ID="TextSuccess" runat="server" Text=""></asp:Label>
                                                    </div>

                                                    <div id="divError" class="alert alert-danger alert-dismissible" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                        <h6><em class="icon fa fa-ban"></em>¡Alerta!</h6>
                                                        <asp:Label ID="TextError" runat="server" Text=""></asp:Label>
                                                    </div>

                                                    <div class="modal-body">

                                                        <form>
                                                            <label for="recipient-name" class="col-form-label">ID INTERNAMIENTO</label>
                                                            <asp:TextBox ID="txtIDInternado" runat="server" CssClass="form-control text-center" ReadOnly="true"></asp:TextBox>
                                                            <div class="form-group">
                                                                <label for="recipient-name" class="col-form-label">PACIENTE</label>
                                                                <asp:TextBox ID="txtPaciente" runat="server" CssClass="form-control text-center" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="recipient-name" class="col-form-label">DOCTOR</label>
                                                                <asp:TextBox ID="txtDoctor" runat="server" CssClass="form-control text-center" ReadOnly="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtIdDoctor" runat="server" CssClass="form-control text-center" Visible="true" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                            <label class="col-form-label">DIAGNÓSTICO</label>
                                                            <asp:TextBox ID="txtInforme" runat="server" TextMode="multiline" CssClass="form-control text-center text-uppercase"></asp:TextBox>
                                                        </form>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-footer bg-dark" style="text-align: center;">
                                                <asp:Button ID="BtnInsert" runat="server" Text="DIAGNÓSTICAR" CssClass="btn btn-secondary" OnClick="BtnInsert_Click" />
                                                <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="BtnCancel_Click" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </div>

</asp:Content>
