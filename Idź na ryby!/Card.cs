using System.Collections.Generic;

namespace Idź_na_ryby_
{
    class Card
    {
        public Values Value;
        public Suit Suit;
        private List<Card> cards = new List<Card>();
        public Card(Suit suit, Values value)
        {
            this.Value = value;
            this.Suit = suit;
        }
        void createCards()
        {
            cards.Add(new Card(Suit.Diamonds, Values.King));
            cards.Add(new Card(Suit.Clubs, Values.Three));
            cards.Add(new Card(Suit.Hearts, Values.Ace));
        }

        public override string ToString()
        {
            return Name;
        }

        private static string[] names0 = new string[]
        {
            "", "asów", "dwójek", "trójek", "czwórek", "piątek", "szóstek", "siódemek", "ósemek", "dziewiątek",
            "dziesiątek", "waletów", "dam", "króli"
        };

        private static string[] names1 = new string[]
        {
            "", "asa", "dwójkę", "trójkę", "czwórkę", "piątkę", "szóstkę", "siódemkę", "ósemkę", "dziewiątkę",
            "dziesiątkę", "waleta", "damę", "króla"
        };

        private static string[] names2AndMore = new string[]
        {
            "", "asy", "dwójki", "trójki", "czwórki", "piątki", "szóstki", "siódemki", "ósemki", "dziewiątki",
            "dziesiątki", "walety", "damy", "króle"
        };

        public static string Plural(Values value, int count)    // niby w podreczniku jest Card.Values
        {
            if (count == 0)
                return names0[(int)value];
            if (count == 1)
                return names1[(int)value];
            return names2AndMore[(int) value];
        }

        private static string[] suits = new string[] {"pik", "trefl", "karo", "kier"};

        private static string[] names = new string[]
        {
            "", "As", "Dwójka", "Trójka", "Czwórka", "Piątka", "Szóstka", "Siódemka", "Ósemka", "Dziewiątka",
            "Dziesiątka", "Walet", "Dama", "Król"
        };

        public string Name
        {
            get { return names[(int) Value] + " " + suits[(int) Suit]; }
        }
    }
}
