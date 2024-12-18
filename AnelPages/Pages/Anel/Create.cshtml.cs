using Dominio.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnelPages.Pages.Anel
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AnelDTOCreate Anel { get; set; }

        public IActionResult OnPost()
        {
            var model = Anel;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // L�gica para adicionar o novo anel 
            // Exemplo: Chamar um servi�o para salvar no banco de dados
            // _anelService.AdicionarAnelAsync(Anel);
            return RedirectToPage("/Anel"); // Redirecionar para outra p�gina ap�s a adi��o }
        }
    }
}
