from django.shortcuts import render
from django.http import HttpResponse

def homePage(request):
    return render(request, "home.html")

def aboutPage(request):
    return render(request, "about.html")

# Create your views here.
