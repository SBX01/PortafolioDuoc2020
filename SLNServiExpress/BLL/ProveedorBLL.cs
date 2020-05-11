﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Validaciones;

namespace BLL
{
    public class ProveedorBLL
    {
        Validacion val = new Validacion();
        #region Propiedades
        string _rut;
        string _nombre;
        string _apellido;
        string _correo;
        int _telefono;



        public Rubros Rubro { get; set; }
        public string Rut 
        { 
            get
            {
             return _rut;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    
                    if (val.validarRut(value))
                    {
                        _rut = value;
                    }
                    else
                    {
                        throw new Exception("El rut ingresado no es válido");
                    }
                }
                else
                {
                    throw new Exception("El rut se encuentra vacio");
                }
            }
                
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nombre = value;
                }
                else
                {
                    throw new Exception("El nombre se encuentra vacio");
                }
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                     _apellido = value;
                }
                else
                {
                    throw new Exception("El apellido se encuentra vacio");
                }
            }
        }
        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (val.emailValido(value))
                    {
                        _correo = value;
                    }
                    else
                    {
                        throw new Exception("El email ingresado no es válido");
                    }
                }
                else
                {
                    throw new Exception("El Email se encuentra vacio");
                }
            }
        }
        public int Tel
        {
            get
            {
                return _telefono;
            }

            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    if (val.telefonoValido(value.ToString()))
                    {
                        _telefono = value;
                    }
                    else
                    {
                        throw new Exception("El telefono ingresado no es válido");
                    }
                }
                else
                {
                    throw new Exception("El telefono se encuentra vacio");
                }
            }
        }
        #endregion
        public ProveedorBLL(){}

        public ProveedorBLL(Proveedor nuevo)
        {
            this.Rut = nuevo.RutProveedor;
            this.Nombre =nuevo.Nombre;
            this.Apellido = nuevo.Apellido;
            this.Correo = nuevo.Correo;
            this.Tel =nuevo.Telefono;
            switch (nuevo.Rubro)
            {
                case "Automotores":
                    this.Rubro = Rubros.Automotores;
                    break;
                case "Combustibles":
                    this.Rubro = Rubros.Combustibles;
                    break;
                case "Lubricantes":
                    this.Rubro = Rubros.Lubricantes;
                    break;
                case "Suministro_Oficina":
                    this.Rubro = Rubros.Suministro_Oficina;
                    break;
                case "Informatica":
                    this.Rubro = Rubros.Informatica;
                    break;
                case "Servicios_básicos":
                    this.Rubro = Rubros.Servicios_básicos;
                    break;
                case "Repuestos_vehiculos":
                    this.Rubro = Rubros.Repuestos_vehiculos;
                    break;
            }
        }

        public void Agregar()
        {

            Proveedor nuevo = new Proveedor();
            nuevo.RutProveedor = this.Rut;
            nuevo.Nombre = this.Nombre;
            nuevo.Apellido = this.Apellido;
            nuevo.Correo = this.Correo;
            nuevo.Telefono = this.Tel;
            nuevo.Rubro = this.Rubro.ToString();
            nuevo.AgregarProveedor();
            Console.WriteLine("BLL: agregar");
        }

        public void Modificar()
        {
            Proveedor editar = new Proveedor();
            editar.RutProveedor = this.Rut;
            editar.Nombre = this.Nombre;
            editar.Apellido = this.Apellido;
            editar.Correo = this.Correo;
            editar.Telefono = this.Tel;
            editar.Rubro = this.Rubro.ToString();
            editar.EditarProveedor();
            Console.WriteLine("BLL: modificar");
        }



        public ProveedorBLL buscarPorRut(string rutPro)
        {
            Proveedor aBsucar = new Proveedor();
            aBsucar = aBsucar.BuscarProveedor(rutPro);
            if(aBsucar != null)
            {
                ProveedorBLL encontado = new ProveedorBLL();
                encontado.Rut = aBsucar.RutProveedor;
                encontado.Nombre = aBsucar.Nombre;
                encontado.Apellido = aBsucar.Apellido;
                encontado.Correo = aBsucar.Correo;
                encontado.Tel = aBsucar.Telefono;
                switch (aBsucar.Rubro)
                {
                    case "Automotores":
                        encontado.Rubro = Rubros.Automotores;
                        break;
                    case "Combustibles":
                        encontado.Rubro = Rubros.Combustibles;
                        break;
                    case "Lubricantes":
                        encontado.Rubro = Rubros.Lubricantes;
                        break;
                    case "Suministro_Oficina":
                        encontado.Rubro = Rubros.Suministro_Oficina;
                        break;
                    case "Informatica":
                        encontado.Rubro = Rubros.Informatica;
                        break;
                    case "Servicios_básicos":
                        encontado.Rubro = Rubros.Servicios_básicos;
                        break;
                    case "Repuestos_vehiculos":
                        encontado.Rubro = Rubros.Repuestos_vehiculos;
                        break;
                }

                return encontado;
            }
            else
            {
                return null;
            }

            
        }

        public string buscarRut(string rutPro)
        {
            //cambiar
            Proveedor proveedor = new Proveedor();
            string provRut;
            provRut = proveedor.BuscarRut(rutPro);
            return provRut;
        }

        public List<ProveedorBLL> listarTodos()
        {
            Proveedor proveedor = new Proveedor();
            List<Proveedor> lista =  proveedor.listar();
            List< ProveedorBLL > listaRetorno = new List<ProveedorBLL>();
            foreach (var item in lista)
            {
                listaRetorno.Add(new ProveedorBLL(item));
            }
            return listaRetorno;
        }

        public List<string> listaRutProveedor()
        {
            Proveedor proveedor = new Proveedor();
            List<string> lista = proveedor.ListarRut();
            return lista;

        }

        public void Eliminar(string rut)
        {
            ProveedorBLL abuscar = new ProveedorBLL();
            Proveedor borrado = new Proveedor();
            abuscar = abuscar.buscarPorRut(rut);
            if (abuscar != null)
            {
                borrado.EliminarProveedor(rut);
            }
            else
            {
                throw new Exception("El proveedor no se ha encontrado");
            }

        }

    }
    public enum Rubros 
    { 
        Automotores, 
        Combustibles, 
        Lubricantes, 
        Suministro_Oficina,
        Informatica, 
        Servicios_básicos,
        Repuestos_vehiculos
    }
}
