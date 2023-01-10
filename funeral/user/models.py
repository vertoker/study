from django.contrib.auth.models import AbstractUser
from django.db import models
from django.urls import reverse

all_fields = [
    "username", "first_name", "last_name", "patronymic"
]


class CustomUser(AbstractUser):
    first_name = models.TextField(max_length=250, null=True, verbose_name='Имя')
    last_name = models.TextField(max_length=250, null=True, verbose_name='Фамилия')
    patronymic = models.TextField(max_length=250, null=True, verbose_name='Отчество')

    def get_absolute_url(self):
        return reverse('edit', args=[str(self.pk)])
