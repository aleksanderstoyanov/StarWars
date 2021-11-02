﻿namespace StarWarsApp.Services.Services.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        public MovieServiceModel GetById(int id);
        public IEnumerable<MovieServiceModel> GetAll();
    }
}
