﻿#pragma checksum "..\..\Adaugare_Rutiera.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8AE0E9C72263DC98BDA88252278CB8406E3757BADD01C85F9B54A04A1D04A2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GaraAuto;
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


namespace GaraAuto {
    
    
    /// <summary>
    /// Adaugare_Rutiera
    /// </summary>
    public partial class Adaugare_Rutiera : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox denumire;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox model;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox culoare;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numar;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numarlocuri;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imagine;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Adaugare_Rutiera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b;
        
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
            System.Uri resourceLocater = new System.Uri("/GaraAuto;component/adaugare_rutiera.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Adaugare_Rutiera.xaml"
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
            this.denumire = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.model = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.culoare = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.numar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.numarlocuri = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\Adaugare_Rutiera.xaml"
            this.numarlocuri.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Number_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imagine = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            
            #line 58 "..\..\Adaugare_Rutiera.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.b = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\Adaugare_Rutiera.xaml"
            this.b.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
