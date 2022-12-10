from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Appointment
from .forms import NewAppointment, EditAppointment

active_fields = [
    'haircut', 'user', 'master', 'entry_date', 'entry_time'
]


class AppointmentListView(ListView):
    model = Appointment
    template_name = 'appointment_list.html'


class AppointmentDetailView(DetailView):
    model = Appointment
    template_name = 'appointment_detail.html'


class AppointmentCreateView(CreateView):
    form_class = NewAppointment
    template_name = 'appointment_new.html'

    def get_success_url(self):
        return reverse_lazy('appointment_detail', kwargs={'pk': self.get_context_data()['appointment'].pk})

    def form_valid(self, form):
        #form.instance.user_id = self.request.user
        return super(AppointmentCreateView, self).form_valid(form)


class AppointmentUpdateView(UpdateView):
    model = Appointment
    form_class = EditAppointment
    template_name = 'appointment_edit.html'
    success_url = reverse_lazy('appointment_list')


class AppointmentDeleteView(DeleteView):
    model = Appointment
    template_name = 'appointment_delete.html'
    success_url = reverse_lazy('appointment_list')