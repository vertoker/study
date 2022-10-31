from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms

class Master(models.Model):
    user = models.ForeignKey("users.User", on_delete=models.PROTECT, null=True)
    start_time = models.TimeField(auto_now=False, auto_now_add=False)
    end_time = models.TimeField(auto_now=False, auto_now_add=False)

    def get_absolute_url(self):
        return reverse('appointments_detail', args=[str(self.id)])