using QU.WordFinder_DevChallenge;

namespace QU.WordFinder_Tests
{
    public class Tests
    {
        private List<string> _matrix;

        [SetUp]
        public void Setup()
        {
            //Sample matrix
            _matrix = new List<string>
            {
                "PABFGTBBCDEFBERRYLOGNVAMCENHDESFXYZUODPS",
                "ORANGEBDTSKGMENUACGHIQWDEYXSHTGYUAJKLAPS",
                "WGHIQWDEKNSLURPMDISPZZZHTUGDNCFTFRGJLTWE",
                "COHRSOTNHCMTKBXLHITHEWATERXPSIFJKIUEDRAS",
                "BHGIEQJYOSNSWLOCOKEUWPEFKBXXMENULCVXWSLD",
                "UWHDMLIUJKCTJCEHKOMXEFWSMNSKFNSALADLOLFA",
                "ROMFLBNXCIEHPFOJACNEEJVSUBAVMCESUSHIQTSD",
                "GYWICFJQKMPWATELNSRFLVDIXYZIBERRYQCOKEGF",
                "EURCNIKOSMKCISPGDISHHWPMOXUETDSALADSALAD",
                "RCENQWVWXRJTCUYGSLLFJUKJXTEBCZPIZZAPIZZA",
                "AOTENAMVWDRJTSGHHFDHTKUKJXTEBCZGSKMGFDGD",
                "SFTENTMVWGRJTCUYGRDFGJUKJXTEBCZDGBPPDKGB",
                "DFTENEMVWFRJTCUYGIDFFGKJGDJKKHEADSGFGDFG",
                "FETENRMVWXSJTCUYGELLFJUKJXTEBCZPIZZADFGL",
                "CETEBANANARJTCUYGSLLKDSPLHPPDFGJJNCOFFEE"
            };
        }


        [Test]
        public void FindWordsTest()
        {
            // Arrange

            var wordsToFind = new List<string> 
            { "BURGER", "SPRITE", "WATER", "PIZZA", "COKE", "SUSHI",
              "SALAD", "FRIES", "COKE","BANANA","COFFEE", "BERRY",
              "SODA","ORANGE" };

            // Act
            var wordFinder = new WordFinder(_matrix);
            var result = wordFinder.Find(wordsToFind).ToList();

            // Assert
            Assert.AreEqual(10, result.Count());
            Assert.Contains("SALAD", result);
            Assert.Contains("PIZZA", result);
            Assert.Contains("BERRY", result);
            Assert.Contains("WATER", result);
            Assert.Contains("COKE", result);
            Assert.Contains("COFFEE", result);
            Assert.Contains("SUSHI", result);
            Assert.Contains("BANANA", result);
            Assert.Contains("BURGER", result);
            Assert.Contains("ORANGE", result);
        }

        [Test]
        public void NoWordsFoundTest()
        { // Arrange

            var wordsToFind = new List<string> { "SPRITE", "SODA" };

            // Act
            var wordFinder = new WordFinder(_matrix);
            var result = wordFinder.Find(wordsToFind).ToList();

            // Assert
            Assert.AreEqual(0, result.Count());
        }


        [Test]
        public void WrongMatrix()
        { // Arrange

            var wrongMatrix = new List<string>
            {
                "PABFGTBBCDUODPSA",
                "IDEFSABDTSKGMENU",
                "WGHIQWTFRGJLTWED",
                "COHRSOTNHCMTKBXLHITHEWATERXDRAS",// Invalid row (not the same length as others)
                "BHGIEQJYOSNXWSLD"
            };

            // Act and Assert
            Assert.Throws<InvalidMatrixException>(() => new WordFinder(wrongMatrix));
        }
    }
}