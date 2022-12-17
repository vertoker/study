from .models import *
from .forms import OrderCreateForm
from cart.cart import Cart
from .models import Shirts
from . import models
from .order import *

from django.http import HttpResponseRedirect
from django.urls import reverse_lazy
from django.views.generic import CreateView, DetailView, DeleteView, UpdateView
from django.views.generic.list import ListView
from django.http import HttpRequest
from django.shortcuts import render


class OrderCreateView(CreateView):
    #form_class = OrderCreateForm
    model = Order
    fields = []
    template_name = "order_create.html"
    success_url = "order_list.html"

    def form_valid(self, form):
        cart = Cart(self.request)
        new_order = form.save()
        order = Order.objects.get(id=new_order.pk)
        order.user = self.request.user

        price = 0
        quantity = 0
        count = 0

        quantities = ''
        products = ''
        sizes = ''

        for item in cart:
            product_in_cart = item.get('product')
            print('===================', product_in_cart)
            quantity += item.get('quantity')
            price += item.get('price') * item.get('quantity')
            if count == 0:
                quantities += str(item.get('quantity'))
                products += str(product_in_cart.pk)
                sizes += str(item.get('size'))
            else:
                quantities += ' ' + str(item.get('quantity'))
                products += ' ' + str(product_in_cart.pk)
                sizes += ' ' + str(item.get('size'))
            count += 1

        print('===================', quantities)
        print('===================', products)
        print('===================', sizes)
        print('===================', count)
        order.products = products
        order.quantity = quantities
        order.sizes = sizes
        order.total_quantity = quantity
        order.total_price = price
        order.address = "123"
        order.save()
        cart.clear()

        return HttpResponseRedirect(reverse_lazy('orders:order_detail', kwargs={'pk': new_order.pk}))

    def get(self, request):
        cart = Cart(request)
        return render(request, 'order_create.html', {'cart': cart})
        # return HttpResponseRedirect(reverse_lazy('orders:order_create', kwargs={'cart': cart}))


def order_list(request):
    orders = Order.objects.filter(user=request.user)
    products_value = []
    print('orders', orders)
    for order in orders:
        quantities = order.quantity.split(' ')
        products = order.products.split(' ')
        sizes = order.sizes.split(' ')
        count = len(order.products)
        print('count', count)
        #for i in range(count):
            #product = Shirts.objects.filter(id=int(products[i]))[0]
            #print('product', product)
            #products_value.append([order.products[i], quantities[i]])
            #print('products', products_value)

    #print('products', products)
    return render(request, 'order_list.html', {'orders': orders})


def order_detail(request, pk):
    order = Order.objects.filter(id=pk)[0]
    products_value = []
    print('order', order)

    quantities = order.quantity.split(' ')
    products = order.products.split(' ')
    sizes = order.sizes.split(' ')

    count = len(order.products) - 1
    if count == 0:
        count = 1
    print('count', count)

    for i in range(count):
        product = Shirts.objects.filter(id=int(products[i]))[0]
        products_value.append(ProductFull(product, int(quantities[i]), sizes[i]))
        print('products', products)

    print('products', products_value)
    return render(request, 'order_detail.html', {'order': order, 'products': products_value})


class OrderListView(ListView):
    model = models.Order
    template_name = "order_list.html"


class OrderDetailView(DetailView):
    model = models.Order
    template_name = 'order_detail.html'
    fields = all_fields


class OrderDeleteView(DeleteView):
    model = Order
    template_name = 'order_delete.html'
    success_url = reverse_lazy('orders:order_list')
