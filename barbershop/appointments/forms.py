from django import forms


class AppointmentCreateForm(forms.Form):
    user = forms.CharField(max_length=100)
