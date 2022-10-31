from django.db import models
from django.urls import reverse
from django.contrib.postgres.fields import ArrayField
from django import forms

#class Appointment(models.Model):
    #haircut = models.ForeignKey("haircuts.haircut", on_delete=models.PROTECT, null=True)
    #user = models.ForeignKey("users.user", on_delete=models.PROTECT, null=True)

    #def get_absolute_url(self):
        #return reverse('appointments_detail', args=[str(self.id)])