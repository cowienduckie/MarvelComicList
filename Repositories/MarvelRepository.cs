using MarvelComicList.Configs;
using MarvelComicList.MarvelModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MarvelComicList.Repositories
{
    public class MarvelRepository : IMarvelRepository
    {
        private string PUBLIC_KEY = Constants.PUBLIC_KEY;
        private string PRIVATE_KEY = Constants.PRIVATE_KEY;

        CharacterDataWrapper IMarvelRepository.GetCharacter(int id)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            //Connection String
            var client = new RestClient($"https://gateway.marvel.com:443/v1/public/characters/{id}?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<CharacterDataWrapper>();
            }

            return null;
        }

        public CharacterDataWrapper GetCharacterList(string name = null, string orderBy = null, int page = 1)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            int limit = 10;
            int offset = --page * limit;

            //Connection String
            string path = $"https://gateway.marvel.com:443/v1/public/characters?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}&limit={limit}&offset={offset}";

            if (name != null)
            {
                path += $"&nameStartsWith={name}";
            }

            if (orderBy != null)
            {
                path += $"&orderBy={orderBy}";
            }

            var client = new RestClient(path);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<CharacterDataWrapper>();
            }

            return null;
        }

        public SeriesDataWrapper GetRelatedSeries(int id, int page = 1)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            int limit = 6;
            int offset = --page * limit;

            //Connection String
            var client = new RestClient($"https://gateway.marvel.com:443/v1/public/characters/{id}/series?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}&limit={limit}&offset={offset}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<SeriesDataWrapper>();
            }

            return null;
        }

        public SeriesDataWrapper GetSeries(int id)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            //Connection String
            var client = new RestClient($"https://gateway.marvel.com:443/v1/public/series/{id}?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<SeriesDataWrapper>();
            }

            return null;
        }

        public SeriesDataWrapper GetSeriesList(string title = null, string orderBy = null, int startYear = -1, int page = 1)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            int limit = 10;
            int offset = --page * limit;

            //Connection String
            string path = $"https://gateway.marvel.com:443/v1/public/series?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}&limit={limit}&offset={offset}";

            if (title != null)
            {
                path += $"&titleStartsWith={title}";
            }
            if (orderBy != null)
            {
                path += $"&orderBy={orderBy}";
            }
            if (startYear != -1)
            {
                path += $"&startYear={startYear}";
            }

            var client = new RestClient(path);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<SeriesDataWrapper>();
            }

            return null;
        }

        public CharacterDataWrapper GetRelatedCharacter(int id, int page = 1)
        {
            long timeStamp = DateTime.Now.ToFileTime();
            string hashCode = MD5Hash($"{timeStamp}" + PRIVATE_KEY + PUBLIC_KEY);

            int limit = 6;
            int offset = --page * limit;

            //Connection String
            var client = new RestClient($"https://gateway.marvel.com:443/v1/public/series/{id}/characters?ts={timeStamp}&apikey={PUBLIC_KEY}&hash={hashCode}&limit={limit}&offset={offset}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<CharacterDataWrapper>();
            }

            return null;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}