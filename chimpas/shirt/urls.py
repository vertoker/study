from django.conf import settings
from django.conf.urls.static import static
from django.urls import path
from . import views

urlpatterns = [
    path('new/', views.image_upload_view, name='shirt_new'),
    path('<int:pk>/', views.ShirtDetailView.as_view(), name='shirt_detail'),
    path('delete/<int:pk>/', views.ShirtDeleteView.as_view(), name='shirt_delete'),
    path('update/<int:pk>/', views.ShirtEditView.as_view(), name='shirt_edit')
]

if settings.DEBUG:
    urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
