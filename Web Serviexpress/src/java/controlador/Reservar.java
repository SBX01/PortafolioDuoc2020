/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.io.IOException;
import java.io.PrintWriter;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.sql.Date;
import java.text.DateFormat;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import modelo.ReservaDAO;
import modelo.Servicio;
import modelo.Reserva;
import modelo.ServicioDAO;
import modelo.UsuarioDAO;
import modelo.Vehiculo;
import modelo.VehiculoDAO;

/**
 *
 * @author Sebastian Carrasco B
 */
public class Reservar extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet Reserva</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet Reserva at " + request.getContextPath() + "</h1>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        //processRequest(request, response);
        HttpSession s = request.getSession();
        
        UsuarioDAO udao = (UsuarioDAO)s.getAttribute("sesion");
        if(udao==null){
            response.sendRedirect("login");
            return;
        }else{
            ServicioDAO dao= new ServicioDAO();
            VehiculoDAO vdao = new VehiculoDAO();
            List<Servicio> servicios;
            List<Vehiculo> vehiculos;
            vehiculos = vdao.listar();
            try{
                /*if(vehiculos.isEmpty()){
                    request.setAttribute("mensajes", "Debes registrar un vehiculo");
                    request.getRequestDispatcher("WEB-INF/reserva.jsp").forward(request, response);
                }else{*/
                    servicios = dao.listar();
                    request.setAttribute("servicios", servicios);
                    request.setAttribute("vehiculos", vehiculos);
                    //response.sendRedirect("Reservar");
                    request.getRequestDispatcher("WEB-INF/reserva.jsp").forward(request, response);
                //}
                
            }
            catch(Exception e){
                e.printStackTrace();
            }
        }
        
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            //processRequest(request, response);
            //obtengo valores
            
            String vehiculo = request.getParameter("vehiculo");
            String rut = request.getParameter("rut");
            int servicio = Integer.parseInt(request.getParameter("servicio"));
            //String estado = request.getParameter("estado");
            
            /*String stopDateStr = request.getParameter("fecha");
            SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");
            Date to = sdf.parse(stopDateStr); otra alternativa*/
            
            
            SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
            java.util.Date fecha = f.parse(request.getParameter("fecha"));
            Date fechasql = new Date(fecha.getTime());
            
            ReservaDAO rdao = new ReservaDAO();
            Reserva r = new Reserva();
            
            r.setPatente(vehiculo);
            /*DateFormat df = new SimpleDateFormat("yyyyMMdd");
            r.setFechareserva((java.sql.Date) df.parse(request.getParameter("fecha")));*/
            
            r.setFechareserva(fechasql);
            r.setEstadoreserva("ACTIVO");
            r.setId_servicio(servicio);
            r.setRut(rut);
            rdao.agregar(r);
            System.out.println("patente: "+ vehiculo+" fecha: "+fechasql+ "| servicio id: "+servicio+ " rut: "+rut);
            request.setAttribute("mensaje", "Reserva realizada correctamente");
            //response.sendRedirect("Reservar");
            request.getRequestDispatcher("WEB-INF/reserva.jsp").forward(request, response);
            
        } catch (ParseException ex) {
            Logger.getLogger(Reservar.class.getName()).log(Level.SEVERE, null, ex);
            request.setAttribute("mensaje", "Ha ocurrido un error desconocido, no se ha podido registrar reserva.");
            request.getRequestDispatcher("WEB-INF/reserva.jsp").forward(request, response);
        }
        }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}