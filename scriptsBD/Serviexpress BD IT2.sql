/* Se eliminan las tablas */
DROP TABLE boleta CASCADE CONSTRAINTS;

DROP TABLE cliente CASCADE CONSTRAINTS;

DROP TABLE detalle_boleta CASCADE CONSTRAINTS;

DROP TABLE detalle_factura CASCADE CONSTRAINTS;

DROP TABLE detalle_servicio CASCADE CONSTRAINTS;

DROP TABLE detallecompra CASCADE CONSTRAINTS;

DROP TABLE detallle_pedido CASCADE CONSTRAINTS;

DROP TABLE empleado CASCADE CONSTRAINTS;

DROP TABLE factura CASCADE CONSTRAINTS;

DROP TABLE pedido CASCADE CONSTRAINTS;

DROP TABLE producto CASCADE CONSTRAINTS;

DROP TABLE proveedor CASCADE CONSTRAINTS;

DROP TABLE reserva CASCADE CONSTRAINTS;

DROP TABLE "RESERVA-SERVICIO" CASCADE CONSTRAINTS;

DROP TABLE servicio CASCADE CONSTRAINTS;

DROP TABLE tipoproducto CASCADE CONSTRAINTS;

DROP TABLE usuario CASCADE CONSTRAINTS;

DROP TABLE vehiculo CASCADE CONSTRAINTS;

/* Se crean las tablas */

CREATE TABLE boleta (
    id_boleta      INTEGER NOT NULL,
    fecha_boleta   DATE NOT NULL,
    totalboleta    NUMBER(9) NOT NULL,
    tipopago       VARCHAR2(15) NOT NULL
);

ALTER TABLE boleta ADD CONSTRAINT boleta_pk PRIMARY KEY ( id_boleta );

