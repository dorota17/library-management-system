﻿#pragma checksum "..\..\..\Okna\DodajEdytujAutora.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8B339DD6FAFDBDB1B09AE48CF2C1B81A6EE88E32EFA90DD6CFD894D5B4842E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Aplikacja.Okna;
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


namespace Aplikacja.Okna {
    
    
    /// <summary>
    /// DodajEdytujAutora
    /// </summary>
    public partial class DodajEdytujAutora : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Okna\DodajEdytujAutora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImie;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Okna\DodajEdytujAutora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNazwisko;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Okna\DodajEdytujAutora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPlec;
        
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
            System.Uri resourceLocater = new System.Uri("/Aplikacja;component/okna/dodajedytujautora.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Okna\DodajEdytujAutora.xaml"
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
            this.txtImie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtNazwisko = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbPlec = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 39 "..\..\..\Okna\DodajEdytujAutora.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Zatwierdz);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\Okna\DodajEdytujAutora.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Wyczysc);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 41 "..\..\..\Okna\DodajEdytujAutora.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Anuluj);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

