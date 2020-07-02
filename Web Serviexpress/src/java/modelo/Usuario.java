/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

/**
 *
 * @author Sebastian Carrasco B
 */
public class Usuario {
    int id_usuario;
    String usuario;
    String pass;
    String rolusuario;
    
    public Usuario(){
        
    }

    public Usuario(int id_usuario, String usuario, String pass, String rolusuario) {
        this.id_usuario = id_usuario;
        this.usuario = usuario;
        this.pass = pass;
        this.rolusuario = rolusuario;
    }

    public int getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(int id_usuario) {
        this.id_usuario = id_usuario;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }

    public String getRolusuario() {
        return rolusuario;
    }

    public void setRolusuario(String rolusuario) {
        this.rolusuario = rolusuario;
    }

    
}
