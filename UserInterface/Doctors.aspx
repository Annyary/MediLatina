<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="UserInterface.Doctors" %>

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
                                <h1 class="text-bold"><i class="fas fa-user-md nav-icon" style="padding-right: 5px;"></i>DOCTORES</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="nav-item fas fa-tachometer-alt" style="padding-right: 5px;"></i>Administración</a></li>
                                    <li class="breadcrumb-item active"><i class="fas fa-user-md" style="padding-right: 5px;"></i>Doctores</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </section>

                <!-- SELECT2 EXAMPLE -->
                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">REGISTRO DE DOCTORES</h3>

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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="De indicar el nombre" ControlToValidate="txtName" CssClass="accent-danger" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el nombre"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>NÚMERO DE COLEGIADO</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe indicar el número" ControlToValidate="txtNumColegiado" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="far fa-id-badge"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtNumColegiado" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el número de colegiado"></asp:TextBox>
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="telephone">TELÉFONO</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe indicar el teléfono" ControlToValidate="txtTelephone" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><em class="fas fa-phone"></em></span>
                                        </div>
                                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" placeholder="Ingrese el teléfono" TextMode="Phone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>SERVICIO ADSCRITO</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe elegir el servicio" ControlToValidate="service" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="service" runat="server" CssClass="form-control" TabIndex="-1" aria-hidden="true" AutoPostBack="false" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->

                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer bg-dark" style="text-align: center;">
                        <asp:Button ID="BtnInsert" runat="server" Text="NUEVO DOCTOR" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                        <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" OnClick="BtnCancel_Click" />
                    </div>
                </div>
                <!-- /.card -->

                <div class="card card-secondary">
                    <div class="card-header">
                        <h3 class="card-title">LISTA DE DOCTORES</h3>
                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary" style="text-align: center; text-transform: uppercase;">
                                    <asp:GridView ID="GridDoctors" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idDoctor" DataSourceID="SqlDataSource1" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="idDoctor" HeaderText="idDoctor" InsertVisible="False" ReadOnly="True" SortExpression="idDoctor" Visible="false" />
                                            <asp:BoundField DataField="num_colegiado" HeaderText="Número colegiado" SortExpression="num_colegiado" />
                                            <asp:BoundField DataField="name" HeaderText="Nombre" SortExpression="name" />
                                            <asp:BoundField DataField="address" HeaderText="Dirección" SortExpression="address" />
                                            <asp:BoundField DataField="telephone" HeaderText="Teléfono" SortExpression="telephone" />
                                            <asp:BoundField DataField="servicio_adscrito" HeaderText="Servicio adscrito" SortExpression="servicio_adscrito" Visible="false" />
                                            <asp:BoundField DataField="idService" HeaderText="idService" InsertVisible="False" ReadOnly="True" SortExpression="idService" Visible="false" />
                                            <asp:BoundField DataField="nameService" HeaderText="Servicio adscrito" SortExpression="nameService" />
                                            <asp:CheckBoxField DataField="status" HeaderText="Estado" SortExpression="status" />
                                            <asp:CommandField ShowDeleteButton="True" EditText="Editar" HeaderText="Acciones">
                                                <ControlStyle CssClass="btn btn-secondary btn-block text-capitalize" />
                                            </asp:CommandField>
                                        </Columns>

                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVEDOCTOR" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTDOCTOR" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTARDOCTORES" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEDOCTOR" UpdateCommandType="StoredProcedure">
                                        <DeleteParameters>
                                            <asp:Parameter Name="idDoctor" Type="Int32" />
                                            <asp:Parameter Name="status" Type="Boolean" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="num_colegiado" Type="Int32" />
                                            <asp:Parameter Name="name" Type="String" />
                                            <asp:Parameter Name="address" Type="String" />
                                            <asp:Parameter Name="telephone" Type="Int32" />
                                            <asp:Parameter Name="servicio_adscrito" Type="Int32" />
                                            <asp:Parameter Name="status" Type="Boolean" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="idDoctor" Type="Int32" />
                                            <asp:Parameter Name="num_colegiado" Type="Int32" />
                                            <asp:Parameter Name="name" Type="String" />
                                            <asp:Parameter Name="address" Type="String" />
                                            <asp:Parameter Name="telephone" Type="Int32" />
                                            <asp:Parameter Name="servicio_adscrito" Type="Int32" />
                                            <asp:Parameter Name="status" Type="Boolean" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <!-- End Datatable -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