CREATE TABLE cliente (
    rut_cli         VARCHAR2(9) NOT NULL,
    nombre_cli      VARCHAR2(30) NOT NULL,
    apellidos_cli   VARCHAR2(30) NOT NULL,
    correo_cli      VARCHAR2(80) NOT NULL,
    telefono_cli    NUMBER(9) NOT NULL,
    direccion_cli   VARCHAR2(80) NOT NULL,
    id_usuario      INTEGER NOT NULL
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( rut_cli );

CREATE TABLE detalle_boleta (
    cantidad_servicio   NUMBER(1) NOT NULL,
    id_boleta           INTEGER NOT NULL,
    id_servicio         INTEGER NOT NULL,
    valor               INTEGER NOT NULL
);

ALTER TABLE detalle_boleta ADD CONSTRAINT detalle_boleta_pk PRIMARY KEY ( id_servicio,
                                                                          id_boleta );

CREATE TABLE detalle_factura (
    cantidadserv   NUMBER(1) NOT NULL,
    id_factura     INTEGER NOT NULL,
    id_servicio    INTEGER NOT NULL,
    valor          INTEGER NOT NULL
);

ALTER TABLE detalle_factura ADD CONSTRAINT detalle_factura_pk PRIMARY KEY ( id_servicio,
                                                                            id_factura );

CREATE TABLE detalle_servicio (
    cantidadprod   NUMBER(9) NOT NULL,
    id_producto    INTEGER NOT NULL,
    id_servicio    INTEGER NOT NULL
);

ALTER TABLE detalle_servicio ADD CONSTRAINT detalle_servicio_pk PRIMARY KEY ( id_producto,
                                                                              id_servicio );

CREATE TABLE detallecompra (
    precio          NUMBER(9) NOT NULL,
    id_producto     INTEGER NOT NULL,
    rut_proveedor   VARCHAR2(9) NOT NULL
);

ALTER TABLE detallecompra ADD CONSTRAINT detallecompra_pk PRIMARY KEY ( id_producto,
                                                                        rut_proveedor );

CREATE TABLE detallle_pedido (
    cantidad      NUMBER NOT NULL,
    estado        VARCHAR2(15) NOT NULL,
    id_producto   INTEGER NOT NULL,
    rut_empl      VARCHAR2(9) NOT NULL,
    comentario    VARCHAR2(40),
    id_pedido     INTEGER NOT NULL
);

ALTER TABLE detallle_pedido
    ADD CONSTRAINT detallle_pedido_pk PRIMARY KEY ( id_producto,
                                                    rut_empl,
                                                    id_pedido );

CREATE TABLE empleado (
    rut_empl         VARCHAR2(9) NOT NULL,
    nombre_empl      VARCHAR2(30) NOT NULL,
    apellido_empl    VARCHAR2(30) NOT NULL,
    direccion_empl   VARCHAR2(80) NOT NULL,
    telefono_empl    NUMBER(9) NOT NULL,
    correo_emp       VARCHAR2(80) NOT NULL,
    cargo_empl       VARCHAR2(30) NOT NULL,
    id_usuario       INTEGER NOT NULL
);

ALTER TABLE empleado ADD CONSTRAINT empleado_pk PRIMARY KEY ( rut_empl );

CREATE TABLE factura (
    id_factura      INTEGER NOT NULL,
    fecha_factura   DATE NOT NULL,
    neto            NUMBER(9) NOT NULL,
    iva             NUMBER(9) NOT NULL,
    total           NUMBER(9) NOT NULL,
    tipopago       VARCHAR2(15) NOT NULL
);

ALTER TABLE factura ADD CONSTRAINT factura_pk PRIMARY KEY ( id_factura );

CREATE TABLE pedido (
    id_pedido            INTEGER NOT NULL,
    fecha_pedido         DATE NOT NULL,
    rut_empl             VARCHAR2(9) NOT NULL,
    descripcion_pedido   VARCHAR2(80) NOT NULL,
    rut_proveedor        VARCHAR2(9) NOT NULL
);

ALTER TABLE pedido ADD CONSTRAINT pedido_pk PRIMARY KEY ( id_pedido );

CREATE TABLE producto (
    id_producto           INTEGER NOT NULL,
    precio_compra         NUMBER(9) NOT NULL,
    stock_produc          NUMBER(9) NOT NULL,
    stockcritico_produc   NUMBER(9) NOT NULL,
    descripcion_produc    VARCHAR2(80) NOT NULL,
    precioventa_produc    NUMBER(9) NOT NULL,
    idtipo                INTEGER NOT NULL,
    fechavenci_produc     DATE NOT NULL
);

ALTER TABLE producto ADD CONSTRAINT producto_pk PRIMARY KEY ( id_producto );

CREATE TABLE proveedor (
    rut_proveedor   VARCHAR2(9) NOT NULL,
    nombre_pro      VARCHAR2(30) NOT NULL,
    apellido_pro    VARCHAR2(30) NOT NULL,
    correo_pro      VARCHAR2(80) NOT NULL,
    telefono_pro    NUMBER(9) NOT NULL,
    rubro_pro       VARCHAR2(30) NOT NULL
);

ALTER TABLE proveedor ADD CONSTRAINT proveedor_pk PRIMARY KEY ( rut_proveedor );

CREATE TABLE reserva (
    id_reserva      INTEGER NOT NULL,
    fecha_reserva   DATE NOT NULL,
    estadoreserva   VARCHAR2(10) NOT NULL,
    patente         VARCHAR2(6) NOT NULL,
    rut_cli         VARCHAR2(9) NOT NULL,
    id_servicio     INTEGER NOT NULL
);

ALTER TABLE reserva ADD CONSTRAINT reserva_pk PRIMARY KEY ( id_reserva );

CREATE TABLE servicio (
    id_servicio       INTEGER NOT NULL,
    tipo_servi        VARCHAR2(15) NOT NULL,
    rut_empl          VARCHAR2(9) NOT NULL,
    precio_servicio   INTEGER NOT NULL
);

ALTER TABLE servicio ADD CONSTRAINT servicio_pk PRIMARY KEY ( id_servicio );

CREATE TABLE tipoproducto (
    idtipo        INTEGER NOT NULL,
    descripcion   VARCHAR2(30) NOT NULL
);

ALTER TABLE tipoproducto ADD CONSTRAINT tipoproducto_pk PRIMARY KEY ( idtipo );

CREATE TABLE usuario (
    id_usuario       INTEGER NOT NULL,
    nombre_usuario   VARCHAR2(30) NOT NULL,
    password         VARCHAR2(250) NOT NULL,
    rolusuario       VARCHAR2(3) NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( id_usuario );

CREATE TABLE vehiculo (
    patente   VARCHAR2(6) NOT NULL,
    anno      NUMBER(4) NOT NULL,
    marca     VARCHAR2(15) NOT NULL,
    modelo    VARCHAR2(15) NOT NULL
);

ALTER TABLE vehiculo ADD CONSTRAINT vehiculo_pk PRIMARY KEY ( patente );

ALTER TABLE cliente
    ADD CONSTRAINT cliente_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES usuario ( id_usuario );

ALTER TABLE detalle_boleta
    ADD CONSTRAINT detalle_boleta_boleta_fk FOREIGN KEY ( id_boleta )
        REFERENCES boleta ( id_boleta );

ALTER TABLE detalle_boleta
    ADD CONSTRAINT detalle_boleta_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE detalle_factura
    ADD CONSTRAINT detalle_factura_factura_fk FOREIGN KEY ( id_factura )
        REFERENCES factura ( id_factura );

ALTER TABLE detalle_factura
    ADD CONSTRAINT detalle_factura_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE detalle_servicio
    ADD CONSTRAINT detalle_servicio_producto_fk FOREIGN KEY ( id_producto )
        REFERENCES producto ( id_producto );

ALTER TABLE detalle_servicio
    ADD CONSTRAINT detalle_servicio_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE detallecompra
    ADD CONSTRAINT detallecompra_producto_fk FOREIGN KEY ( id_producto )
        REFERENCES producto ( id_producto );

ALTER TABLE detallecompra
    ADD CONSTRAINT detallecompra_proveedor_fk FOREIGN KEY ( rut_proveedor )
        REFERENCES proveedor ( rut_proveedor );

ALTER TABLE detallle_pedido
    ADD CONSTRAINT detallle_pedido_empleado_fk FOREIGN KEY ( rut_empl )
        REFERENCES empleado ( rut_empl );

ALTER TABLE detallle_pedido
    ADD CONSTRAINT detallle_pedido_pedido_fk FOREIGN KEY ( id_pedido )
        REFERENCES pedido ( id_pedido );

ALTER TABLE detallle_pedido
    ADD CONSTRAINT detallle_pedido_producto_fk FOREIGN KEY ( id_producto )
        REFERENCES producto ( id_producto );

ALTER TABLE empleado
    ADD CONSTRAINT empleado_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES usuario ( id_usuario );

ALTER TABLE pedido
    ADD CONSTRAINT pedido_empleado_fk FOREIGN KEY ( rut_empl )
        REFERENCES empleado ( rut_empl );

ALTER TABLE pedido
    ADD CONSTRAINT pedido_proveedor_fk FOREIGN KEY ( rut_proveedor )
        REFERENCES proveedor ( rut_proveedor );

ALTER TABLE producto
    ADD CONSTRAINT producto_tipoproducto_fk FOREIGN KEY ( idtipo )
        REFERENCES tipoproducto ( idtipo );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_cliente_fk FOREIGN KEY ( rut_cli )
        REFERENCES cliente ( rut_cli );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_vehiculo_fk FOREIGN KEY ( patente )
        REFERENCES vehiculo ( patente );

ALTER TABLE servicio
    ADD CONSTRAINT servicio_empleado_fk FOREIGN KEY ( rut_empl )
        REFERENCES empleado ( rut_empl );
/* ELIMINAR SEQUENCIAS */
DROP SEQUENCE idBol_seq;
DROP SEQUENCE idFac_seq;
DROP SEQUENCE idPed_seq;
DROP SEQUENCE idRev_seq;
DROP SEQUENCE idSS_seq;
DROP SEQUENCE idUser_seq;
DROP SEQUENCE IDTIPO_SEQ;
/* secuencias para incrementar automatico */
CREATE SEQUENCE idBol_seq START WITH 1;
CREATE SEQUENCE idFac_seq START WITH 1;
CREATE SEQUENCE idPed_seq START WITH 1;
CREATE SEQUENCE idRev_seq START WITH 1;
CREATE SEQUENCE idSS_seq START WITH 1;
CREATE SEQUENCE idUser_seq START WITH 1;
CREATE SEQUENCE IDTIPO_SEQ START WITH 1;
/

/*  Encriptar y desencriptar*/
create or replace PACKAGE ADM_UTIL AS
    FUNCTION encryptor (
            input_string        IN  VARCHAR2
        ) RETURN NVARCHAR2;

    FUNCTION decryptor (
            INPUT_STRING        IN  VARCHAR2
        ) RETURN VARCHAR2;
END ADM_UTIL;
/
create or replace PACKAGE BODY ADM_UTIL
IS
    SQLERRMSG   VARCHAR2(255);
    SQLERRCDE   NUMBER;
  
    DES_CBC_NONE        CONSTANT PLS_INTEGER :=
        DBMS_CRYPTO.ENCRYPT_DES + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_NONE;
    SH1_ECB_ZERO        CONSTANT PLS_INTEGER :=
        DBMS_CRYPTO.HASH_SH1 + DBMS_CRYPTO.CHAIN_ECB + DBMS_CRYPTO.PAD_ZERO;
  FUNCTION encryptor (
        input_string        IN  VARCHAR2
    ) RETURN NVARCHAR2
    IS
      
        key_seed                VARCHAR2(64);
        converted_seed      RAW(64);
        converted_string    RAW(64);
        encrypted_string    RAW(64);

    BEGIN

        key_seed:='asjdjeuu5men1m40ptoemzia'; --llave encriptacion no cambiar

        converted_string := UTL_I18N.STRING_TO_RAW(input_string, 'AL32UTF8');
        converted_seed   := UTL_I18N.STRING_TO_RAW(key_seed, 'AL32UTF8');

        encrypted_string := 
             DBMS_CRYPTO.ENCRYPT(
                 src => converted_string
                ,typ => SH1_ECB_ZERO 
                ,key => converted_seed
                ,iv =>  NULL);

        RETURN encrypted_string;

    EXCEPTION
        WHEN OTHERS THEN
            SQLERRMSG := SQLERRM;
            SQLERRCDE := SQLCODE;
            RETURN NULL;

    END encryptor;


  FUNCTION decryptor (
        input_string        IN  VARCHAR2
    ) RETURN VARCHAR2
    IS
        converted_string    VARCHAR2(64);
        key_seed                VARCHAR2(64) ;            
        converted_seed      RAW(64);
        decrypted_string    VARCHAR2(64);

    BEGIN
        key_seed:='asjdjeuu5men1m40ptoemzia'; --llave encriptacion no cambiar

        converted_string := UTL_I18N.STRING_TO_RAW(input_string, 'AL32UTF8');
        converted_seed   := UTL_I18N.STRING_TO_RAW(key_seed, 'AL32UTF8');

        decrypted_string := 
            DBMS_CRYPTO.DECRYPT(
                 src => input_string
                ,typ => SH1_ECB_ZERO
                ,key => converted_seed
                ,iv =>  NULL);

        converted_string := UTL_I18N.RAW_TO_CHAR(decrypted_string, 'AL32UTF8');

        RETURN converted_string;

    EXCEPTION
        WHEN OTHERS THEN
            SQLERRMSG := SQLERRM;
            SQLERRCDE := SQLCODE;
            RETURN NULL;

    END decryptor;

  END;
  
/
/* Login */
create or replace FUNCTION AUTH_USER -- funcion del login
(
  USERNAME IN VARCHAR2 
, USERPASS IN VARCHAR2 
) RETURN VARCHAR2 IS 
        v_user varchar2(80);
        v_pass varchar2(255);
        v_result varchar2(20);
BEGIN
  v_result:='false';
  select nombre_usuario as username, ADM_UTIL.decryptor(password) as pass 
  into v_user, v_pass
  from usuario
  where nombre_usuario= USERNAME;
  
  if v_user = username and v_pass = userpass then
    v_result:='true';
  elsif v_user = null or v_pass = null then
    v_result:='false';
  else
    v_result:='false';
  end if;
  return v_result;
EXCEPTION
 WHEN OTHERS THEN
    return 'false';
END AUTH_USER;
/
/* Retornar rol*/
create or replace FUNCTION GET_ROL -- funcion para retornar el rol
(
  username IN VARCHAR2 
) RETURN VARCHAR2 IS
    v_rol varchar2(10);

BEGIN

  select rolusuario
  into v_rol
  from usuario 
  where nombre_usuario = username;
  
  IF v_rol != null or  v_rol !=' ' then
    return v_rol;
  else 
    return 'no esta';
  end if;
EXCEPTION
    WHEN OTHERS THEN
     return 'error';
  
END GET_ROL;
/
/* agregar usuario*/
create or replace PROCEDURE AGREGARUSER 
(
  NOMBREUSUARIO IN VARCHAR2 
, CONTRA IN VARCHAR2 
, ROLUSER IN VARCHAR2 
) AS 
BEGIN

  INSERT INTO usuario (
    id_usuario,
    nombre_usuario,
    password,
    rolusuario
  )
  VALUES (IDUSER_SEQ.nextval, nombreusuario, adm_util.encryptor(contra) , roluser);
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then
    
    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);
END AGREGARUSER;
/
/*agregar proveedor*/
create or replace PROCEDURE AGREGARPROV 
(
 RUT IN VARCHAR2 ,
 NOMBRE IN VARCHAR2,
 APELLIDO IN VARCHAR2 ,
 CORREO IN VARCHAR2,
 TEL IN NUMBER,
 RUBRO IN VARCHAR2
) AS 
BEGIN

  INSERT INTO PROVEEDOR (
    RUT_PROVEEDOR,
    NOMBRE_PRO,
    APELLIDO_PRO,
    CORREO_PRO,
    TELEFONO_PRO,
    RUBRO_PRO
  )
  VALUES (RUT, NOMBRE, APELLIDO, CORREO,TEL ,RUBRO );
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then

    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);
