using Microsoft.AspNetCore.Mvc;
using ProjetoHoteis.lib.Data.Repositorios;
using ProjetoHoteis.lib.Models;
using ProjetoHoteis.web.DTOs.RespostaHTTP;
using System.Text.Json;

namespace ProjetoHoteis.web.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    public readonly HotelRepositorio _repositorio;
    
    public HotelController(HotelRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodosAsync()
    {
        return Ok(await _repositorio.BuscarTodosAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id)
    {
        return Ok(await _repositorio.BuscarPorIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> SalvarAsync(Hotel hotel)
    {
        await _repositorio.AdicionarAsync(hotel);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePorIdAsync(int id)
    {
        await _repositorio.DeletarAsync(id);
        return Ok();
    }

    [HttpGet("CEP")]
    public async Task<IActionResult> GetCEPAsync(string cep)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        var resposta = await response.Content.ReadAsStringAsync();
        var respostaObjeto = JsonSerializer.Deserialize<ViaCepRespostaHttp>(resposta);
        return Ok(resposta);
    }
}
