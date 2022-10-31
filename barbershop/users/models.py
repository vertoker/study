from django.contrib.auth.models import AbstractUser
from django.db import models
from django.urls import reverse

class CustomUser(AbstractUser):
    GENDER_CHOICES = (
            ('M', 'Male'),
            ('F', 'Female'),
            ('O', 'Other'),
        )

    age = models.PositiveIntegerField(default=18)
    gender = models.CharField(max_length=1, choices=GENDER_CHOICES)
    first_name = models.CharField(max_length=50, default=None)
    last_name = models.CharField(max_length=50, default=None)
    patronymic = models.CharField(max_length=50, default=None)

    def get_absolute_url(self):
        return reverse('user_edit', args=[str(self.pk)])
