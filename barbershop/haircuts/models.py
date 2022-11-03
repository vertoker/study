from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms


class Haircut(models.Model):
    title = models.CharField(max_length=200)

    image1 = models.URLField(max_length=200, default=None)
    image2 = models.URLField(max_length=200, default=None)
    image3 = models.URLField(max_length=200, default=None)
    image4 = models.URLField(max_length=200, default=None)
    image5 = models.URLField(max_length=200, default=None)

    # В минутах
    time_execution = models.PositiveIntegerField()
    description = models.TextField(default=None)
    full_description = models.TextField(default=None)
    price = models.PositiveIntegerField()
    old_price = models.PositiveIntegerField(default=None)

    def get_absolute_url(self):
        return reverse('haircut_detail', args=[str(self.id)])

    def __str__(self):
        return self.title
