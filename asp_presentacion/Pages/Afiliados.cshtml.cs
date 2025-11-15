// Página Razor para gestión de Afiliados
// Proporciona funcionalidad CRUD completa con interfaz morada
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class AfiliadosModel : PageModel
    {
        // Instancia de la presentación de afiliados
        private readonly IAfiliadosPresentacion _afiliadosPresentacion;

        // Constructor que recibe la presentación por inyección de dependencias
        public AfiliadosModel(IAfiliadosPresentacion afiliadosPresentacion)
        {
            _afiliadosPresentacion = afiliadosPresentacion;
        }

        // Lista de afiliados para mostrar en la tabla
        public List<Afiliado> Afiliados { get; set; } = new List<Afiliado>();

        // Afiliado actual para editar/crear
        public Afiliado? Actual { get; set; }

        // Acción actual (Listar, Editar, Nuevo, Eliminar)
        public string Accion { get; set; } = Enumerables.Ventanas.Listar;

        // Archivo de imagen para subir
        [BindProperty]
        public IFormFile? FormFile { get; set; }

        // Método GET: carga la lista de afiliados
        public async Task OnGetAsync()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listar;
                Afiliados = await _afiliadosPresentacion.Listar();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar afiliados: {ex.Message}";
            }
        }

        // Método POST: guarda un nuevo afiliado o modifica uno existente
        public async Task<IActionResult> OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                // Si hay un archivo de imagen, lo procesa
                if (FormFile != null)
                {
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    // Actual!.Imagen = EncodingHelper.ToString(memoryStream.ToArray());
                    memoryStream.Dispose();
                }

                // Determina si es nuevo o modificación
                Afiliado? resultado = null;
                if (Actual!.Id == 0)
                {
                    // Es un nuevo afiliado
                    resultado = await _afiliadosPresentacion.Guardar(Actual!);
                }
                else
                {
                    // Es una modificación
                    resultado = await _afiliadosPresentacion.Modificar(Actual!);
                }

                TempData["Success"] = "Afiliado guardado correctamente";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al guardar: {ex.Message}";
                return Page();
            }
        }

        // Método POST: borra un afiliado
        public async Task<IActionResult> OnPostBtBorrar(int id)
        {
            try
            {
                var afiliado = new Afiliado { Id = id };
                await _afiliadosPresentacion.Borrar(afiliado);
                TempData["Success"] = "Afiliado borrado correctamente";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al borrar: {ex.Message}";
                return RedirectToPage();
            }
        }

        // Método GET: carga un afiliado para editar
        public async Task<IActionResult> OnGetEditar(int id)
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Afiliados = await _afiliadosPresentacion.Listar();
                Actual = Afiliados.FirstOrDefault(a => a.Id == id);
                if (Actual == null)
                {
                    TempData["Error"] = "Afiliado no encontrado";
                    return RedirectToPage();
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar: {ex.Message}";
                return RedirectToPage();
            }
        }

        // Método GET: prepara formulario para nuevo afiliado
        public async Task<IActionResult> OnGetNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Nuevo;
                Actual = new Afiliado();
                Afiliados = await _afiliadosPresentacion.Listar();
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return RedirectToPage();
            }
        }
    }
}

