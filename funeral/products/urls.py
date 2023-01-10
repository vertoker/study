from django.urls import path
from . import views

app_name = 'product'

urlpatterns = [
    path("list/", views.product_list, name='list'),
    path("list/CF/", views.product_list_cf, name='list_CF'),
    path("list/WR/", views.product_list_wr, name='list_WR'),
    path("list/CR/", views.product_list_cr, name='list_CR'),
    path("list/MN/", views.product_list_mn, name='list_MN'),
    path("list/TX/", views.product_list_tx, name='list_TX'),
    path("list/N/", views.product_list_n, name='list_N'),
]