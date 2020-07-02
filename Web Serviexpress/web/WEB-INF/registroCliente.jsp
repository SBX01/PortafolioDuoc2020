<%-- 
    Document   : registroCliente
    Created on : 30-03-2020, 16:39:41
    Author     : Sebastian Carrasco B
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Registro</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <style>
            <jsp:include page="csspage.jsp" flush="true"/>
            .input-group{
                margin: 10px;
            }
            .form-control{
                width: 100%
            }
        </style>
    </head>
    <body>
        <div class="container">
        <div class="jumbotron">
            <center><h1><img src="https://serviexpress.info/imagenes/serviexpress-logo.png"></h1>
            <p>Taller Mecánico</p></center>
        </div>
            <center>
                <form method="Post" action="registro">
            <div class="dform">
            <h1>Registrarse</h1>
            <div class="input-group">
              <span class="input-group-addon">Nombre de Usuario</span>
              <input id="user" type="text" class="form-control" name="user">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Contraseña</span>
              <input id="pass" type="password" class="form-control" name="pass">
            </div>
            <div class="input-group">
              <span class="input-group-addon">RUT Cliente</span>
              <input id="rut" type="text" class="form-control" name="rut">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Nombre Cliente</span>
              <input id="nombre" type="text" class="form-control" name="nombre">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Apellidos Cliente</span>
              <input id="apellido" type="text" class="form-control" name="apellidos">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Correo</span>
              <input id="correo" type="mail" class="form-control" name="correo">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Telefono</span>
              <input id="telefono" type="text" class="form-control" name="telefono">
            </div>
            <div class="input-group">
              <span class="input-group-addon">Direccion</span>
              <input id="direccion" type="text" class="form-control" name="direccion">
            </div>
            <input type="submit" id="btn" name="btn" class="btn btn-info" value="Registrarse"/>
            <a style="color: white" href="login"><b>Volver</b></a>
            </div>
        </form>
        <h3 style="color: white">${mensaje}</h3>
        </center>
        </div>
    </body>
</html>
