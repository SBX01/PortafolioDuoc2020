<%-- 
    Document   : cliente
    Created on : 24-04-2020, 0:24:56
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
        <title>Perfil ${usuario}</title>
        <jsp:include page="navbar.jsp" flush="true" />
        <style>
            <jsp:include page="csspage.jsp" flush="true" />
        </style>
    </head>
    <body>
        <center><div class="dform">
        <form class="form-horizontal" method="post" action="PerfilCliente">
            <!--<input type="hidden" name="idu" value="${iduser}"/>-->
            <label>Perfil de <b>${usuario}</b></label>
            <table class="table table-hover" border="1" style="width: 100%; margin-top: 25px; border-color: white; background-color: white; color: black;">
                <thead>
                    <tr>
                        <th>RUT Cliente</th>
                        <th>Nombres</th>
                        <th>Apellidos</th>
                        <th>Correo</th>
                        <th>Telefono</th>
                        <th>Direccion</th>
                    </tr>
                </thead>
                <tbody>
                <c:forEach var="c" items="${clientes}">
                    <tr>
                        <td><b>${c.getRut()}</b></td>
                        <td>${c.getNombre()}</td>
                        <td>${c.getApellidos()}</td>
                        <td>${c.getCorreo()}</td>
                        <td>${c.getTelefono()}</td>
                        <td>${c.getDireccion()}</td>
                        
                    </tr>
                </c:forEach>
                </tbody>
            </table>
            
        </form>
            <a class="btn btn-default" id="btn" href="Reservar">Realizar Reserva</a>
        </div>
        </center>
    </body>
</html>
