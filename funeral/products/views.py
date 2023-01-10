from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from django.shortcuts import render
from .models import *

active_fields = [
    'title', 'article', 'price', 'image', 'type'
]


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
