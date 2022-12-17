from django.conf import settings
from django.conf.urls.static import static
from django.urls import path
from . import views

app_name = 'order'

urlpatterns = [
    path('', views.order_list, name='list'),
    path('create/', views.OrderCreateView.as_view(), name='create'),
    path('<int:pk>/', views.order_detail, name='detail')
]
