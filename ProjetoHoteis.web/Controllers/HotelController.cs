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
    public IActionResult GetTodos()
    {
        return Ok(_repositorio.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetPorId(int id)
    {
        return Ok(_repositorio.BuscarPorId(id));
    }

    [HttpPost]
    public IActionResult Salvar(Hotel hotel)
    {
        _repositorio.Adicionar(hotel);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeletePorId(int id)
    {
        _repositorio.Deletar(id);
        return Ok();
    }

    [HttpGet("CEP")]
    public async Task<IActionResult> GetCEP(string cep)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        var resposta = await response.Content.ReadAsStringAsync();
        var respostaObjeto = JsonSerializer.Deserialize<ViaCepRespostaHttp>(resposta);
        return Ok(resposta);
    }
}
