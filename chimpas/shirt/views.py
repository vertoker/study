from django.contrib.auth.mixins import LoginRequiredMixin
from django.shortcuts import render
from django.urls import reverse_lazy
from django.views.generic import CreateView, DetailView, DeleteView, UpdateView
from django.views.generic.list import ListView

from . import models
from .forms import ImageForm
from cart.forms import CartAddProductForm


def homePageView(request):
    return render(request, "home.html")


def aboutPageView(request):
    return render(request, "about.html")


def delieveryPageView(request):
    return render(request, "contacts.html")


class ShirtListView(ListView):
    model = models.Shirts
    template_name = "home.html"


class ShirtCreateView(LoginRequiredMixin, CreateView):
    model = models.Shirts
    template_name = 'shirt_new.html'
    fields = ['name', 'price', 'image', 'description']
    login_url = 'login'

    def form_valid(self, form):
        form.instance.author = self.request.user
        return super().form_valid(form)


class ShirtDetailView(DetailView):
    model = models.Shirts
    form_shirt = CartAddProductForm()
    template_name = 'shirt_detail.html'
    fields = ['name', 'price', 'image']


class ShirtDeleteView(DeleteView):
    model = models.Shirts
    template_name = 'shirt_delete.html'
    success_url = reverse_lazy('home')


class ShirtEditView(UpdateView):
    model = models.Shirts
    template_name = 'shirt_edit.html'
    fields = ['name', 'price', 'image', 'description']


def image_upload_view(request):
    if request.method == 'POST':
        form = ImageForm(request.POST, request.FILES)
        if form.is_valid():
            form.save()
            img_obj = form.instance
            return render(request, 'shirt_new.html', {'form': form, 'img_obj': img_obj})
    else:
        form = ImageForm()
    return render(request, 'shirt_new.html', {'form': form})

