using System;
using System.Threading.Tasks;
using CadastroMedicoApi.Data;
using CadastroMedicoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroMedicoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MedicoController : ControllerBase
    {
        private readonly IRepository _repo;
        public MedicoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllMedicoModelAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: oi {ex.Message}");
            }
        }

        [HttpGet("{medicoId}")]
        public async Task<IActionResult> GetByMedicoId(int medicoId)
        {
            try
            {
                var result = await _repo.GetMedicoModelById(medicoId, true);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("especialidade/{especialidadeId}")]
        public async Task<IActionResult> GetByEspecialidadeId(int especialidadeId)
        {
            try
            {
                var result = await _repo.GetAllMedicoModelByEspecialidadeId(especialidadeId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(MedicoModel model)
        {
            try
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{medicoId}")]
        public async Task<IActionResult> put(int medicoId, MedicoModel model)
        {
            try
            {
                var medico = await _repo.GetMedicoModelById(medicoId, false);
                if(medico == null)
                {
                    return NotFound();
                }

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Alteração Realizada!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{medicoId}")]
        public async Task<IActionResult> delete(int medicoId)
        {
            try
            {
                var medico = await _repo.GetMedicoModelById(medicoId, false);

                if(medico == null) 
                {
                    return NotFound();
                }

                _repo.Delete(medico);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message = "Medico Deletado!"});
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}