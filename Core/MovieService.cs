using Core.Dto;
using Data.Context;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MovieService
    {
        public Boolean isSaved { get; set; }
        private Movie movie { get; set; }
        public DtoMovie _movie { get; set; }

        UnitOfWork unitOfWork = new UnitOfWork();
        Repository<Movie> movieRepo;
        Repository<CastRole> castRoleRepo;
        Repository<Cast> castRepo;
        Repository<MovieCastRoleMap> movieCastRoleMapRepo;
        List<DtoCastCastRole> CastCastRoles = new List<DtoCastCastRole>();

        public MovieService(DtoMovie film)
        {
            movieRepo = unitOfWork.MovieRepository;
            castRoleRepo = unitOfWork.CastRoleRepository;
            castRepo = unitOfWork.CastRepository;
            movieCastRoleMapRepo = unitOfWork.MovieCastRoleMapRepository;

            unitOfWork.MovieRepository.SilmeEvent += delegate (Movie obj) {
                Console.WriteLine(obj.name + " adlı filmi silme İsteği geldi" );
            };

            _movie = film;
            _movie.isSaved = MovieIsSaved();
        }
        
        public Boolean MovieIsSaved()
        {
            movie = movieRepo.Select(o => o.link == _movie.link);
            if (movie == null) return false;
            else return true;
        }
        public List<DtoCastCastRole> getCastList()
        {
          
            
            List<Cast> filmCasts = new List<Cast>();
    
            Movie findMovie = movie;
           
            //Veritabanına Kaydedilmişse
            if (findMovie != null)
            {
                List<MovieCastRoleMap> mcr = movieCastRoleMapRepo.SelectAll(c => c.MovieId == findMovie.MovieId);
                DtoCastCastRole cast;
                _movie.description = findMovie.description;
                foreach (var item in mcr)
                {
                    cast = new DtoCastCastRole();
                    cast.castBio = item.cast.bio;
                    cast.castLink = item.cast.link;
                    cast.castName = item.cast.name;
                    cast.castRol = item.CastRole.name;
                    cast.movieLink = item.movie.link;
                    cast.movieName = item.movie.name;
                    CastCastRoles.Add(cast);
                }
                isSaved = true;
                return CastCastRoles;
            }

            // Veritabanına Kaydedilmemişse
            else
            {
                //movie ve secilenFilm
                isSaved = false;
                ImdbService imdb = new ImdbService("https://www.imdb.com/" + _movie.link);
                string result = imdb.result;
                _movie.description = imdb.GetMovieDescription();

                List<Cast> directors = imdb.GetMovieDirectors();
                List<Cast> writers = imdb.GetMovieWriters();
                List<Cast> stars = imdb.GetMovieStars();

                foreach (Cast director in directors)
                {
                    DtoCastCastRole cast = new DtoCastCastRole();
                    CastRole findRol = castRoleRepo.Select(o => o.name == "Director");
                    cast.castName = director.name;
                    cast.castBio = director.bio;
                    cast.castRol = findRol.name;
                    cast.castLink = director.link;
                    cast.movieLink = _movie.link;
                    cast.movieName = _movie.name;

                    CastCastRoles.Add(cast);
                }
                foreach (Cast writer in writers)
                {
                    DtoCastCastRole cast = new DtoCastCastRole();
                    CastRole findRol = castRoleRepo.Select(o => o.name == "Writer");
                    cast.castName = writer.name;
                    cast.castBio = writer.bio;
                    cast.castRol = findRol.name;
                    cast.castLink = writer.link;
                    cast.movieLink = _movie.link;
                    cast.movieName = _movie.name;
                    CastCastRoles.Add(cast);
                }
                foreach (Cast star in stars)
                {
                    DtoCastCastRole cast = new DtoCastCastRole();
                    CastRole findRol = castRoleRepo.Select(o => o.name == "Star");
                    cast.castName = star.name;
                    cast.castBio = star.bio;
                    cast.castRol = findRol.name;
                    cast.castLink = star.link;
                    cast.movieLink = _movie.link;
                    cast.movieName = _movie.name;
                    CastCastRoles.Add(cast);
                }
                return CastCastRoles;
            }
        }

        public void Kaydet() {
            Movie secilenFilm = new Movie();
            secilenFilm.description = _movie.description;
            secilenFilm.link = _movie.link;
            secilenFilm.name = _movie.name;
            secilenFilm.year = _movie.year;
            
            movieRepo.Insert(secilenFilm);
            unitOfWork.Save();
            foreach (DtoCastCastRole cast in CastCastRoles)
            {
                Cast findCast = castRepo.Select(o => o.link == cast.castLink);
                if (findCast == null)
                {
                    findCast = new Cast();
                    findCast.bio = cast.castBio;
                    findCast.link = cast.castLink;
                    findCast.name = cast.castName;
                    castRepo.Insert(findCast);
                    unitOfWork.Save();
                    CastRole findRol = castRoleRepo.Select(o => o.name == cast.castRol);
                    MovieCastRoleMap mapItem = new MovieCastRoleMap();
                    //mapItem.cast = findCast;
                    //mapItem.movie = secilenFilm;
                    //mapItem.CastRole = findRol;
                    mapItem.MovieId = secilenFilm.MovieId;
                    mapItem.CastRoleId = findRol.CastRoleId;
                    mapItem.CastId = findCast.CastId;
                    movieCastRoleMapRepo.Insert(mapItem);
                    unitOfWork.Save();
                }
                else
                {
                    CastRole findRol = castRoleRepo.Select(o => o.name == cast.castRol);
                    MovieCastRoleMap mapItem = new MovieCastRoleMap();
                    //mapItem.cast = findCast;
                    //mapItem.movie = secilenFilm;
                    //mapItem.CastRole = findRol;
                    mapItem.MovieId = secilenFilm.MovieId;
                    mapItem.CastRoleId = findRol.CastRoleId;
                    mapItem.CastId = findCast.CastId;
                    movieCastRoleMapRepo.Insert(mapItem);
                    unitOfWork.Save();
                }
            }
      
        }
        public void Sil()
        {
            movie = movieRepo.Select(o => o.link == _movie.link);
            movieRepo.Delete(movie.MovieId);
            unitOfWork.Save();
        }
    }

  
}
