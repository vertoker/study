from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.ArticleListView.as_view(), name='blog_list'),
    path('<int:pk>/', views.ArticleDetailView.as_view(), name='blog_detail'),
    path('new/', views.ArticleCreateView.as_view(), name='blog_new'),
    path('<int:pk>/edit', views.ArticleUpdateView.as_view(), name='blog_edit'),
    path('<int:pk>/delete', views.ArticleDeleteView.as_view(), name='blog_delete')
]
