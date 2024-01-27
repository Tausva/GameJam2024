using Assets.Scripts.Enums;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets
{
    public class Repository
    {
        public Dictionary<string, string> GetJokesByLanguage(LanguageJoke languageJoke)
        {
            var jokes = new Dictionary<string, string>();

            switch (languageJoke)
            {
                case LanguageJoke.English:
                    jokes = GetDadJokesInEnglish();
                    break;
                case LanguageJoke.Lithuania:
                    jokes = GetDadJokesInLithuania();
                    break;

            }

            return jokes;
        }

        private Dictionary<string, string> GetDadJokesInEnglish()
        {

            var filePath = $"{Application.dataPath}/Data/EnglishDadJokes.csv";

            var jokes = GetData(filePath);

            return jokes;
        }


        private Dictionary<string, string> GetDadJokesInLithuania()
        {
            var filePath = $"{Application.dataPath}/Data/LithuaniaDadJokes.csv";

            var jokes = GetData(filePath);

            return jokes;
        }

        private Dictionary<string, string> GetData(string filePath)
        {
            var jokes = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string question = parts[0];
                        string answer = parts[1];
                        jokes.TryAdd(question, answer);
                    }
                }
            }

            return jokes;
        }
    }
}
