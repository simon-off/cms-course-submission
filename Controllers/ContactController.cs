using crito.Models;
using crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace crito.Controllers;

public class ContactController : SurfaceController
{
    public ContactController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactForm contactForm)
    {
        if (!ModelState.IsValid || contactForm.Email.IsNullOrWhiteSpace() || contactForm.Message.IsNullOrWhiteSpace())
        {
            return CurrentUmbracoPage();
        }

        // THIS IS WHERE THE MAGIC HAPPENS
        /*
        // Instantiate MailService
        using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contact@crito.com", "ChangeThis123!");

        // To sender
        await mail.SendAsync(contactForm.Email, "Thanks for reaching out!", "We'll get back to you as soon as possible.");

        // To us
        await mail.SendAsync("contact@crito.com", $"{contactForm.Name} sent a message.", contactForm.Message);
        */

        return LocalRedirect("/contact");
    }
}