END AGREGARPROV;
/
/*editar proveedor*/
CREATE OR REPLACE PROCEDURE EDITARPROV 
(

 NOMBRE IN VARCHAR2,
 APELLIDO IN VARCHAR2 ,
 CORREO IN VARCHAR2,
 TEL IN NUMBER,
 RUBRO IN VARCHAR2,
 RUT IN VARCHAR2 
) AS 
BEGIN

  UPDATE proveedor
  SET NOMBRE_PRO = NOMBRE,
      APELLIDO_PRO = APELLIDO,
      CORREO_PRO = CORREO,
      TELEFONO_PRO = TEL,
      RUBRO_PRO = RUBRO
  WHERE RUT_PROVEEDOR = RUT;
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then

    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);

END EDITARPROV;
/
execute AGREGARUSER('admin','admin','adm'); -- ejemplo insert administrador
--ROL DE USUARIO "adm" "emp" "cli" en minusculas para evitar errores
commit;
/
create or replace FUNCTION FN_LISTARUSUARIO RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM USUARIO;
    RETURN L_CURSOR;
END FN_LISTARUSUARIO;
/
create or replace FUNCTION FN_LISTARPROVEEDORES RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM proveedor;
    RETURN L_CURSOR;
END FN_LISTARPROVEEDORES;
/ 

