/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

//import java.sql.CallableStatement;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Sebastian Carrasco B
 */
public class UsuarioDAO {
    PreparedStatement ps;
    ResultSet rs;
    Conexion c = new Conexion();
    Connection con;
    
    /*public int regUser(Usuario us){
        int r=0;
        String sql="Insert into usuario(id_usuario, nombre_usuario, password, rolusuario) "
                + "VALUES(USUARIO_SEQ.NEXTVAL, ?,?,?)";
        try{
            con = c.conectar();
            ps = con.prepareStatement(sql);
            ps.setString(1, us.getUsuario());
            ps.setString(2, us.getPass());            
            ps.setString(3, us.getRolusuario());
                        
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
    
    public int regUser(Usuario u){
        try {
            con = c.conectar();
            CallableStatement cstmt = con.prepareCall("{Call sp_insertarUsuario(?,?,?)}");
            cstmt.setString(1, u.getUsuario());
            cstmt.setString(2, u.getPass());
            cstmt.setString(3, u.getRolusuario());
            //cstmt.registerOutParameter(1, java.sql.Types.VARCHAR);
            cstmt.executeUpdate();
            
            } catch (SQLException ex) {
                Logger.getLogger(ReservaDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
        return 0;
    }
    
        public String loguear(String user, String pass){
        String rolusuario="";
        //String sql = "Select rolusuario FROM USUARIO WHERE nombre_usuario = LOWER('"+user+"') AND password = lower('"+pass+"')";
        String sql = "Select rolusuario FROM USUARIO WHERE nombre_usuario = ('"+user+"') AND adm_util.decryptor(password) = '"+pass+"'";
        try{
            con = c.conectar();
            ps = con.prepareStatement(sql); 
            rs = ps.executeQuery();

            while(rs.next()){                    
                rolusuario = rs.getString(1);
            }
            con.close();
        } catch(Exception e){

        System.out.println("error");
    }

    return rolusuario;
    }
    
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
    
    public List buscarUsu(String nombre){
        List<Usuario> lista = new ArrayList<>();
        String sql = "select id_usuario from usuario where nombre_usuario='"+nombre+"'";
        try {
            con=c.conectar();
            ps=con.prepareStatement(sql);
            rs=ps.executeQuery();
            while(rs.next()){
               Usuario u = new Usuario();
               u.setId_usuario(rs.getInt(1));
               lista.add(u);            
            }   
        } catch (Exception e) {
            e.printStackTrace();
        } return lista;
    }    
    /*public String loguear(String user, String pass){
        try {
            CallableStatement pa = con.prepareCall("{call listarUsuario(?,?)}");
            pa.setString(1, user);
            pa.setString(2, pass);
            //pa.registerOutParameter(3, java.sql.Types.VARCHAR);
            pa.execute();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }*/
}
