﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para EliminarProveedor.xaml
    /// </summary>
    public partial class EliminarProveedor : MetroWindow
    {
        public EliminarProveedor()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedor reg = new RegistroProveedor();
            this.Close();
            reg.ShowDialog();
        }
    }
}
