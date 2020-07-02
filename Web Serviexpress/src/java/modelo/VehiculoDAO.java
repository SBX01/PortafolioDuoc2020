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

/**
 *
 * @author Sebastian Carrasco B
 */
public class VehiculoDAO {
    PreparedStatement ps;
    ResultSet rs;
    Conexion c = new Conexion();
    Connection con;
    
    public List listar(){
        List<Vehiculo>lista = new ArrayList<>();
        String sql = "select * from vehiculo";
        try {
            con = c.conectar();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while(rs.next()){
               Vehiculo v = new Vehiculo();
               v.setPatente(rs.getString(1));
               v.setAnno(rs.getInt(2));
               v.setMarca(rs.getString(3));
               v.setModelo(rs.getString(4));
               lista.add(v);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return lista;
    }
    
    /*public int agregar(Vehiculo v){
        int r=0;
        String sql="insert into vehiculo(patente, anno, marca, modelo)"
                + "VALUES(?,?,?,?)";
        try{
            con = c.conectar();
            ps = con.prepareStatement(sql);
            ps.setString(1, v.getPatente());
            ps.setInt(2, v.getAnno());            
            ps.setString(3, v.getMarca());
            ps.setString(4, v.getModelo());
                        
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

    public int agregarVeh(Vehiculo v){
        try {
            con = c.conectar();
            CallableStatement cstmt = con.prepareCall("{Call sp_vehiculos(?,?,?,?)}");
            cstmt.setString(1, v.getPatente());
            cstmt.setInt(2, v.getAnno());
            cstmt.setString(3, v.getMarca());
            cstmt.setString(4, v.getModelo());
            //cstmt.registerOutParameter(1, java.sql.Types.VARCHAR);
            cstmt.executeUpdate();
            
            } catch (SQLException ex) {
                Logger.getLogger(ReservaDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
        return 0;
    }
    
    public void eliminar(String id){
        String sql="DELETE FROM vehiculo where patente='"+id+"'";
        try {
            con=c.conectar();
            ps = con.prepareStatement(sql);
            ps.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }
        
    }
}
