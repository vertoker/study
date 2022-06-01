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
int* SelectAttackCards(string commentMain, string commentCardID, Deck deck) {
    cout << commentMain << endl;

    vector<Card> first = 

    while (true) {

    }
    return atoi(str);
}
int EnterSelectedCard(string comment, int countDeck) {
    cout << comment;
    char str[32], * p = str;
    cin >> str;

    while (*p) {
        if (!isdigit(*p++)) {
            return EnterSelectedCard(comment, countDeck);
        }
    }
    return atoi(str);
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

    void PrintSuit() {
        switch (_suit)
        {
        case Suit::Diamonds: cout << static_cast<char>(4) << " (бубны)"; break;
        case Suit::Hearts: cout << static_cast<char>(3) << " (черви)"; break;
        case Suit::Clubs: cout << static_cast<char>(5) << " (трефы)"; break;
        case Suit::Spades: cout << static_cast<char>(6) << " (пики)"; break;
        }
        cout << endl;
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

class Decision {
public:
    DecisionType decisionType = DecisionType::Bot;
    bool isOver = false;

    Decision() {

    }

    vector<int> MakeDecision(Deck deck, vector<Card> cards) {
        if (decisionType == DecisionType::Human)
            return HumanDecision(deck, cards);
        return BotDecision(deck, cards);
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
    vector<int> HumanDecision(Deck deck, vector<Card> cards) {
        cout << "Ваша колода" << endl;
        deck.Print();
        cout << "Выкинутые карты на вас" << endl;
        for (Card card : cards)
        {
            card.Print();
        }
        return EnterBool("Возьмёте карту? (y, n) - ");
    }
    vector<int> BotDecision(Deck deck, vector<Card> cards) {
        cout << "Количество карт у бота - " << deck.length << endl;
        //deck.Print();
        //cout << "Выбранная карта" << endl;
        //card.Print();
        //int cardWeigth = card._weight;
        //bool decision = weigth == 21 || weigth < 18;
        /*if (decision)
            cout << "Бот взял карту" << endl;
        else
            cout << "Бот спасовал карту" << endl;*/
        return deck.length - 1;
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
        cout << "Козырная карта" << endl;
        dispencer.cards[0].Print();
        cout << "Козырная масть - " << dispencer.cards[0] << endl;


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

            cout << "Игрок #" << counterCurrent + 1 << " - " << players[counterCurrent].GetType() << endl;

            Card card = dispencer.PopLast();
            if (players[counterCurrent].MakeDecision(decks[counterCurrent], card)) {
                decks[counterCurrent].Add(card);
            }
            else {
                dispencer.Add(card);
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