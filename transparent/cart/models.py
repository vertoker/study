from django.conf import settings
from django.db import models
from package.models import Package

sizes = ['XS', 'S', 'M', 'L', 'XL', 'XXL']


class Cart(models.Model):
    user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
    product = models.ForeignKey(Package, on_delete=models.CASCADE)
    quantity = models.IntegerField(null=False, blank=False)
    created_at = models.DateTimeField(auto_now_add=True)
