//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevExpress.GridDemo {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class RowEditModePage : ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::DevExpress.Mobile.DataGrid.GridControl grid;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::DevExpress.Mobile.DataGrid.PickerColumn colCustomer;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private Picker cbRowEditMode;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(RowEditModePage));
            grid = this.FindByName<global::DevExpress.Mobile.DataGrid.GridControl>("grid");
            colCustomer = this.FindByName<global::DevExpress.Mobile.DataGrid.PickerColumn>("colCustomer");
            cbRowEditMode = this.FindByName<Picker>("cbRowEditMode");
        }
    }
}
