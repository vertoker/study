from django.contrib.auth.forms import UserCreationForm, UserChangeForm
from .models import *


class AdminCreationForm(UserCreationForm):
    class Meta(UserCreationForm.Meta):
        model = Admin
        fields = all_fields


class AdminChangeForm(UserChangeForm):
    class Meta:
        model = Admin
        fields = all_fields

