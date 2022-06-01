#include <iostream>;
#include <utility>;
#include <vector>;
#include <chrono>;
#include <thread>;
using namespace std;

int EnterNumber(string comment) {
    cout << comment;
    char str[32], * p = str;
    cin >> str;

    while (*p) {
        if (!isdigit(*p++)) {
            return EnterNumber(comment);
        }
    }
    return atoi(str);
}
bool EnterBool(string comment) {
    cout << comment;
    string condition;
    cin >> condition;
    if (condition == "y") {
        return true;
    }
    if (condition == "n") {
        return false;
    }
    return EnterBool(comment);
}
int Clamp(int value, int min, int max) {
    if (value < min)
        return min;
    if (value > max)
        return max;
    return value;
}

enum Suit
{
    Diamonds = 0, Hearts = 1, Clubs = 2, Spades = 3
};

static void Print(Suit suit) {
    switch (suit)
    {
    case Suit::Diamonds: cout << static_cast<char>(4); break;
    case Suit::Hearts: cout << static_cast<char>(3); break;
    case Suit::Clubs: cout << static_cast<char>(5); break;
    case Suit::Spades: cout << static_cast<char>(6); break;
    }
}
static void PrintFull(Suit suit) {
    switch (suit)
    {
    case Suit::Diamonds: cout << static_cast<char>(4) << " (бубны)"; break;
    case Suit::Hearts: cout << static_cast<char>(3) << " (черви)"; break;
    case Suit::Clubs: cout << static_cast<char>(5) << " (трефы)"; break;
    case Suit::Spades: cout << static_cast<char>(6) << " (пики)"; break;
    }
}

enum Number {
    Card6 = 0, Card7 = 1, Card8 = 2, Card9 = 3, Card10 = 4,
    CardJack = 5, CardQueen = 6, CardKing = 7, CardAce = 8
};

static void Print(Number number) {
    switch (number)
    {
    case Number::Card6: cout << '6'; break;
    case Number::Card7: cout << '7'; break;
    case Number::Card8: cout << '8'; break;
    case Number::Card9: cout << '9'; break;
    case Number::Card10: cout << '10'; break;
    case Number::CardJack: cout << 'J'; break;
    case Number::CardQueen: cout << 'Q'; break;
    case Number::CardKing: cout << 'K'; break;
    case Number::CardAce: cout << 'A'; break;
    }
}

enum DecisionType {
    Human = 0, Bot = 1
};

static string ToString(DecisionType type) {
    switch (type)
    {
    case DecisionType::Human: return "Человек";
    case DecisionType::Bot: return "Бот";
    }
    return "";
}

struct Card {
public:
    Suit _suit = Suit::Diamonds;
    Number _number = Number::CardAce;

    Card() {

    }

    Card(Suit suit, Number number) {
        _suit = suit;
        _number = number;
    };

    int GetCardID() {
        int suitNum = static_cast<int>(_suit);
        int numberNum = static_cast<int>(_number);
        return 9 * suitNum * numberNum;
    }

    void Print() {
        PrintNumber();
        PrintSuit();
    }
    void PrintTable() {
        PrintNumberTable();
        PrintSuitTable();
        cout << ' ';
    }

    void PrintNumber() {
        cout << "Карта ";
        PrintNumberTable();
    }
    void PrintNumberTable() {
    }
    void PrintSuit() {
        switch (_suit)
        {
        }
        cout << endl;
    }
    void PrintSuitTable() {
        switch (_suit)
        {
        case Suit::Diamonds: cout << static_cast<char>(4); break;
        case Suit::Hearts: cout << static_cast<char>(3); break;
        case Suit::Clubs: cout << static_cast<char>(5); break;
        case Suit::Spades: cout << static_cast<char>(6); break;
        }
    }
};

class Deck {
public:
    Card cards[36];
    int length = 0;

    Deck() {

    }

    void Fill() {
        length = 36;
        for (size_t x = 0; x < 9; x++)
        {
            for (size_t y = 0; y < 4; y++)
            {
                int counter = x * 4 + y;
                cards[counter] = Card(static_cast<Suit>(y), static_cast<Number>(x));
            }
        }
    }
    void Shuffle() {
        for (size_t i = 0; i < length; i++) {
            int next = rand() % length;
            Card card = cards[i];
            cards[i] = cards[next];
            cards[next] = card;
        }
    }
    Card GetRandom() {
        if (length == 1)
            return cards[0];
        return cards[rand() % length - 1];
    }
    void Print() {
        if (length == 0) {
            cout << "Карт в колоде нету :(" << endl;
            return;
        }
        for (int i = 0; i < length; i++)
            cards[i].Print();
    }

    void Add(Card card) {
        cards[length] = card;
        length++;
    }
    bool CanPop(int id) {
        return length > 0 && id < length;
    }
    Card Pop(int id) {
        Card result = cards[id];
        for (int i = id; i < length - 1; i++)
            cards[i] = cards[i + 1];
        length--;
        return result;
    }
    bool CanPopLast() {
        return length > 0;
    }
    Card PopLast() {
        length--;
        Card result = cards[length];
        return result;
    }
};

// Атака // Защита
struct CardComparison {
public:
    Card cardAttack;

    void SetAttack(Card card) {
        cardAttack = card;
    }
    bool CanDefense(Card card, Suit trump) {
        return CanDefense(cardAttack, card, trump);
    }
    static bool CanDefense(Card card1, Card card2, Suit trump) {
        if (card1._suit == trump) {
            if (card2._suit == trump) {
                return IsBigger(card1, card2);
            }
            else {
                return true;
            }
        }
        else {
            if (card2._suit == trump) {
                return false;
            }
            else {
                return IsBigger(card1, card2);
            }
        }
    }
private:
    static bool IsBigger(Card attack, Card defense) {
        return static_cast<int>(attack._number) < static_cast<int>(defense._number);
    }
};

