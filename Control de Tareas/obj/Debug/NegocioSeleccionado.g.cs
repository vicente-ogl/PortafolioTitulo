﻿#pragma checksum "..\..\NegocioSeleccionado.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58BD19FF879FA4902395C53C2657BBB4B92FB9E23DE16AA1F2070EE06C8E7205"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Control_de_Tareas;
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


namespace Control_de_Tareas {
    
    
    /// <summary>
    /// NegocioSeleccionado
    /// </summary>
    public partial class NegocioSeleccionado : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\NegocioSeleccionado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid_SeleccionarNegocio;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NegocioSeleccionado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_SeleccionarNegocio_Volver;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\NegocioSeleccionado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_SeleccionarNegocio_Seleccionar;
        
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
            System.Uri resourceLocater = new System.Uri("/Control de Tareas;component/negocioseleccionado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NegocioSeleccionado.xaml"
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
            this.DataGrid_SeleccionarNegocio = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.Btn_SeleccionarNegocio_Volver = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\NegocioSeleccionado.xaml"
            this.Btn_SeleccionarNegocio_Volver.Click += new System.Windows.RoutedEventHandler(this.Btn_SeleccionarNegocio_Volver_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Btn_SeleccionarNegocio_Seleccionar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\NegocioSeleccionado.xaml"
            this.Btn_SeleccionarNegocio_Seleccionar.Click += new System.Windows.RoutedEventHandler(this.Btn_SeleccionarNegocio_Seleccionar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
