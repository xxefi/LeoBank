﻿#pragma checksum "..\..\..\..\Views\PayBalanceView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A53CBB83B474264E76F8D2241ECBAF05950024C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LeoBank.ViewModels;
using LeoBank.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace LeoBank.Views {
    
    
    /// <summary>
    /// PayBalanceView
    /// </summary>
    public partial class PayBalanceView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 122 "..\..\..\..\Views\PayBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox card;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LeoBank;component/views/paybalanceview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\PayBalanceView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.card = ((System.Windows.Controls.TextBox)(target));
            
            #line 120 "..\..\..\..\Views\PayBalanceView.xaml"
            this.card.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 121 "..\..\..\..\Views\PayBalanceView.xaml"
            this.card.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.card_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 140 "..\..\..\..\Views\PayBalanceView.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_1);
            
            #line default
            #line hidden
            
            #line 141 "..\..\..\..\Views\PayBalanceView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 159 "..\..\..\..\Views\PayBalanceView.xaml"
            ((System.Windows.Controls.PasswordBox)(target)).PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 160 "..\..\..\..\Views\PayBalanceView.xaml"
            ((System.Windows.Controls.PasswordBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PasswordBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

