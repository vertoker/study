class ProductFull:
    def __init__(self, product, quantity, size):
        self.product = product
        self.quantity = quantity
        self.price = product.price
        self.size = size
        self.total_price = quantity * self.price
