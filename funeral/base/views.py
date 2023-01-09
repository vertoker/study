from django.views.generic import TemplateView


class HomeView(TemplateView):
    template_name = 'home.html'


class AboutView(TemplateView):
    template_name = 'about.html'


class FuneralArrangementsView(TemplateView):
    template_name = 'funeral_arrangements.html'


class FuneralCremationView(TemplateView):
    template_name = 'funeral_cremation.html'


class FuneralInlifeView(TemplateView):
    template_name = 'funeral_inlife.html'


class IfCloseManDeadView(TemplateView):
    template_name = 'if_close_man_dead.html'


class RegistrationDocumentsView(TemplateView):
    template_name = 'registration_documents.html'


class InfrastructureView(TemplateView):
    template_name = 'infrastructure.html'
