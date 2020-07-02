/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import modelo.Reserva;
import modelo.ReservaDAO;
import modelo.Servicio;
import modelo.ServicioDAO;
import modelo.UsuarioDAO;
import modelo.Vehiculo;
import modelo.VehiculoDAO;

/**
 *
 * @author Sebastian Carrasco B
 */
public class ListaReservas extends HttpServlet {

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
            out.println("<title>Servlet ListaReservas</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet ListaReservas at " + request.getContextPath() + "</h1>");
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
        }else{
            ReservaDAO rdao = new ReservaDAO();
            ServicioDAO sdao= new ServicioDAO();
            List<Reserva> reservas;
            //int servid = Integer.parseInt(request.getParameter("servid"));
            //List<Servicio> servicios= sdao.buscar(servid);
            List<Servicio> servicios = sdao.listar();
            try {
                reservas = rdao.listar();
                if(reservas.isEmpty()){
                    request.setAttribute("mensajes", "No se han realizado reservas");
                    request.getRequestDispatcher("WEB-INF/listaReservas.jsp").forward(request, response);
               }
                
                request.setAttribute("servicios", servicios);
                System.out.println(servicios);
                request.setAttribute("reservas", reservas);
                request.getRequestDispatcher("WEB-INF/listaReservas.jsp").forward(request, response);
            } catch (Exception e) {
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
        //processRequest(request, response);
        String accion = request.getParameter("accion");
        ReservaDAO rdao= new ReservaDAO();
        switch(accion){
            case "Cancelar Reserva":
                int reser = Integer.parseInt(request.getParameter("idreserva"));
                rdao.eliminar(reser);
                response.sendRedirect("ListaReservas");
                break;
            default:
                request.getRequestDispatcher("WEB-INF/listaReservas.jsp").forward(request, response);
                throw new AssertionError();
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
