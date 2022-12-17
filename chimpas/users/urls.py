from django.urls import path
from . import views

urlpatterns = [
    path("signup/", views.SignUp.as_view(), name='signup'),
    path("<int:pk>/edit", views.UserUpdateView.as_view(), name='user_edit')
]