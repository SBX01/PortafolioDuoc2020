﻿#pragma checksum "..\..\EliminarProveedor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A3D36B8DBB4C83935116ED4E122805556F4A5067D6B24239365EA370630311F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using ServiExpress;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ServiExpress {
    
    
    /// <summary>
    /// EliminarProveedor
    /// </summary>
    public partial class EliminarProveedor : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\EliminarProveedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblrutp;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EliminarProveedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cborutprov;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EliminarProveedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btnatras;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\EliminarProveedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReload;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\EliminarProveedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProv;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ServiExpress;component/eliminarproveedor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EliminarProveedor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\EliminarProveedor.xaml"
            ((ServiExpress.EliminarProveedor)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MetroWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblrutp = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cborutprov = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\EliminarProveedor.xaml"
            this.cborutprov.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cborutprov_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btnatras = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\EliminarProveedor.xaml"
            this.Btnatras.Click += new System.Windows.RoutedEventHandler(this.Btnatras_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnReload = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\EliminarProveedor.xaml"
            this.btnReload.Click += new System.Windows.RoutedEventHandler(this.btnReload_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgProv = ((System.Windows.Controls.DataGrid)(target));
            
            #line 43 "..\..\EliminarProveedor.xaml"
            this.dgProv.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgProv_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

