<%-- 
    Document   : vehiculo
    Created on : 05-05-2020, 0:30:41
    Author     : Sebastian Carrasco B
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <title>Ingresar Vehiculo</title>
        <style>
            <jsp:include page="csspage.jsp" flush="true"/>
            .input-group{
                margin: 10px;
            }
        </style>
        <jsp:include page="navbar.jsp" flush="true" />
    </head>
    <body>
        <center>
        <form action="RegistrarVehiculo" method="post">
        <div class="dform">
        <h1>Ingresar Vehículo</h1>
        <div class="input-group">
            <span class="input-group-addon">Patente</span>
            <input id="patente" type="text" class="form-control" name="patente" required>
        </div>
        <div class="input-group">
            <span class="input-group-addon">Año</span>
            <input id="anno" type="number" class="form-control" name="anno" required>
        </div>
        <div class="input-group">
            <span class="input-group-addon">Marca</span>
            <input id="marca" type="text" class="form-control" name="marca"required>
        </div>
        <div class="input-group">
            <span class="input-group-addon">Modelo</span>
            <input id="modelo" type="text" class="form-control" name="modelo" required>
        </div>

        </div>
        
        
        <input type="submit" id="btn" name="accion" class="btn btn-info" value="Registrar"/>
        <a style="color: white" href="Reservar"><b>Volver</b></a>
        </div>
        
    </form>
        <h3 style="color: white">${mensaje}</h3>
    </center>
    
    <h1>Lista de Vehiculos Registrados</h1>
    <table class="table table-hover" border="1" style="width: 100%; margin-top: 25px; border-color: white; background-color: lightgray; color: black;">
                <thead>
                    <tr>
                        <th>Patente Vehiculo</th>
                        <th>Marca</th>
                        <th>Modelo</th>
                        <th>Año Vehiculo</th>
                        <th>Acción</th>
                    </tr>
                </thead>
                <tbody>
                <c:forEach var="ve" items="${vehiculos}">
                    <tr>
                        <td><b>${ve.getPatente()}</b></td>
                        <td>${ve.getMarca()}</td>
                        <td>${ve.getModelo()}</td>
                        <td>${ve.getAnno()}</td>
                        <td>
                            <form action="RegistrarVehiculo" method="post">
                                <input type="hidden" name="idpatente" value="${ve.getPatente()}"/>
                                <input style="width: 100%" type="submit" name="accion" class="btn btn-success" value="Eliminar">
                            </form>
                        </td>
                    </tr>
                </c:forEach>
                </tbody>
            </table>
    <center><h3 style="color: white">${error}</h3></center>
    </body>
</html>
