from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import *

active_fields = [
    'title', 'article', 'price', 'image', 'type'
]


class ProductListView(ListView):
    model = Product
    template_name = 'product_list.html'


class HaircutDetailView(DetailView):
    model = Product
    template_name = 'haircut_detail.html'


class HaircutCreateView(CreateView):
    model = Product
    template_name = 'Product.html'


class HaircutUpdateView(UpdateView):
    model = Product
    template_name = 'haircut_edit.html'
    fields = active_fields


class HaircutDeleteView(DeleteView):
    model = Product
    template_name = 'haircut_delete.html'
    success_url = reverse_lazy('haircut_list')
