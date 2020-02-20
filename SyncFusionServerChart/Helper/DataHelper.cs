using Newtonsoft.Json;
using SyncFusionServerChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncFusionServerChart.Helper
{
    public class DataHelper
    {
        /// <summary>
        /// read json files and return list of movies along with its character name 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CharacterDetailsViewModel> GetMovieCharacterDetailsList()
        {
            CharacterModel[] CharacterModelData =  JsonConvert.DeserializeObject<CharacterModel[]>(System.IO.File.ReadAllText("./wwwroot/sample-data/Character.json"));
            CharacterMetaDataModel[] CharacterMetaDataList = JsonConvert.DeserializeObject<CharacterMetaDataModel[]>(System.IO.File.ReadAllText("./wwwroot/sample-data/MetaData.json"));

            var characters = (from movie in CharacterMetaDataList
                              join character in CharacterModelData on movie.script_id equals character.script_id
                              select new
                              {
                                  MovieName = movie.title,
                                  ScriptID = movie.script_id,
                                  Gender = character.gender,
                                  Gross = movie.gross,
                                  words = character.words
                              }).GroupBy(s => new { s.ScriptID, s.MovieName,s.Gross })
                              .Select(g => new CharacterDetailsViewModel
                              {
                                  MovieName = g.Key.MovieName,
                                  ScriptID = g.Key.ScriptID,
                                  Gross = g.Key.Gross,
                                  TotalWords = g.Sum(a => a.words),
                                  MenWords = g.Where(x => x.Gender == "m").Sum(a => a.words),
                                  WomenWords = g.Where(x => x.Gender == "f").Sum(a => a.words)
                              });

            return characters;
        }

    }
}
