# PortafolioDuoc2020
Portafolio de solucion al caso de "serviexpress".

Para que el funcionamiento de la solución sea la correcta se necesita la base de datos.

Oracle Database 11g Express Edition Release 11.2.0.2.0 - 64bit Production.

Paso muy importante, para Oracle 11 XE hay que habilitar permisos de EXECUTE sobre DBMS_CRYPTO, de lo contrario no correrá:
Entramos a la terminal y escribimos:

-sqlplus / as sysdba

Ejecutamos el comando:

-grant execute on dbms_crypto to PUBLIC;

Esto para poder ejecutarlo en cualquier USER.

Ejecutar el script "creacion usuario.sql" y luego ejecutar "Serviexpress BD IT2.sql".

Importante
-------
- El módulo de facturas y boletas aún no funcionan correctamente.
- El módulo de facturas y boletas no válidan datos,es decir en campos como cantidad o neto se puede ingresar numeros negativos
y se guardarán.
- El módulo de pedidos tiene un pequeño error, lista todos los productos, esto hay que corregirlo ya que,
los prodructos se deberían listar segun el proveedor.
