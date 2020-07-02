<%-- 
    Document   : reserva
    Created on : 15-04-2020, 20:32:53
    Author     : Sebastian Carrasco B
--%>


<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Reserva</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
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
        <form action="Reservar" method="post">
        <div class="dform">
        <h1>Realizar Reserva</h1>
        <div class="input-group">
          <span class="input-group-addon">Fecha Reserva</span>
          <input id="fecha" type="date" class="form-control" name="fecha" required>
        </div>
        <div class="input-group">
            <span class="input-group-addon">Vehículo</span>
            <select name="vehiculo" required class="form-control" id="exampleFormControlSelect1" required>
              <option selected>--Seleccione Vehículo--</option>
              <c:forEach items="${vehiculos}" var="v">
                    <option value="${v.getPatente()}">${v.getMarca()} ${v.getModelo().toUpperCase()} - Patente [${v.getPatente()}]</option>
              </c:forEach>
            </select> 
        </div>
        <!--<a href="RegistrarVehiculo">Añadir Vehiculo</a>-->
        
            <div class="input-group">
              <span class="input-group-addon">RUT Cliente</span>
              <input id="rut" type="text" class="form-control" name="rut" required>
            </div>
        
        <div class="input-group">
            <span class="input-group-addon">Servicio</span>
            <select name="servicio" required class="form-control" id="exampleFormControlSelect1" required>
              <option selected>--Seleccione servicio--</option>
              <c:forEach items="${servicios}" var="s">
                    <option value="${s.getId_servicio()}">${s.getTiposervicio()} | Valor: $${s.getPrecioServicio()}</option>
              </c:forEach>
            </select>
        </div>
        </div>
        
        <input type="submit" id="btn" name="btn" class="btn btn-info" value="Registrar"/>
        <a style="color: white" href="PerfilCliente"><b>Volver</b></a>
        </div>
    </form>
            <h3 style="color: white">${mensaje}</h3>
    </center>

    </body>
</html>
