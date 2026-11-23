using Microsoft.AspNetCore.Mvc;
using ExerciciosMVC.Models;
using ExerciciosMVC.ViewModels;

namespace ExerciciosMVC.Controllers
{
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new()
        {
            new Evento { Id = 1, Nome = "FuteSoccer", Descricao = "Evento sobre futebol.", Local = "São Paulo", DataEvento = new DateTime(2026, 11, 25), QuantidadeVagas = 1000, ValorIngresso = 1000m },
            new Evento { Id = 2, Nome = "Haptamil", Descricao = "Evento sobre remédios.", Local = "São Caetando do Sul", DataEvento = new DateTime(2026, 12, 22), QuantidadeVagas = 500, ValorIngresso = 500m }
        };

        public IActionResult Index()
        {
            return View(_eventos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento); // retornar para a View de cadastro com erros de validação
            }

            evento.Id = _eventos.Any() ? _eventos.Max(e => e.Id) + 1 : 1;

            _eventos.Add(evento);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }



        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.NomeBusca) &&
                string.IsNullOrEmpty(vm.LocalBusca) &&
                !vm.DataInicial.HasValue) // Verifica se os parametros estão vazios.
            {
                vm.Resultados = new List<Evento>(); // Cria uma lista sem informações.
                return View(vm);
            }

            IEnumerable<Evento> consulta = _eventos;

            if (!string.IsNullOrEmpty(vm.NomeBusca))
            {
                consulta = consulta.Where(a => a.Nome.Contains(vm.NomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(vm.LocalBusca))
            {
                consulta = consulta.Where(a => a.Local.Contains(vm.LocalBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (vm.DataInicial.HasValue)
            {
                consulta = consulta.Where(a => a.DataEvento.Date >= vm.DataInicial.Value.Date).ToList();
            }

            vm.Resultados = consulta.ToList();

            return View(vm);
        }

        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();
            return View(evento);
        }
    }
}