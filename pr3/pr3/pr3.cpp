#include <algorithm>
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
bool InClampArray(int value, int length) {
    return value >= 0 && value < length;
}
bool InVector(vector<int>& vec, int& value) {
    for (auto id : vec)
    {
        if (id == value) {
            return true;
        }
    }
    return false;
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
        length = 16;
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

    void Add(vector<Card> bito) {
        //cout << bito.size() << endl;
        for (Card card : bito) {
            cards[length] = card;
            length++;
        }
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
        if (card1._suit == card2._suit) {
            return IsBigger(card1, card2);
        }
        else if (card1._suit == trump) {
            return false;
        }
        else if (card2._suit == trump) {
            return true;
        }
        return false;
    }
private:
    static bool IsBigger(Card attack, Card defense) {
        //cout << static_cast<int>(attack._number) << ' ' << static_cast<int>(defense._number) << endl;
        return static_cast<int>(attack._number) < static_cast<int>(defense._number);
    }
};

class Table {
public:
    static const bool isFirst = true;

    static void Print(vector<Card> attackSorted) {
        for (int i = 0; i < attackSorted.size(); i++)
            attackSorted[i].PrintTable(i);
        cout << endl;
    }
};

static int EnterSelectedCard(Deck& deck) {
    cout << "Введите номер карты (введите s для остановки): ";
    char str[4], * p = str;
    cin >> str;

    if (str[0] == 's') {
        return -1;
    }
    while (*p) {
        if (!isdigit(*p++)) {
            return EnterSelectedCard(deck);
        }
    }
    int id = atoi(str);
    if (id < deck.length) {
        return id;
    }
    return EnterSelectedCard(deck);
}
static vector<Card> SelectAttackCards(Deck& deck, int countNext) {
    cout << "Выберите карты для атаки" << endl;

    vector<int> ids;
    Number current;
    int id;

    do {
        id = EnterSelectedCard(deck);

        if (id == -1) {
            break;
        }
        if (ids.size() == 0) {
            current = deck.cards[id]._number;
        }
        if (deck.cards[id]._number == current) {
            ids.push_back(id);
        }
        else {
            cout << "Не совпадает номер у карт" << endl;
        }

    } while (ids.size() < deck.length && ids.size() < countNext);

    vector<Card> cards;
    int length = deck.length;
    sort(ids.begin(), ids.end());
    for (size_t i = 0; i < ids.size(); i++)
        cards.push_back(deck.Pop(ids.at(ids.size() - i - 1)));
    return cards;
}

int EnterNumberDecision(string comment) {
    cout << comment;
    char str[32], * p = str;
    cin >> str;

    if (str[0] == 's') {
        return -1;
    }
    while (*p) {
        if (!isdigit(*p++)) {
            return EnterNumber(comment);
        }
    }
    return atoi(str);
}
static void EnterDefenseAndAttackCard(vector<Card> attackSorted, Deck& deck, Suit trump, int& idAttack, int& idDefense, vector<int>& attacks, vector<int>& defenses) {
    do {
        idAttack = EnterNumberDecision("Введите номер карты из колоды атаки (напишите s если хотите остановиться): ");
        if (idAttack == -1)
            return;
    } while (!InClampArray(idAttack, attackSorted.size()) && !InVector(attacks, idAttack));
    do {
        idDefense = EnterNumberDecision("Введите номер карты из колоды защиты (напишите s если хотите остановиться): ");
        if (idDefense == -1)
            return;
    } while (!InClampArray(idDefense, deck.length) && !InVector(defenses, idDefense));

    if (!CardComparison::CanDefense(attackSorted[idAttack], deck.cards[idDefense], trump)) {
        cout << "Карта из защиты не в состоянии побить карту атаки" << endl;
        return EnterDefenseAndAttackCard(attackSorted, deck, trump, idAttack, idDefense, attacks, defenses);
    }
}
static vector<Card> SelectDefenseCards(vector<Card> attackSorted, Deck& deck, Suit trump, bool& isDefended) {
    cout << "Защищайтесь" << endl;

    int idAttack = -1, idDefense = -1;
    vector<int> attacks, defenses;

    do {
        EnterDefenseAndAttackCard(attackSorted, deck, trump, idAttack, idDefense, attacks, defenses);
        if (idAttack == -1 || idDefense == -1) {
            break;
        }
        attacks.push_back(idAttack);
        defenses.push_back(idDefense);
    } while (deck.CanPopLast() && attackSorted.size() != 0);

    cout << defenses.size() << endl;
    cout << attackSorted.size() << endl;
    isDefended = defenses.size() == attackSorted.size();
    sort(attacks.begin(), attacks.end());
    sort(defenses.begin(), defenses.end());
    for (size_t i = 0; i < defenses.size(); i++)
        attackSorted.push_back(deck.Pop(defenses.at(defenses.size() - i - 1)));
    cout << endl;
    return attackSorted;
}

