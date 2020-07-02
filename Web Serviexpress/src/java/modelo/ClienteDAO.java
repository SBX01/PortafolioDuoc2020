/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import modelo.Usuario;

/**
 *
 * @author Sebastian Carrasco B
 */
public class ClienteDAO {
    PreparedStatement ps;
    ResultSet rs;
    Conexion c = new Conexion();
    Connection con;
    
    /*public int agregar(Cliente cl){
        int r=0;
        String sql="insert into cliente(rut_cli, nombre_cli, apellidos_cli, correo_cli, telefono_cli, direccion_cli, id_usuario)"
                + "VALUES(?,?,?,?,?,?,(select last_number-1 from user_sequences WHERE sequence_name = 'USUARIO_SEQ'))";
        try{            
            con = c.conectar();
            ps = con.prepareStatement(sql);
            ps.setString(1, cl.getRut());
            ps.setString(2, cl.getNombre());
            ps.setString(3, cl.getApellidos());
            ps.setString(4, cl.getCorreo());
            ps.setInt(5, cl.getTelefono());
            ps.setString(6, cl.getDireccion());             
            r = ps.executeUpdate();
            
            if(r==1){
                r=1;
            }else{
                r=0;
            }
        } catch(Exception e) {
            e.printStackTrace();
        }
        return r;
    }*/
    public int agregar(Cliente cc){
        try {
            con = c.conectar();
            CallableStatement cstmt = con.prepareCall("{Call sp_insertarCliente(?,?,?,?,?,?)}");
            cstmt.setString(1, cc.getRut());
            cstmt.setString(2, cc.getNombre());
            cstmt.setString(3, cc.getApellidos());
            cstmt.setString(4, cc.getCorreo());
            cstmt.setInt(5, cc.getTelefono());
            cstmt.setString(6, cc.getDireccion());
            //cstmt.setInt(7, cc.getId_usuario());
            
            //cstmt.registerOutParameter(1, java.sql.Types.VARCHAR);
            cstmt.executeUpdate();
            
            } catch (SQLException ex) {
                Logger.getLogger(ReservaDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
        return 0;
    }
    
    
    /*public List listarCliente(){
        List<Cliente>lista = new ArrayList<>();
        String sql = "select * from cliente";
        try {
            con = c.conectar();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while(rs.next()){
               Cliente c = new Cliente();
               c.setRut(rs.getString(1));
               c.setNombre(rs.getString(2));
               c.setApellidos(rs.getString(3));
               c.setCorreo(rs.getString(4));
               c.setTelefono(rs.getInt(5));
               c.setDireccion(rs.getString(6));
               c.setId_usuario(rs.getInt(7));
               lista.add(c);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return lista;
    }*/
    
    public List buscar(int id){
        List<Cliente> lista = new ArrayList<>();
        String sql = "select * from cliente where id_usuario="+id+"";
        try {
            con=c.conectar();
            ps=con.prepareStatement(sql);
            rs=ps.executeQuery();
            while(rs.next()){
               Cliente cc = new Cliente();
               cc.setRut(rs.getString(1));
               cc.setNombre(rs.getString(2));
               cc.setApellidos(rs.getString(3));
               cc.setCorreo(rs.getString(4));
               cc.setTelefono(rs.getInt(5));
               cc.setDireccion(rs.getString(6));
               cc.setId_usuario(rs.getInt(7));
               lista.add(cc);            }   
        } catch (Exception e) {
            e.printStackTrace();
        } return lista;
    }
}
