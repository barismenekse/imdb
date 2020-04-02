using Core;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        
        
        MovieService movieService;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            movieService.Kaydet();
            btnKaydet.Visible = false; btnSil.Visible = true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            movieService.Sil();
            btnKaydet.Visible = true; btnSil.Visible = false;
        }

        private async void btnListele_ClickAsync(object sender, EventArgs e)
        {
            string imdbLink = "https://www.imdb.com/find?ref_=nv_sr_fn&q=" + txtBxMovieName.Text.Trim() + "&s=all";
            List<DtoMovie> _filmler = ImdbService.getMovies(imdbLink);
            lbMovies.Items.Clear();
            for (int i = 0; i < _filmler.Count; i++)
            {
                lbMovies.Items.Add(_filmler[i]);
            }
            

        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnKaydet.Visible = false; btnSil.Visible = false;
            lbCasts.Items.Clear();
            lbDirectors.Items.Clear();
            lbStars.Items.Clear();
            lbWriters.Items.Clear();
            lblBio.Text = "";
            lblDescription.Text = "";
            lblRate.Text = "Rate: ";
            DtoMovie _movie = (DtoMovie)lbMovies.SelectedItem;
            movieService = new MovieService(_movie);
            ImdbService imdbService = new ImdbService("https://www.imdb.com/"+_movie.link);
            List<DtoCastCastRole> casts = movieService.getCastList();
            lblRate.Text = "Rate: " + imdbService.GetMovieRate();
            lblDescription.Text = movieService._movie.description;
            if (movieService.isSaved) { btnKaydet.Visible = false; btnSil.Visible = true; }
            else { btnKaydet.Visible = true; btnSil.Visible = false; }
            foreach (var cast in casts)
            {
                lbCasts.Items.Add(cast);

                if (cast.castRol == "Director") lbDirectors.Items.Add(cast.castName);
                else if (cast.castRol == "Writer") lbWriters.Items.Add(cast.castName);
                else if (cast.castRol == "Star") lbStars.Items.Add(cast.castName);
            }
            
        }

        private void lbCasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DtoCastCastRole cast = (DtoCastCastRole)lbCasts.SelectedItem;
            lblBio.Text = cast.castBio;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnKaydet.Visible = false; btnSil.Visible = false;
            
        }
    }
}
