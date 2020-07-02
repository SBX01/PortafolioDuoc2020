<%-- 
    Document   : login
    Created on : 30-03-2020, 16:41:12
    Author     : Sebastian Carrasco B
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Inicio sesión</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
        <style>
        <jsp:include page="csspage.jsp" flush="true" />
        </style>
    </head>
    <body>
        <div class="container">
        <div class="jumbotron">
            <center><h1><img src="https://serviexpress.info/imagenes/serviexpress-logo.png"></h1>
            <p>Taller Mecánico</p></center>
        </div>
        <center><div class="dform">   
            <h1>Iniciar Sesión</h1>
        <form class="form-horizontal" method="post" action="login">
        <div class="form-group">
        <label class="control-label col-sm-2" for="user">Usuario:</label>
        <div class="col-sm-10">
        <input type="text" class="form-control" name="user" id="user" placeholder="Ingrese usuario">
        </div>
        </div>
        <div class="form-group">
        <label class="control-label col-sm-2" for="pwd">Contraseña:</label>
        <div class="col-sm-10">
        <input type="password" class="form-control" name="pass" id="pwd" placeholder="Ingrese su contraseña">
        </div>
        </div>
        <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <input type="submit" id="btn" name="btn" class="btn btn-info" value="Ingresar"></input>
        </div>
        <p style="color: white; margin-left: 5px;">¿No tienes cuenta? Registrate <a href="registro">aquí</a></p>
        </div>
        </form>
            <h3 style="color: white">${mensaje}</h3>
        </div>
        </center>
      </div>
    </body>
</html>
