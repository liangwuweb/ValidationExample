﻿using Microsoft.AspNetCore.Mvc;
using ValidationExample.CustomModelBinder;
using ValidationExample.Models;


namespace ValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))] Person person)
        public IActionResult Index(Person person)
        {

            if (!ModelState.IsValid) 
            {   

                //selectMany faltten the ModelState.Values, so we can select each err and put them into a enum list, no for each loop needed
                
                //List<string> errorList = new List<string>();
                //foreach (var value in ModelState.Values) { 
                //    foreach (var error in value.Errors) {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}

                // get modelstate errors from model validation
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
