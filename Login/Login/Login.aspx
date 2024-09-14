<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/styles.css" rel="stylesheet" />
    <title>Inicio de sesion</title>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validarFormulario();">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <div class="form-group">
                <label for="txtNombreUsuario">Nombre de Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtContrasenia">Contraseña</label>
                <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn" OnClick="btnIniciarSesion_Click" />
            </div>
            <div class="links">
                <asp:HyperLink ID="hlOlvideContrasenia" runat="server" Text="Olvidé mi contraseña" />
                <br />
                <asp:HyperLink ID="hlCrearCuenta" runat="server" Text="Crear una cuenta" />
            </div>
        </div>
    </form>

    <script>
        <!--Caracteres basicos para inyeccion sql se valida aqui y cuando se envie al servidor.-->
    function inyeccionSQL(input) {
        var caracteresEspeciales = /['";\-]/;
        return caracteresEspeciales.test(input);
    }

    function validarFormulario() {
        var usuario = document.getElementById('<%= txtNombreUsuario.ClientID %>').value;
        var contrasena = document.getElementById('<%= txtContrasenia.ClientID %>').value;

            // Validar si el campo contiene caracteres peligrosos
            if (inyeccionSQL(usuario) || inyeccionSQL(contrasena)) {
                alert("Los campos no deben contener caracteres especiales como comillas o guiones.");
                return false; // Previene el envío del formulario
            }

            // Validar que los campos no estén vacíos
            if (usuario === "" || contrasena === "") {
                alert("Por favor, complete los campos de usuario y contraseña.");
                return false;
            }

                alert("Exito! Campos no nulos y sin caracteres especiales. :)"); 
            return true; // Permite el envío del formulario
        }
</script>
</body>
</html>
