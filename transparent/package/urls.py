from django.conf import settings
from django.conf.urls.static import static
from django.urls import path
from . import views

app_name = 'package'

urlpatterns = [
    path('', views.PackageListView.as_view(), name='list'),
    path('about/', views.aboutPageView, name='about'),
    path('create/', views.PackageCreateView.as_view(), name='create'),
    path('<int:pk>/', views.PackageDetailView.as_view(), name='detail'),
    path('edit/<int:pk>/', views.PackageEditView.as_view(), name='edit'),
    path('delete/<int:pk>/', views.PackageDeleteView.as_view(), name='delete')
]
