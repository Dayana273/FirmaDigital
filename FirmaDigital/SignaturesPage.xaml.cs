using FirmaDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirmaDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturesPage : TabbedPage
    {
        public SignaturesPage(List<Signature> signatures)
        {
            InitializeComponent();
            signaturesListView.ItemsSource = signatures;
        }
    }
}


