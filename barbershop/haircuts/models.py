from django.db import models
from django.urls import reverse

class Haircut(models.Model):
    title = models.CharField(max_length=200)
    image = models.URLField(max_length=200)
    description = models.TextField()

    def get_absolute_url(self):
        return reverse('haircut_detail', args=[str(self.id)])

    def __str__(self):
        return self.title