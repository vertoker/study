from django import forms
from .models import Cart


class CartAddProductForm(forms.Form):
    quantity = forms.IntegerField(min_value=1, label='Количество', widget=forms.NumberInput(attrs={'class': 'input_class'}))
    update = forms.BooleanField(required=False, initial=False, widget=forms.HiddenInput)

    class Meta:
        model = Cart
