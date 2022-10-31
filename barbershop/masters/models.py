from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms

class Master(models.Model):
    user = models.ForeignKey("users.CustomUser", on_delete=models.PROTECT, null=True)
    start_time = models.TimeField(auto_now=False, auto_now_add=False)
    end_time = models.TimeField(auto_now=False, auto_now_add=False)
    begin_time = models.TimeField(auto_now=False, auto_now_add=False)

    photo1 = models.URLField(max_length=200, default=None)
    photo2 = models.URLField(max_length=200, default=None)
    photo3 = models.URLField(max_length=200, default=None)
    description = models.TextField(default=None)

    def get_absolute_url(self):
        return reverse('master_detail', args=[str(self.id)])