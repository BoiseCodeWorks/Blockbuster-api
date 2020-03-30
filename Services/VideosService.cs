using System;
using System.Collections.Generic;
using blockbuster_api.Models;
using blockbuster_api.Repositories;

namespace blockbuster_api.Services
{
    public class VideosService
    {
        private readonly VideosRepository _repo;
        public VideosService(VideosRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Video> Get()
        {
            return _repo.Get();
        }

        public Video Get(int id)
        {
            Video found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public Video Create(Video newVid)
        {
            return _repo.Create(newVid);
        }

        public Video Edit(Video updatedVideo)
        {
            Video exists = _repo.Get(updatedVideo.Id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Edit(updatedVideo);
        }

        public string Delete(int id)
        {
            Video exists = _repo.Get(id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            //if you are the creator
            if (_repo.Delete(id))
            {
                return "Success";
            }
            throw new Exception("Something went wrong with deleting that item");
        }

    }
}