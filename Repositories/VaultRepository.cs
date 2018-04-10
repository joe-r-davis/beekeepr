using System.Collections.Generic;
using System.Data;
using beekeepr.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace beekeepr.Repositories
{
    public class VaultRepository
    {

        private readonly IDbConnection _db;

        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }

        //CREATEONE
        public Vault Add(Vault vault)
        {
            int id = _db.ExecuteScalar<int>($@"
      INSERT INTO vaults (
            name,
            description,
            userId
      ) VALUES (@name, @description, @userId)", vault);
            vault.Id = id;
            return vault;
        }

        //READ: FINDONE FINDALL FINDMANY
        public Vault GetById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>(@"
        SELECT * FROM vaults WHERE id = @id
      ", new { id = id });
        }

        public IEnumerable<Vault> GetVaults()
        {
            return _db.Query<Vault>("SELECT * FROM vaults");
        }

        public Vault Update(int id, Vault vault)
        {
            Vault updated = _db.QueryFirstOrDefault<Vault>(@"
            UPDATE vaults SET
            name = @Name,
            description = @Description,
            userId = @UserId
            WHERE id = @id;
            SELECT * FROM Vaults WHERE id = @id;", vault);
            return updated;
        }

        public string FindByIdAndRemove(int id)
        {
            _db.Execute(@"
        DELETE FROM vaults WHERE id = @id
      ", new { id = id });
            return "successful deletion";
        }

    }
}