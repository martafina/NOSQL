﻿#pragma checksum "..\..\..\ucWindows\ucNewPost.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CEF1977675EC997C077B3DFB94A7B079A4CE980B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SociaNetwork.ucWindows;
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


namespace SociaNetwork.ucWindows {
    
    
    /// <summary>
    /// ucNewPost
    /// </summary>
    public partial class ucNewPost : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TrainsitionigContentSlide;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Main;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnComment;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLike;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPerson;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ucWindows\ucNewPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLike;
        
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
            System.Uri resourceLocater = new System.Uri("/SociaNetwork;component/ucwindows/ucnewpost.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ucWindows\ucNewPost.xaml"
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
            this.TrainsitionigContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.Main = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 26 "..\..\..\ucWindows\ucNewPost.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PersonsWhoLikes);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 27 "..\..\..\ucWindows\ucNewPost.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PersonsWhoComment);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnComment = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\ucWindows\ucNewPost.xaml"
            this.btnComment.Click += new System.Windows.RoutedEventHandler(this.Comment);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLike = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\ucWindows\ucNewPost.xaml"
            this.btnLike.Click += new System.Windows.RoutedEventHandler(this.Like);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPerson = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\ucWindows\ucNewPost.xaml"
            this.btnPerson.Click += new System.Windows.RoutedEventHandler(this.Person);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 47 "..\..\..\ucWindows\ucNewPost.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Posts);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 48 "..\..\..\ucWindows\ucNewPost.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextPost);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtLike = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

