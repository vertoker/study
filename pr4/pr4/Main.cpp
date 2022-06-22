#include <SFML/Graphics.hpp>

void Move(sf::Vector2f& origin, float speed) {
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::Left) || sf::Keyboard::isKeyPressed(sf::Keyboard::A))
        origin.x -= speed;
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::Right) || sf::Keyboard::isKeyPressed(sf::Keyboard::D))
        origin.x += speed;
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::Up) || sf::Keyboard::isKeyPressed(sf::Keyboard::W))
        origin.y -= speed;
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::Down) || sf::Keyboard::isKeyPressed(sf::Keyboard::S))
        origin.y += speed;
}

void Clamp(sf::Vector2f& origin, sf::Vector2f start, sf::Vector2f end) {
    if (origin.x < start.x)
        origin.x = start.x;
    else if (origin.x > end.x)
        origin.x = end.x;
    if (origin.y < start.y)
        origin.y = start.y;
    else if (origin.y > end.y)
        origin.y = end.y;
}

int main()
{
    float speed = 0.35f;
    sf::Vector2f start(0.f, 0.f);
    sf::Vector2f end(450.f, 450.f);

    sf::RenderWindow window(sf::VideoMode(500, 500), "Game");
    sf::RectangleShape character(sf::Vector2f(50.f, 50.f));
    character.setFillColor(sf::Color::Green);

    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
                window.close();
        }

        sf::Vector2f position = character.getPosition();
        Move(position, speed);
        Clamp(position, start, end);
        character.setPosition(position);

        window.clear();
        window.draw(character);
        window.display();
    }

    return 0;
}