using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController, Route("receptek")]
    public class ReceptekController(AppDbContext context) : ControllerBase
    {
        AppDbContext context { get; } = context;

        [HttpGet]
        public IEnumerable<ReceptJoinKategoria> Get() => context
            .Receptek
            .Join(context.Kategoriak, recept => recept.KatId, kategoria => kategoria.Id, (recept, kategoria) => new ReceptJoinKategoria {
                Id = recept.Id,
                Nev = recept.Nev,
                Kategoria = new KategoriaDTO {
                    Id = kategoria.Id,
                    Nev = kategoria.Nev
                },
                KepEleresiUt = recept.KepEleresiUt,
                Leiras = recept.Leiras
            })
        ;

        [HttpGet("{katId}")]
        public IEnumerable<ReceptJoinKategoria> GetKategoriaSzerint([FromRoute] int katId) => Get()
            .Where(receptJoinKategoria => receptJoinKategoria.Kategoria.Id == katId)
        ;

        [HttpPost]
        public ActionResult Post([FromBody] ReceptDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Recept rekord = new Recept {
                    Id = data.Id,
                    Nev = data.Nev,
                    KatId = data.KatId,
                    KepEleresiUt = data.KepEleresiUt,
                    Leiras = data.Leiras
                };
                context.Receptek.Add(rekord);
                try
                {
                    context.SaveChanges();
                    return Ok(new ReceptDTO {
                        Id = rekord.Id,
                        Nev = rekord.Nev,
                        KatId = rekord.KatId,
                        KepEleresiUt = rekord.KepEleresiUt,
                        Leiras = rekord.Leiras
                    });
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return Conflict(e.InnerException?.Message);
                }
                catch (DbUpdateException e)
                {
                    return BadRequest(e.InnerException?.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            Recept? rekord = context.Receptek.Find(id);
            if (rekord is not null)
            {
                context.Receptek.Remove(rekord);
                try
                {
                    context.SaveChanges();
                    return Ok(new ReceptDTO {
                        Id = rekord.Id,
                        Nev = rekord.Nev,
                        KatId = rekord.KatId,
                        KepEleresiUt = rekord.KepEleresiUt,
                        Leiras = rekord.Leiras
                    });
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return Conflict(e.InnerException?.Message);
                }
                catch (DbUpdateException e)
                {
                    return BadRequest(e.InnerException?.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        public class ReceptJoinKategoria
        {
            public int Id { get; set; }
            public string Nev { get; set; }
            public KategoriaDTO Kategoria { get; set; }
            public string KepEleresiUt { get; set; }
            public string Leiras { get; set; }
        }
    }
}
