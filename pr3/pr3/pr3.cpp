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
string CharToString(char x) {
    string s(1, x);
    return s;
}

enum Suit
{
    Diamonds = 0, Hearts = 1, Clubs = 2, Spades = 3
};
static string ToString(Suit suit) {
    switch (suit)
    {
    case Suit::Diamonds: return CharToString(static_cast<char>(4));
    case Suit::Hearts: return CharToString(static_cast<char>(3));
    case Suit::Clubs: return CharToString(static_cast<char>(5));
    case Suit::Spades: return CharToString(static_cast<char>(6));
    }
}
static string ToStringFull(Suit suit) {
    switch (suit)
    {
    case Suit::Diamonds: return CharToString(static_cast<char>(4)) + " (бубны)";
    case Suit::Hearts: return CharToString(static_cast<char>(3)) + " (черви)";
    case Suit::Clubs: return CharToString(static_cast<char>(5)) + " (трефы)";
    case Suit::Spades: return CharToString(static_cast<char>(6)) + " (пики)";
    }
}
enum Number {
    Card6 = 0, Card7 = 1, Card8 = 2, Card9 = 3, Card10 = 4,
    CardJack = 5, CardQueen = 6, CardKing = 7, CardAce = 8
};
static string ToString(Number number) {
    switch (number)
    {
    case Number::Card6: return "6";
    case Number::Card7: return "7";
    case Number::Card8: return "8";
    case Number::Card9: return "9";
    case Number::Card10: return "10";
    case Number::CardJack: return "J";
    case Number::CardQueen: return "Q";
    case Number::CardKing: return "K";
    case Number::CardAce: return "A";
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
        cout /*<< "Карта "*/ << ToString(_number) << ToStringFull(_suit) << endl;
    }
    void Print(int id) {
        cout /*<< "Карта "*/ << ToString(_number) << ToStringFull(_suit) << " => " << id << endl;
    }
    void PrintTable(int id) {
        cout << ToString(_number) << ToString(_suit) << " (" << id << ") ";
    }
};

class Deck {
public:
    Card* cards;
    int length = 0;

    Deck() {
        cards = new Card[36];
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
            cards[i].Print(i);
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
    bool isFirst = true;
    int length = 0;

    Table() {

    }

    void Attack(vector<Card> attackSorted) {
        length = attackSorted.size();
        for (int i = 0; i < length; i++)
        {
            comparisons[i].SetAttack(attackSorted[i]);
        }
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
            return false;
        }
    }
    void Defense() {

    }
    void Print() {
        for (int i = 0; i < length; i++)
            comparisons[i].cardAttack.PrintTable(i);
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

        if (table.length > 0) {
            cout << "Выкинутые карты на столе: " << endl;
            table.Print();
        }
        else {
            cout << "На столе нету карт" << endl;
        }
        cout << endl;

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
        for (size_t i = 0; i < count; i++)
        {
            players[i] = Decision();
            decks[i] = Deck();
        }
        players[0].decisionType = DecisionType::Human;
    }

    void Game() {
        cout << "Игра началась" << endl << endl;

        for (size_t x = 0; x < count; x++)
        {
            for (size_t y = 0; y < 6; y++) {
                decks[x].Add(dispencer.PopLast());
            }
        }

        cout << "Козырная карта" << endl;
        dispencer.cards[0].Print();
        trump = dispencer.cards[0]._suit;
        //cout << "Козырная масть - " << ToStringFull(trump) << endl;
        cout << endl;

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

            cout << "Нападает игрок #" << counterCurrent + 1 << " - " << ToString(players[counterCurrent].decisionType) << endl;

            vector<Card> attackDeck = players[counterCurrent].MakeDecision(decks[counterCurrent], table);
            cout << endl;

            int next = Clamp(counterCurrent + 1, 0, count);
            cout << "Защищается игрок #" << next + 1 << " - " << ToString(players[next].decisionType) << endl;

            if (table.CanDefense(attackDeck, decks[next], trump)) {
                cout << "Игрок может защититься" << endl;
            }

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

    GameController controller = GameController(EnterNumber("Введите количество игроков (от 2 до 5): "));
    controller.Game();
}