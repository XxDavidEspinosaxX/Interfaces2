using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace cine3
{
    /// <summary>
    /// Lògica d'interacció per a Gui2.xaml
    /// </summary>
    public partial class Gui2 : Window
    {

        public List<String> GenereList { get; set; }
        public List<String> LanguageList { get; set; }
        public List<String> HourList { get; set; }
        public List<String> MinuteList { get; set; }
        public Gui2()
        {
            InitializeComponent();
            GenereList = new List<String>
            {
                "Acció",
                "Ciencia Ficció",
                "Comèdia",
                "Documental",
                "Drama",
                "Fantasía",
                "Musical",
                "Suspense",
                "Terror",

            };
            LanguageList = new List<String>
            {
                "VO",
                "Castellà",
            };
            HourList = new List<String>
            {
                "00",
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20",
                "21",
                "22",
                "23",
            };
            MinuteList = new List<String>
            {
                "00",
                "15",
                "30",
                "45",
            };

            this.DataContext = this;

        }

        private void UpdateButton()
        {
            bool titolComplet = !string.IsNullOrEmpty(tb_titol.Text);
            bool salaComplet = !string.IsNullOrEmpty(tb_sala.Text);
            bool duracioComplet = !string.IsNullOrEmpty(tb_duracio.Text) && int.TryParse(tb_duracio.Text, out int duracio) && duracio > 0;
            bool idiomaComplet = !string.IsNullOrWhiteSpace(cb_idioma.Text);
            bool horaComplet = !string.IsNullOrWhiteSpace(cb_hora.Text);
            bool minutsComplet = !string.IsNullOrWhiteSpace(cb_minuts.Text);
            bool genereSeleccionat = cb_genere1.SelectedItem != null || cb_genere2.SelectedItem != null || cb_genere3.SelectedItem != null;
            bool dataIniciComplet = dp_dataInici.SelectedDate != null;
            bool dataFinalComplet = dp_dataFinal.SelectedDate != null;
            bool datesCorrectes = dp_dataInici.SelectedDate <= dp_dataFinal.SelectedDate;

            // Actualitzar l'estat del botó amb totes les condicions
            bt_insertarPelicula.IsEnabled = titolComplet && salaComplet && duracioComplet && idiomaComplet && horaComplet && minutsComplet && genereSeleccionat && dataIniciComplet && dataFinalComplet && datesCorrectes;
        }
        // Per validació dels camps tipus Text
        private void ValidarCamps(object sender, TextChangedEventArgs e)
        {
            UpdateButton();
        }

        // Per validació dels camps tipus Selectors
        private void ValidarCampsCB(object sender, SelectionChangedEventArgs e)
        {
            UpdateButton();
        }

        // Acció quan es fa clic al botó per inserir la pel·lícula
        private void bt_insertarPelicula_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Recoger los datos de los controles
                string titol = tb_titol.Text;
                string sala = tb_sala.Text;
                string idioma = cb_idioma.Text;
                string hora = $"{cb_hora.Text}:{cb_minuts.Text}";
                string duracio = tb_duracio.Text;
                string genere1 = cb_genere1.SelectedItem?.ToString() ?? "";
                string genere2 = cb_genere2.SelectedItem?.ToString() ?? "";
                string genere3 = cb_genere3.SelectedItem?.ToString() ?? "";
                string dataInici = dp_dataInici.SelectedDate?.ToString("yyyy-MM-dd") ?? "";
                string dataFinal = dp_dataFinal.SelectedDate?.ToString("yyyy-MM-dd") ?? "";

                // Crear contenido para guardar
                string contenido = $"Títol: {titol}\nSala: {sala}\nIdioma: {idioma}\nHora: {hora}\nDuració: {duracio}\n" +
                                   $"Géneres: {genere1}, {genere2}, {genere3}\nData Inici: {dataInici}\nData Final: {dataFinal}\n";

                // Ruta del archivo
                string rutaArchivo = "peliculas.txt";

                // Guardar en archivo
                System.IO.File.AppendAllText(rutaArchivo, contenido + "\n---------------------\n");

                // Mostrar mensaje de éxito
                MessageBox.Show("Pel·lícula afegida correctament i guardada en el fitxer!", "Èxit", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpiar campos (opcional)
                LimpiarCamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar les dades: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método opcional para limpiar los campos después de insertar
        private void LimpiarCamps()
        {
            tb_titol.Clear();
            tb_sala.Clear();
            cb_idioma.SelectedIndex = -1;
            cb_hora.SelectedIndex = -1;
            cb_minuts.SelectedIndex = -1;
            tb_duracio.Clear();
            cb_genere1.SelectedIndex = -1;
            cb_genere2.SelectedIndex = -1;
            cb_genere3.SelectedIndex = -1;
            dp_dataInici.SelectedDate = null;
            dp_dataFinal.SelectedDate = null;
            UpdateButton(); // Deshabilitar el botón nuevamente
        }

    }
}