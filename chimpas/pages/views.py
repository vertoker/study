from django.views.generic import TemplateView


class HomePageView(TemplateView):
    template_name = 'home.html'


class AboutUsView(TemplateView):
    template_name = 'about.html'


class DeliveryView(TemplateView):
    template_name = 'contacts.html'