--CREA un procedimeinto que recibiendo variables guarda un empelado
CREATE OR REPLACE PROCEDURE AgregarEmpleado(rut VARCHAR2, nombre VARCHAR2,apellido VARCHAR2, direccion VARCHAR2, telefono NUMBER,
 correo VARCHAR2, cargo VARCHAR2,id_usuario INTEGER) AS
 BEGIN
 INSERT INTO empleado VALUES (rut, nombre, apellido, direccion, telefono, correo, cargo ,id_usuario);
 commit;
 END AgregarEmpleado;
 /
 --Crea un procedimiento que borra comparando el rut dado con el algun empekado dentro de la li-sta--
 CREATE OR REPLACE PROCEDURE BorrarEmpleado (rut_borrar VARCHAR2) 
 IS BEGIN DELETE FROM empleado WHERE rut_empl=rut_borrar;  
 commit;
 EXCEPTION WHEN OTHERS THEN ROLLBACK;
 END BorrarEmpleado;
 /
 --este modifica los datos del empleaod buscandolo por rut, aun no lo implemento
CREATE OR REPLACE PROCEDURE ModificarEmpleado(rut VARCHAR2, nombre VARCHAR2,apellido VARCHAR2, direccion VARCHAR2, telefono NUMBER,
correo VARCHAR2, cargo VARCHAR2)IS
BEGIN UPDATE empleado SET nombre_empl=nombre, apellido_empl=apellido,  direccion_empl=direccion, telefono_empl=telefono,
correo_emp= correo, cargo_empl=cargo WHERE rut_empl= rut;
commit;
EXCEPTION WHEN OTHERS THEN ROLLBACK;
END ModificarEmpleado;
/--PROCEDIMIENTO VEHICULOS

