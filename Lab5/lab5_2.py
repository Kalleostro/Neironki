import numpy as np
import matplotlib.pyplot as plt

import NeuralNetwork as nn


def deserialize(filename):
    with open(filename, "r") as file: 
        rows = file.read().split()
        data = []
        for i, k in enumerate(rows[:-1]):
            data.append(float(k))
    return data


def draw_menu():
    print("Меню")
    print("1. Температура в Бресте")
    print("2. Экстраполированные данные")
    print("3. Выход")


def train_nets(seq_length, train, rnn, perceptron, mean, std):

    for epoch in range(300):
        q = np.random.randint(0, seq_length)
        for i in range(q, len(train) - seq_length, seq_length):
            x = (np.array(train[i            : i+seq_length]).reshape(1, seq_length) - mean) / std
            y = (np.array(train[i+seq_length : i+seq_length+1]).reshape(1, 1) - mean) / std
            rnn(x)
            rnn.backward(y)
            rnn.update()
            perceptron.forward(x)
            perceptron.backward(y)
            perceptron.update()
    return True

def menu_item_1(train):
    plt.plot(train)
    plt.xlabel("День")
    plt.ylabel("Температура")
    plt.title("Температура воздуха в городе")
    plt.grid()
    plt.show()

def menu_item_2(seq_length, train, test, rnn, perceptron, mean, std):
    rnn_y = []
    perceptron_y = []
    for i in train[-seq_length:]:
        rnn_y.append((i - mean) / std)
        perceptron_y.append((i - mean) / std)
    for i in range(len(test)):
        out_rnn = rnn(np.array(rnn_y[i:i+seq_length]).reshape(1, seq_length)).reshape(-1)
        out_perceptron = perceptron(np.array(perceptron_y[i:i+seq_length]).reshape(1, seq_length)).reshape(-1)
        rnn_y.append(out_rnn[0])
        perceptron_y.append(out_perceptron[0])
    plt.plot(np.array(rnn_y[seq_length:]) * std + mean, label="Сеть Элмана")
    plt.plot(np.array(perceptron_y[seq_length:]) * std + mean, label="Персептрон")
    plt.plot(test, label="Настоящая температура")
    plt.legend()
    plt.grid()
    plt.show()


def create_nets(seq_length):

    rnn = nn.RNN(seq_length, 30, 1, 0.003)

    perceptron = nn.NN(0.003)
    perceptron.add_layer(seq_length, 30, "tanh")
    perceptron.add_layer(30, 1)

    return rnn, perceptron


if __name__ == "__main__":

    train = deserialize("train.txt")    
    test = deserialize("test.txt")
    mean = np.mean(train)
    std = np.std(train)

    seq_length = 30
    rnn, perceptron = create_nets(seq_length)
    
    flag = False
    k = 0
    while not flag:
        draw_menu()
        try:
            k = int(input("Введите номер пункта меню: "))
        except ValueError:
            pass
        print()
        
        if k == 1:
            menu_item_1(train)
        elif k == 2:
            train_nets(seq_length, train, rnn, perceptron, mean, std)
            print("\nОбучение завершено успешно.\a\n")
            menu_item_2(seq_length, train, test, rnn, perceptron, mean, std)
        elif k == 3:
            flag = True