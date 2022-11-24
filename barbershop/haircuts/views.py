from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Haircut
from .forms import NewHaircut

active_fields = [
    'title', 'image1', 'image2',
    'image3', 'image4', 'image5',
    'time_execution', 'description',
    'full_description', 'price', 'old_price'
]

class HaircutListView(ListView):
    model = Haircut
    template_name = 'haircut_list.html'

class HaircutDetailView(DetailView):
    model = Haircut
    template_name = 'haircut_detail.html'

class HaircutCreateView(CreateView):
    form_class = NewHaircut
    template_name = 'haircut_new.html'

class HaircutUpdateView(UpdateView):
    model = Haircut
    template_name = 'haircut_edit.html'
    fields = active_fields

class HaircutDeleteView(DeleteView):
    model = Haircut
    template_name = 'haircut_delete.html'
    success_url = reverse_lazy('haircut_list')
