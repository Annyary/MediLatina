<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="UserInterface.Patient" %>

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
                                <h1 class="text-bold"><i class="nav-icon fas fa-user" style="padding-right: 5px;"></i>PACIENTES</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-icon fas fa-user" style="padding-right: 5px;"></i>Pacientes</a></li>
                                    <li class="breadcrumb-item active"><i class="nav-icon fas fa-user" style="padding-right: 5px;"></i>Pacientes</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <!--  -->
                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">REGISTRO DE PACIENTES</h3>

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
                                    <label>NOMBRE</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar el nombre" ControlToValidate="txtName" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el nombre"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>NÚMERO SOCIAL</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe indicar el número" ControlToValidate="txtNumSocial" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-id-badge"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtNumSocial" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el número social"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>DIRECCIÓN</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe indicar la dirección" ControlToValidate="txtAddress" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-map-marked-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese la dirección"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>TELÉFONO</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe indicar el teléfono" ControlToValidate="txtTelephone" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-phone"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el teléfono"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>CUMPLEAÑOS</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe indicar la fecha" ControlToValidate="txtBirth" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-calendar-alt"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtBirth" runat="server" CssClass="form-control text-uppercase" TextMode="Date"></asp:TextBox>
                                    </div>
                                    <!-- /.input group -->
                                </div>
                                <div class="form-group">
                                    <label>GÉNERO</label>
                                    <asp:DropDownList ID="gender" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="True">--Seleccione un género</asp:ListItem>
                                        <asp:ListItem>Masculino</asp:ListItem>
                                        <asp:ListItem>Femenino</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->

                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer bg-dark" style="text-align: center;">
                        <asp:Button ID="BtnInsert" runat="server" Text="NUEVO PACIENTE" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                        <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" />
                    </div>
                </div>
                <!-- /.card -->

                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">LISTA DE PACIENTES</h3>
                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary text-uppercase" style="text-align: center; text-transform: uppercase">

                                    <asp:GridView CssClass="table table-bordered table-hover dataTable table-responsive-xl" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idPacient" DataSourceID="SqlDataSource1" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="num_social" HeaderText="Número social" SortExpression="num_social" />
                                            <asp:BoundField DataField="name" HeaderText="Nombre" SortExpression="name" />
                                            <asp:BoundField DataField="telephone" HeaderText="Teléfono" SortExpression="telephone" />
                                            <asp:BoundField DataField="address" HeaderText="Dirección" SortExpression="address" />
                                            <asp:BoundField DataField="birth" HeaderText="Nacimiento" SortExpression="birth" />
                                            <asp:BoundField DataField="gender" HeaderText="Género" SortExpression="gender" />
                                            <asp:CheckBoxField DataField="status" HeaderText="Estado" SortExpression="status" />
                                            <asp:CommandField ShowEditButton="True" EditText="Editar" HeaderText="Acciones">
                                                <ControlStyle CssClass="btn btn-secondary text-capitalize" />
                                            </asp:CommandField>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVEPATIENT" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTPATIENT" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTARPACIENTES" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEPATIENT" UpdateCommandType="StoredProcedure">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idPatient" Type="Int32" />
                                            <asp:Parameter Name="status" Type="Boolean" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="name" Type="String" />
                                            <asp:Parameter Name="num_social" Type="Int32" />
                                            <asp:Parameter Name="address" Type="String" />
                                            <asp:Parameter Name="telephone" Type="Int32" />
                                            <asp:Parameter Name="birth" Type="DateTime" />
                                            <asp:Parameter Name="gender" Type="String" />
                                            <asp:Parameter Name="status" Type="Boolean" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="idPacient" Type="Int32" />
                                            <asp:Parameter Name="name" Type="String" />
                                            <asp:Parameter Name="num_social" Type="Int32" />
                                            <asp:Parameter Name="address" Type="String" />
                                            <asp:Parameter Name="telephone" Type="Int32" />
                                            <asp:Parameter Name="birth" Type="DateTime" />
                                            <asp:Parameter Name="gender" Type="String" />
                                            <asp:Parameter Name="status" Type="Boolean" />
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
