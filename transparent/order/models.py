from user.models import CustomUser
from django.conf import settings
from django.contrib.auth.models import User
from django.db import models
from django.db.models import CASCADE

admin_fields = ['user', 'address', 'created', 'products', 'count_products',
                'quantities', 'total_price', 'total_quantity', 'total_quantity_units']
all_fields = ['user', 'address', 'created', 'products', 'count_products',
              'quantities', 'total_price', 'total_quantity', 'total_quantity_units']
form_fields = []


class Order(models.Model):
    user = models.ForeignKey("user.CustomUser", on_delete=models.DO_NOTHING, null=True)
    address = models.CharField(max_length=500, verbose_name='Адрес', null=True)
    created = models.DateTimeField(auto_now_add=True)

    count_products = models.PositiveIntegerField(null=True)
    products = models.CharField(max_length=500, verbose_name='Продукты', null=True)
    quantities = models.CharField(max_length=500, verbose_name='Количества', null=True)
    prices = models.CharField(max_length=500, verbose_name='Цены', null=True)
    total_quantity = models.PositiveIntegerField(null=True)
    total_quantity_units = models.PositiveIntegerField(null=True)
    total_price = models.PositiveIntegerField(null=True)

    class Meta:
        ordering = ('-created',)
        verbose_name = 'Заказ'
        verbose_name_plural = 'Заказы'

    def __str__(self):
        return 'Order {}'.format(self.id)
