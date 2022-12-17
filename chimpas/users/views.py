from django.urls import reverse_lazy
from django.views import generic
from django.views.generic.edit import UpdateView
from .forms import CustomUserCreationForm
from .models import *

class SignUp(generic.CreateView):
    form_class = CustomUserCreationForm
    success_url = reverse_lazy('login')
    template_name = 'signup.html'

class UserUpdateView(UpdateView):
    model = CustomUser
    template_name = 'user_edit.html'
    success_url = reverse_lazy('home')
    fields = all_fields
