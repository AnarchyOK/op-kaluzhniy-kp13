﻿#pragma checksum "..\..\AddWPFActor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1C0B4B18286448DE8E7DA40D5ADCE5BEEED7FC7FB7E367E67CE89577F869ECD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfCursFormsDB;


namespace WpfCursFormsDB {
    
    
    /// <summary>
    /// AddWPFActor
    /// </summary>
    public partial class AddWPFActor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToStartWindow;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextSurname;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDField;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ID_Label;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddWPFActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab4;component/addwpfactor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddWPFActor.xaml"
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
            this.ToStartWindow = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AddWPFActor.xaml"
            this.ToStartWindow.Click += new System.Windows.RoutedEventHandler(this.ToStartWindow_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\AddWPFActor.xaml"
            this.DataGrid1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid1_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\AddWPFActor.xaml"
            this.DataGrid1.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.DataGrid1_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AddWPFActor.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.IDField = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\AddWPFActor.xaml"
            this.IDField.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.IDField_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ID_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.RemoveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\AddWPFActor.xaml"
            this.RemoveBtn.Click += new System.Windows.RoutedEventHandler(this.RemoveBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

