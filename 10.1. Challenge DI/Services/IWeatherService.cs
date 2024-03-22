﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IWeatherService
    {
        public List<CityWeather> GetCities();
        public CityWeather? CityDetails(string cityCode);
    }
}
