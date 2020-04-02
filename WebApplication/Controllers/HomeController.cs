using Core;
using Core.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web;
using System.Web.Helpers;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace WebApplication.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage List(string movieName)
        {
            
            string imdbLink = "https://www.imdb.com/find?ref_=nv_sr_fn&q=" + movieName + "&s=all";

            List<DtoMovie> _filmler = ImdbService.getMovies(imdbLink);
            foreach (var film in _filmler)
            {
                film.isSaved = new MovieService(film)._movie.isSaved;
                ImdbService imdb = new ImdbService("https://www.imdb.com/" + film.link);
                film.description = imdb.GetMovieDescription();
                film.rate = imdb.GetMovieRate();
            }
            string response = JsonConvert.SerializeObject(_filmler);
            return new HttpResponseMessage()
            {
                Content = new StringContent(response, System.Text.Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        public  HttpResponseMessage Cast([FromBody]HttpContent content)
        {

             var encoding = Encoding.UTF8;
             string documentContents;
             using (Stream receiveStream = Request.Content.ReadAsStreamAsync().Result)
             {
                 receiveStream.Position = 0;
                 using (StreamReader readStream = new StreamReader(receiveStream, encoding))
                 {
                     documentContents = readStream.ReadToEnd();
                 }
             }
             
            DtoMovie movie = JsonConvert.DeserializeObject<DtoMovie>(documentContents);
            List<DtoCastCastRole> _casts = new MovieService(movie).getCastList();
            string response = JsonConvert.SerializeObject(_casts);
            return new HttpResponseMessage()
            {
                Content = new StringContent(response, System.Text.Encoding.UTF8, "application/json")
            };
        }

        [HttpPost]
        public void Movie([FromBody]string content)
        {
            var encoding = Encoding.UTF8;
            string documentContents;
            using (Stream receiveStream = Request.Content.ReadAsStreamAsync().Result)
            {
                receiveStream.Position = 0;
                using (StreamReader readStream = new StreamReader(receiveStream, encoding))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            DtoMovie movie = JsonConvert.DeserializeObject<DtoMovie>(documentContents);
        }

        [HttpPost]
        public void Delete([FromBody]string content)
        {
            var encoding = Encoding.UTF8;
            string documentContents;
            using (Stream receiveStream = Request.Content.ReadAsStreamAsync().Result)
            {
                receiveStream.Position = 0;
                using (StreamReader readStream = new StreamReader(receiveStream, encoding))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            DtoMovie movie = JsonConvert.DeserializeObject<DtoMovie>(documentContents);
            movie.isSaved = false;
            MovieService service = new MovieService(movie);
            service.getCastList();
            service.Sil();
        }

        [HttpPost]
        public void Kaydet([FromBody]string content)
        {
            var encoding = Encoding.UTF8;
            string documentContents;
            using (Stream receiveStream = Request.Content.ReadAsStreamAsync().Result)
            {
                receiveStream.Position = 0;
                using (StreamReader readStream = new StreamReader(receiveStream, encoding))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            DtoMovie movie = JsonConvert.DeserializeObject<DtoMovie>(documentContents);
            movie.isSaved = true;
            MovieService service = new MovieService(movie);
            service.getCastList();
            service.Kaydet();
        }
    }
}
