from django.conf import settings
from django.conf.urls.static import static
from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path("", include('base.urls')),
    path("products/", include('products.urls')),
    path("admin/", admin.site.urls),
    path("users/", include('user.urls')),
    path("users/", include('django.contrib.auth.urls'))
] + static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
