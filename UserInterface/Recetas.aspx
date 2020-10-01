<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recetas.aspx.cs" Inherits="UserInterface.Recetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-6">
                                <h1 class="text-bold text-uppercase"><i class="fas fa-tasks nav-icon" style="padding-right: 5px;"></i>Recetas</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="fas fa-pills nav-icon" style="padding-right: 5px;"></i>Fármacos</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-tasks nav-icon" style="padding-right: 5px;"></i>Recetas</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <!-- SELECT2 EXAMPLE -->
                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title text-uppercase">Registro de recetas</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
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

                        <div class="row text-uppercase">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Fármaco</label>
                                    <asp:DropDownList ID="farmaco" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="False" />
                                </div>
                                <div class="form-group">
                                    <label>Presentación</label>
                                    <asp:DropDownList ID="presentacion" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="False" />
                                </div>
                                <div class="form-group">
                                    <label>Doctor</label>
                                    <asp:DropDownList ID="doctor" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="False" />
                                </div>

                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Paciente</label>
                                    <asp:DropDownList ID="paciente" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="False" />
                                </div>
                                <div class="form-group">
                                    <label>CANTIDAD</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe indicar la cantidad" ControlToValidate="txtCantidad" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese la cantidad"></asp:TextBox>
                                    </div>

                                    <label>Fecha emisión</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar la fecha" ControlToValidate="txtEmision" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-calendar-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtEmision" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="false"></asp:TextBox>
                                    </div>
                                    <!-- /.input group -->
                                </div>
                            </div>
                            <!-- /.col -->
                            <!-- /.row -->
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer bg-dark" style="text-align: center;">
                            <asp:Button ID="BtnInsert" runat="server" Text="NUEVA RECETA" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                            <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" />
                        </div>
                    </div>
                    <!-- /.card -->

                </div>

                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title text-uppercase">Lista de recetas</h3>
                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary text-uppercase">
                                    <asp:GridView ID="GridReceta" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl text-center" AutoGenerateColumns="False" DataKeyNames="idReceta" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
                                        <Columns>
                                            <asp:BoundField DataField="idReceta" HeaderText="idReceta" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="idReceta" />
                                            <asp:BoundField DataField="namePaciente" HeaderText="Paciente" SortExpression="namePaciente" />
                                            <asp:BoundField DataField="nameDoctor" HeaderText="Doctor" SortExpression="nameDoctor" />
                                            <asp:BoundField DataField="nombre_comercial" HeaderText="Fármaco" SortExpression="nombre_comercial" />
                                            <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="cantidad" />
                                            <asp:BoundField DataField="fecha_emision" HeaderText="fecha emisión" SortExpression="fecha_emision" />
                                            <asp:BoundField DataField="doctor" HeaderText="doctor" Visible="false" SortExpression="doctor" />
                                            <asp:BoundField DataField="farmaco" HeaderText="farmaco" Visible="false" SortExpression="farmaco" />
                                            <asp:BoundField DataField="presentacion" Visible="false" HeaderText="presentacion" SortExpression="presentacion" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVERECETA" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTRECETA" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTRECETA" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATERECETA" UpdateCommandType="StoredProcedure">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idReceta" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="doctor" Type="Int32" />
                                            <asp:Parameter Name="farmaco" Type="Int32" />
                                            <asp:Parameter Name="presentacion" Type="Int32" />
                                            <asp:Parameter Name="cantidad" Type="Double" />
                                            <asp:Parameter Name="fecha_emision" Type="DateTime" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="idReceta" Type="Int32" />
                                            <asp:Parameter Name="farmaco" Type="Int32" />
                                            <asp:Parameter Name="doctor" Type="Int32" />
                                            <asp:Parameter Name="paciente" Type="Int32" />
                                            <asp:Parameter Name="cantidad" Type="Double" />
                                            <asp:Parameter Name="presentacion" Type="Int32" />
                                            <asp:Parameter Name="fecha_emision" Type="DateTime" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- End Datatable -->
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
