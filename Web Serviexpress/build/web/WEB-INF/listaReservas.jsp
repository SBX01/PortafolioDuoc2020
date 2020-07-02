<%-- 
    Document   : listaReservas
    Created on : 26-05-2020, 5:14:06
    Author     : Sebastian Carrasco B
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <title>Reservas existentes</title>
        <jsp:include page="navbar.jsp" flush="true" />
        <style>
            <jsp:include page="csspage.jsp" flush="true" />
        </style>
    </head>
    <body>
        <h1>Lista de Reservas existentes</h1>
    <table class="table table-hover" border="1" style="width: 100%; margin-top: 25px; border-color: white; background-color: lightgray; color: black;">
                <thead>
                    <tr>
                        <th>ID Reserva</th>
                        <th>Fecha de Reserva</th>
                        <th>Estado de la Reserva</th>
                        <th>Vehiculo</th>
                        <th>Cliente</th>
                        <th>Servicio solicitado</th>
                    </tr>
                </thead>
                <tbody>
                <c:forEach var="r" items="${reservas}">
                    <tr>
                        <input type="hidden" name="servid" value="${r.getId_reserva()}"/>
                        <td><b>${r.getId_reserva()}</b></td>
                        <td>${r.getFechareserva()}</td>
                        <td>${r.getEstadoreserva()}</td>
                        <td>${r.getPatente()}</td>
                        <td>${r.getRut()}</td>
                        <!--<c:forEach items="${servicios}" var="ser">
                            <td value="${r.getId_servicio()}">${ser.getTiposervicio()}</td>
                        </c:forEach>-->
                        <td>${r.getId_servicio()}</td>
                        <td>
                            <form action="ListaReservas" method="post">
                                <input type="hidden" name="idreserva" value="${r.getId_reserva()}"/>
                                <input style="width: 100%" type="submit" name="accion" class="btn btn-success" value="Cancelar Reserva">
                            </form>
                        </td>
                    </tr>
                </c:forEach>
                </tbody>
            </table>
    <center><h4 style="color: white">${mensajes}</h4></center>
    </body>
</html>
