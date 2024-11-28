using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace cine3
{
    /// <summary>
    /// Lògica d'interacció per a MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logica logica;

        private string correu { get; set; }

        private string contrasenya { get; set; }

        public MainWindow(string correu, string contrasenya)
        {
            this.correu = correu;
            this.contrasenya = contrasenya;
        }

        public MainWindow()
        {
            InitializeComponent();
            Logica logica = new Logica();
            this.logica = logica;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // Comprovar si el correu és vàlid
            if (!IsValidEmail(email))
            {
                MessageBox.Show("El correu no és vàlid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Comprovar si la contrasenya té almenys 3 caràcters
            if (password.Length < 3)
            {
                MessageBox.Show("La contrasenya ha de tenir almenys 3 caràcters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Administrador
            if (email == "admin@admin.com")
            {
                if (password == "admin")
                {
                    Gui2 gui2 = new Gui2();
                    gui2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contrasenya incorrecta per a l'usuari administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                string filePath = "usuaris.txt";

                // Si el fitxer no existeix, crear-lo (buit)
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }

                // Comprovar si l'usuari ja existeix al fitxer
                bool userExists = false;
                string[] users = File.ReadAllLines(filePath);
                foreach (string user in users)
                {
                    if (user.StartsWith(email + ":"))
                    {
                        userExists = true;
                        break;
                    }
                }

                if (userExists)
                {
                    Gui3 gui3 = new Gui3();
                    gui3.Show();
                    this.Hide();
                }
                else
                {
                    // Afegir l'usuari només si les dades són vàlides i no existeix al fitxer
                    File.AppendAllText(filePath, email + ":" + password + Environment.NewLine);
                    MessageBox.Show("Usuari registrat correctament", "Informació", MessageBoxButton.OK, MessageBoxImage.Information);

                    Gui3 gui3 = new Gui3();
                    gui3.Show();
                    this.Hide();
                }
            }
        }

        // Funció per validar correus electrònics
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
