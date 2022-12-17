from django.urls import path, include
from . import views
from shirt.views import ShirtListView

urlpatterns = [
    path("", ShirtListView.as_view(), name='home'),
    path("about/", views.AboutUsView.as_view(), name='about'),
    path('contacts/', views.DeliveryView.as_view(), name='contacts'),

]