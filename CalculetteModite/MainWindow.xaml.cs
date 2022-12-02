using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace CalculetteModite
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string calcul;

        /*long GeneratioDunChiffreAleatoireCommeUnTeube()
        {
            Stopwatch montre = new Stopwatch();
            montre.Start();

            Random rnd = new Random();
            int variableInutileParcequeCestDrole = rnd.Next(0, 10000);

            for (int i = 0; i == variableInutileParcequeCestDrole; i++) 
            {
                ;
            }

            montre.Stop();

            return variableInutileParcequeCestDrole % 500;

        }*/

        public MainWindow()
        {
            InitializeComponent();

            calculEnCours.Text = calcul;

            Random rnd = new Random();
            byte couleur1 = byte.Parse(rnd.Next(0, 255).ToString());
            byte couleur2 = byte.Parse(rnd.Next(0, 255).ToString());
            byte couleur3 = byte.Parse(rnd.Next(0, 255).ToString());
            byte couleur4 = byte.Parse(rnd.Next(0, 255).ToString());

            this.Background = new SolidColorBrush(Color.FromArgb(couleur1, couleur2, couleur3, couleur4));

            couleur1 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur2 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur3 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur4 = byte.Parse(rnd.Next(0, 255).ToString());
            trucpourfaireuneadditionencliquant.Background = new SolidColorBrush(Color.FromArgb(0xFF, couleur2, couleur3, couleur4));

            couleur1 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur2 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur3 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur4 = byte.Parse(rnd.Next(0, 255).ToString());
            iNUTILE.Background = new SolidColorBrush(Color.FromArgb(0xFF, couleur2, couleur3, couleur4));

            couleur1 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur2 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur3 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur4 = byte.Parse(rnd.Next(0, 255).ToString());
            ToDo.Background = new SolidColorBrush(Color.FromArgb(0xFF, couleur2, couleur3, couleur4));

            couleur1 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur2 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur3 = byte.Parse(rnd.Next(0, 255).ToString());
            couleur4 = byte.Parse(rnd.Next(0, 255).ToString());
            TRUCPOURVERIFIERSIDEUXMACHINSSONTEGAUX.Background = new SolidColorBrush(Color.FromArgb(0xFF, couleur2, couleur3, couleur4));


        }

        private void trucpourfaireuneadditionencliquant_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPourUnNombre.Text == String.Empty)
            {
                MessageBox.Show("Il faut rentrer un nombre dans le champ de texte");
                return;
            }
            try
            {
                int chiffre = int.Parse(textBoxPourUnNombre.Text);
                calcul += chiffre + " + ";
                MainWindow mw = new MainWindow();
                mw.Owner = Window.GetWindow(this);
                mw.ShowDialog();
                this.Close();
            }
            catch(Exception)
            {
                panik();
            }
        }

        private void TRUCPOURVERIFIERSIDEUXMACHINSSONTEGAUX_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPourUnNombre.Text == String.Empty)
            {
                MessageBox.Show("Il faut rentrer un nombre dans le champ de texte");
                return;
            }
            try
            {
                int chiffre = int.Parse(textBoxPourUnNombre.Text);
                calcul += chiffre + "-";
                MainWindow mw = new MainWindow();
                mw.Owner = Window.GetWindow(this);
                mw.ShowDialog();
                this.Close();
            }
            catch (Exception)
            {
                panik();
            }
        }

        private void iNUTILE_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxPourUnNombre.Text == String.Empty)
            {
                MessageBox.Show("Il faut rentrer un nombre dans le champ de texte");
                return;
            }
            try
            {
                int chiffre = int.Parse(textBoxPourUnNombre.Text);
                calcul += chiffre + "*";
                MainWindow mw = new MainWindow();
                mw.Owner = Window.GetWindow(this);
                mw.ShowDialog();
                this.Close();
            }
            catch (Exception)
            {
                panik();
            }
        }

        private void ToDo_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPourUnNombre.Text == String.Empty)
            {
                MessageBox.Show("Il faut rentrer un nombre dans le champ de texte");
                return;
            }
            try
            {
                int chiffre = int.Parse(textBoxPourUnNombre.Text);
                calcul += chiffre + "%2B"; // Normalement c'est +
                MainWindow mw = new MainWindow();
                mw.Owner = Window.GetWindow(this);
                mw.ShowDialog();
                this.Close();
            }
            catch(Exception)
            {
                panik();
            }
        }

        public void panik()
        {
            // TODO
            return;
        }
        private void boutonpourleresultat_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPourUnNombre.Text == String.Empty)
            {
                MessageBox.Show("Il faut rentrer un nombre dans le champ de texte");
                return;
            }
            calcul += textBoxPourUnNombre.Text;
            string Url = "http://api.mathjs.org/v4/?expr=";
            Url += calcul;
            var webRequest = WebRequest.Create(Url.Trim());

            var responseStream = webRequest.GetResponse().GetResponseStream();
            using (var streamReader = new StreamReader(responseStream))
            {
                boutonpourleresultat.Content = streamReader.Read();
            }
            MessageBox.Show("Merci d'avoir utilisé l'application :)");
        }
    }
}
