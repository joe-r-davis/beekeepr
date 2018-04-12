using System;
using System.Collections.Generic;
using beekeepr.Models;
using beekeepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace beekeepr
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultRepository _repo;
        public VaultsController(VaultRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return _repo.GetVaults();
        }

        [HttpGet("{id}")]
        public Vault Get(int id)
        {
            return _repo.GetById(id);
        }

        [HttpGet("uservaults")]
        public IEnumerable<Vault> GetUserVaults()
        {
            var user = HttpContext.User;
            var id = user.Identity.Name;
            return _repo.GetVaultsByUserId(id);
        }        

        [HttpPost]
        public Vault AddVault([FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return _repo.Add(vault);
            }
            return null;
        }

        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return _repo.Update(id, vault);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _repo.FindByIdAndRemove(id);
        }
    }
}

