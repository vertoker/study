#include <iostream>
#include <utility>
#include <vector>
#include <chrono>
#include <thread>
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
    cout << "Некорректный ответ" << endl;
    return EnterBool(comment);
}

enum Suit
{
    Diamonds = 0, Hearts = 1, Clubs = 2, Spades = 3
};

enum Number {
    Card6 = 0, Card7 = 1, Card8 = 2, Card9 = 3, Card10 = 4,
    CardJack = 5, CardQueen = 6, CardKing = 7, CardAce = 8
};

enum DecisionType {
    Human = 0, Bot = 1
};

int StaticWeight[9] = {
    6, 7, 8, 9, 10, 5, 4, 3, 11
};

struct Card {
public:
    Suit _suit = Suit::Diamonds;
    Number _number = Number::CardAce;
    int _weight = 0;

    Card() {

    }

    Card(Suit suit, Number number, int weight) {
        _suit = suit;
        _number = number;
        _weight = weight;
    };

    int GetCardID() {
        int suitNum = static_cast<int>(_suit);
        int numberNum = static_cast<int>(_number);
        return 9 * suitNum * numberNum;
    }

    void Print() {
        switch (_number)
        {
        case Number::Card6: cout << "Карта 6"; break;
        case Number::Card7: cout << "Карта 7"; break;
        case Number::Card8: cout << "Карта 8"; break;
        case Number::Card9: cout << "Карта 9"; break;
        case Number::Card10: cout << "Карта 10"; break;
        case Number::CardJack: cout << "Карта J"; break;
        case Number::CardQueen: cout << "Карта Q"; break;
        case Number::CardKing: cout << "Карта K"; break;
        case Number::CardAce: cout << "Карта A"; break;
        }
        switch (_suit)
        {
        case Suit::Diamonds: cout << static_cast<char>(4) << " (бубны) => "; break;
        case Suit::Hearts: cout << static_cast<char>(3) << " (черви) => "; break;
        case Suit::Clubs: cout << static_cast<char>(5) << " (трефы) => "; break;
        case Suit::Spades: cout << static_cast<char>(6) << " (пики) => "; break;
        }
        cout << _weight << endl;
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
                cards[counter] = Card(static_cast<Suit>(y), static_cast<Number>(x), StaticWeight[x]);
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
        cout << "В колоде общее количество очков = " << CalculateWeight() << endl;
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

    int CalculateWeight() {
        int weight = 0;
        for (int i = 0; i < length; i++)
            weight += cards[i]._weight;
        return weight;
    }
};

class Decision {
public:
    DecisionType decisionType = DecisionType::Bot;
    bool isOver = false;

    Decision() {

    }

    bool MakeDecision(Deck deck, Card card) {
        if (decisionType == DecisionType::Human)
            return HumanDecision(deck, card);
        return BotDecision(deck, card);
    }

    string GetType() {
        switch (decisionType)
        {
        case DecisionType::Human: return "Человек";
        case DecisionType::Bot: return "Бот";
        }
        return "";
    }

private:
    bool HumanDecision(Deck deck, Card card) {
        cout << "Ваша колода" << endl;
        deck.Print();
        //cout << "Выбранная карта" << endl;
        //card.Print();
        return EnterBool("Возьмёте карту? (y, n) - ");
    }
    bool BotDecision(Deck deck, Card card) {
        cout << "Количество карт у бота - " << deck.length << endl;
        //deck.Print();
        //cout << "Выбранная карта" << endl;
        //card.Print();
        int weigth = deck.CalculateWeight();
        //int cardWeigth = card._weight;
        bool decision = weigth == 21 || weigth < 18;
        if (decision)
            cout << "Бот взял карту" << endl;
        else
            cout << "Бот спасовал карту" << endl;
        return decision;
    }
};

class GameController {
public:
    Deck dispencer = Deck();
    Deck* decks;
    Decision* players;
    int count = 1;

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

        bool inGame = true;
        int counterCurrent = 0;
        int counterInPlay = count;
        int answerNoCounter = 0;
        while (inGame)
        {
            if (dispencer.length == 0) {
                count = decks->length;
                break;
            }
            if (players[counterCurrent].isOver) {
                counterCurrent++;
                if (counterCurrent == count)
                    counterCurrent = 0;
                continue;
            }

            cout << "Игрок #" << counterCurrent + 1 << " - " << players[counterCurrent].GetType() << endl;

            Card card = dispencer.PopLast();
            if (players[counterCurrent].MakeDecision(decks[counterCurrent], card)) {
                decks[counterCurrent].Add(card);
                answerNoCounter = 0;
            }
            else {
                dispencer.Add(card);
                answerNoCounter++;
            }
            cout << endl;

            int weight = decks[counterCurrent].CalculateWeight();
            bool solutionLose = weight > 21;
            bool solutionWin = weight == 21;
            if (solutionLose) {
                cout << "Игрок проигрывает, так как сумма его карт больше 21" << endl;
                players[counterCurrent].isOver = true;
                counterInPlay--;
                cout << endl;
                if (counterInPlay == 0)
                    break;
                continue;
            }
            if (solutionWin) {
                cout << "Игрок выигрывает, так как сумма его карт равна 21" << endl;
                players[counterCurrent].isOver = true;
                counterInPlay--;
                cout << endl;
                if (counterInPlay == 0)
                    break;
                continue;
            }

            if (answerNoCounter == counterInPlay)
                break;

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
            int next = deck.CalculateWeight();
            if (next > 21) {
                continue;
            }
            else if (maxResult < next) {
                winnersID.resize(0);
                maxResult = next;
                winnersID.push_back(i);
            }
            else if (maxResult == next) {
                winnersID.push_back(i);
            }
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