from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.MasterListView.as_view(), name='master_list'),
    path('<int:pk>/', views.MasterDetailView.as_view(), name='master_detail'),
    path('new/', views.MasterCreateView.as_view(), name='master_new'),
    path('<int:pk>/edit', views.MasterUpdateView.as_view(), name='master_edit'),
    path('<int:pk>/delete', views.MasterDeleteView.as_view(), name='master_delete')
]
