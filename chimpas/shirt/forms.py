from django import forms
from .models import Shirts

class ImageForm(forms.ModelForm):
    class Meta:
        model = Shirts
        fields = ('__all__')