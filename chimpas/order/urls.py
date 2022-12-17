from django.conf import settings
from django.conf.urls.static import static
from django.urls import path
from . import views

app_name = 'orders'

urlpatterns = [
    path('', views.order_list, name='order_list'),
    path('create/', views.OrderCreateView.as_view(), name='order_create'),
    path('<int:pk>/', views.order_detail, name='order_detail'),
    path('delete/<int:pk>/', views.OrderDeleteView.as_view(), name='order_delete')
]
