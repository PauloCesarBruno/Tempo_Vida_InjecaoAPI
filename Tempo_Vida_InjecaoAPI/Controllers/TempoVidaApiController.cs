using Microsoft.AspNetCore.Mvc;
using Tempo_Vida_InjecaoAPI.Interfaces;
using Tempo_Vida_InjecaoAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tempo_Vida_InjecaoAPI.Controllers
{
    [Route("values")]
    [ApiController]
    public class TempoVidaApiController : ControllerBase
    {
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingetonService _singetonService;

        public TempoVidaApiController(ITransientService transientService,
               IScopedService scopedService,
               ISingetonService singetonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singetonService = singetonService;
        }

        [HttpGet("guides")]
        public IActionResult Get()
        {
            //Somente para testar o Transient que muda a cada Instância, por isso essa nova Insância.
            var transientService2 = HttpContext.RequestServices.GetRequiredService<ITransientService>();
            var scopedService2 = HttpContext.RequestServices.GetRequiredService<IScopedService>();
            var singletonService2 = HttpContext.RequestServices.GetRequiredService<ISingetonService>();

            return Ok(new
            {

                PrimeiraInstancia = new // Primeira Instancia
                {
                    Transient = _transientService.OperationId,
                    Scoped = _scopedService.OperationId,
                    Singleton = _singetonService.OperationId
                },
                                      
                SegundaChamada = new // Segunda Instancia
                {
                    Transient = transientService2.OperationId,
                    Scoped = scopedService2.OperationId,
                    Singleton = singletonService2.OperationId
                },

                NotaTransient = "Os valores precisam mudar a cada INSTANCIA",
                NotaScoped = "Os valores precisam mudar a cada REQUISIÇÃO",
                NotaSingleton = "Os valores precisam ser os mesmos em todas as REQUISIÇÕES"
            });
        }
    }
}
