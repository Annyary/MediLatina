<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vademecum.aspx.cs" Inherits="UserInterface.Vademecum" %>

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
                                <h1 class="text-bold"><i class="fas fa-pills nav-icon" style="padding-right: 5px;"></i>FÁRMACOS</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="fas fa-pills nav-icon" style="padding-right: 5px;"></i>Fármacos</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-pills nav-icon" style="padding-right: 5px;"></i>Fármacos</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <!-- SELECT2 EXAMPLE -->
                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title text-uppercase">Registro de fármacos</h3>

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
                                    <label class="text-uppercase">Número de registro</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar el número" ControlToValidate="txtNumRegistro" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtNumRegistro" runat="server" CssClass="form-control text-uppercase" placeholder="Número de registro"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="text-uppercase">Nombre comercial</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe indicar el nombre" ControlToValidate="txtNombreComercial" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-id-badge"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtNombreComercial" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el nombre comercial"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="text-uppercase">Nombre clínico</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe indicar el nombre" ControlToValidate="txtNombreClinico" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-map-marked-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtNombreClinico" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el nombre clínico"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label class="text-uppercase">Compuesto químico</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe indicar el compuesto" ControlToValidate="txtCompuestoQuimico" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-map-marked-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtCompuestoQuimico" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el compuesto químico"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="text-uppercase">Ubicación</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe indicar la ubicación" ControlToValidate="txtUbicacion" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-phone"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese la ubicación"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="text-uppercase">Proveedor</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe indicar el proveedor" ControlToValidate="txtProveedor" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-calendar-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el proveedor"></asp:TextBox>
                                    </div>
                                    <!-- /.input group -->
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->

                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer bg-dark" style="text-align: center;">
                        <asp:Button ID="BtnInsert" runat="server" Text="NUEVO FÁRMACO" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                        <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" />
                    </div>
                </div>
                <!-- /.card -->

                <div class="card card-secondary text-uppercase">
                    <div class="card-header">
                        <h3 class="card-title text-uppercase">Lista de fármacos</h3>
                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary" style="text-align: center; text-transform: uppercase">
                                    <asp:GridView ID="GridVademecum" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idVademecum" DataSourceID="SqlDataSource1" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="idVademecum" Visible="false" HeaderText="idVademecum" InsertVisible="False" ReadOnly="True" SortExpression="idVademecum" />
                                            <asp:BoundField DataField="num_registro" HeaderText="Número registro" SortExpression="num_registro" />
                                            <asp:BoundField DataField="nombre_comercial" HeaderText="Nombre comercial" SortExpression="nombre_comercial" />
                                            <asp:BoundField DataField="nombre_clinico" HeaderText="nombre clínico" SortExpression="nombre_clinico" />
                                            <asp:BoundField DataField="compuesto_quimico" HeaderText="compuesto químico" SortExpression="compuesto_quimico" />
                                            <asp:BoundField DataField="ubicacion" HeaderText="ubicación" SortExpression="ubicacion" />
                                            <asp:BoundField DataField="proveedor" HeaderText="proveedor" SortExpression="proveedor" />
                                            <asp:CommandField HeaderText="Acciones" DeleteText="Eliminar" EditText="Editar" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Actualizar">
                                                <ControlStyle CssClass="btn btn-secondary text-capitalize" />
                                            </asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVEVADEMECUM" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTVADEMECUM" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTARVADEMECUM" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEVADEMECUM" UpdateCommandType="StoredProcedure">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idVademecum" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="num_registro" Type="String" />
                                            <asp:Parameter Name="nombre_comercial" Type="String" />
                                            <asp:Parameter Name="nombre_clinico" Type="String" />
                                            <asp:Parameter Name="compuesto_quimico" Type="String" />
                                            <asp:Parameter Name="ubicacion" Type="String" />
                                            <asp:Parameter Name="proveedor" Type="String" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="idVademecum" Type="Int32" />
                                            <asp:Parameter Name="num_registro" Type="String" />
                                            <asp:Parameter Name="nombre_comercial" Type="String" />
                                            <asp:Parameter Name="nombre_clinico" Type="String" />
                                            <asp:Parameter Name="compuesto_quimico" Type="String" />
                                            <asp:Parameter Name="ubicacion" Type="String" />
                                            <asp:Parameter Name="proveedor" Type="String" />
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
