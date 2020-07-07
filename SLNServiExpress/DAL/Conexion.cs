﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        //private readonly static Conexion instancia = new Conexion();
        const string conString = "User Id=serviexpress;Password=adminjuanpedro;Data Source=localhost:1521/xe;";
        //string conString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;

        public OracleConnection con = null;
        public Conexion()
        {
            con = new OracleConnection(conString);
        }
        //public static Conexion Instance
        //{
        //    get
        //    {
        //        return instancia;
        //    }
        //}


        public void Conectar()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error BLL: " + ex.Message);
            }
           
        }
        public void desconectar()
        {
            try
            {
                con.Close();
            }
            catch(Exception ex)
            {
                con.Close();
                Console.WriteLine("Error BLL: " + ex.Message);

            }
            Console.WriteLine("DAL: desconectar");
        }


    }
}
