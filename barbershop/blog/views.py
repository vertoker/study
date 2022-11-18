from django.views.generic import ListView, DetailView
from django.views.generic.edit import CreateView, UpdateView, DeleteView
from django.urls import reverse_lazy
from .models import Article

active_fields = [
    'title', 'description', 'article'
]

class ArticleListView(ListView):
    model = Article
    template_name = 'blog_list.html'

class ArticleDetailView(DetailView):
    model = Article
    template_name = 'blog_detail.html'

class ArticleCreateView(CreateView):
    model = Article
    template_name = 'blog_new.html'
    fields = active_fields

class ArticleUpdateView(UpdateView):
    model = Article
    template_name = 'blog_edit.html'
    fields = active_fields

class ArticleDeleteView(DeleteView):
    model = Article
    template_name = 'blog_delete.html'
    success_url = reverse_lazy('blog_list')
