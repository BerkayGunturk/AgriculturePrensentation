﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgriculturePrensentation.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       
        private readonly IContactService _contactService;

		public DefaultController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
		[HttpPost]
		public IActionResult SendMessage(Contact contact)
		{
			contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Insert(contact);
            return RedirectToAction("Index", "Default");
		}
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
	}
}
