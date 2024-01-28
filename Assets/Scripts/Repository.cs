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
                    jokes = GetData("Data/EnglishDadJokes");
                    break;
                case LanguageJoke.Lithuania:
                    jokes = GetData("Data/LithuaniaDadJokes");
                    break;

            }

            return jokes;
        }

        private Dictionary<string, string> GetData(string filePath)
        {
            var asset = Resources.Load(filePath) as TextAsset;

            var jokes = new Dictionary<string, string>();

            StringReader reader = new StringReader(asset.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();

                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string question = parts[0];
                    string answer = parts[1];
                    jokes.TryAdd(question, answer);
                }
            }

            return jokes;
        }
    }
}
