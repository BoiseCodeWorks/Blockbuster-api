using System.Collections.Generic;
using System.Data;
using blockbuster_api.Models;
using Dapper;

namespace blockbuster_api.Repositories
{
    public class VideosRepository
    {
        private readonly IDbConnection _db;
        public VideosRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Video> Get()
        {
            string sql = "SELECT * FROM videos";
            return _db.Query<Video>(sql);
        }

        //get by id
        public Video Get(int Id)
        {
            string sql = "SELECT * FROM videos WHERE id = @Id";
            return _db.QueryFirstOrDefault<Video>(sql, new { Id });
        }

        //post
        public Video Create(Video newVideo)
        {
            string sql = @"
            INSERT INTO videos
            (title, description, runtime, IsAvailable)
            VALUES
            (@Title, @Description, @Runtime, true);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVideo);
            newVideo.Id = id;
            newVideo.IsAvailable = true;
            return newVideo;
        }

        //put
        public Video Edit(Video updatedVideo)
        {
            string sql = @"
            UPDATE videos
            SET
                title = @Title,
                description = @Description, 
                runtime = @Runtime,
                isAvailable = @IsAvailable
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedVideo);
            return updatedVideo;
        }

        //delete
        public bool Delete(int Id)
        {
            string sql = "DELETE FROM videos WHERE id = @Id LIMIT 1";
            int changed = _db.Execute(sql, new { Id });
            return changed == 1;
        }
    }
}