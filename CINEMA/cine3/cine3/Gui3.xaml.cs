using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace cine3
{
    public partial class Gui3 : Window
    {
        public List<string> GenereList { get; set; }
        public List<string> LanguageList { get; set; }
        public List<Pelicula> Peliculas { get; set; }

        public Gui3()
        {
            InitializeComponent();

            // Inicializar las listas de géneros e idiomas
            GenereList = new List<string> { "Acció", "Comèdia", "Drama", "Terror", "Ciencia Ficció" };
            LanguageList = new List<string> { "VO", "Castellà" };


            // Lista de ejemplo de películas
            Peliculas = new List<Pelicula>
            {
               };

            // Establecer el contexto de datos
            this.DataContext = this;

            // Cargar todas las películas al inicio
            listBoxPeliculas.ItemsSource = Peliculas;
        }

        // Método para aplicar los filtros
        private void AplicarFiltros(object sender, EventArgs e)
        {
            var genereSeleccionat = cb_filtrarGenere.SelectedItem?.ToString();
            var dataSeleccionada = dp_filtrarData.SelectedDate;
            var idiomaSeleccionat = cb_filtrarIdioma.SelectedItem?.ToString();

            var peliculasFiltradas = Peliculas.Where(p =>
                (string.IsNullOrEmpty(genereSeleccionat) || p.Genero.Contains(genereSeleccionat)) &&
                (!dataSeleccionada.HasValue || p.DataInici.Date == dataSeleccionada.Value.Date) &&
                (string.IsNullOrEmpty(idiomaSeleccionat) || p.Idioma.Contains(idiomaSeleccionat))
            ).ToList();

            listBoxPeliculas.ItemsSource = peliculasFiltradas;
        }

        // Método para mostrar todas las películas
        private void MostrarTodasPeliculas_Click(object sender, RoutedEventArgs e)
        {
            listBoxPeliculas.ItemsSource = Peliculas;
        }
    }

}
