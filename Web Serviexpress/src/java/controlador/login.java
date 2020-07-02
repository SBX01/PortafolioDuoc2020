/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import modelo.ClienteDAO;
import modelo.Conexion;
import modelo.Usuario;
import modelo.UsuarioDAO;

/**
 *
 * @author Sebastian Carrasco B
 */
public class login extends HttpServlet {
    Conexion con;
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
            out.println("<title>Servlet login</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet login at " + request.getContextPath() + "</h1>");
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
            request.getRequestDispatcher("WEB-INF/login.jsp").forward(request, response); 
        }else{
            request.getRequestDispatcher("WEB-INF/cliente.jsp").forward(request, response);
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
        //processReq0uest(request, response);
        
        //Usuario u = new Usuario();
        UsuarioDAO udao = new UsuarioDAO();
        //ClienteDAO cdao = new ClienteDAO();
        String accion = request.getParameter("btn");
        
         switch (accion){
            case "Ingresar":
                //request.getRequestDispatcher("WEB-INF/reserva.jsp").forward(request, response);
                if(request.getParameter("btn")!=null){
                    //con.conectar();                    
                    String user= request.getParameter("user");
                    String pass= request.getParameter("pass");
                    HttpSession sesion = request.getSession();
                    //rol = udao.loguear(user, pass);
                    
                    //int rut = cdao.buscar(0)
                    String log=udao.loguear(user, pass);      
                    
                        if(log.equalsIgnoreCase("cli")){
                           System.out.println(udao.loguear(user, pass));
                               sesion.setAttribute("sesion", udao);
                               sesion.setAttribute("iduser", udao.buscarUsu(user));
                               sesion.setAttribute("rolusuario", "Cli");
                               request.getSession().setAttribute("usuario", user.toUpperCase());
                               System.out.println("cliente");
                               request.getRequestDispatcher("WEB-INF/cliente.jsp").forward(request, response);
                               //response.sendRedirect("PerfilCliente"); 
                        }
                        else{
                             System.out.println("error, usuario no existe");   
                        }
                                                      
                              

                       
                   }else{
                       System.out.println("error");
                   }

               default:
                   request.setAttribute("mensaje", "Usuario y/o contraseña incorrectos.");
                   request.getRequestDispatcher("WEB-INF/login.jsp").forward(request, response);                
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
