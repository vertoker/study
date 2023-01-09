from django.urls import path
from . import views

app_name = 'base'

urlpatterns = [
    path("", views.HomeView.as_view(), name='home'),
    path("about/", views.AboutView.as_view(), name='about'),
    path("funeral/arrangements/", views.FuneralArrangementsView.as_view(), name='funeral_arrangements'),
    path("funeral/cremation/", views.FuneralCremationView.as_view(), name='funeral_cremation'),
    path("funeral/inlife/", views.FuneralInlifeView.as_view(), name='funeral_inlife'),
    path("if-close-man-dead/", views.IfCloseManDeadView.as_view(), name='if_close_man_dead'),
    path("registration-documents/", views.RegistrationDocumentsView.as_view(), name='registration_documents'),
    path("infrastructure/", views.InfrastructureView.as_view(), name='infrastructure'),
]