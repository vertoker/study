from django.utils.translation import gettext_lazy as _
from django.db import models
from django.urls import reverse
from django import forms

active_fields = ['title', 'price', 'image', 'type']


class Product(models.Model):

    class ProductType(models.TextChoices):
        COFFIN = 'CF', _('Гробы')
        WREATH = 'WR', _('Венки')
        CROSSES = 'CR', _('Кресты на могилу')
        MONUMENT = 'MN', _('Памятники на могилу')
        TEXTILE = 'TX', _('Текстиль')
        NONE = 'N', _('Пусто')

    title = models.CharField(max_length=250, verbose_name='Название товара')
    price = models.PositiveIntegerField(default=1000, verbose_name='Цена')
    image = models.ImageField(upload_to='Products', null=True, verbose_name='Изображение')
    type = models.CharField(max_length=2, choices=ProductType.choices, default=ProductType.NONE, verbose_name='Тип товара')

    def __str__(self):
        return self.title
