﻿#pragma checksum "..\..\Player.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C91BF597A06322CC6CDE3B16D6CB38D8F9B6487"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Player
    /// </summary>
    public partial class Player : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox graphInput;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button P_Main;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button P_Next;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox graphChoose;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button P_NextExisting;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button P_Browse;
        
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
            System.Uri resourceLocater = new System.Uri("/ParaPencariJose;component/player.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Player.xaml"
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
            this.graphInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.P_Main = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Player.xaml"
            this.P_Main.Click += new System.Windows.RoutedEventHandler(this.backToMain);
            
            #line default
            #line hidden
            return;
            case 3:
            this.P_Next = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Player.xaml"
            this.P_Next.Click += new System.Windows.RoutedEventHandler(this.inputGraph);
            
            #line default
            #line hidden
            return;
            case 4:
            this.graphChoose = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\Player.xaml"
            this.graphChoose.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GraphChoose_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.P_NextExisting = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Player.xaml"
            this.P_NextExisting.Click += new System.Windows.RoutedEventHandler(this.inputExistingGraph);
            
            #line default
            #line hidden
            return;
            case 6:
            this.P_Browse = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Player.xaml"
            this.P_Browse.Click += new System.Windows.RoutedEventHandler(this.browseExistingGraph);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

