/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.Date;
//import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
//import java.sql.SQLException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Sebastian Carrasco B
 */
public class ReservaDAO {
    PreparedStatement ps;
    ResultSet rs;
    Conexion c = new Conexion();
    Connection con;
    
    /*public int agregar(Reserva re){
        int r=0;
        String sql="insert into reserva(id_reserva, fecha_reserva, estadoreserva, patente, rut_cli, id_servicio)"
                + "VALUES(reserva_seq.nextval,?,?,?,?,?)";
        try{
            con = c.conectar();
            ps = con.prepareStatement(sql);
            ps.setDate(1, (java.sql.Date)re.getFechareserva());
            ps.setString(2, re.getEstadoreserva());
            ps.setString(3, re.getPatente());
            ps.setString(4, re.getRut());
            ps.setInt(5, re.getId_servicio());
            
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
        
        public int agregar(Reserva r){
        try {
            con = c.conectar();
            CallableStatement cstmt = con.prepareCall("{Call sp_reserva(?,?,?,?,?)");
            cstmt.setDate(1, (java.sql.Date) r.getFechareserva());
            cstmt.setString(2, r.getEstadoreserva());
            cstmt.setString(3, r.getPatente());
            cstmt.setString(4, r.getRut());
            cstmt.setInt(5, r.getId_servicio());
            cstmt.executeUpdate();
        } catch (SQLException ex) {
            Logger.getLogger(ReservaDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
        return 0;
        }
   
        public List listar(){
        List<Reserva>lista = new ArrayList<>();
        String sql = "SELECT id_reserva, fecha_reserva, estadoreserva, vehiculo.marca||' '|| vehiculo.modelo, cliente.nombre_cli ||' '|| cliente.apellidos_cli, id_servicio from reserva natural join cliente natural join vehiculo natural join servicio";
        try {
            con = c.conectar();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while(rs.next()){
               Reserva r = new Reserva();
               r.setId_reserva(rs.getInt(1));
               r.setFechareserva(rs.getDate(2));
               r.setEstadoreserva(rs.getString(3));
               r.setPatente(rs.getString(4));
               r.setRut(rs.getString(5));
               r.setId_servicio(rs.getInt(6));
               lista.add(r);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return lista;
    }
        
    public void eliminar(int id){
        String sql="DELETE FROM reserva where id_reserva="+id+"";
        try {
            con=c.conectar();
            ps = con.prepareStatement(sql);
            ps.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }
        
    }    
    
}
