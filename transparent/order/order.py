class ProductFull:
    def __init__(self, product, quantity):
        self.product = product
        self.quantity = quantity
        self.price = product.price
        self.total_price = quantity * self.price
