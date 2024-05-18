from django import forms
from .models import *


class ImageForm(forms.ModelForm):
    class Meta:
        model = Package
        fields = all_fields


class CreateForm(forms.ModelForm):
    class Meta:
        model = Package
        fields = all_fields
        widgets = {
            'title': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'description': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'size': forms.NumberInput(attrs={'class': 'form-control rounded 3'},),
            'thickness': forms.NumberInput(attrs={'class': 'form-control rounded 3',
                                             'min': '1', 'step': '1'}),
            'quantity': forms.NumberInput(attrs={'class': 'form-control rounded 3',
                                             'min': '1', 'step': '1'}),
            'price': forms.NumberInput(attrs={'class': 'form-control rounded 3',
                                             'min': '1', 'step': '1'}),
            'type': forms.TextInput(attrs={'class': 'form-control rounded 3'})
        }


class EditForm(forms.ModelForm):
    class Meta:
        model = Package
        fields = all_fields
        widgets = {
            'title': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'description': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'size': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'thickness': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'quantity': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'price': forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            'type': forms.TextInput(attrs={'class': 'form-control rounded 3'})
        }
