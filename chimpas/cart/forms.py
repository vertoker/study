from django import forms
from .models import Cart


class CartAddProductForm(forms.Form):
    # sizes_field = forms.CharField(max_length=5, choices=sizes, verbose_name='Размер')
    quantity = forms.IntegerField(min_value=1, label='Количество',
                                  widget=forms.NumberInput(attrs={'class': 'input_class'}))
    size = forms.IntegerField(max_value=1, label='Размер',
                              widget=forms.NumberInput(attrs={'class': 'input_class'}))
    update = forms.BooleanField(required=False, initial=False, widget=forms.HiddenInput)

    class Meta:
        model = Cart
