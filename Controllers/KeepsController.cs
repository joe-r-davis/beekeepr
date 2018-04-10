using System;
using System.Collections.Generic;
using beekeepr.Models;
using beekeepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace beekeepr
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository _repo;
        public KeepsController(KeepRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _repo.GetKeeps();
        }

        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public Keep AddKeep([FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return _repo.Add(keep);
            }
            return null;
        }

        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return _repo.Update(id, keep);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _repo.FindByIdAndRemove(id);
        }

        // [HttpGet("report/{userId}")]
        // public IEnumerable<UserKeepOrderReport> GetReport(string userId)
        // {
        //     return _repo.GetUserKeepReport(userId);
        // }

    }
}