using System;
using System.Collections.Generic;
using System.IO;
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

            // Intentar cargar películas desde un archivo
            Peliculas = CargarPeliculasDesdeArchivo("peliculas.txt");

            // Establecer el contexto de datos
            this.DataContext = this;

            // Cargar las películas en la lista
            listBoxPeliculas.ItemsSource = Peliculas;
        }

        // Método para cargar películas desde un archivo
        private List<Pelicula> CargarPeliculasDesdeArchivo(string rutaArchivo)
        {
            var peliculas = new List<Pelicula>();

            if (!File.Exists(rutaArchivo))
            {
                // Retorna una lista vacía si el archivo no existe
                return peliculas;
            }

            var lines = File.ReadAllLines(rutaArchivo);

            foreach (var line in lines.Skip(1)) // Saltar la primera línea (encabezado)
            {
                var columns = line.Split(',');

                if (columns.Length >= 4)
                {
                    try
                    {
                        var pelicula = new Pelicula
                        {
                            Titulo = columns[0].Trim(),
                            Genero = new List<string> { columns[1].Trim() },
                            DataInici = DateTime.Parse(columns[2].Trim()),
                            Idioma = new List<string> { columns[3].Trim() }
                        };
                        peliculas.Add(pelicula);
                    }
                    catch
                    {
                        // Ignorar líneas con datos inválidos
                    }
                }
            }

            return peliculas;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gui5 gui5 = new Gui5();
            gui5.Show();
            this.Hide();
        }
    }
}
