from django.db import models
from django.urls import reverse

sizes = ['XS', 'S', 'M', 'L', 'XL', 'XXL']


class Shirts(models.Model):
    name = models.CharField(max_length=100, default='none')
    description = models.TextField(max_length=500, blank=True, null=True)
    price = models.PositiveIntegerField()
    # size = models.IntegerField(null=False, blank=False)
    image = models.ImageField(upload_to='Shirts', null=True, verbose_name='Изображение')
    # sizes_field = models.CharField(unique=False, max_length=5, null=True, choices=sizes, verbose_name='Размер')

    def __str__(self):
        return self.name

    def get_absolute_url(self):
        return reverse('home')
