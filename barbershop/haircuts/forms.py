from django import forms
from .models import Haircut

active_fields = [
    'title', 'image1', 'image2',
    'image3', 'image4', 'image5',
    'time_execution', 'description',
    'full_description', 'price', 'old_price'
]


class NewHaircut(forms.ModelForm):
    class Meta:
        model = Haircut
        widgets = {
            "title": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "image1": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "image2": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "image3": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "image4": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "image5": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "time_execution": forms.NumberInput(attrs={'class': 'form-control rounded 3'}),
            "description": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "full_description": forms.TextInput(attrs={'class': 'form-control rounded 3'}),
            "price": forms.NumberInput(attrs={'class': 'form-control rounded 3'}),
            "old_price": forms.NumberInput(attrs={'class': 'form-control rounded 3'})
        }
        fields = active_fields
