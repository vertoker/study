from django.conf import settings
from django.db import models
from shirt.models import Shirts

sizes = ['XS', 'S', 'M', 'L', 'XL', 'XXL']


class Cart(models.Model):
    user = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.CASCADE)
    product = models.ForeignKey(Shirts, on_delete=models.CASCADE)
    quantity = models.IntegerField(null=False, blank=False)
    size = models.CharField(max_length=3, default='M')
    created_at = models.DateTimeField(auto_now_add=True)
