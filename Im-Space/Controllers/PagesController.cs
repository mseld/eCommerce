using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IM.Web.Models;
using IM.Web.Services;
using AutoMapper;
using System.Threading;
using System.IO;

namespace IM.Web.Controllers
{
    public class PagesController : BaseController
    {
        //private readonly IPage pageService;

        public PagesController(DataContext db) : base(db)
        {
        }

        private List<QuestionViewModel> GetQuestions(int group) {

            var questions = db.Questions.Where(q => q.QuestionGroupId == group);

            var answers = db.Answers.Where(ans => questions.Any(q => q.AnswerGroupId == ans.AnswerGroupId)).ToList();

            List<QuestionViewModel> Questions = new List<QuestionViewModel>();
            
            foreach (var q in questions)
            {
                var obj = new QuestionViewModel
                {
                    Id = q.Id,
                    Text = q.Text,
                    Textlocalized = q.Textlocalized,
                    HasOthersOption = q.HasOthersOption,
                    QuestionGroupId = q.QuestionGroupId,
                    AnswerGroupId = q.AnswerGroupId,
                    QuestionType = q.QuestionType,                    
                };

                if (q.QuestionType == QuestionTypes.Radiobutton)
                    obj.Answers = answers
                        .Where(ans => ans.AnswerGroupId == q.AnswerGroupId)
                        .Select(ans => new AnswerViewModel
                        {
                            Id = ans.Id,
                            Text = ans.Text,
                            Textlocalized = ans.Textlocalized
                        }).ToList();

                Questions.Add(obj);
            }
            return Questions;
        }

        public ActionResult Questionnaire()
        {
            string languageCode = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            ViewBag.DealingPeriod = db.BusinessLists.Where(luk => luk.ListType == "DealingPeriod").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Region = db.BusinessLists.Where(luk => luk.ListType == "Region").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            var model = new QuestionnaireViewModel();
            model.Questions = GetQuestions(1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Questionnaire(QuestionnaireViewModel model)
        {
            string languageCode = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            ViewBag.DealingPeriod = db.BusinessLists.Where(luk => luk.ListType == "DealingPeriod").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Region = db.BusinessLists.Where(luk => luk.ListType == "Region").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            if (ModelState.IsValid)
            {
                try
                {
                    Questionnaire questionnaire = new Questionnaire {
                        CompanyName = model.CompanyName,
                        CellPhone = model.CellPhone,
                        Region = model.Region,
                        DealingPeriod = model.DealingPeriod,
                    };

                    db.Questionnaires.Add(questionnaire);
                    db.SaveChanges();

                    for (int i = 0; i < model.Questions.Count; i++)
                    {
                        var q = new QuestionAnswer {
                            QuestionId = model.Questions[i].Id,
                            AnswerId = model.Questions[i].Value,
                            QuestionGroupId = model.Questions[i].QuestionGroupId,
                            AnswerGroupId = model.Questions[i].AnswerGroupId,
                            parentId = questionnaire.Id,                            
                        };
                        db.QuestionAnswers.Add(q);
                    }

                    db.SaveChanges();

                    return RedirectToAction("Questionnaire")
                        .WithSuccess(string.Format("Data has been added Successfully".TA()));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }


        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ProductDetails(int id = 1)
        {
            return View();
        }

        public ActionResult Comments()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comments(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Comment comment;
                    if (model.Attachment != null && model.Attachment.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(model.Attachment.FileName);
                        string root = Server.MapPath("~/Storage");
                        var upload = new Upload { Type = UploadType.Attachments };
                        db.Uploads.Add(upload);
                        db.SaveChanges();
                        model.Attachment.SaveAs(Path.Combine(root, upload.Id.ToString() + ext));
                        model.FileId = upload.Id.ToString();
                    }

                    if (model.Id == 0)
                    {
                        comment = Mapper.Map<Comment>(model);
                        db.Comments.Add(comment);
                    }
                    else
                    {
                        comment = db.Comments.Find(model.Id);
                        Mapper.Map(model, comment);
                    }
                    db.SaveChanges();

                    return RedirectToAction("Comments")
                        .WithSuccess(string.Format("Comment has been added".TA()));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }

        public ActionResult CustomerInfo()
        {
            string languageCode = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            ViewBag.Nationality = db.BusinessLists.Where(luk => luk.ListType == "Nationality").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Age = db.BusinessLists.Where(luk => luk.ListType == "Age").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Region = db.BusinessLists.Where(luk => luk.ListType == "Region").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            var model = new CustomerInfoViewModel();
            model.Questions = GetQuestions(2);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerInfo(CustomerInfoViewModel model)
        {
            string languageCode = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            ViewBag.Nationality = db.BusinessLists.Where(luk => luk.ListType == "Nationality").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Age = db.BusinessLists.Where(luk => luk.ListType == "Age").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            ViewBag.Region = db.BusinessLists.Where(luk => luk.ListType == "Region").ToList().Select(luk => new SelectListItem
            {
                Value = luk.Key,
                Text = (languageCode == "en") ? luk.Text : luk.TextLocalized
            });

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerInformation custInfo = new CustomerInformation
                    {
                        Name = model.Name,
                        Phone = model.Phone,
                        Email = model.Email,
                        Gender = model.Gender,
                        Age = model.Age,
                        Nationality = model.Nationality,
                        Region = model.Region,                        
                    };

                    db.CustomerInformations.Add(custInfo);
                    db.SaveChanges();

                    for (int i = 0; i < model.Questions.Count; i++)
                    {
                        var q = new QuestionAnswer
                        {
                            QuestionId = model.Questions[i].Id,
                            AnswerId = model.Questions[i].Value,
                            QuestionGroupId = model.Questions[i].QuestionGroupId,
                            AnswerGroupId = model.Questions[i].AnswerGroupId,
                            parentId = custInfo.Id,
                        };
                        db.QuestionAnswers.Add(q);
                    }

                    db.SaveChanges();

                    return RedirectToAction("Questionnaire")
                        .WithSuccess(string.Format("Data has been added Successfully".TA()));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }

        public ActionResult Distributors()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Distributors(DistributorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Distributor distributor;
                    if (model.Id == 0)
                    {
                        distributor = Mapper.Map<Distributor>(model);
                        db.Distributors.Add(distributor);
                    }
                    else
                    {
                        distributor = db.Distributors.Find(model.Id);
                        Mapper.Map(model, distributor);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Distributors")
                        .WithSuccess(string.Format("Distributor has been added".TA()));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContactUs contact;
                    if (model.Id == 0)
                    {
                        contact = Mapper.Map<ContactUs>(model);
                        db.ContactUs.Add(contact);
                    }
                    else
                    {
                        contact = db.ContactUs.Find(model.Id);
                        Mapper.Map(model, contact);
                    }
                    db.SaveChanges();
                    return RedirectToAction("ContactUs")
                        .WithSuccess(string.Format("Contact Information has been added".TA()));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult Photos()
        {
            return View();
        }

        public ActionResult Branches()
        {
            return View();
        }

        public ActionResult Certificates()
        {
            return View();
        }

        public ActionResult CompanyProfile()
        {
            return View();
        }

        public ActionResult CompanyGoals()
        {
            return View();
        }

        public ActionResult CompanyMessage()
        {
            return View();
        }

        public ActionResult Partnership()
        {
            return View();
        }
    }   
}