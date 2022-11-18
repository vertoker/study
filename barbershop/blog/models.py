from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms


class Article(models.Model):
    title = models.CharField(max_length=200)
    description = models.TextField(default=None)
    article = models.TextField(default=None)

    def get_absolute_url(self):
        return reverse('haircut_detail', args=[str(self.id)])

    def __str__(self):
        return self.title
