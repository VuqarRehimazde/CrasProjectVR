﻿using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DTOLayer;
using DTOLayer.AboutDTO;
using DTOLayer.FAQDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FAQController : BaseController
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var faqs = _faqService.TGetAll().Data;
            return View(faqs);
        }
        [HttpGet]
        public IActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFAQ(FAQCreateDTOs faqdtos)
        {
            var result = _faqService.TAdd(faqdtos, out List<ValidationFailure> errors);

            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(faqdtos);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateFAQ(int id)
        {
            var faq = _faqService.TGetById(id).Data;
            return View(faq);
        }

        [HttpPost]
        public IActionResult UpdateFAQ(FAQDTOs faqDTOs)
        {
            var result = _faqService.TUpdate(faqDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(faqDTOs);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFAQ(int id)
        {
            var value = _faqService.TGetById(id).Data;
            _faqService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult HardDeleteFAQ(int id)
        {
            var value = _faqService.TGetById(id).Data;
            _faqService.THardDelete(value);
            return RedirectToAction("Index");
        }

    }
}