create or replace PROCEDURE sp_vehiculos(patente vehiculo.patente%TYPE,
anno vehiculo.anno%TYPE, marca vehiculo.marca%TYPE, modelo vehiculo.modelo%TYPE)
AS
BEGIN
    insert into vehiculo VALUES(patente, anno, marca, modelo);
END;
/
--PROCEDIMIENTO RESERVA

create or replace PROCEDURE sp_reserva(r_fecha reserva.fecha_reserva%TYPE,
r_estado reserva.estadoreserva%TYPE, r_patente reserva.patente%TYPE, rut_cli reserva.rut_cli%TYPE)
AS
BEGIN
    INSERT INTO RESERVA(id_reserva, fecha_reserva, estadoreserva, patente, rut_cli)
    VALUES(IDREV_SEQ.nextval,r_fecha, r_estado, r_patente, rut_cli);
END;

select adm_util.decryptor(password) from usuario where nombre_usuario = 'admin';

CREATE OR REPLACE PROCEDURE EditarCli
(

 RUT IN VARCHAR2,
 NOMBRE IN VARCHAR2 ,
 APELLIDOS IN VARCHAR2,
 CORREO  IN VARCHAR2,
 DIRECCION IN VARCHAR2,
 TELEFONO IN NUMBER
) AS 
BEGIN

  UPDATE cliente
  SET NOMBRE_CLI = NOMBRE,
      APELLIDOS_CLI = APELLIDOS ,
      CORREO_CLI = CORREO,
      DIRECCION_CLI = DIRECCION,
      TELEFONO_CLI = TELEFONO
  WHERE RUT_CLI = RUT;
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then

    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);

