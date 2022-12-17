from django.contrib.auth.models import AbstractUser
from django.db import models
from django.urls import reverse

all_fields = [
    "username","email", "address", "gender"
]


class CustomUser(AbstractUser):
    GENDER_CHOICES = (
            ('M', 'Male'),
            ('F', 'Female'),
            ('O', 'Other'),
        )

    address = models.TextField(max_length=250, null=True)
    gender = models.CharField(max_length=1, choices=GENDER_CHOICES)


    def get_absolute_url(self):
        return reverse('user_edit', args=[str(self.pk)])

    def __str__(self):
        return self.first_name + " " + self.last_name
