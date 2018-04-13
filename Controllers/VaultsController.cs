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
        private readonly KeepRepository _keepsRepo;
        public VaultsController(VaultRepository repo, KeepRepository keepsRepo)
        {
            _repo = repo;
            _keepsRepo = keepsRepo;
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

        [HttpPost("keeps")]
        public VaultKeep ConnectVaultAndKeep([FromBody] VaultKeep vaultKeep)
        {
            return _repo.ConnectVaultAndKeep(vaultKeep);
        }

        [HttpDelete("{vaultId}/keeps/{keepId}")]
        public string DisconnectVaultAndKeep(int vaultId, int keepId)
        {
            var user = HttpContext.User;
            if (user.Identity.Name != null)
            {
                var sessionId = user.Identity.Name;
                var vaultKeep = new VaultKeep();
                vaultKeep.VaultId = vaultId;
                vaultKeep.KeepId = keepId;
                vaultKeep.UserId = sessionId;
                return _repo.DisconnectVaultAndKeep(vaultKeep);
            }
            return null;
        }

        [HttpGet("{id}/keeps")]
        public IEnumerable<Keep> GetKeepsByVaultId(string id)
        {
            var user = HttpContext.User;
            var sessionId = user.Identity.Name;
            return _keepsRepo.GetByVaultId(id);
        }

        [HttpGet("keeps/byVault")]
        public AllKeepsResults GetAllKeepsByVault()
        {
            IEnumerable<Vault> allVaults = Get();
            List<int> vaultIds = new List<int>();
            foreach (Vault vault in allVaults)
            {
                vaultIds.Add(vault.Id);
            }

            AllKeepsResults results = new AllKeepsResults();
            foreach (int vaultId in vaultIds)
            {
                // fire _keepsRepo.GetByVaultId(vaultId)
                // add to results... vaultId: return value from prev line
            }
            return results;
        }
    }
}

