from django.urls import reverse_lazy
from django.views import generic
from django.views.generic.edit import UpdateView
from .forms import *
from .models import *


class SignUp(generic.CreateView):
    form_class = AdminCreationForm
    success_url = reverse_lazy('admin:home')
    template_name = 'signup.html'


class AdminUpdateView(UpdateView):
    model = Admin
    template_name = 'admin_edit.html'
    success_url = reverse_lazy('admin:home')
    fields = all_fields