END EditarCli;
/
create or replace FUNCTION FN_LISTARCLIENTES RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM Cliente;
    RETURN L_CURSOR;
END FN_LISTARCLIENTES;
/
create or replace PROCEDURE AGREGARCLIENTE 
(
 RUT IN VARCHAR2 ,
 NOMBRE IN VARCHAR2,
 APELLIDOS IN VARCHAR2 ,
 CORREO IN VARCHAR2,
 DIRECCION IN VARCHAR2,
 TELEFONO IN NUMBER,
 IDUSUARIO IN NUMBER
) AS 
BEGIN

  INSERT INTO CLIENTE (
    RUT_CLI,
    NOMBRE_CLI,
    APELLIDOS_CLI,
    CORREO_CLI,
    TELEFONO_CLI,
   DIRECCION_CLI,
   ID_USUARIO
  )
  VALUES (RUT, NOMBRE, APELLIDOS, CORREO,TELEFONO ,DIRECCION,IDUSUARIO );
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then

    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);
END AGREGARCLIENTE;
/
create or replace PROCEDURE ELIMINAR_PROVEDOR (rut_borrar VARCHAR2) 
 IS BEGIN 
 DELETE FROM proveedor WHERE rut_proveedor=rut_borrar;  
 commit;
 EXCEPTION WHEN OTHERS THEN ROLLBACK;
 END ELIMINAR_PROVEDOR;
 /
 -- PEDIDO / DETALLE PEDIDO
create or replace FUNCTION FN_LISTARDETALLEPEDIDO RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM DETALLLE_PEDIDO;
    RETURN L_CURSOR;
