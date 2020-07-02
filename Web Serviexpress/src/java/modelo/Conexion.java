/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 *
 * @author Sebastian Carrasco B
 */
public class Conexion {
    Connection con;
    String url = "jdbc:oracle:thin:@localhost:1521:XE";
//    String user = "SERVIE";
//    String pass = "19C"; 
    String user = "serviexpress"; //coneccion seba olivera
    String pass = "seba";
    
    
    public Connection conectar(){
        try{
            Class.forName("oracle.jdbc.driver.OracleDriver");
            con=DriverManager.getConnection(url,user,pass);
        } catch (Exception e){
            e.printStackTrace();
        }
        return con;
    }
}
