﻿#pragma checksum "..\..\WatcherGraph.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD766D4092F7F01DD3812AF022337C0AD03AFF92"
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
    /// WatcherGraph
    /// </summary>
    public partial class WatcherGraph : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas W_Canvas;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startQuery;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox queryBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backToMain;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WatcherGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseQuery;
        
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
            System.Uri resourceLocater = new System.Uri("/ParaPencariJose;component/watchergraph.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WatcherGraph.xaml"
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
            this.W_Canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.startQuery = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\WatcherGraph.xaml"
            this.startQuery.Click += new System.Windows.RoutedEventHandler(this.querySolution);
            
            #line default
            #line hidden
            return;
            case 3:
            this.queryBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\WatcherGraph.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.backTo);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backToMain = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\WatcherGraph.xaml"
            this.backToMain.Click += new System.Windows.RoutedEventHandler(this.backToMainMenu);
            
            #line default
            #line hidden
            return;
            case 6:
            this.browseQuery = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\WatcherGraph.xaml"
            this.browseQuery.Click += new System.Windows.RoutedEventHandler(this.browse);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

