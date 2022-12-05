from django.db import models
from django.urls import reverse
from django.conf import settings
from django.contrib.postgres.fields import ArrayField
from django import forms


class Appointment(models.Model):
    user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE, null=True)
    haircut = models.ForeignKey("haircuts.haircut", on_delete=models.PROTECT, null=True)
    master = models.ForeignKey("masters.Master", on_delete=models.PROTECT, null=True)
    entry_date = models.DateField(auto_now=False, auto_now_add=False)
    entry_time = models.TimeField(auto_now=False, auto_now_add=False)

    def get_absolute_url(self):
        return reverse('appointment_detail', args=[str(self.pk)])