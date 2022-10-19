from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.HaircutListView.as_view(), name='haircut_list'),
    path('<int:pk>/', views.HaircutDetailView.as_view(), name='haircut_detail'),
    path('new/', views.HaircutCreateView.as_view(), name='haircut_new'),
    path('<int:pk>/edit', views.HaircutUpdateView.as_view(), name='haircut_edit'),
    path('<int:pk>/delete', views.HaircutDeleteView.as_view(), name='haircut_delete')
]
