using AppJogoForca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Repositories
{
    public class WordRepositories
    {
        private List<Word> _words;

        public WordRepositories()
        {
                _words = new List<Word>();
                _words.Add(new Word("Nome", "Maria".ToUpper()));
                _words.Add(new Word("Vegetal", "Cenoura".ToUpper()));
                _words.Add(new Word("Fruta", "Abacate".ToUpper()));
                _words.Add(new Word("Carro", "Renegade".ToUpper()));
                _words.Add(new Word("Moto", "Ducati".ToUpper()));
                _words.Add(new Word("Moto", "Yamaha".ToUpper()));
        }

        public Word GetRandleWord()
        {
            Random random = new Random();
            var number = random.Next(0, _words.Count);

            return _words[number];
        }
    }
}