END FN_LISTARDETALLEPEDIDO;
/
create or replace FUNCTION FN_LISTARPEDIDOS RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM PEDIDO;
    RETURN L_CURSOR;
END FN_LISTARPEDIDOS;
/
create or replace PROCEDURE SP_MODIFICARPEDIDO(
idPedido NUMBER,
FECHA date,
rutEmpleado varchar2,
descripcion varchar2,
rutProveedor varchar2
) as
BEGIN

 UPDATE PEDIDO
 SET
 fecha_pedido = fecha,
 rut_empl = rutEmpleado,
 descripcion_pedido = descripcion,
 rut_proveedor = rutproveedor
 WHERE id_pedido = idPedido;
 
 
 commit;
 DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
when others
then 
DBMS_OUTPUT.PUT_LINE('Error');
 
END SP_MODIFICARPEDIDO;
/
create or replace PROCEDURE SP_EDITARDETALLEPEDIDO
(
idproducto number,
idPedido number,
rutEmp VARCHAR2,
cantidadUnidades number,
estadoPedido varchar2,
comentarioDetalle varchar2
)
AS 
BEGIN
 
 UPDATE DETALLLE_PEDIDO
 SET
 ID_PRODUCTO = idproducto,
 rut_empl = rutEmp,
 cantidad = cantidadUnidades,
 estado = estadoPedido,
 comentario = comentarioDetalle
 WHERE ID_PEDIDO=idPedido and id_producto = idproducto and rut_empl = rutEmp ;
 commit;
 
END SP_EDITARDETALLEPEDIDO;
/
create or replace PROCEDURE SP_AGREGARPEDIDO(
FECHA date,
rutEmpleado varchar2,
descripcion varchar2,
rutProveedor varchar2
) as
BEGIN
 insert into pedido (id_pedido,fecha_pedido,rut_empl,descripcion_pedido,rut_proveedor)
 values (IDPED_SEQ.nextval,fecha,rutEmpleado,descripcion,rutProveedor);
 
 commit;
 DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
when others
then 
DBMS_OUTPUT.PUT_LINE('Error');
 
END SP_AGREGARPEDIDO;
/
create or replace PROCEDURE SP_AGREGARDETALLEPEDIDO(
idproducto number,
idPedido number,
rutEmp VARCHAR2,
cantidadUnidades number,
estado varchar2,
comentario varchar2
) as
BEGIN

 insert into 
 DETALLLE_PEDIDO (cantidad,estado,id_producto,rut_empl,comentario,id_pedido)
 values (cantidadunidades,estado,idproducto,rutEmp,comentario,idPedido);

 commit;
 DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
when others
then 
DBMS_OUTPUT.PUT_LINE('Error');

END SP_AGREGARDETALLEPEDIDO;
/
create or replace PROCEDURE SP_ELIMINARDETALLEPEDIDO
(
idPedido number,
idProducto number,
rutEmp varchar2
)
AS 
BEGIN
  
  DELETE FROM DETALLLE_PEDIDO WHERE ID_PEDIDO=idPedido and id_producto = idproducto and rut_empl = rutEmp ;
  commit;
END SP_ELIMINARDETALLEPEDIDO;
/
-- Listar productos --
create or replace FUNCTION FN_LISTARPRODUCTOS RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM PRODUCTO;
    RETURN L_CURSOR;
END FN_LISTARPRODUCTOS;
/
create or replace PROCEDURE AGREGAFACTURA 
(
    
    fecha_factura IN  DATE,
    neto           IN NUMBER,
    iva            IN NUMBER,
    total          IN NUMBER,
    tipopago      IN VARCHAR2
) AS 
BEGIN

  INSERT INTO factura (
    id_factura ,
    fecha_factura,
    neto,
    iva,
    total, 
    tipopago 
  )
  VALUES (idFac_seq.nextval,  fecha_factura, neto, iva,total,tipopago);
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then
    
    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);
