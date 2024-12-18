using AnelPages.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnelPages.Pages.Anel
{
    public class IndexModel : PageModel
    {
        private readonly AnelApiService _anelApiService;

        public IndexModel(AnelApiService anelApiService)
        {
            _anelApiService = anelApiService;
        }

        public IEnumerable<AnelEntidade> Aneis { get; private set; }

        public async Task OnGetAsync()
        {
            Aneis = await _anelApiService.GetAneisAsync();
        }
    }
}
