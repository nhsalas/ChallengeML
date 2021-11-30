using Data.Repositories;
using Datos.Repositories.SQL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {

        BitacoraRepositorySQL Bitacora = new BitacoraRepositorySQL();

        [HttpPost]
        public IActionResult Add(Bitacora bitacora)
        {
            Bitacora.Add(bitacora);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Bitacora> movimientos = new List<Bitacora>();
            movimientos = (List<Bitacora>)Bitacora.GetAll();
            return Ok(movimientos);

        }
    }
}

