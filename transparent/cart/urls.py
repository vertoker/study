from django.urls import path
from . import views

app_name = 'cart'

urlpatterns = [
    path('cart_add/<int:id>/', views.cart_add, name='cart_add'),
    path('cart_remove/<int:id>/', views.cart_remove, name='cart_remove'),
    path('product-plus/<int:id>/', views.cart_plus_product, name='cart_plus_product'),
    path('product-minus/<int:id>/', views.cart_minus_product, name='cart_minus_product')
]