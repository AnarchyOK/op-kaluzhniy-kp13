﻿#pragma checksum "..\..\EditCinemas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C717817147BFFB8CA4B1B1EE7BA576AFD6B8DADFA234C6991EE8C20BB488A983"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab4;
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


namespace Lab4 {
    
    
    /// <summary>
    /// EditCinemas
    /// </summary>
    public partial class EditCinemas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TCity;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox District;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TSeats;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EditCinemas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDField;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab4;component/editcinemas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditCinemas.xaml"
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
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\EditCinemas.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\EditCinemas.xaml"
            this.DataGrid1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid1_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.District = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\EditCinemas.xaml"
            this.District.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.District_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TSeats = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\EditCinemas.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\EditCinemas.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.IDField = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

