using AutoMapper;
using PostCommentDemo.DTOs;
using PostCommentDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostCommentDemo.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        PostCommet_DemoSm24Entities db = new PostCommet_DemoSm24Entities();
        public ActionResult Index()
        {
            //list of all posts
            var data = db.Posts.ToList();
            var mapper = getMapper();
            var data2 = mapper.Map<List<PostDTO>>(data);
            //map to DTO
            return View(data2);
        }
        [HttpGet]
        public ActionResult Create() {
            return View(new PostDTO());
        }
        [HttpPost]
        public ActionResult Create(PostDTO obj) {
            if (ModelState.IsValid) {
                //convert postDTO to Post
                var mapper = getMapper();
                var post = mapper.Map<Post>(obj);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var exobj = db.Posts.Find(id);
            var mapper = getMapper();
            var data = mapper.Map<PostDTO>(exobj);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(PostDTO obj) { 
            var exobj = db.Posts.Find(obj.Id);
            //db.Entry(exobj).CurrentValues.SetValues(obj);
            exobj.Title = obj.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            var obj = db.Posts.Find(id);
            db.Posts.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public static Mapper getMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
            });
            return new Mapper(config);
        }
    }
}