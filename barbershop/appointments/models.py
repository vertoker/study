from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms

class Appointment(models.Model):
    haircut = models.ForeignKey("haircuts.haircut", on_delete=models.PROTECT, null=True)
    user = models.ForeignKey("users.CustomUser", on_delete=models.PROTECT, null=True)
    master = models.ForeignKey("masters.Master", on_delete=models.PROTECT, null=True)
    start_time = models.TimeField(auto_now=False, auto_now_add=False)

    def get_absolute_url(self):
        return reverse('appointment_detail', args=[str(self.id)])