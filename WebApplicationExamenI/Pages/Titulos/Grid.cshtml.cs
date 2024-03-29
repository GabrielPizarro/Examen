using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationExamenI.Pages.Titulos
{ 
public class GridModel : PageModel
{
    private readonly ITitulosService titulosService;

    public GridModel(ITitulosService titulosService)
    {
        this.titulosService = titulosService;
    }

    public IEnumerable<TitulosEntity> GridList { get; set; } = new List<TitulosEntity>();

    public string Mensaje { get; set; } = "";

    public async Task<IActionResult> OnGet()
    {
        try
        {
            GridList = await titulosService.Get();

            if (TempData.ContainsKey("Msg"))
            {
                Mensaje = TempData["Msg"] as string;
            }

            TempData.Clear();

            return Page();
        }
        catch (Exception ex)
        {

            return Content(ex.Message);
        }

    }

    public async Task<IActionResult> OnGetEliminar(int id)
    {
        try
        {
            var result = await titulosService.Delete(new()
            {
                Id_Titulo = id

            });

            if (result.CodeError != 0)
            {
                throw new Exception(result.MsgError);
            }
            TempData["Msg"] = "Se elimino correctamente";

            return Redirect("Grid");

        }
        catch (Exception ex)
        {

            return Content(ex.Message);
        }

    }
}
}