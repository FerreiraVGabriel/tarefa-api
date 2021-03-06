using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Repositories;
using System;

namespace TarefasBackEnd.Models{

  [ApiController]
  [Route("tarefa")]
  public class TarefaController : ControllerBase
  {
    [HttpGet]
    public IActionResult Read([FromServices]ITarefaRepository repository){

      var tarefas = repository.Read();
      return Ok(tarefas);
    }

      [HttpPost]
    public IActionResult Create([FromBody]Tarefa model, [FromServices]ITarefaRepository repository){

      if(!ModelState.IsValid)
      return BadRequest();

      repository.Create(model);

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id,[FromBody]Tarefa model, [FromServices]ITarefaRepository repository){

      if(!ModelState.IsValid)
      return BadRequest();

      repository.Update(new Guid(id),model);

      return Ok();
    }

     [HttpDelete("{id}")]
    public IActionResult Delete(string id, [FromServices]ITarefaRepository repository)
    {
      repository.Delete(new Guid(id));
      return Ok();
    }
  }
}