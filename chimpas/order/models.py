from users.models import CustomUser
from django.conf import settings
from django.contrib.auth.models import User
from django.db import models
from django.db.models import CASCADE
from shirt.models import Shirts

admin_fields = ['user', 'address', 'created', 'quantity', 'products', 'total_price', 'total_quantity']
all_fields = ['products', 'user', 'address', 'created', 'quantity', 'total_price', 'total_quantity']
form_fields = ['address']


class Order(models.Model):
    ORD_STATUS = [
        ('Обработка заказа', 'В обработке'),
        ('Сборка заказа', 'Сборка'),
        ('Заказ готов', 'Заказ готов'),
        ('Заказ завершен', 'Заказ завершен'),
        ('Заказ отменен', 'Заказ отменен')
    ]

    products = models.CharField(max_length=500, verbose_name='Продукты', null=True)
    quantity = models.CharField(max_length=500, verbose_name='Количества', null=True)
    sizes = models.CharField(max_length=500, verbose_name='Размеры', null=True)
    total_quantity = models.PositiveIntegerField(null=True)
    total_price = models.PositiveIntegerField(null=True)

    user = models.ForeignKey("users.CustomUser", on_delete=models.DO_NOTHING, null=True)
    address = models.CharField(max_length=250)
    created = models.DateTimeField(auto_now_add=True)
    # paid = models.BooleanField(default=False)
    # status = models.CharField("status", choices=ORD_STATUS, default='Обработка заказа', max_length=17)

    class Meta:
        ordering = ('-created',)
        verbose_name = 'Заказ'
        verbose_name_plural = 'Заказы'

    def __str__(self):
        return 'Order {}'.format(self.id)
