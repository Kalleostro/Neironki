import numpy as np
import matplotlib.pyplot as plt

import NeuralNetwork as nn


def draw_menu():
    print("Меню:")
    print("1. Обучить")
    print("2. Аппроксимация + графики")
    print("3. Графическая разница нейронов")
    print("4. Выход")


def menu_item_1(fx, rbf, perceptron_1, perceptron_2, perceptron_1x2, perceptron_1x3):
    x = np.random.uniform(-2.5, 5.5, size=[150000, 1])
    y = fx(x)
    rbf.sigma = np.std(y)
    rbf.fit(x, y)
    for i in range(150000):
        xi = x[i].reshape(1, 1)
        yi = y[i].reshape(1, 1)
        perceptron_1.forward(xi)
        perceptron_1.backward(yi)
        perceptron_1.update()
        perceptron_2.forward(xi)
        perceptron_2.backward(yi)
        perceptron_2.update()
        perceptron_1x2.forward(xi)
        perceptron_1x2.backward(yi)
        perceptron_1x2.update()
        perceptron_1x3.forward(xi)
        perceptron_1x3.backward(yi)
        perceptron_1x3.update()
    return True

def menu_item_2(fx, rbf, perceptron_1, perceptron_2):
    points = np.linspace(-2.5, 5.5, 500)
    p1 = []
    p2 = []
    for i in points:
        p1.append(perceptron_1(i.reshape(1, 1)).reshape(-1))
        p2.append(perceptron_2(i.reshape(1, 1)).reshape(-1))
    plt.plot(points, rbf.predict(points), "g", label="РБС")
    plt.plot(points, p1, "b", label="Персептрон с 1 скрытым слоем")
    plt.plot(points, p2, "r", label="Персептрон с 2 скрытыми слоями")
    plt.plot(points, fx(points), "k--", label="График функции")
    plt.xlabel("x")
    plt.ylabel("y")
    plt.title(r"Аппроксимация заданной функции")
    plt.legend()
    plt.grid()
    plt.show()

def menu_item_3(fx, perceptron_1, perceptron_1x2, perceptron_1x3):
    points = np.linspace(-2.5, 5.5, 500)
    p1 = []
    p1_x2 = []
    p1_x3 = []
    for i in points:
        p1.append(perceptron_1(i.reshape(1, 1)).reshape(-1))
        p1_x2.append(perceptron_1x2(i.reshape(1, 1)).reshape(-1))
        p1_x3.append(perceptron_1x3(i.reshape(1, 1)).reshape(-1))
    plt.plot(points, p1, "b", label="Персептрон с 7 нейронами на скрытом слое")
    plt.plot(points, p1_x2, "g", label="Персептрон с 63 нейронами на скрытом слое")
    plt.plot(points, p1_x3, "r", label="Персептрон с 567 нейронами на скрытом слое")
    plt.plot(points, fx(points), "k--", label="График функции")
    plt.xlabel("x")
    plt.ylabel("y")
    plt.title(r"Аппроксимация заданной функции")
    plt.legend()
    plt.grid()
    plt.show()


def create_nets():

    rbf = nn.RBFNet(6)

    hidden_neurons = 7
    lr = 0.00001

    perceptron_1 = nn.NN(lr)
    perceptron_1.add_layer(1, hidden_neurons, "tanh", need_bias=True)
    perceptron_1.add_layer(hidden_neurons, 1)

    perceptron_2 = nn.NN(lr / 2)
    perceptron_2.add_layer(1, hidden_neurons, "tanh", need_bias=True)
    perceptron_2.add_layer(hidden_neurons, hidden_neurons, "tanh", need_bias=True)
    perceptron_2.add_layer(hidden_neurons, 1)

    perceptron_1x2 = nn.NN(lr)
    perceptron_1x2.add_layer(1, hidden_neurons * 3 ** 2, "tanh", need_bias=True)
    perceptron_1x2.add_layer(hidden_neurons * 3 ** 2, 1)

    perceptron_1x3 = nn.NN(lr)
    perceptron_1x3.add_layer(1, hidden_neurons * 3 ** 4, "tanh", need_bias=True)
    perceptron_1x3.add_layer(hidden_neurons * 3 ** 4, 1)

    return rbf, perceptron_1, perceptron_2, perceptron_1x2, perceptron_1x3


if __name__ == "__main__":

    training_complete = False
    fx = lambda x: pow(2,x*np.cos(x)*np.sin(x))/(pow(np.sin(x),2)+pow(np.cos(x),2))
    rbf, perceptron_1, perceptron_2, perceptron_1x2, perceptron_1x3 = create_nets()
    
    flag = False
    k = 0
    while not flag:
        draw_menu()
        try:
            k = int(input("Выберите пункт меню: "))
        except ValueError:
            pass
        print()
        
        if k == 1:
            training_complete = menu_item_1(fx, rbf, perceptron_1, perceptron_2, perceptron_1x2, perceptron_1x3)
            print("\nОбучение завершено успешно.\a\n")
        elif k == 2:
            if training_complete:
                menu_item_2(fx, rbf, perceptron_1, perceptron_2)
            else:
                print("Ошибка. Необходимо обучить сеть.\n")
        elif k == 3:
            if training_complete:
                menu_item_3(fx, perceptron_1, perceptron_1x2, perceptron_1x3)
            else:
                print("Ошибка. Необходимо обучить сеть.\n")
        elif k == 4:
            flag = True