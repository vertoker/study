from django.db import models
from django.urls import reverse

all_fields = ['title', 'description', 'size', 'thickness', 'quantity', 'price', 'type', 'image']


class Package(models.Model):
    image = models.ImageField(upload_to='Package', verbose_name='Изображение')
    title = models.CharField(max_length=100, default='')
    description = models.TextField(max_length=1000, blank=True, null=True)
    size = models.CharField(max_length=30, default='')
    thickness = models.PositiveIntegerField()
    quantity = models.PositiveIntegerField()
    price = models.PositiveIntegerField()
    type = models.CharField(max_length=100, default='')

    def __str__(self):
        return self.title

    def get_absolute_url(self):
        return reverse('package:list')
