using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idź_na_ryby_
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            // To tutaj rozpoczyna się gra - metoda wywoływana jest tylko na jej początku. Tasuje talię, rozdaje każdemu graczowi po pięć kart,
            // a następnie używa pętli foreach do wywołania metody PullOutBooks() każdego gracza.
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            // Rozegraj jedną rundę gry. Parametrem jest karta, którą wybrał z ręki Twój gracz - pobierz jej wartość. 
            // Przeglądnij potem wszystkich uczestników gry i wywołaj metodę AskForACard() każdego z nich, począwszy od użytkownika, który znajduje się
            // pod indeksem zero na liście graczy - upewnij się, że poszukiwana jest zaznaczona wartość. Następnie wywołaj PullOutBooks() - jeżeli zwróci
            // true, oznacza to, że Twojemu graczowi skończyły się karty i potrzebuje nowych. Po wykonaniu ruchu przez przeciwników posortuj karty gracza
            // (aby ładnie wyglądały na formularzu). Sprawdź pulę, aby określić, czy nie jest pusta. Jeżeli tak, zmodyfikuj tekst kontrolki TextBox,
            // aby wyświetlała: "Na kupce nie ma żadnych kart. Gra skończona!", i zwróć true. W przeciwnym razie zwróć false.
        }

        public bool PullOutBooks(Player player)
        {
            // Wyłóż grupy wszystkich uczestników gry. Zwróć true, gdy graczowi braknie kart. W przeciwnym razie zwróć false.
            // Każda grupa dodawana jest do słownika books. Graczowi kończą się karty, jeżeli użył ich wszystkich do tworzenia grup - wtedy wygrywa grę.
        }

        public string DescribeBooks()
        {
            // Zwróć długi napis określający grupy każdego gracza, przeglądając słownik books: "Janek ma grupę szóstek, (nowa linia) Edek ma grupę asów".
        }

        public string GetWinnerName()
        {
            // Ta metoda wywoływana jest na końcy gry. Używa ona swojego własnego słownika (Dictionary<string, int> winners) w celu określenia liczby grup
            // będących w posiadaniu każdego z graczy na końcu rozgrywki. Na początku korzysta z pętli foreach w odniesieniu do books. 
            // Keys - foreach(Values value in books.Keys) - aby wypełnić słownik winners liczbą grup każdego z uczestników. Następnie przegląda 
            // ten nowy słownik, aby znaleźć gracza z największą ich liczbą. Na końcu po raz ostatni przegląda zmienną winners i tworzy listę
            // zwycięsców w formie łańcucha znaków podobnego do tego: "Janek i Edek". Jeżeli istnieje tylko jeden zwycięsca, zwracany jest następujący 
            // ciąg znaków: "Edek: 3 grupy". W przeciwnym razie przybiera on postać: "Remis pomiędzy Janek i Edek: 2 grupy".
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " ma " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " kartę.\r\n";
                else if (players[i].CardCount == 2 || players[i].CardCount == 3 || players[i].CardCount == 4)
                    description += " karty.\r\n";
                else
                    description += " kart.\r\n";
            }
            description += "Na kupce pozostało kart: " + stock.Count + "\r\n";
            return description;
        }
    }


}
