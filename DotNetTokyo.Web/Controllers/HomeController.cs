﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using DotNetTokyo.Web.Helpers;
using DotNetTokyo.Web.Services;

namespace DotNetTokyo.Web.Controllers
{
    public class HomeController : LocalizedController
    {
        private IMeetupService meetupService;

        public HomeController()
        {
            // TODO: Switch to DI
            meetupService = new MeetupService(new HttpClient());
        }

        [OutputCache(VaryByCustom = "url", Duration = 3600)]
        public async Task<ActionResult> Index()
        {
            // the meetup is not currently running - prevent blowing up incase meetup.com removes it
            // return View(await meetupService.GetUpcomingEvents());

            return View(new List<Models.Event>());
        }
    }
}