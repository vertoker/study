from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.AppointmentListView.as_view(), name='appointment_list'),
    path('<int:pk>/', views.AppointmentDetailView.as_view(), name='appointment_detail'),
    path('new/', views.AppointmentCreateView.as_view(), name='appointment_new'),
    path('new/ms=<int:ms>&hc=<int:hc>', views.AppointmentCreateView.as_view(), name='appointment_new_params'),
    path('<int:pk>/edit', views.AppointmentUpdateView.as_view(), name='appointment_edit'),
    path('<int:pk>/delete', views.AppointmentDeleteView.as_view(), name='appointment_delete')
]
