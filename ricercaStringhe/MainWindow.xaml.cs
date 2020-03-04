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
            string testo = txt_multilinea.Text;
            string ricerca = txt_ricerca.Text;
            if(testo.Contains(ricerca))
            {
                int index = testo.IndexOf(ricerca);
                int grandezza = testo.Length;
                int offsetSinistro = testo.LastIndexOf(" ",Math.Max(0, index - 3));
                if(offsetSinistro<0)
                {
                    offsetSinistro = 0;
                }
                int offsetDestro = testo.IndexOf(" ",index + ricerca.Length);
                //if (offsetDestro > grandezza)
                //{
                //    offsetDestro = 0;
                //}
                int offsetfine = offsetDestro - offsetSinistro + ricerca.Length;
                string trovato = testo.Substring(offsetSinistro,Math.Min(0,offsetfine));
                if(offsetfine>grandezza)
                {
                    offsetfine = grandezza;
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
