from django.contrib.auth.models import AbstractUser
from django.db import models

class CustomUser(AbstractUser):
    GENDER_CHOICES = (
            ('M', 'Male'),
            ('F', 'Female'),
            ('O', 'Other'),
        )

    age = models.PositiveIntegerField(default=18)
    gender = models.CharField(max_length=1, choices=GENDER_CHOICES)
