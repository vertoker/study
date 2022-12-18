from django.shortcuts import render, redirect, get_object_or_404
from django.views.decorators.http import require_POST
from package.models import Package
from .cart import Cart
from .forms import CartAddProductForm


#@require_POST
def cart_add(request, id):
    cart = Cart(request)
    product = get_object_or_404(Package, id=id)
    cart.add(product=product, quantity=1, update_quantity=1)
    return redirect('order:create')


def cart_remove(request, id):
    cart = Cart(request)
    product = get_object_or_404(Package, id=id)
    cart.remove(product)
    return redirect('order:create')


def cart_detail(request):
    cart = Cart(request)
    return render(request, 'order_create.html', {'cart': cart})


def cart_plus_product(request, id):
    cart = Cart(request)
    product = get_object_or_404(Package, id=id)
    cart.product_plus(product)
    return redirect('order:create')


def cart_minus_product(request, id):
    cart = Cart(request)
    product = get_object_or_404(Package, id=id)
    cart.product_minus(product)
    return redirect('order:create')
