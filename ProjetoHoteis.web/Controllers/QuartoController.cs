using Microsoft.AspNetCore.Mvc;
using ProjetoHoteis.lib.Data.Repositorios;
using ProjetoHoteis.lib.Models;

namespace ProjetoHoteis.web.Controllers;

[ApiController]
[Route("[controller]")]
public class QuartoController : ControllerBase
{
    public readonly QuartoRepositorio _repositorio;
    public QuartoController(QuartoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodosAsync()
    {
        var resposta = await _repositorio.BuscarTodosAsync();
        return Ok(resposta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id)
    {
        var resposta = await _repositorio.BuscarPorIdAsync(id);
        return Ok(resposta);
    }

    [HttpPost]
    public async Task<IActionResult> SalvarAsync(Quarto quarto)
    {
        await _repositorio.AdicionarAsync(quarto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePorIdAsync(int id)
    {
        await _repositorio.DeletarAsync(id);
        return Ok();
    }
}
