using Dominio.DTO;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AnelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnelController : ControllerBase
    {
        public IAnelServico _servico { get; set; }

        public AnelController(IAnelServico anelServico)
        {
            _servico = anelServico;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _servico.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnelDTOCreate dtoCreate)
        {
            //Contagem de aneis
            var contagem = await _servico.Verifica(dtoCreate.TipoAnel);
            if (!String.IsNullOrEmpty(contagem))
            {
                ModelState.AddModelError("Erro: ", contagem);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _servico.Post(dtoCreate);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetCepWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetCepWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _servico.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AnelEntidade dtoUpdate)
        {
            //Contagem de aneis
            var contagem = await _servico.Verifica(dtoUpdate.TipoAnel);
            if (!String.IsNullOrEmpty(contagem))
            {
                ModelState.AddModelError("Erro: ", contagem);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _servico.Put(dtoUpdate);
                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _servico.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
