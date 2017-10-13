using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idź_na_ryby_
{
    class Player
    {
        private string name;
        public string Name { get { return name; }}
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm.Text = Name + " dołączył do gry";
            // Konstruktor klasy Player inicjalizuje prywatne pola i dodaje do kontrolki TextBox wiersz, który ma postać:
            // "Janek dołączył do gry" - użyj jednak prywatnego pola name i nie zapomnij dodać znaków nowej linii na końcu każdego dodawanego wiersza.
        }

        public IEnumerable<Values> PullOutBooks()   // metoda dodaje wartość do zwracanych grup i usuwa karty z tej wartości z ręki gracza
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values) i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    for (int card = cards.Count - 1; card >= 0; card--) // nie wiem o chuj tu
                        cards.Deal(card);
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            return cards.Peek(random.Next(cards.Count)).Value;
            // Ta metoda pobiera losową wartość, ale musi się ona znajdować w zestawie
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck cardsIHave = cards.PullOutValues(value);
            textBoxOnForm.Text = Name + " ma " + cardsIHave.Count + " " + Card.Plural(value, cardsIHave.Count) + "\n";
            return cardsIHave;
            // To tutaj przeciwnik sprawdza, czy masz karty o określonej wartości. Wartości wyciągane są za pomocą metody Deck.PullOutValues().
            // Dodaj do kontrolki TextBox napis "Janek ma 3 szóstki" - użyj nowej statycznej metody Card.Plural().
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {

            // Tu jest przeciążona wersja AskForACard() - wybierz z zestawu losową wartość przy użyciu GetRandomValue() i zażądaj jej za pomocą AskForACard().
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            textBoxOnForm.Text = Name + " pyta, czy ktoś ma " + Card.Plural(value, 1);
            int cardsBefore = cards.Count;
            foreach (Player player in players)
                player.DoYouHaveAny(value);
            int difference = cards.Count - cardsBefore;
            if(difference == 0)

            // Zażądaj określonej wartości od innych graczy. Na początku dodaj do pola tekstowego wiersz o postaci: "Janek pyta, czy ktoś ma damę".
            // Następnie przejdź przez listę graczy przekazanych do metody w postaci parametrów i spytaj każdego z nich, czy ma daną wartość, przy użyciu medoty DoYouHaveAny().
            // Przekaże ona zestaw kart - dodaj je do bieżącego zestawu. Sprawdź, ile kart zostało dodanych. Jeżeli nie było żadnej, to pociągnij jedną kartę z kupki
            // (ona także została przekazana w postaci parametru). Na końcu powinieneś dodać do kontrolki TextBox wiersz o postaci: "Janek pobrał kartę z kupki".
        }

        // Jest jeszcze właściwość i kilka krótkich metod, które już został za Ciebie napisane.
        public int CardCount { get { return cards.Count; }}
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
