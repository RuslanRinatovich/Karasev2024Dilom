﻿#pragma checksum "..\..\..\Pages\GoodsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CB95E957534D327F86D17B8C6100847E5A33E2028B80131E12E8C6061F8537BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using WpfAssortmentCheck.Pages;


namespace WpfAssortmentCheck.Pages {
    
    
    /// <summary>
    /// GoodsPage
    /// </summary>
    public partial class GoodsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridGood;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCategories;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBrands;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExcel;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\GoodsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfAssortmentCheck;component/pages/goodspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\GoodsPage.xaml"
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
            
            #line 10 "..\..\..\Pages\GoodsPage.xaml"
            ((WpfAssortmentCheck.Pages.GoodsPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PageIsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGridGood = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\..\Pages\GoodsPage.xaml"
            this.DataGridGood.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGridGoodLoadingRow);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnCategories = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Pages\GoodsPage.xaml"
            this.BtnCategories.Click += new System.Windows.RoutedEventHandler(this.BtnCategories_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnBrands = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Pages\GoodsPage.xaml"
            this.BtnBrands.Click += new System.Windows.RoutedEventHandler(this.BtnBrands_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnExcel = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Pages\GoodsPage.xaml"
            this.BtnExcel.Click += new System.Windows.RoutedEventHandler(this.BtnExcel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\GoodsPage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAddClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Pages\GoodsPage.xaml"
            this.BtnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 38 "..\..\..\Pages\GoodsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 47 "..\..\..\Pages\GoodsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnPrice_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

