from .models import *
from .forms import OrderCreateForm
from cart.cart import Cart
from package.models import *
from .models import *
from .order import *

from django.http import HttpResponseRedirect
from django.urls import reverse_lazy
from django.views.generic import CreateView, DetailView, DeleteView, UpdateView
from django.views.generic.list import ListView
from django.http import HttpRequest
from django.shortcuts import render


class OrderCreateView(CreateView):
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
        quantity_units = 0
        count = 0

        quantities = ''
        products = ''

        for item in cart:
            product_in_cart = item.get('product')
            print('===================', product_in_cart)
            quantity += item.get('quantity')
            quantity_units += item.get('quantity') * item.get('quantity_package')
            price += item.get('price') * item.get('quantity')
            if count == 0:
                quantities += str(item.get('quantity'))
                products += str(product_in_cart.pk)
            else:
                quantities += ' ' + str(item.get('quantity'))
                products += ' ' + str(product_in_cart.pk)
            count += 1

        print('===================', quantities)
        print('===================', products)
        print('===================', count)
        order.count_products = count
        order.products = products
        order.quantities = quantities
        order.total_quantity = quantity
        order.total_quantity_units = quantity_units
        order.total_price = price
        order.address = self.request.user.address
        order.save()
        cart.clear()

        return HttpResponseRedirect(reverse_lazy('order:detail', kwargs={'pk': new_order.pk}))

    def get(self, request):
        cart = Cart(request)
        return render(request, 'order_create.html', {'cart': cart})
        # return HttpResponseRedirect(reverse_lazy('orders:order_create', kwargs={'cart': cart}))


def order_list(request):
    orders = Order.objects.filter(user=request.user)
    return render(request, 'order_list.html', {'orders': orders})


def order_detail(request, pk):
    order = Order.objects.filter(id=pk)[0]
    products_value = []
    print('order', order)

    quantities = order.quantities.split(' ')
    products = order.products.split(' ')

    for i in range(order.count_products):
        product = Package.objects.filter(id=int(products[i]))[0]
        print('products', product)
        products_value.append(ProductFull(product, int(quantities[i])))

    print('products', products_value)
    return render(request, 'order_detail.html', {'order': order, 'products': products_value})


class OrderListView(ListView):
    model = Order
    template_name = "order_list.html"


class OrderDeleteView(DeleteView):
    model = Order
    template_name = 'order_delete.html'
    fields = all_fields
    success_url = reverse_lazy('order:list')
