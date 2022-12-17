from django.shortcuts import render, redirect, get_object_or_404
from django.views.decorators.http import require_POST
from shirt.models import Shirts
from .cart import Cart
from .forms import CartAddProductForm


#@require_POST
def cart_add(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    #form = CartAddProductForm(request.POST)
    #if form.is_valid():
        #cd = form.cleaned_data
    cart.add(product=product, quantity=1, update_quantity=1)
    return redirect('orders:order_create')


def cart_remove(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    cart.remove(product)
    return redirect('orders:order_create')


def cart_detail(request):
    cart = Cart(request)
    return render(request, 'order_create.html', {'cart': cart})


def cart_plus_product(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    cart.product_plus(product)
    return redirect('orders:order_create')


def cart_minus_product(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    cart.product_minus(product)
    return redirect('orders:order_create')


def cart_plus_size(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    cart.size_plus(product)
    return redirect('orders:order_create')


def cart_minus_size(request, id):
    cart = Cart(request)
    product = get_object_or_404(Shirts, id=id)
    cart.size_minus(product)
    return redirect('orders:order_create')

