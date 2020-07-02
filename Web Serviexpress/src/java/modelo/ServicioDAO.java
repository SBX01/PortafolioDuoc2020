/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Sebastian Carrasco B
 */
public class ServicioDAO {
    PreparedStatement ps;
    ResultSet rs;
    Conexion c = new Conexion();
    Connection con;
    
    public List listar(){
        List<Servicio>lista = new ArrayList<>();
        String sql = "select * from servicio";
        try {
            con = c.conectar();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while(rs.next()){
               Servicio s = new Servicio();
               s.setId_servicio(rs.getInt(1));
               s.setTiposervicio(rs.getString(2));
               s.setRutEmpleado(rs.getString(3));
               s.setPrecioServicio(rs.getInt(4));
               lista.add(s);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return lista;
    }
    
    public List buscar(int id){
        List<Servicio> lista = new ArrayList<>();
        String sql = "select id_servicio from servicio where id_servicio="+id+"";
        try {
            con=c.conectar();
            ps=con.prepareStatement(sql);
            rs=ps.executeQuery();
            while(rs.next()){
               Servicio ss = new Servicio();
               ss.setId_servicio(rs.getInt(1));
               lista.add(ss);
            }   
        } catch (Exception e) {
            e.printStackTrace();
        } return lista;
    }
}
