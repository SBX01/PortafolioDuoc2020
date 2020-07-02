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
public class Servicio {
    int id_servicio;
    String tiposervicio;
    String rutEmpleado;
    int precioServicio;

    public Servicio() {
    }

    public Servicio(int id_servicio, String tiposervicio, String rutEmpleado, int precioServicio) {
        this.id_servicio = id_servicio;
        this.tiposervicio = tiposervicio;
        this.rutEmpleado = rutEmpleado;
        this.precioServicio = precioServicio;
    }

    public int getId_servicio() {
        return id_servicio;
    }

    public void setId_servicio(int id_servicio) {
        this.id_servicio = id_servicio;
    }

    public String getTiposervicio() {
        return tiposervicio;
    }

    public void setTiposervicio(String tiposervicio) {
        this.tiposervicio = tiposervicio;
    }

    public String getRutEmpleado() {
        return rutEmpleado;
    }

    public void setRutEmpleado(String rutEmpleado) {
        this.rutEmpleado = rutEmpleado;
    }

    public int getPrecioServicio() {
        return precioServicio;
    }

    public void setPrecioServicio(int precioServicio) {
        this.precioServicio = precioServicio;
    }
    
    
    
}
