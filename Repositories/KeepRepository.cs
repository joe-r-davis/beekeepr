using System.Collections.Generic;
using System.Data;
using beekeepr.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Linq;

namespace beekeepr.Repositories
{
    public class KeepRepository
    {

        private readonly IDbConnection _db;

        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }

        //CREATEONE
        public Keep Add(Keep keep)
        {
            int id = _db.ExecuteScalar<int>($@"
      INSERT INTO keeps (
            title,
            imageUrl,
            articleUrl,
            public,
            keepCount,
            shareCount,
            viewCount,
            userId
      ) VALUES (@title, @imageUrl, @articleUrl, @public, @keepCount, @shareCount, @viewCount, @userId)", keep);
            keep.Id = id;
            return keep;
        }

        //READ: FINDONE FINDALL FINDMANY
        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>(@"
        SELECT * FROM keeps WHERE id = @id
      ", new { id = id });
        }

        public IEnumerable<Keep> GetKeeps()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        //     public IEnumerable<UserKeepList> GetUserKeepList(string userId)
        //     {

        //         return _db.Query<UserKeepList>(@"
        //     SELECT
        //       u.name username,
        //       u.email,
        //       ob.burgerId,
        //       ob.quantity,
        //       ob.orderId,
        //       b.name keep,
        //       b.kcal
        //     FROM keeplist kl
        //     JOIN users u ON u.id = ob.userId
        //     JOIN keeps k ON b.id = ob.keepId
        //     WHERE userId = @id;
        //   ", new { id = userId });

        //     }

        public Keep Update(int id, Keep keep)
        {
            Keep updated = _db.QueryFirstOrDefault<Keep>(@"
            UPDATE keeps SET
            title = @Title,
            imageUrl = @ImageUrl,
            articleUrl = @ArticleUrl,
            public = @Public,
            keepCount = @KeepCount,
            shareCount = @ShareCount,
            viewCount = @ViewCount,
            userId = @UserId
            WHERE id = @id;
            SELECT * FROM Keeps WHERE id = @id;", keep);
            return updated;
        }

        public string FindByIdAndRemove(int id)
        {
            _db.Execute(@"
        DELETE FROM keeps WHERE id = @id
      ", new { id = id });
            return "successful deletion";
        }

        public List<Keep> GetKeepsByUserId(string id)
        // public IEnumerable<Keep> GetKeepsByUserId(string id)
        {
            return _db.Query<Keep>(@"
        SELECT * FROM keeps WHERE userId = @userId
      ", new { userId = id}).ToList();
    //   ", new { id = userId});
        }

    }
}