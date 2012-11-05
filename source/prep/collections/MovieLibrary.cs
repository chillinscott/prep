using System;
using System.Collections.Generic;

namespace prep.collections
{
    public class MovieLibrary
    {
        IList<Movie> _movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this._movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return new ReadOnlyCollection<Movie>(_movies);
        }

        public void add(Movie movie)
        {
            if (!_movies.Contains(movie))
                _movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return movies_matching(m => m.production_studio == ProductionStudio.Pixar);
            
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in _movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar ||
                    movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return movies_matching(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return movies_matching(m => m.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return movies_matching(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return movies_matching(m => m.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return movies_matching(m => m.genre == Genre.action);
            
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> movies_matching(MovieCriteria criteria)
        {
            foreach (var movie in _movies)
            {
                if (criteria(movie))
                    yield return movie;
            }
        }
    }

    public delegate bool MovieCriteria(Movie movie);




}