#pragma checksum "..\..\EditProdAndOperator.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AF1DF84B9AD15959DCC1DC1728A0A818FE0BA75C63D0BEA4BEABD7E07C187AB4"
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
    /// EditProdAndOperator
    /// </summary>
    public partial class EditProdAndOperator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TSurname;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDField;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TName2;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EditProdAndOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TSurname2;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab4;component/editprodandoperator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditProdAndOperator.xaml"
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
            
            #line 10 "..\..\EditProdAndOperator.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\EditProdAndOperator.xaml"
            this.DataGrid1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid1_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\EditProdAndOperator.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.IDField = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\EditProdAndOperator.xaml"
            this.IDField.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.IDField_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\EditProdAndOperator.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TName2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TSurname2 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

