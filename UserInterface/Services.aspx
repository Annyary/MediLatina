<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="UserInterface.Services" %>

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

                                <h1 class="text-bold">
                                    <i class="fas fa-concierge-bell nav-icon" style="padding-right: 5px;"></i>
                                    SERVICIOS
                                </h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-item fas fa-tachometer-alt" style="padding-right: 5px;"></i>Administración</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-concierge-bell nav-icon" style="padding-right: 5px;"></i>Servicios</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <div class="row">
                    <div class="col-md-6">
                        <div class="card card-secondary">
                            <div class="card-header">
                                <h3 class="card-title">REGISTRO DE SERVICIOS</h3>

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

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>NOMBRE</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar el nombre" ControlToValidate="txtName" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            <div class="input-group">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                                </div>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el nombre" AutoPostBack="false" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <!-- /.row -->

                            </div>
                            <!-- /.card-body -->
                            <div class="card-footer bg-dark" style="text-align: center;">
                                <asp:Button ID="BtnInsert" runat="server" Text="NUEVO SERVICIO" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                                <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" OnClick="BtnCancel_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="card card-secondary">
                            <div class="card-header">
                                <h3 class="card-title">LISTA DE SERVICIOS</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                                </div>
                            </div>

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box box-primary" style="text-align: center; text-transform: uppercase">
                                            <asp:GridView ID="GridService" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AutoGenerateColumns="False" DataKeyNames="idService" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="5">
                                                <Columns>
                                                    <asp:BoundField DataField="idService" HeaderText="idService" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="idService" />
                                                    <asp:BoundField DataField="name" HeaderText="Nombre del servicio" SortExpression="name" />
                                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Acciones">
                                                        <ControlStyle CssClass="btn btn-secondary text-capitalize" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVESERVICE" InsertCommand="SP_INSERTSERVICE" SelectCommand="SP_LISTARSERVICIOS" UpdateCommand="SP_UPDATESERVICE" DeleteCommandType="StoredProcedure" InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure" UpdateCommandType="StoredProcedure">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="idService" Type="Int32" />
                                                </DeleteParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="name" Type="String" />
                                                </InsertParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="idService" Type="Int32" />
                                                    <asp:Parameter Name="name" Type="String" />
                                                </UpdateParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>

                </div>

            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
