using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWebMotors.Models;

namespace TesteWebMotors.Controllers
{
    public class ValuesController : ApiController
    {
        public ValuesController()
        {

        }
        // GET api/values
        public IHttpActionResult Get()
        {
            IList<VeiculosViewModel> veiculo = null;

            using (var ctx = new teste_webmotorsEntities())
            {
                veiculo = ctx.tb_AnuncioWebmotors.Include("Veiculos")
                            .Select(s => new VeiculosViewModel()
                            {
                                ID = s.ID,
                                marca = s.marca,
                                modelo = s.modelo,
                                versao = s.versao,
                                ano = s.ano,
                                quilometragem = s.quilometragem,
                                observacao = s.observacao

                            }).ToList<VeiculosViewModel>();


                if (veiculo.Count == 0)
                {
                    return NotFound();
                }

                return Ok(veiculo);
            }
        }

        // GET api/values
        public IHttpActionResult GetById(int id)
        {
            using (var ctx = new teste_webmotorsEntities())
            {
                var veiculo = ctx.tb_AnuncioWebmotors.Where(x => x.ID == id).FirstOrDefault();


                if (veiculo == null)
                {
                    return NotFound();
                }

                return Ok(veiculo);
            }
        }

        //Get action methods of the previous section
        public IHttpActionResult Post(VeiculosViewModel veiculos)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new teste_webmotorsEntities())
            {
                ctx.tb_AnuncioWebmotors.Add(new tb_AnuncioWebmotors()
                {
                    ID = veiculos.ID,
                    marca = veiculos.marca,
                    modelo = veiculos.modelo,
                    versao = veiculos.versao,
                    ano = veiculos.ano,
                    quilometragem = veiculos.quilometragem,
                    observacao = veiculos.observacao
                });

                ctx.SaveChanges();
            }

            return Ok();
        }



        public IHttpActionResult Put(VeiculosViewModel veiculos)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new teste_webmotorsEntities())
            {
                var existingVeiculos = ctx.tb_AnuncioWebmotors.Where(s => s.ID == veiculos.ID)
                                                        .FirstOrDefault<tb_AnuncioWebmotors>();

                if (existingVeiculos != null)
                {
                    existingVeiculos.marca = veiculos.marca;
                    existingVeiculos.modelo = veiculos.modelo;
                    existingVeiculos.versao = veiculos.versao;
                    existingVeiculos.ano = veiculos.ano;
                    existingVeiculos.quilometragem = veiculos.quilometragem;
                    existingVeiculos.observacao = veiculos.observacao;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new teste_webmotorsEntities())
            {
                var veiculos = ctx.tb_AnuncioWebmotors
                    .Where(s => s.ID == id)
                    .FirstOrDefault();

                ctx.Entry(veiculos).State = System.Data.Entity.EntityState.Deleted;

                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
