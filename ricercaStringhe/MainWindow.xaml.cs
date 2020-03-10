using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ricercaStringhe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_cerca_Click(object sender, RoutedEventArgs e)
        {
            
            string trovato = "";
            string testo = txt_multilinea.Text;
            string ricerca = txt_ricerca.Text;
            if(testo.Contains(ricerca))
            {
                int index = testo.IndexOf(ricerca,StringComparison.OrdinalIgnoreCase);
                int grandezza = testo.Length;
                int offsetSinistro = testo.LastIndexOf(" ",Math.Max(0, index - 3));
                if(offsetSinistro < 0)
                {
                    offsetSinistro = 0;
                }
                int offsetDestro = testo.IndexOf(" ",Math.Min(grandezza,index+ 2));
                if (offsetDestro < 0 )
                {
                    trovato = testo.Substring(offsetSinistro, grandezza- offsetSinistro);
                }
                else
                {
                    trovato = testo.Substring(offsetSinistro, offsetDestro - offsetSinistro + ricerca.Length);
                }
                lbl_risp.Content = $"...{trovato}...";
            }
            else
            {
                lbl_risp.Content = "";

            }
        }
    }
}
