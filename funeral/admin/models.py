from django.contrib.auth.models import AbstractUser
from django.db import models
from django.urls import reverse

all_fields = [
    "username", "first_name", "last_name", "patronymic"
]


class Admin(AbstractUser):
    first_name = models.TextField(max_length=250, null=True)
    last_name = models.TextField(max_length=250, null=True)
    patronymic = models.TextField(max_length=250, null=True)

    def get_absolute_url(self):
        return reverse('admin_edit', args=[str(self.pk)])
