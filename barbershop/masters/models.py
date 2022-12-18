from django.db import models
from django.urls import reverse
from django.core.validators import MaxValueValidator, MinValueValidator
from django.contrib.postgres.fields import ArrayField
from django import forms

class Master(models.Model):
    user = models.ForeignKey("users.CustomUser", on_delete=models.CASCADE, null=False)
    start_time = models.PositiveIntegerField(default=8, validators=[MinValueValidator(0), MaxValueValidator(24)])
    end_time = models.PositiveIntegerField(default=20, validators=[MinValueValidator(0), MaxValueValidator(24)])
    #begin_time = models.TimeField(auto_now=False, auto_now_add=False)

    photo1 = models.URLField(max_length=200, default="", null=True)
    photo2 = models.URLField(max_length=200, default="", null=True)
    photo3 = models.URLField(max_length=200, default="", null=True)
    description = models.TextField(default="", null=True)
    full_description = models.TextField(default="", null=True)

    def get_absolute_url(self):
        return reverse('master_detail', args=[str(self.id)])

    def __str__(self):
        return self.user.first_name
