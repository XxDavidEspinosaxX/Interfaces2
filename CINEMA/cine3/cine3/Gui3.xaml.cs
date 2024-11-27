﻿using System;
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
            LanguageList = new List<string> { "VO", "Castellà", "Anglès" };

            // Lista de ejemplo de películas
            Peliculas = new List<Pelicula>
            {
                new Pelicula("Pelicula 1", "Sala 1", new List<string> { "VO" }, new List<string> { "Acció" }, new DateTime(2024, 11, 27), new DateTime(2024, 11, 27), new List<string> { "12" }, new List<string> { "00" }, "120 min"),
                new Pelicula("Pelicula 2", "Sala 2", new List<string> { "Castellà" }, new List<string> { "Drama" }, new DateTime(2024, 11, 27), new DateTime(2024, 11, 27), new List<string> { "14" }, new List<string> { "30" }, "90 min"),
                new Pelicula("Pelicula 3", "Sala 3", new List<string> { "VO" }, new List<string> { "Terror" }, new DateTime(2024, 11, 27), new DateTime(2024, 11, 27), new List<string> { "16" }, new List<string> { "00" }, "100 min")
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