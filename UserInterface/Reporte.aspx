<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="UserInterface.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
                                    <i class="fas fa-clipboard-list" style="padding-right: 5px;"></i>REPORTES DE MEDILATINA
                                </h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-item fas fa-tachometer-alt" style="padding-right: 5px;"></i>Administración</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-clipboard-list nav-item" style="padding-right: 5px;"></i>Reportes</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <!-- Small Box (Stat card) -->
                <div class="row">
                    <div class="col-lg-3 col-6">
                        <!-- small card -->
                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3>₡
                                    <asp:Label ID="lblConsumo" runat="server" ToolTip="Monto total de egresos del hospital"></asp:Label></h3>
                                <h4>EGRESOS</h4>
                            </div>
                            <div class="icon">
                                <i class="fas fa-calculator"></i>
                            </div>
                            <a href="#" class="small-box-footer"></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small card -->
                        <div class="small-box bg-success">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblPacientes" runat="server" ToolTip="Cantidad total de pacientes"></asp:Label>
                                </h3>
                                <h4>PACIENTES</h4>
                            </div>
                            <div class="icon">
                                <i class="fas fa-user"></i>
                            </div>
                            <a href="#" class="small-box-footer"></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small card -->
                        <div class="small-box bg-warning">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblDoctores" runat="server" ToolTip="Cantidad total de doctores"></asp:Label>
                                </h3>

                                <h4>DOCTORES</h4>
                            </div>
                            <div class="icon">
                                <i class="fas fa-user-md"></i>
                            </div>
                            <a href="#" class="small-box-footer"></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small card -->
                        <div class="small-box bg-danger">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblServicios" runat="server" ToolTip="Cantidad total de servicios"></asp:Label>
                                </h3>

                                <h4>SERVICIOS</h4>
                            </div>
                            <div class="icon">
                                <i class="fas fa-concierge-bell"></i>
                            </div>
                            <a href="#" class="small-box-footer"></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>


                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">LISTA DE CONSUMO DE PACIENTES</h3>
                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary" style="text-align: center; text-transform: uppercase;">
                                    <asp:GridView ID="GridReportes" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl w-100" AutoGenerateColumns="False" DataKeyNames="idReporte" DataSourceID="SqlDataSource1" AllowSorting="True" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="idReporte" Visible="false" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="idReporte" />
                                            <asp:BoundField DataField="namePaciente" HeaderText="Paciente" SortExpression="namePaciente" />
                                            <asp:BoundField DataField="nombre_comercial" HeaderText="Fármaco" SortExpression="nombre_comercial" />
                                            <asp:BoundField DataField="tipo" HeaderText="Presentación" SortExpression="tipo" />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" />
                                            <asp:BoundField DataField="consumo" HeaderText="Consumo" ReadOnly="True" SortExpression="consumo">
                                                <ItemStyle CssClass="bg-success" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" SelectCommand="SP_LISTREPORTES" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </section>
    </div>
    <!-- /.row -->

</asp:Content>
