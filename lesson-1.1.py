from turtle import *

width(10)

# Прямоугольник
up()
goto(-300, 300)
down()
for i in range(2):
    right(90)
    forward(50)
    right(90)
    forward(100)

# Шестиугольник
up()
goto(300, 300)
down()
for i in range(6):
    right(60)
    forward(50)

# Треугольник
up()
goto(-350, -50)
down()
right(60)
for i in range(3):
    forward(70)
    right(120)

# Звезда
up()
goto(250, -50)
down()
left(60)
for i in range(5):
    right(66)
    forward(50)
    left(60)
    forward(50)
    right(66)

up()
goto(0, 0)
down()
