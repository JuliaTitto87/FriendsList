using FriendsList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Text;

namespace FriendsList.Controllers
{
    public class FriendController : Controller
    {
        static List<FriendViewModel> Friends = new List<FriendViewModel>();
        // GET: FriendController
        public ActionResult Index()
        {
            return View(Friends);
        }

        // GET: FriendController/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: FriendController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FriendViewModel friend )
        {
            try
            {
                friend.Id = Environment.TickCount;
                Friends.Add(friend);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendController/Edit/5
        public ActionResult Edit(int id)
        {
            FriendViewModel friend = Friends.FirstOrDefault(x => x.Id == id);
          return View(friend);
            
        }

        // POST: FriendController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FriendViewModel friend)
        {
            try
            {
                int id = Friends.IndexOf(Friends.Where(x => x.Id == friend.Id).FirstOrDefault());
                Friends[id] = friend;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendController/Delete/5
        public ActionResult Delete(int id)
		{
            FriendViewModel friend = Friends.FirstOrDefault(x => x.Id == id);
            return View(friend);
        }

        // POST: FriendController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FriendViewModel friend)
        {
            List<FriendViewModel> friendController = new List<FriendViewModel>();
            friendController = Friends;
            try
            {
                int id = Friends.IndexOf(Friends.Where(x => x.Id == friend.Id).FirstOrDefault());
                Friends.Remove(Friends[id]);
                
             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
