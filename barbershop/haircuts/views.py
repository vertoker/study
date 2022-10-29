from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Haircut

class HaircutListView(ListView):
    model = Haircut
    template_name = 'haircut_list.html'

class HaircutDetailView(DetailView):
    model = Haircut
    template_name = 'haircut_detail.html'

class HaircutCreateView(CreateView):
    model = Haircut
    template_name = 'haircut_new.html'
    fields = ['title', 'image1', 'image2', 'image3', 'image4', 'image5', 'description', 'full_description', 'price', 'old_price']

class HaircutUpdateView(UpdateView):
    model = Haircut
    template_name = 'haircut_edit.html'
    fields = ['title', 'image1', 'image2', 'image3', 'image4', 'image5', 'description', 'full_description', 'price', 'old_price']

class HaircutDeleteView(DeleteView):
    model = Haircut
    template_name = 'haircut_delete.html'
    success_url = reverse_lazy('haircut_list')
