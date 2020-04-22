using System;
using DapperDemoAPI.Extra;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorMsgRunningController : ControllerBase
    {
        [HttpGet]
        [Route("NaturalMsg")]
        public string NaturalMsg()
        {
            ErrorMsgRunning errorMsgRunning = new ErrorMsgRunning();
            errorMsgRunning.WhatNumberIs();
            return "throw error msg.";
        }

        [HttpGet]
        [Route("ThrowExceptionDirectly")]
        public IActionResult ThrowExceptionDirectly()
        {
            throw new Exception("See you tomorrow.");
        }
    }
}