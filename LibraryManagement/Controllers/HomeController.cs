using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
{
    ViewBag.Title = HttpContext.Items["ErrorType"]?.ToString() switch
    {
        "BookNotFound" => "gold dead book",
        "DatabaseDown" => "gold unavailable book",
        "GeneralError" => "gold borrowed book",
        _ => "Library Error"
    };
    ViewBag.StatusCode = "500";
    ViewBag.Message = HttpContext.Items["ErrorMessage"]?.ToString() ?? "Unknown error";
    ViewBag.Details = ViewBag.Message;
    return View();
}


}


