﻿using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Teknik.Configuration;
using Teknik.IdentityServer.ViewModels;
using Teknik.Logging;
using Teknik.Utilities;

namespace Teknik.IdentityServer.Controllers
{
    public class ErrorController : DefaultController
    {
        private readonly IIdentityServerInteractionService _interaction;

        public ErrorController(ILogger<Logger> logger, Config config, IIdentityServerInteractionService interaction) : base(logger, config)
        {
            _interaction = interaction;
        }

        public IActionResult HttpError(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return Http401();
                case 403:
                    return Http403();
                case 404:
                    return Http404();
                default:
                    return HttpGeneral(statusCode);
            }
        }

        public IActionResult HttpGeneral(int statusCode)
        {
            ViewBag.Title = statusCode + " - " + _config.Title;

            LogError(LogLevel.Error, "HTTP Error Code: " + statusCode);

            ErrorViewModel model = new ErrorViewModel();
            model.StatusCode = statusCode;

            return GenerateActionResult(CreateErrorObj("Http", statusCode, "Invalid HTTP Response"), View("~/Views/Error/HttpGeneral.cshtml", model));
        }

        [AllowAnonymous]
        public IActionResult Http401()
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;

            ViewBag.Title = "401 - " + _config.Title;
            ViewBag.Description = "Unauthorized";

            LogError(LogLevel.Error, "Unauthorized");

            ErrorViewModel model = new ErrorViewModel();
            model.StatusCode = StatusCodes.Status401Unauthorized;

            return GenerateActionResult(CreateErrorObj("Http", StatusCodes.Status401Unauthorized, "Unauthorized"), View("~/Views/Error/Http401.cshtml", model));
        }

        [AllowAnonymous]
        public IActionResult Http403()
        {
            Response.StatusCode = StatusCodes.Status403Forbidden;

            ViewBag.Title = "403 - " + _config.Title;
            ViewBag.Description = "Access Denied";

            LogError(LogLevel.Error, "Access Denied");

            ErrorViewModel model = new ErrorViewModel();
            model.StatusCode = StatusCodes.Status403Forbidden;

            return GenerateActionResult(CreateErrorObj("Http", StatusCodes.Status403Forbidden, "Access Denied"), View("~/Views/Error/Http403.cshtml", model));
        }

        [AllowAnonymous]
        public IActionResult Http404()
        {
            Response.StatusCode = StatusCodes.Status404NotFound;

            ViewBag.Title = "404 - " + _config.Title;
            ViewBag.Description = "Uh Oh, can't find it!";

            LogError(LogLevel.Warning, "Page Not Found");

            ErrorViewModel model = new ErrorViewModel();
            model.StatusCode = StatusCodes.Status404NotFound;

            return GenerateActionResult(CreateErrorObj("Http", StatusCodes.Status404NotFound, "Page Not Found"), View("~/Views/Error/Http404.cshtml", model));
        }

        [AllowAnonymous]
        public IActionResult Http500(Exception exception)
        {
            if (HttpContext != null)
            {
                var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    exception = ex.Error;
                }
                HttpContext.Session.Set("Exception", exception);
            }

            Response.StatusCode = StatusCodes.Status500InternalServerError;

            ViewBag.Title = "500 - " + _config.Title;
            ViewBag.Description = "Something Borked";

            LogError(LogLevel.Error, "Server Error", exception);

            ErrorViewModel model = new ErrorViewModel();
            model.StatusCode = StatusCodes.Status500InternalServerError;
            model.Exception = exception;

            return GenerateActionResult(CreateErrorObj("Http", StatusCodes.Status500InternalServerError, exception.Message), View("~/Views/Error/Http500.cshtml", model));
        }

        [AllowAnonymous]
        public async Task<IActionResult> IdentityError(string errorId)
        {
            var message = await _interaction.GetErrorContextAsync(errorId);

            Response.StatusCode = StatusCodes.Status500InternalServerError;

            ViewBag.Title = "Identity Error - " + _config.Title;
            ViewBag.Description = "The Identity Service threw an error";

            LogError(LogLevel.Error, "Identity Error: " + message.Error);

            IdentityErrorViewModel model = new IdentityErrorViewModel();
            model.Title = message.Error;
            model.Description = message.ErrorDescription;

            return GenerateActionResult(CreateErrorObj("Http", StatusCodes.Status500InternalServerError, message.Error), View("~/Views/Error/IdentityError.cshtml", model));
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitErrorReport(SubmitReportViewModel model)
        {
            try
            {
                string exceptionMsg = model.Exception;

                // Try to grab the actual exception that occured
                Exception ex = HttpContext.Session.Get<Exception>("Exception");
                if (ex != null)
                {
                    exceptionMsg = string.Format(@"
Exception: {0}

Source: {1}

Stack Trace:

{2}
", ex.GetFullMessage(true), ex.Source, ex.StackTrace);
                }

                // Let's also email the message to support
                SmtpClient client = new SmtpClient();
                client.Host = _config.ContactConfig.EmailAccount.Host;
                client.Port = _config.ContactConfig.EmailAccount.Port;
                client.EnableSsl = _config.ContactConfig.EmailAccount.SSL;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential(_config.ContactConfig.EmailAccount.Username, _config.ContactConfig.EmailAccount.Password);
                client.Timeout = 5000;

                MailMessage mail = new MailMessage(new MailAddress(_config.NoReplyEmail, _config.NoReplyEmail), new MailAddress(_config.SupportEmail, "Teknik Support"));
                mail.Sender = new MailAddress(_config.ContactConfig.EmailAccount.EmailAddress);
                mail.Subject = "[Exception] Application Exception Occured";
                mail.Body = @"
An exception has occured at: " + model.CurrentUrl + @"

----------------------------------------
User Message:

" + model.Message + @"

----------------------------------------
" + exceptionMsg;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error submitting report. Exception: " + ex.Message });
            }

            return Json(new { result = "true" });
        }

        private object CreateErrorObj(string type, int statusCode, string message)
        {
            return new { error = new { type = type, status = statusCode, message = message } };
        }

        private void LogError(LogLevel level, string message)
        {
            LogError(level, message, null);
        }

        private void LogError(LogLevel level, string message, Exception exception)
        {
            if (Request != null)
            {
                message += " | Url: " + Request.GetDisplayUrl();

                message += " | Referred Url: " + Request.Headers["Referer"].ToString();

                message += " | Method: " + Request.Method;

                message += " | User Agent: " + Request.Headers["User-Agent"].ToString();
            }

            _logger.Log(level, message, exception);
        }
    }
}