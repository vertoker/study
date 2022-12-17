from django.contrib.auth.models import AbstractUser
from django.db import models
from django.urls import reverse

all_fields = [
    "username", "email", "address"
]


class CustomUser(AbstractUser):
    address = models.TextField(max_length=250, null=True)

    def get_absolute_url(self):
        return reverse('user_edit', args=[str(self.pk)])

    def __str__(self):
        return self.first_name + " " + self.last_name
