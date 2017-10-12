using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Idź_na_ryby_
{
    class Deck
    {           // Wez to usun lol
        private List<Card> cards;
        private Random random = new Random();

        public Card Peek(int cardNumber)    // pozwala obejrzeć kartę bez pobierania jej.
        {
            return cards[cardNumber];
        }

        public Card Deal()      // pobieranie karty z wierzchu talii
        {
            return Deal(0);
        }

        public bool ContainsValue(Values value)     // zwraca true, jeśli znaleziono kartę w zestawie o określonej wartości
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }

        public Card Deal(int index)     // usuwa z zestawu i zwraca kartę
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        public Deck PullOutValues(Values value)     // zwraca grupę kart o podanej wartości z zestawu
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if(cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }

        public bool HasBook(Values value)       // jeżeli w zestawie jest grupa o podanej wartości, zwraca true
        {
            int NumberOfCards = 0;
            foreach(Card card in cards)
                if (card.Value == value)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else
                return false;
        }

        public void SortByValue()       // sortuje zestaw przy uzyciu klasy CardComparer_byValue
        {
            cards.Sort(new CardComparer_byValue());
        }

        public Deck()
        {
            cards = new List<Card>();
            for(int suit = 0; suit <= 3; suit++)
            for (int value = 1; value <= 13; value++)
                cards.Add(new Card((Suit) suit, (Values) value));
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count
        {
            get { return cards.Count; }
        }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }


        public void Shuffle()       // mieszanko kart
        {
            List<Card> newCards = new List<Card>();
            Card randomCard;
            while (cards.Count > 0)
            {
                newCards.Add(Deal(random.Next(cards.Count)));
            }
            cards = newCards;   
        }
        public IEnumerable<string> GetCardNames()
        {
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                CardNames[i] = cards[i].Name;
            }
            return CardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
