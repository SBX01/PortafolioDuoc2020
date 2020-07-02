/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author Sebastian Carrasco B
 */
public class Reserva {
    int id_reserva;
    Date fechareserva;
    String estadoreserva;
    String patente;
    String rut;
    int id_servicio;

    public Reserva() {
    }

    public Reserva(int id_reserva, Date fechareserva, String estadoreserva, String patente, String rut, int id_servicio) {
        this.id_reserva = id_reserva;
        this.fechareserva = fechareserva;
        this.estadoreserva = estadoreserva;
        this.patente = patente;
        this.rut = rut;
        this.id_servicio = id_servicio;
    }

    public int getId_reserva() {
        return id_reserva;
    }

    public void setId_reserva(int id_reserva) {
        this.id_reserva = id_reserva;
    }

    public Date getFechareserva() {
        return fechareserva;
    }

    public void setFechareserva(Date fechareserva) {
        this.fechareserva = fechareserva;
    }

    public String getEstadoreserva() {
        return estadoreserva;
    }

    public void setEstadoreserva(String estadoreserva) {
        this.estadoreserva = estadoreserva;
    }

    public String getPatente() {
        return patente;
    }

    public void setPatente(String patente) {
        this.patente = patente;
    }

    public String getRut() {
        return rut;
    }

    public void setRut(String rut) {
        this.rut = rut;
    }

    public int getId_servicio() {
        return id_servicio;
    }

    public void setId_servicio(int id_servicio) {
        this.id_servicio = id_servicio;
    }
    
    public String fechaFormateada(Date date){
        return new SimpleDateFormat("dd-MM-yyyy").format(date);
    }
    
    
}
