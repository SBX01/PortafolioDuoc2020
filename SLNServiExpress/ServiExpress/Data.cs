using ServiExpress.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpress
{
    public static class Data
    {
        public static bool EstaLogeado { get; set; }
        public static bool EsAdmin { get; set; }
        public static string NombreUser { get; set; }
        public static string RolUserActivo { get; set; }
        public static int IdUserActivo { get; set; }
        public static string CargoEmpleadoLogeado { get; set; }
        public static string RutEmpleadoActivo { get; set; }
        public static long IdProductoSeleccionado { get; set; }

    }
}
