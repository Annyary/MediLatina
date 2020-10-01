<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dosis.aspx.cs" Inherits="UserInterface.Dosis" %>

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
                                <h1 class="text-bold text-uppercase"><i class="far fa-sticky-note" style="padding-right: 5px;"></i>DOSIS DE MEDICAMENTOS</h1>
                            </div>
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#"><i class="fas fa-pills nav-icon" style="padding-right: 5px;"></i>Fármacos</a></li>
                                    <li class="breadcrumb-item active"><i class="far fa-sticky-note" style="padding-right: 5px;"></i>Dosis</li>
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
                                <h3 class="card-title text-uppercase">Dosis de medicamentos</h3>

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
                                    <div class="col-md-12 text-uppercase">
                                        <div class="form-group">
                                            <label>Fármaco</label>
                                            <asp:DropDownList ID="farmaco" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="false" />
                                        </div>

                                        <div class="form-group">
                                            <label>Presentación</label>
                                            <asp:DropDownList ID="presentacion" runat="server" CssClass="form-control text-uppercase" TabIndex="-1" aria-hidden="true" AutoPostBack="false" />
                                        </div>

                                        <div class="form-group">
                                            <label>Precio</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe indicar el precio" ControlToValidate="txtPrecio" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            <div class="input-group">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><em class="fas fa-indent"></em></span>
                                                </div>
                                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese el precio" AutoPostBack="false" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <!-- /.row -->

                            </div>
                            <!-- /.card-body -->
                            <div class="card-footer bg-dark" style="text-align: center;">
                                <asp:Button ID="BtnInsert" runat="server" Text="NUEVA DOSIS" CssClass="btn btn-primary w-25" OnClick="BtnInsert_Click" />
                                <asp:Button ID="BtnCancel" runat="server" Text="CANCELAR" CssClass="btn btn-secondary w-25" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="card card-secondary text-uppercase">
                            <div class="card-header">
                                <h3 class="card-title">Lista de servicios</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><em class="fas fa-minus"></em></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><em class="fas fa-remove"></em></button>
                                </div>
                            </div>

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box box-primary" style="text-align: center; text-transform: uppercase">
                                            <asp:GridView ID="GridDosis" runat="server" CssClass="table table-bordered table-hover dataTable table-responsive-xl" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="farmaco,presentacion" DataSourceID="SqlDataSource1" PageSize="5">
                                                <Columns>
                                                    <asp:BoundField DataField="nombre_comercial" HeaderText="Fármaco" SortExpression="nombre_comercial" />
                                                    <asp:BoundField DataField="tipo" HeaderText="Presentación" SortExpression="tipo" />
                                                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                                    <asp:BoundField DataField="farmaco" Visible="false" HeaderText="farmaco" ReadOnly="True" SortExpression="farmaco" />
                                                    <asp:BoundField DataField="presentacion" Visible="false" HeaderText="presentacion" ReadOnly="True" SortExpression="presentacion" />
                                                    <asp:CommandField ShowDeleteButton="True">
                                                        <ControlStyle CssClass="btn btn-secondary text-capitalize" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:medilatinaConnectionString %>" DeleteCommand="SP_REMOVEDOSIS" DeleteCommandType="StoredProcedure" InsertCommand="SP_INSERTDOSIS" InsertCommandType="StoredProcedure" SelectCommand="SP_LISTARDOSIS" SelectCommandType="StoredProcedure" UpdateCommand="SP_UPDATEDOSIS" UpdateCommandType="StoredProcedure">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="farmaco" Type="Int32" />
                                                    <asp:Parameter Name="presentacion" Type="Int32" />
                                                </DeleteParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="farmaco" Type="Int32" />
                                                    <asp:Parameter Name="presentacion" Type="Int32" />
                                                    <asp:Parameter Name="precio" Type="Double" />
                                                </InsertParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="farmaco" Type="Int32" />
                                                    <asp:Parameter Name="presentacion" Type="Int32" />
                                                    <asp:Parameter Name="precio" Type="Double" />
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