class Table {
public:
    CardComparison comparisons[6];

    Table() {

    }

    bool CanDefense(vector<Card> attackSorted, Deck deck, Suit trump) {
        vector<int> usedCardsID;

        for (int i = 0; i < deck.length; i++)
        {
            for (int used : usedCardsID) {
                if (i == used) {
                    continue;
                }
            }

            for (Card card : attackSorted)
            {
                if (CardComparison::CanDefense(card, deck.cards[i], trump)) {
                    usedCardsID.push_back(i);
                }
            }
        }
    }
    void SetAttack(vector<Card> attackSorted) {
        for (int i = 0; i < 6; i++)
        {
            comparisons[i].SetAttack(attackSorted[i]);
        }
    }
    void Print() {
        for (auto comparison : comparisons)
            comparison.cardAttack.PrintTable();
        cout << endl;
    }
};

static Card EnterSelectedCard(Deck deck) {
    cout << "Введите номер карты: ";
    char str[4], * p = str;
    cin >> str;

    while (*p) {
        if (!isdigit(*p++)) {
            return EnterSelectedCard(deck);
        }
    }
    int id = atoi(str);
    return deck.Pop(id);
}
static vector<Card> SelectAttackCards(Deck deck) {
    cout << "Выберите карты для атаки" << endl;

    vector<Card> cards;

    do {
        cards.push_back(EnterSelectedCard(deck));
    } while (EnterBool("Хотите продолжить ввод (y, n): ") && deck.CanPopLast());
    return cards;
}

class Decision {
public:
    DecisionType decisionType = DecisionType::Bot;
    bool isOver = false;

    Decision() {

    }

    vector<Card> MakeDecision(Deck deck, Table table) {
        if (decisionType == DecisionType::Human)
            return HumanDecision(deck, table);
        return HumanDecision(deck, table);//Изменить потом
    }

private:
    vector<Card> HumanDecision(Deck deck, Table table) {
        cout << "Ваша колода" << endl;
        deck.Print();
        cout << "Выкинутые карты на столе: " << endl;
        table.Print();
        return SelectAttackCards(deck);
    }
    vector<Card> BotDecision(Deck deck, Table table) {
        cout << "Количество карт у бота - " << deck.length << endl;
        cout << "Выкинутые карты на столе: " << endl;
        table.Print();
        //deck.Print();
        //cout << "Выбранная карта" << endl;
        //card.Print();
        //int cardWeigth = card._weight;
        //bool decision = weigth == 21 || weigth < 18;
        /*if (decision)
            cout << "Бот взял карту" << endl;
        else
            cout << "Бот спасовал карту" << endl;*/
        return SelectAttackCards(deck);
    }
};

class GameController {
public:
    Deck dispencer = Deck();
    Table table = Table();
    Suit trump;

    int count = 1;
    Decision* players;
    Deck* decks;

    GameController(int countPlayers) {
        count = countPlayers;
        dispencer.Fill();
        dispencer.Shuffle();
        //dispencer.Print();

        decks = new Deck[count];
        players = new Decision[count];
        for (int i = 0; i < count; i++)
        {
            decks[i] = Deck();
            players[i] = Decision();
        }
        players[0].decisionType = DecisionType::Human;
    }

    void Game() {
        cout << "Игра началась" << endl << endl;
        cout << "Козырная карта" << endl;
        dispencer.cards[0].Print();
        trump = dispencer.cards[0]._suit;
        cout << "Козырная масть - ";
        PrintFull(trump);
        cout << endl << endl;

        bool inGame = true;
        int counterCurrent = 0;
        int counterInPlay = count;
        while (inGame)
        {
            if (dispencer.length == 0) {// Проверка раздатчика
                count = decks->length;
                break;
            }
            if (players[counterCurrent].isOver) {//Проверка на проигрыш игрока
                counterCurrent++;
                if (counterCurrent == count)
                    counterCurrent = 0;
                continue;
            }

            cout << "Игрок #" << counterCurrent + 1 << " - " << ToString(players[counterCurrent].decisionType) << endl;
            int next = Clamp(counterCurrent + 1, 0, count);
            cout << "Идёт нападение на игрока #" << next + 1 << " - " << ToString(players[next].decisionType) << endl;

            vector<Card> attackDeck = players[counterCurrent].MakeDecision(decks[counterCurrent], table);

            counterCurrent++;
            if (counterCurrent == count)
                counterCurrent = 0;

            this_thread::sleep_for(chrono::milliseconds(100));
        }
        PrintResults();
    }
private:
    void PrintResults() {
        cout << "Результаты" << endl;

        int maxResult = 0;
        vector<int> winnersID;
        for (int i = 0; i < count; i++)
        {
            cout << endl << "Игрок #" << i + 1 << endl;
            Deck deck = decks[i];
            deck.Print();
        }
        cout << endl;
        cout << "Максимальное количество очков - " << maxResult << endl;
        cout << "Победили игроки под номерами: " << endl;
        for (int i = 0; i < winnersID.size(); i++)
        {
            cout << winnersID.at(i) + 1 << ' ';
        }
    }
};

int main()
{
    setlocale(LC_ALL, "Russian");
    srand(time(NULL));

    GameController controller = GameController(EnterNumber("Введите количество игроков (от 2 до 7): "));
    controller.Game();
}