class Decision {
public:
    DecisionType decisionType = DecisionType::Bot;
    bool isTimeOut = false;
    bool isOver = false;

    Decision() {

    }

    vector<Card> MakeDecisionAttack(Deck& deck, int countNext) {
        if (decisionType == DecisionType::Human)
            return HumanDecisionAttack(deck, countNext);
        return HumanDecisionAttack(deck, countNext);//Изменить потом
    }
    vector<Card> MakeDecisionDefense(vector<Card> attackSorted, Deck& deck, Suit trump, bool& isDefended) {
        if (decisionType == DecisionType::Human)
            return HumanDecisionDefense(attackSorted, deck, trump, isDefended);
        return HumanDecisionDefense(attackSorted, deck, trump, isDefended);//Изменить потом
    }
    /*vector<Card> MakeDecisionContrAttack(vector<Card> bito, Deck deck, int attackCount) {
        if (decisionType == DecisionType::Human)
            return HumanDecisionContrAttack(bito, deck, attackCount);
        return HumanDecisionContrAttack(bito, deck, attackCount);//Изменить потом
    }*/

private:
    vector<Card> HumanDecisionAttack(Deck& deck, int countNext) {
        cout << "Ваша колода" << endl;
        deck.Print();
        cout << endl;
        return SelectAttackCards(deck, countNext);
    }
    vector<Card> HumanDecisionDefense(vector<Card> attackSorted, Deck& deck, Suit trump, bool& isDefended) {
        cout << "Ваша колода" << endl;
        deck.Print();

        cout << "Выкинутые карты на столе: " << endl;
        Table::Print(attackSorted);

        cout << endl;

        return SelectDefenseCards(attackSorted, deck, trump, isDefended);
    }

    vector<Card> BotDecisionAttack(Deck deck, int countNext) {
        cout << "Количество карт у бота - " << deck.length << endl;

        vector<Card> attackSorted;
        attackSorted.push_back(deck.Pop(rand() % deck.length));

        //table.Print();
        
        //deck.Print();
        //cout << "Выбранная карта" << endl;
        //card.Print();
        //int cardWeigth = card._weight;
        //bool decision = weigth == 21 || weigth < 18;
        /*if (decision)
            cout << "Бот взял карту" << endl;
        else
            cout << "Бот спасовал карту" << endl;*/
        return SelectAttackCards(deck, countNext);
    }
};

class GameController {
public:
    Deck dispencer = Deck();
    Table table = Table();
    Suit trump;

    int count = 1;
    vector<int> winnersID;
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
        if (dispencer.length > 0)
            cout << "В колоде - " << dispencer.length << " карт" << endl;
        else
            cout << "В колоде не осталось карт" << endl;
        cout << endl;

