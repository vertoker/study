from django import forms
from .models import Appointment

active_fields = ('haircut', 'user', 'master', 'entry_time')


class NewAppointment(forms.ModelForm):
    class Meta:
        model = Appointment
        widgets = {
            "haircut": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "user": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "master": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "entry_time": forms.TextInput(attrs={'class': 'form-control rounded 3', 'type': 'datetime-local'})
        }
        fields = active_fields


class EditAppointment(forms.ModelForm):
    class Meta:
        model = Appointment
        widgets = {
            "haircut": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "user": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "master": forms.Select(attrs={'class': 'form-control rounded 3'}),
            "entry_time": forms.TextInput(attrs={'class': 'form-control rounded 3', 'type': 'datetime-local'})
        }
        fields = active_fields
