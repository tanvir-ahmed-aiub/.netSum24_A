using AutoMapper;
using PostCommentDemo.Auth;
using PostCommentDemo.DTOs;
using PostCommentDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostCommentDemo.Controllers
{
    [Logged]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        PostCommet_DemoSm24Entities db = new PostCommet_DemoSm24Entities();
        public ActionResult Index()
        {
            var data = db.Posts.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post,PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<PostDTO>>(data);
            return View(data2);
        }
        public ActionResult Comments(int id) {
            var data = db.Posts.Find(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var post = mapper.Map<PostDTO>(data);
            return View(post);

        }
    }
}