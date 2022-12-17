from decimal import Decimal
from django.conf import settings
from .models import *
from shirt.models import Shirts

class Cart(object):
    def __init__(self, request):

        self.session = request.session
        cart = self.session.get(settings.CART_SESSION_ID)
        if not cart:
            # save an empty cart in the session
            cart = self.session[settings.CART_SESSION_ID] = {}
        self.cart = cart

    def add(self, product, quantity=1, update_quantity=False):
        product_id = str(product.id)
        if product_id not in self.cart:
            self.cart[product_id] = {'quantity': 0, 'size': 'M',
                                     'price': str(product.price)}
        if update_quantity:
            self.cart[product_id]['quantity'] = quantity
        else:
            self.cart[product_id]['quantity'] += quantity
        self.save()

    def save(self):
        # Обновление сессии cart
        self.session[settings.CART_SESSION_ID] = self.cart
        # Отметить сеанс как "измененный", чтобы убедиться, что он сохранен
        self.session.modified = True

    def remove(self, product):
        product_id = str(product.id)
        if product_id in self.cart:
            del self.cart[product_id]
            self.save()

    def __iter__(self):
        product_ids = self.cart.keys()
        products = Shirts.objects.filter(id__in=product_ids)

        for product in products:
            self.cart[str(product.id)]['product'] = product

        for item in self.cart.values():
            # item['size'] = Decimal(item['size'])
            item['price'] = Decimal(item['price'])
            item['total_price'] = item['price'] * item['quantity']
            yield item

    def __len__(self):

        return sum(item['quantity'] for item in self.cart.values())

    def get_total_price(self):

        return sum(Decimal(item['price']) * item['quantity'] for item in
                   self.cart.values())

    def clear(self):
        # удаление корзины из сессии
        del self.session[settings.CART_SESSION_ID]
        self.session.modified = True

    def product_plus(self, product):

        product_id = str(product.id)
        if product_id in self.cart:
            self.cart[product_id]['quantity'] += 1
        self.save()

    def product_minus(self, product):
        product_id = str(product.id)
        if product_id in self.cart:
            if self.cart[product_id]['quantity'] <= 1:
                self.remove(product)
            else:
                self.cart[product_id]['quantity'] -= 1
        self.save()

    def size_plus(self, product):
        product_id = str(product.id)
        if product_id in self.cart:
            if sizes.index(self.cart[product_id]['size']) < len(sizes) - 1:
                self.cart[product_id]['size'] = sizes[sizes.index(self.cart[product_id]['size']) + 1]
        self.save()

    def size_minus(self, product):
        product_id = str(product.id)
        if product_id in self.cart:
            if sizes.index(self.cart[product_id]['size']) > 0:
                self.cart[product_id]['size'] = sizes[sizes.index(self.cart[product_id]['size']) - 1]
        self.save()

    def clear(self):
        del self.session[settings.CART_SESSION_ID]
        self.session.modified = True
