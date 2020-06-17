import numpy as np


class LinearLayer:
    def __init__(self, input_number, output_number, activation="none", need_bias=False):
               
        self.weight = np.random.uniform(low=-np.sqrt(1 / input_number), 
            high=np.sqrt(1 / input_number), size=[input_number, output_number])
        
        self.need_bias = need_bias
        self.bias = 0
        if need_bias:
            self.bias = np.random.uniform(low=-np.sqrt(1 / input_number), 
                high=np.sqrt(1 / input_number), size=[1, output_number])
        
        self.activation = lambda x: x
        self.der_activation = lambda x: 1

        if activation == "tanh":
            self.activation = lambda x: np.tanh(x)
            self.der_activation = lambda x: 1 - self.activation(x) ** 2

    def forward(self, x, acc, mu):
        self.input = x
        self.mid = x @ (self.weight - mu * acc["weight"])
        if self.need_bias:
            self.mid += (self.bias - mu * acc["bias"])
        self.out = self.activation(self.mid)
        return self.out
    
    def backward(self, grad, acc, mu):
        dout = grad * self.der_activation(self.mid)
        self.dw = self.input.T @ dout
        if self.need_bias:
            self.db = (dout - mu * acc["bias"])
        dinp = dout @ (self.weight - mu * acc["weight"]).T
        return dinp


class NN:
    def __init__(self, lr=0.01, mu=0.85):
        self.lr = lr
        self.layers = []
        self.params = []
        self.optim = self.NAG     
        self.criterion = self.MSELoss

        self.out = 0

        self.mu = mu
        
    def add_layer(self, input_number, output_number, activation="none", need_bias=False):
        self.layers.append(LinearLayer(input_number, output_number, activation, need_bias))
        self.params.append({"accumulated": {"weight": 0, "bias": 0}})
    
    def forward(self, x):
        z = x
        for layer, param in zip(self.layers, self.params):
            z = layer.forward(z, param["accumulated"], self.mu)
        self.out = z
        return z
    
    def predict(self, x):
        z = x
        for layer in self.layers:
            z = layer.forward(z, {"weight": 0, "bias": 0}, 0)
        self.out = z
        return z

    def __call__(self, *args):
        return self.predict(*args)
    
    def backward(self, y):
        grad = self.criterion(y, True)
        for layer, param in zip(list(reversed(self.layers)), list(reversed(self.params))):
            grad = layer.backward(grad, param["accumulated"], self.mu)

    def MSELoss(self, y, der=False):
        if not der:
            return np.mean((self.out - y) ** 2)
        return self.out - y
    
    def update(self):
        for layer, param in zip(self.layers, self.params):
            self.optim(layer.weight, layer.dw, param)
            if layer.need_bias:
                self.optim(layer.bias, layer.db, param, "bias")

    def NAG(self, weight, dw, param, key="weight"):
        param["accumulated"][key] = self.mu * param["accumulated"][key] + self.lr * dw
        weight -= param["accumulated"][key]


class RBFNet:
    def __init__(self, hidden_number, sigma=1.0):
        self.hidden_number = hidden_number
        self.sigma = sigma
        self.centers = 0
        self.weights = 0

    def rbf(self, point, center):
        return np.exp(-np.linalg.norm((point - center) ** 2 / (2 * self.sigma ** 2)))

    def calculate_interpolation_matrix(self, x):
        g = np.zeros((len(x), self.hidden_number))
        for i, point in enumerate(x):
            for j, center in enumerate(self.centers):
                g[i, j] = self.rbf(point, center)
        return g

    def fit(self, x, y):
        self.centers = x[np.random.choice(len(x), self.hidden_number)]
        g = self.calculate_interpolation_matrix(x)
        inv_g = np.linalg.pinv(g)
        self.weights = inv_g @ y

    def predict(self, x):
        g = self.calculate_interpolation_matrix(x)
        return g @ self.weights


class RNN:
    def __init__(self, input_number, hidden_number, output_number, lr=0.01):
        self.lr = lr

        self.w_ih = np.random.uniform(-np.sqrt(1 / input_number), np.sqrt(1 / input_number), 
            size=[input_number, hidden_number])
        self.b_ih = np.random.uniform(size=[1, hidden_number])

        self.w_hh = np.random.uniform(-np.sqrt(1 / hidden_number), np.sqrt(1 / hidden_number), 
            size=[hidden_number, hidden_number])
        self.b_hh = np.random.uniform(size=[1, hidden_number])

        self.h = np.zeros(shape=[1, hidden_number])
        self.h_t_1 = np.zeros(shape=[1, hidden_number])

        self.w = np.random.uniform(-np.sqrt(1 / hidden_number), np.sqrt(1 / hidden_number), 
            size=[hidden_number, output_number])
        
    def forward(self, x):
        self.x = x
        self.h_t_1 = self.h
        self.h = self.x @ self.w_ih + self.b_ih + self.h_t_1 @ self.w_hh + self.b_hh
        self.h = np.tanh(self.h)
        self.out = self.h @ self.w
        return self.out
    
    def __call__(self, *args):
        return self.forward(*args)
    
    def backward(self, y):
        dloss = self.out - y
        self.dw = self.h.T @ dloss
        dh = dloss @ self.w.T
        grad = (1 - np.tanh(self.h) ** 2) * dh
        self.dw_ih = self.x.T @ grad
        self.db_ih = 1 * grad
        self.dw_hh = self.h_t_1.T @ grad
        self.db_hh = 1 * grad
        
    def update(self):
        self.w -= self.lr * self.dw
        self.w_ih -= self.lr * self.dw_ih
        self.b_ih -= self.lr * self.db_ih
        self.w_hh -= self.lr * self.dw_hh
        self.b_hh -= self.lr * self.db_hh
