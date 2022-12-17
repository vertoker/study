from django import forms
from django.contrib.auth.forms import UserCreationForm, UserChangeForm
from .models import *


class CustomUserCreationForm(UserCreationForm):
    class Meta(UserCreationForm.Meta):
        model = CustomUser
        fields = all_fields


class CustomUserChangeForm(UserChangeForm):
    class Meta:
        model = CustomUser
        fields = all_fields