        bool inGame = true;
        int current = 0;
        int counterOffPlay = 0;
        while (inGame)
        {
            if (players[current].isOver || players[current].isTimeOut) {//Проверка на проигрыш игрока
                players[current].isTimeOut = false;
                current++;
                if (current == count)
                    current = 0;
                continue;
            }
            int next = GetNextPlayer(current);

            cout << "Нападает игрок #" << current + 1 << " - " << ToString(players[current].decisionType) << endl;

            vector<Card> attackDeck = players[current].MakeDecisionAttack(decks[current], decks[next].length);
            cout << endl;

            cout << "Защищается игрок #" << next + 1 << " - " << ToString(players[next].decisionType) << endl;

            bool isDefended;
            int lengthNext = decks[next].length;
            vector<Card> bito = players[next].MakeDecisionDefense(attackDeck, decks[next], trump, isDefended);
            if (isDefended) {
                cout << "Игрок " << next + 1 << " защитился" << endl;
                cout << "Карты идут в бито" << endl;
            }
            else {
                cout << "Игрок " << next + 1 << " не смог защититься" << endl;
                cout << "Игрок " << next + 1 << " забирает " << bito.size() << " карт" << endl;
                players[next].isTimeOut = true;
                decks[next].Add(bito);
            }
            cout << endl;

            // Дать карты тем, у кого их нету
            if (decks[current].length < 6) {
                int canGet = 6 - decks[current].length;
                if (canGet > dispencer.length)
                    canGet = dispencer.length;

                if (canGet > 0) {
                    cout << "Игрок " << current + 1 << " взял " << canGet << " карт" << endl;
                    for (int i = 0; i < canGet; i++)
                    {
                        Card card = dispencer.PopLast();
                        card.Print();
                        decks[current].Add(card);
                    }
                    if (dispencer.length > 0)
                        cout << "В колоде - " << dispencer.length << " карт" << endl;
                    cout << endl;
                }
            }

            if (decks[next].length < 6) {
                int canGet = 6 - decks[next].length;

                if (canGet > dispencer.length)
                    canGet = dispencer.length;
                if (canGet > 0) {
                    cout << "Игрок " << next + 1 << " взял " << canGet << " карт" << endl;
                    for (int i = 0; i < canGet; i++)
                    {
                        Card card = dispencer.PopLast();
                        card.Print();
                        decks[next].Add(card);
                    }
                    if (dispencer.length > 0)
                        cout << "В колоде - " << dispencer.length << " карт" << endl;
                    cout << endl;
                }
            }

            // Проверка на выигрыш
            if (decks[current].length == 0) {
                cout << "Игрок под номером " << current + 1 << " завершает игру" << endl;
                winnersID.push_back(current);
                players[current].isOver = true;

                counterOffPlay++;
                if (counterOffPlay == count - 1) {
                    for (size_t i = 0; i < count; i++)
                    {
                        if (!players[i].isOver) {
                            winnersID.push_back(i);
                            break;
                        }
                    }
                    break;
                }
            }
            if (decks[next].length == 0) {
                cout << "Игрок под номером " << next + 1 << " завершает игру" << endl;
                winnersID.push_back(next);
                players[next].isOver = true;

                counterOffPlay++;
                if (counterOffPlay == count - 1) {
                    for (size_t i = 0; i < count; i++)
                    {
                        if (!players[i].isOver) {
                            winnersID.push_back(i);
                            break;
                        }
                    }
                    break;
                }
            }

            current++;
            if (current == count)
                current = 0;

            this_thread::sleep_for(chrono::milliseconds(100));
        }
        PrintResults();
    }
private:
    int GetNextPlayer(int current) {
        int next = current;
        do
        {
            next++;
            if (next == count)
                next = 0;

            if (!players[next].isOver) {
                return next;
            }
        } while (next != current);
        return next;
    }
    void PrintResults() {
        cout << endl;
        cout << "Результаты" << endl;

        cout << endl;
        cout << "Список выбывших по счёту" << endl;
        for (int i = 0; i < winnersID.size(); i++)
        {
            cout << "Игрок #" << winnersID.at(i) + 1 << endl;
        }
        cout << endl;

        if (decks[winnersID.back()].length > 0) {
            cout << "Колода проигравшего игрока" << endl;
            decks[winnersID.back()].Print();
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