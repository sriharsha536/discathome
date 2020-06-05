using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DVDRentalAPI.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected string GetController()
        {
            var controllerName = _httpContextAccessor.HttpContext.GetRouteData().Values["controller"].ToString();
            return controllerName;
        }

        protected string GetAction()
        {
            var actionName = _httpContextAccessor.HttpContext.GetRouteData().Values["action"].ToString();
            return actionName;
        }

        protected string GetUserName()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            return userName;
        }

        protected string GetHostIpAddress()
        {
            var ipAddress = $"{_httpContextAccessor.HttpContext.Request.Host.Host}:{_httpContextAccessor.HttpContext.Request.Host.Port}";
            return ipAddress;
        }

        protected string GetExceptionMessage(Exception exception)
        {
            var errorMessage = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
            var message = $"Error in Controller:{GetController()} with Action: {GetAction()} for User: {GetUserName()} from IpAddress: {GetHostIpAddress()}\n Error: {errorMessage}";
            return message;
        }

        protected int GetUserId()
        {
            var value = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Name).Value;
            return int.Parse(value);
        }
    }
}
