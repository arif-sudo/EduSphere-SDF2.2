﻿using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_A_ApiApp01.Controllers
{
    public class AuthController : Controller
    {
        //private static UserContext _context = new UserContext();
        
        // GET: Auth/Login
        public ActionResult Login()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            return View();
        }
        // POST: /Auth/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("username", "Username is required.");
            }

            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is required.");
            }

            // Check if ModelState is valid
            if (!ModelState.IsValid)
            {
                // If not valid, return the view with the model
                return View();
            }

            // Validate username and password (you can implement your own logic here)
            if (!IsValidUser(username, password))
            {
                // If credentials are not valid, return to the login page with an error message
                TempData["ErrorMessage"] = "Invalid username or password.";
                return RedirectToAction("Login");
            }
            // Redirect to a different page upon successful login || Create json token
            return RedirectToAction("Index", "Home");
        }

        // GET: Auth/Register
        public ActionResult Register()
        {
            ViewBag.WarningMessage = TempData["WarningMessage"] as string;
            return View();
        }

        // POST: Auth/Register
        [HttpPost]
        public ActionResult Register(string username, string email, string password) 
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    ModelState.AddModelError("username", "Username is required.");
                }
                if (string.IsNullOrEmpty(email))
                {
                    ModelState.AddModelError("email", "Email is required.");
                }
                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("password", "Password is required.");
                }

                // Check if ModelState is valid
                if (!ModelState.IsValid)
                {
                    // If not valid, return the view with the model
                    return View();
                }

                using (UserContext context = new UserContext())
                {
                    Users user = context.users.FirstOrDefault(u => u.UserName == username);
                    if (user != null)
                    {

                        TempData["WarningMessage"] = "A user with this username already exists. Please choose a different username";
                        return RedirectToAction("Register");
                    }

                    Users newUser = new Users
                    {
                        UserName = username,
                        Email = email,
                        Password = password
                    };

                    context.users.Add(newUser);
                    context.SaveChanges();
                }

                return RedirectToAction("Login");
            }
            catch (Exception _ex)
            {
                return RedirectToAction("Register");
            }

        }




        // GET: Auth/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Auth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private bool IsValidUser(string username, string password)
        {
            using (var context = new UserContext())
            {
                // Check if a user with the given username and password exists in the database
                // Use bcrypt or sha512 hashing
                return context.users.Any(u => u.UserName == username && u.Password == password);
            }
        }
    }
}