<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserInterface.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acceso al sistema</title>
    <webopt:BundleReference runat="server" Path="~/dist/css" />
    <!-- Font Awesome Icons -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- IonIcons -->
    <link rel="stylesheet" href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css" />
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />

    <link href="dist/css/login.css" rel="stylesheet" type="text/css" />

</head>
<body class="bg-gradient-gray-dark">
    <div class="contenido" id="login-box">
        <div class="header text-center">
            <h1 class="text-bold"><em class="fas fa-heartbeat" style="font-size: 32px; padding-right: 5px; color: #e52d27;"></em>MEDILATINA</h1>
            <h3>INICIAR SESIÓN</h3>
        </div>
        <form id="form1" runat="server">
            <div class="box bg-gray-light ">
                <div class="form-group">
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Ingrese el usuario"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="Ingrese la contraseña" TextMode="Password"></asp:TextBox>
                </div>
                <div class="footer">
                </div>
                <asp:Button ID="Button1" runat="server" Text="INGRESAR" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
            </div>
            <div class="copy text-center">
                <p>&copy; 2019 Universidad Latina de Costa Rica</p>
                <p>Todos los derechos reservados</p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El usuario es obligatorio" ControlToValidate="txtUser" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El password es obligatorio" ControlToValidate="txtPass" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </div>
        </form>

        <div id="divErrorSignIn" class="alert alert-danger alert-dismissible" runat="server">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <h6><em class="icon fa fa-ban"></em>¡Alerta!</h6>
            <asp:Label ID="ErrorSignInMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
</body>
</html>
