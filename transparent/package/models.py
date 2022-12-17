from django.db import models
from django.urls import reverse

all_fields = ['title', 'description', 'size_width', 'size_heigth', 'thickness', 'quantity', 'price', 'type', 'image']


class Package(models.Model):
    image = models.ImageField(upload_to='Shirts', null=True, verbose_name='Изображение')
    title = models.CharField(max_length=100, default='none')
    description = models.TextField(max_length=1000, blank=True, null=True)
    size_width = models.PositiveIntegerField()
    size_heigth = models.PositiveIntegerField()
    thickness = models.PositiveIntegerField()
    quantity = models.PositiveIntegerField()
    price = models.PositiveIntegerField()
    type = models.CharField(max_length=100, default='none')

    def __str__(self):
        return self.title

    def get_absolute_url(self):
        return reverse('')
