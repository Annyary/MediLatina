<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Internamiento.aspx.cs" Inherits="UserInterface.Internamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">

                <section class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-6">
                                <h1 class="text-bold"><i class="far fa-plus-square nav-icon" style="padding-right: 5px;"></i>NUEVO INTERNAMIENTO</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-icon fas fa-copy" style="padding-right: 5px;"></i>Internamiento</a></li>
                                    <li class="breadcrumb-item active"><i class="far fa-plus-square nav-icon" style="padding-right: 5px;"></i>Nuevo Internamiento</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </section>

                <%--SECCIÓN DE INSERTAR NUEVO INGRESO--%>
                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">NUEVO INTERNAMIENTO</h3>

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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>PACIENTE</label>
                                    <asp:DropDownList ID="paciente" runat="server" CssClass="form-control" TabIndex="-1" aria-hidden="true" AutoPostBack="false" />
                                </div>
                                <div class="form-group">
                                    <label>SERVICIO</label>
                                    <asp:DropDownList ID="servicio" runat="server" CssClass="form-control" TabIndex="-1" aria-hidden="true" AutoPostBack="false" OnSelectedIndexChanged="ServicioSeleccionado" />
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">

                                <%--                                <div class="form-group">
                                    <label>DOCTOR</label>
                                    <asp:DropDownList ID="doctor" runat="server" CssClass="form-control" TabIndex="-1" aria-hidden="true" AutoPostBack="false" />
                                </div>--%>

                                <div class="form-group">
                                    <label>FECHA DE INGRESO</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar la fecha" ControlToValidate="fechaIngreso" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-calendar-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="fechaIngreso" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="false"></asp:TextBox>
                                    </div>
                                    <!-- /.input group -->
                                </div>


                            </div>
                            <!-- /.col -->
                            <!-- /.row -->
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer bg-dark" style="text-align: center;">
                            <asp:Button ID="BtnInsert" runat="server" Text="NUEVO INTERNAMIENTO" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                            <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" OnClick="BtnCancel_Click" />
                        </div>
                    </div>
                    <!-- /.card -->

                </div>

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
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AutoGenerateColumns="False" DataKeyNames="idInternamiento" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="namePatient" HeaderText="Paciente" SortExpression="namePatient" ReadOnly="True" />
                                            <asp:BoundField DataField="nameDoctor" HeaderText="Doctor" SortExpression="nameDoctor" />
                                            <asp:BoundField DataField="nameService" HeaderText="Servicio" SortExpression="nameService" ReadOnly="True" />
                                            <asp:BoundField DataField="idInternamiento" Visible="false" HeaderText="idInternamiento" InsertVisible="False" ReadOnly="True" SortExpression="idInternamiento" />
                                            <asp:BoundField DataField="paciente" Visible="false" HeaderText="paciente" SortExpression="paciente" />
                                            <asp:BoundField DataField="servicio" Visible="false" HeaderText="servicio" SortExpression="servicio" />
                                            <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha ingreso" SortExpression="fecha_ingreso" ReadOnly="True" />
                                            <asp:BoundField DataField="fecha_salida" HeaderText="Fecha salida" SortExpression="fecha_salida" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="DELETE FROM [Internado] WHERE  [idInternamiento] = @idInternamiento" InsertCommand="SP_INSERTINTERNADO" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTINTERNADO" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEINTERNADO" UpdateCommandType="StoredProcedure">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idInternamiento" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="paciente" Type="Int32" />
                                            <asp:Parameter Name="servicio" Type="Int32" />
                                            <asp:Parameter Name="fechaIngreso" Type="DateTime" />
                                            <asp:Parameter Name="fechaSalida" Type="DateTime" />
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
