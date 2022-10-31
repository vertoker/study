from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Master

class MasterListView(ListView):
    model = Master
    template_name = 'master_list.html'

class MasterDetailView(DetailView):
    model = Master
    template_name = 'master_detail.html'

class MasterCreateView(CreateView):
    model = Master
    template_name = 'master_new.html'
    fields = ['user', 'start_time', 'end_time', 'begin_time', 'photo1', 'photo2', 'photo3', 'description']

class MasterUpdateView(UpdateView):
    model = Master
    template_name = 'master_edit.html'
    fields = ['user', 'start_time', 'end_time', 'begin_time', 'photo1', 'photo2', 'photo3', 'description']

class MasterDeleteView(DeleteView):
    model = Master
    template_name = 'master_delete.html'
    success_url = reverse_lazy('haircut_list')
