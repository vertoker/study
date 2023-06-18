from django.urls import path
from . import views

app_name = 'product'

urlpatterns = [
    path('<int:pk>/', views.product_detail.as_view(), name='detail'),
    path('create/', views.product_create.as_view(), name='create'),
    path('delete/<int:pk>/', views.product_delete.as_view(), name='delete'),
    path('edit/<int:pk>/', views.product_edit.as_view(), name='edit'),
    path("list/", views.product_list, name='list'),
    path("list/CF/", views.product_list_cf, name='list_CF'),
    path("list/WR/", views.product_list_wr, name='list_WR'),
    path("list/CR/", views.product_list_cr, name='list_CR'),
    path("list/MN/", views.product_list_mn, name='list_MN'),
    path("list/TX/", views.product_list_tx, name='list_TX'),
    path("list/N/", views.product_list_n, name='list_N'),
]