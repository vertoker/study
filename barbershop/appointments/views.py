from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Appointment

active_fields = [
    'haircut', 'user', 'master', 'start_time'
]


class AppointmentListView(ListView):
    model = Appointment
    template_name = 'appointment_list.html'


class AppointmentDetailView(DetailView):
    model = Appointment
    template_name = 'appointment_detail.html'


class AppointmentCreateView(CreateView):
    model = Appointment
    template_name = 'appointment_new.html'
    fields = active_fields

    def form_valid(self, form):
        repair = form.save()
        form.instance.user = repair.user
        return super().form_valid(form)


class AppointmentUpdateView(UpdateView):
    model = Appointment
    template_name = 'appointment_edit.html'
    fields = active_fields


class AppointmentDeleteView(DeleteView):
    model = Appointment
    template_name = 'appointment_delete.html'
    success_url = reverse_lazy('appointment_list')