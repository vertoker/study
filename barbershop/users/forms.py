from django import forms
from django.contrib.auth.forms import UserCreationForm, UserChangeForm
from .models import CustomUser


class CustomUserCreationForm(UserCreationForm):
    class Meta(UserCreationForm.Meta):
        model = CustomUser
        widgets = {
            'first_name': forms.TextInput(attrs={'class': 'textinput textInput form-control is-invalid', 'pattern': '[a-zA-Zа-яА-Я]+'}),
            'last_name': forms.TextInput(attrs={'class': 'textinput textInput form-control is-invalid', 'pattern': '[a-zA-Zа-яА-Я]+'}),
            'patronymic': forms.TextInput(attrs={'class': 'textinput textInput form-control is-invalid', 'pattern': '[a-zA-Zа-яА-Я]+'})
        }
        fields = ("username", "first_name", "last_name", "patronymic", "age", "gender")


class CustomUserChangeForm(UserChangeForm):
    class Meta:
        model = CustomUser
        fields = ("username", "first_name", "last_name", "patronymic", "age", "gender")
