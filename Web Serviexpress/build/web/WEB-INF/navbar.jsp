<%-- 
    Document   : navbar
    Created on : 28-04-2020, 18:09:54
    Author     : Sebastian Carrasco B
--%>

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
        <img src="https://serviexpress.info/imagenes/serviexpress-logo.png" style="padding: 5px 5px" width="150" height="50">
    </div>
    <ul class="nav navbar-nav">
      <li><a href="PerfilCliente">Perfil</a></li>
      <li><a href="ListaReservas">Reservas</a></li>
      <li><a href="RegistrarVehiculo">Vehiculo</a></li>
    </ul>
      <a class="btn btn-info navbar-btn" id="btn" href="cerrarsesion">Cerrar Sesión</a>
      <li style="color: #33ff00"><h6>Conectado como ${usuario}</h6></li>
  </div>
</nav>