using Newtonsoft.Json.Linq;

namespace ErrorHandler.Evaluations
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var naipes = new string[] { "2d", "3d", "4s", "5s", "2s" };
            var naipes2 = new string[] { "2d", "3d", "4d", "5d", "6d" };

            string[] handWIn = GetPlayerWins(naipes, naipes2);
            Assert.True(naipes2.SequenceEqual(handWIn));
        }

        private string[] GetPlayerWins(string[] naipes, string[] naipes2)
        {
            var handObj = new Hand();
            handObj.GenerateNaipes(naipes);
            var handObj2 = new Hand();
            handObj2.GenerateNaipes(naipes2);

            handObj.GenerateGame();
            handObj2.GenerateGame();

            return new string[] { };
        }
    }

    public class Naipe
    {
        public char Category { get; private set; }
        public char Type { get; private set; }

        public Naipe(char category, char type)
        {
            Category = category;
            Type = type;
        }
    }

    class Hand
    {
        public Naipe[] Naipes = new Naipe[4];

        internal void GenerateNaipes(string[] naipes)
        {
            int i = 0;
            foreach(var naipe in naipes)
            {

                var newNaipe = new Naipe(naipe[0], naipe[1]);
                Naipes[i] = newNaipe;
                i++;
            }
        }

        internal void GenerateGame()
        {
            var repetGame = new RepetitionsGame();
            repetGame.GenerateGame(Naipes);
            var flushGame = new FlushGame();
            flushGame.GenerateGame(Naipes);

            repetGame.GetBestGame();
        }

    }

    public interface IGame
    {
        public void GenerateGame(Naipe[] naipes);
        public HandResult GetBestGame();
    }

    class RepetitionsGame : IGame
    {
        public Dictionary<char, int> Numbers = new Dictionary<char, int>();
        public void GenerateGame(Naipe[] naipes)
        {
            foreach(var naipe in naipes)
            {
                if (Numbers.ContainsKey(naipe.Category))
                {
                    var value = Numbers[naipe.Category];
                    Numbers[naipe.Category] = value + 1;
                } else
                {
                    Numbers.Add(naipe.Category, 1);
                }
            }
        }

        public HandResult GetBestGame()
        {
            var handRes = new HandResult();
            foreach(var val in Numbers.Values)
            {
                if (val < 1)
                {
                    continue;
                }

                if (val == 2)
                {
                    handRes = new HandResult()
                    {
                    };
                }
            }
            return null;
        }
    }

    class FlushGame : IGame
    {
        public Dictionary<char, int> Numbers = new Dictionary<char, int>();

        public void GenerateGame(Naipe[] naipes)
        {
            foreach (var naipe in naipes)
            {
                if (Numbers.ContainsKey(naipe.Type))
                {
                    var value = Numbers[naipe.Type];
                    Numbers[naipe.Type] = value + 1;
                }
                else
                {
                    Numbers.Add(naipe.Type, 1);
                }
            }
        }

        public HandResult GetBestGame()
        {
            throw new NotImplementedException();
        }
    }

    public class HandResult
    {
        public string Category { get; set; }
        public GameEnum Game { get; set; }
    }

    public enum GameEnum
    {
        NONE = 0,
        DOBLE = 1,
        TRIkA = 2,
        FLUSH = 3,
    }

}