from django.contrib.auth.mixins import LoginRequiredMixin
from django.shortcuts import render
from django.urls import reverse_lazy
from django.views.generic import CreateView, DetailView, DeleteView, UpdateView
from django.views.generic.list import ListView

from .models import *
from .forms import *
from cart.forms import CartAddProductForm


def aboutPageView(request):
    return render(request, "about.html")


class PackageListView(ListView):
    model = Package
    template_name = "package_list.html"


class PackageCreateView(CreateView):
    form_class = CreateForm
    template_name = 'package_new.html'
    # fields = all_fields
    login_url = 'login'


class PackageDetailView(DetailView):
    model = Package
    form_shirt = CartAddProductForm()
    template_name = 'package_detail.html'
    fields = all_fields


class PackageDeleteView(DeleteView):
    model = Package
    template_name = 'package_delete.html'
    success_url = reverse_lazy('package:list')


class PackageEditView(UpdateView):
    model = Package
    form_class = EditForm
    template_name = 'package_edit.html'
    login_url = 'login'


def image_upload_view(request):
    if request.method == 'POST':
        form = ImageForm(request.POST, request.FILES)
        if form.is_valid():
            form.save()
            img_obj = form.instance
            return render(request, 'package_new.html', {'form': form, 'img_obj': img_obj})
    else:
        form = ImageForm()
    return render(request, 'package_new.html', {'form': form})