END  AGREGAFACTURA;
/
CREATE OR REPLACE PROCEDURE EditarFac
(
    idf IN NUMBER,
    fecha_factura IN  DATE,
    neto           IN NUMBER,
    iva            IN NUMBER,
    total          IN NUMBER,
    tipopago      IN VARCHAR2
) AS 
BEGIN

  UPDATE factura
  SET fecha_factura =  fecha_factura,
      neto  = neto  ,
      iva   = iva ,
       total  = total,  
       tipopago  =  tipopago 
  WHERE id_factura   = idf;
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then

    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);

END EditarFac;
/
create or replace FUNCTION FN_LISTARFacturas RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM factura;
    RETURN L_CURSOR;
END FN_LISTARFacturas;
/

create or replace FUNCTION FN_LISTARSERV RETURN SYS_REFCURSOR AS 
L_CURSOR SYS_REFCURSOR;
BEGIN
    OPEN l_cursor FOR 
    SELECT * FROM servicio;
    RETURN L_CURSOR;
END FN_LISTARSERV;
/
create or replace PROCEDURE AGREGAFACTURADET 
(
    
    cantidadserv IN NUMBER,
    id_factura  IN NUMBER,
    id_servicio  IN NUMBER,
    valor        IN NUMBER
   
) AS 
BEGIN

  INSERT INTO detalle_factura (
    cantidadserv,
    id_factura,
    id_servicio,
    valor
  
  )
  VALUES (cantidadserv,  id_factura,id_servicio, valor);
  commit;
    DBMS_OUTPUT.PUT_LINE('Tarea completada exitosamente');
EXCEPTION
    when others then
    
    DBMS_OUTPUT.PUT_LINE('ocurrio un error: ');
    DBMS_OUTPUT.PUT_LINE(SQLERRM);
END  AGREGAFACTURADET;
/* insertar datos */
execute AGREGARUSER('admin','admin','adm');
execute AGREGARUSER('seba','seba','emp');
execute AGREGARUSER('juanMecanico','1234','emp');
execute AGREGARUSER('persona1','pass','cli');
execute AGREGARUSER('persona2','contra','cli');
/
-- agregar proveedores

execute agregarprov('111111111','Jose','Muroz','Algo@correo.cl',986731245,'Automotores');
execute agregarprov('72702123','Pedro Arturo','Sierra','uncorreo@yopmail.com',987654321,'Suministro_Oficina');
					
-- agregar clientes
execute agregarcliente('172441610','Francisco','Torres','contactoCliente@yopmail.com','Avenida Siempreviva 742',123456789,5);
execute agregarcliente('165499832','Juan','Pilot','contactoCliente@yopmail.com','calle desconocida 994',123456789,6);
-- agregar empleados
execute agregarempleado('83239514','Juan Jose','Fuenzalida','Evergreen Terrace',988961776,'correo@yopmail.com','Mecanico',3);
execute agregarempleado('78638265','Sebastian','Fernandez','Main Street',897621453,'correo@yopmail.com','Bodeguero',2);

-- Tipo de producto
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Lubricantes');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Nehumaticos');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Baterias');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Selladores');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Adesivos');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Alternador');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Embregues');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Carroceria');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Filtro');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Frenos');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Distribucion');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Motor');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Suspension');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Catalizador');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Sensores');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Refrigeracion');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Calefaccion');
insert into tipoproducto (idtipo,descripcion) values (IDTIPO_SEQ.nextval,'Eletricidad');
-- agregar productos
INSERT INTO producto VALUES ('9148231052022', '150000', '100', '20', 'Neumaticos aro 13', '180000', '22', TO_DATE('2022-05-31 10:28:21', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO producto VALUES ('1512531052022', '185000', '300', '20', 'Neumaticos aro 15', '200000', '22', TO_DATE('2022-05-31 10:28:21', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO producto VALUES ('91403200000000', '200000', '300', '20', 'Motor diesel', '200000', '32', null);
-- servicios
insert into servicio values(IDSS_SEQ.nextval,'Revision Full','83239514',20000); -- id 2 
-- vehiculo
INSERT INTO vehiculo(PATENTE, ANNO, MARCA, MODELO) VALUES ('xh6640', '1993', 'toyota', 'tercel');
-- reserva
insert into reserva values(IDREV_SEQ.nextval,'01-06-2020','pendiente','xh6640','172441610',2); -- id 1
commit;