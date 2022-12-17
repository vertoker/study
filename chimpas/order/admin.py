from django.contrib import admin

# Register your models here.
from django.contrib import admin
from .models import *


class OrderAdmin(admin.ModelAdmin):
    list_display = admin_fields
    list_filter = ['created']
    model = Order


admin.site.register(Order, OrderAdmin)
