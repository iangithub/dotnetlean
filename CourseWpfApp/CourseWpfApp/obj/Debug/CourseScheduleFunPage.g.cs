#pragma checksum "..\..\CourseScheduleFunPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EB1BD5B720947DB52F45B0D9A8B99770D877AD7B4D5AB4DF94682FE1A032FC2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWpfApp;
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


namespace CourseWpfApp {
    
    
    /// <summary>
    /// CourseScheduleFunPage
    /// </summary>
    public partial class CourseScheduleFunPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView InfoList;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Query_CName;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Query_TName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Query;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ShowDetail;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateBtn;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\CourseScheduleFunPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWpfApp;component/courseschedulefunpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CourseScheduleFunPage.xaml"
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
            this.InfoList = ((System.Windows.Controls.ListView)(target));
            
            #line 21 "..\..\CourseScheduleFunPage.xaml"
            this.InfoList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InfoList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Query_CName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Query_TName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Query = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\CourseScheduleFunPage.xaml"
            this.Query.Click += new System.Windows.RoutedEventHandler(this.Query_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowDetail = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.CreateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\CourseScheduleFunPage.xaml"
            this.CreateBtn.Click += new System.Windows.RoutedEventHandler(this.CreateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UpdateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\CourseScheduleFunPage.xaml"
            this.UpdateBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\CourseScheduleFunPage.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

