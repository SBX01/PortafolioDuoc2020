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
import modelo.UsuarioDAO;
import modelo.Vehiculo;
import modelo.VehiculoDAO;

/**
 *
 * @author Sebastian Carrasco B
 */
public class RegistrarVehiculo extends HttpServlet {
    
    
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
            out.println("<title>Servlet Vehiculo</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet Vehiculo at " + request.getContextPath() + "</h1>");
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
            //VehiculoDAO vdao = new VehiculoDAO();
            VehiculoDAO vdao = new VehiculoDAO();
            List<Vehiculo> vehiculos;
            
            try {
                vehiculos = vdao.listar();
                request.setAttribute("vehiculos", vehiculos);
                request.getRequestDispatcher("WEB-INF/vehiculo.jsp").forward(request, response);
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
        VehiculoDAO vdao = new VehiculoDAO();
        Vehiculo v = new Vehiculo();
        switch(accion){
            case "Registrar":
                String patente = request.getParameter("patente");
                int anno = Integer.parseInt(request.getParameter("anno"));
                String marca = request.getParameter("marca");
                String modelo = request.getParameter("modelo");
                
                v.setPatente(patente);
                v.setAnno(anno);
                v.setMarca(marca);
                v.setModelo(modelo);
                vdao.agregarVeh(v);

                List<Vehiculo> vehiculos = vdao.listar();
                request.setAttribute("vehiculos", vehiculos);
                request.setAttribute("mensaje", "Vehiculo añadido correctamente");
                request.getRequestDispatcher("WEB-INF/vehiculo.jsp").forward(request, response);
                
                //response.sendRedirect("RegistrarVehiculo");
                break;
            case "Eliminar":
                String paten = request.getParameter("idpatente");
                //vehiculos = vdao.listar();
                //request.setAttribute("vehiculos", vehiculos);
                try {
                    vdao.eliminar(paten);
                    //request.setAttribute("error", "Vehiculo correctamente eliminado");
                    //request.getRequestDispatcher("WEB-INF/vehiculo.jsp").forward(request, response);
                    response.sendRedirect("RegistrarVehiculo");
                } catch (Exception e) {
                    e.printStackTrace();
                    vehiculos = vdao.listar();
                    request.setAttribute("vehiculos", vehiculos);
                    request.setAttribute("error", "Este vehículo esta asociado a una reserva");
                }
                //response.sendRedirect("RegistrarVehiculo");
                break;
            default:
                request.setAttribute("error", "Ha ocurrido un problema desconocido, no se ha podido eliminar el vehiculo.");
                request.getRequestDispatcher("WEB-INF/vehiculo.jsp").forward(request, response);
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
