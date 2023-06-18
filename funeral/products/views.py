from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from django.shortcuts import render

from .forms import CreateForm, EditForm
from .models import *


class product_create(CreateView):
    form_class = CreateForm
    template_name = 'product_create.html'
    success_url = reverse_lazy('product:list')
    # fields = all_fields
    login_url = 'login'


class product_detail(DetailView):
    model = Product
    template_name = 'product_detail.html'
    fields = active_fields


class product_delete(DeleteView):
    model = Product
    template_name = 'product_delete.html'
    success_url = reverse_lazy('product:list')


class product_edit(UpdateView):
    model = Product
    form_class = EditForm
    template_name = 'product_edit.html'
    success_url = reverse_lazy('product:list')

def product_list(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter()})


def product_list_cf(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="CF")})


def product_list_wr(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="WR")})


def product_list_cr(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="CR")})


def product_list_mn(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="MN")})


def product_list_tx(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="TX")})


def product_list_n(request):
    return render(request, 'product_list.html', {'products': Product.objects.filter(type="N")})
