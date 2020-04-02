using Core.Dto;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class ImdbService
    {
        WebClient wc = new WebClient();
        public string result; // Html Dosyası
        public ImdbService(string movieLink)
        {
            this.result = wc.DownloadString(movieLink);
        }

        public static List<DtoMovie> getMovies(string imdbLink)
        {
            WebClient wc = new WebClient();
            string result = wc.DownloadString(imdbLink);
            int tableIndex = result.IndexOf("<table");
            int tableBitisIndex = result.IndexOf("</table>");
            result = result.Substring(tableIndex, tableBitisIndex - tableIndex);
            //List<Movie> filmler = new List<Movie>();
            List<DtoMovie> _filmler = new List<DtoMovie>();
            while (true)
            {
               
                

                int tdIndex = result.IndexOf("result_text");
                if (tdIndex == -1) break;
                result = result.Substring(tdIndex, result.Length - tdIndex);
                int tdBitisIndex = result.IndexOf("</td>");
                string tempResult = result.Substring(0, tdBitisIndex);

                string linkResult = tempResult;
                int ahrefIndex = linkResult.IndexOf("<a href=");
                linkResult = linkResult.Substring(ahrefIndex, tempResult.Length - ahrefIndex);
                int ahrefSonuIndex = linkResult.IndexOf(">");
                string link = linkResult.Substring(10, ahrefSonuIndex - 12);

                string filmResult = linkResult;
                filmResult = filmResult.Substring(ahrefSonuIndex, filmResult.Length - ahrefSonuIndex);
                int filmAdSonuIndex = filmResult.IndexOf("</a>");
                string filmAdi = filmResult.Substring(1, filmAdSonuIndex - 1);

                string filmYiliResult = filmResult;
                int filmIlkIndex = filmYiliResult.IndexOf("(");
                filmYiliResult = filmResult.Substring(filmIlkIndex, filmYiliResult.Length - filmIlkIndex);
                int filmSonIndex = filmYiliResult.IndexOf(")");
                string filmYılı = filmYiliResult.Substring(1, filmSonIndex - 1);

                result = result.Substring(tdBitisIndex, result.Length - tdBitisIndex);

                DtoMovie _film = new DtoMovie();
                _film.name = filmAdi;
                _film.link = link;
                _film.year = filmYılı;
                _filmler.Add(_film);
            }
            return _filmler;
        }
        public string GetMovieRate()
        {
            return result.Substring(result.IndexOf("<span itemprop=\"ratingValue\">") + 29, 3);
        }

        public string GetMovieDescription()
        {
            
            int summaryIndex = result.IndexOf("summary_text");
            string tempResult = result.Substring(summaryIndex, result.Length - summaryIndex);
            int summaryBitisIndex = tempResult.IndexOf("</div>");
            int ahrefBitisIndex = tempResult.IndexOf("<a href=");
            int bitisIndex = 0;
            if (summaryBitisIndex > ahrefBitisIndex) bitisIndex = ahrefBitisIndex;
            else bitisIndex = summaryBitisIndex;
            tempResult = tempResult.Substring(15, bitisIndex - 15);
            return tempResult;
        }
        public List<Cast> GetMovieDirectors()
        {
            List<Cast> directors = new List<Cast>();
            // Directorler
            int sayac = 0;
            Regex regex = new Regex("<a href(.*?)ref_=tt_ov_dr\"(\n)*?(.*?)</a>");
            MatchCollection matches = regex.Matches(result);
            foreach (Match match in matches)
            {

                string temp = match.Value.Substring(9);
                string link;
                link = temp.Substring(0, temp.IndexOf("\""));
                temp = temp.Substring(temp.IndexOf(">"));
                string isim;
                isim = temp.Substring(1, temp.IndexOf("<") - 1);

                string bio = wc.DownloadString("https://www.imdb.com" + link);
                if (bio.IndexOf("name-trivia-bio-text") == -1) break;
                bio = bio.Substring(bio.IndexOf("name-trivia-bio-text"));
                bio = bio.Substring(bio.IndexOf("inline\">") + 8);

                bio = bio.Substring(0, bio.IndexOf("span class") - 1);
                bio = Regex.Replace(bio, "<a href(.*?)</a>", "");
                Cast director = new Cast();
                director.bio = bio;
                director.name = isim;
                director.link = link;
                directors.Add(director);
                if (sayac == 2) break;
                sayac++;
            }
            return directors;
        }

        public List<Cast> GetMovieWriters()
        {
            List<Cast> writers = new List<Cast>();
            // Yazarlar
            int sayac = 0;
            Regex regex = new Regex("<a href(.*?)ref_=tt_ov_wr\"(\n)*?(.*?)</a>");
            MatchCollection matches = regex.Matches(result);
            foreach (Match match in matches)
            {

                string temp = match.Value.Substring(9);
                string link;
                link = temp.Substring(0, temp.IndexOf("\""));
                temp = temp.Substring(temp.IndexOf(">"));
                string isim;
                isim = temp.Substring(1, temp.IndexOf("<") - 1);

                string bio = wc.DownloadString("https://www.imdb.com" + link);
                if (bio.IndexOf("name-trivia-bio-text") == -1) break;
                bio = bio.Substring(bio.IndexOf("name-trivia-bio-text"));
                bio = bio.Substring(bio.IndexOf("inline\">") + 8);

                bio = bio.Substring(0, bio.IndexOf("span class") - 1);
                bio = Regex.Replace(bio, "<a href(.*?)</a>", "");
                Cast writer = new Cast();
                writer.bio = bio;
                writer.name = isim;
                writer.link = link;
                writers.Add(writer);
                if (sayac == 2) break;
                sayac++;
            }
            return writers;
        }

        public List<Cast> GetMovieStars()
        {
            List<Cast> stars = new List<Cast>();
            // Yazarlar
            int sayac = 0;
            Regex regex = new Regex("<a href(.*?)ref_=tt_ov_st_sm\"(\n)*?(.*?)</a>");
            MatchCollection matches = regex.Matches(result);
            foreach (Match match in matches)
            {

                string temp = match.Value.Substring(9);
                string link;
                link = temp.Substring(0, temp.IndexOf("\""));
                temp = temp.Substring(temp.IndexOf(">"));
                string isim;
                isim = temp.Substring(1, temp.IndexOf("<") - 1);

                string bio = wc.DownloadString("https://www.imdb.com" + link);
                if (bio.IndexOf("name-trivia-bio-text") == -1) break;
                bio = bio.Substring(bio.IndexOf("name-trivia-bio-text"));
                bio = bio.Substring(bio.IndexOf("inline\">") + 8);

                bio = bio.Substring(0, bio.IndexOf("span class") - 1);
                bio = Regex.Replace(bio, "<a href(.*?)</a>", "");
                Cast star = new Cast();
                star.bio = bio;
                star.name = isim;
                star.link = link;
                stars.Add(star);
                if (sayac == 2) break;
                sayac++;
            }
            return stars;
        }
    }
}
