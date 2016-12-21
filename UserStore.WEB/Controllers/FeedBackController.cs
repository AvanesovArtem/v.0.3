using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using UserStore.BLL.Interfaces;
using PizzaShopThreeLayer.Models;
using UserStore.BLL.DTO;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class FeedBackController : Controller
    {
        private ICommentService _commentService;

        public FeedBackController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public ActionResult Comments()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var comments = _commentService.GetAllComment();

            return View("FeedBack",comments);
        }

        [HttpGet]
        public ActionResult Remove(int ?ide)
        {
            if (ide != null)
            {
                _commentService.DeleteComment((int)ide);
            }
            return PartialView("Remove");
        }
        [Authorize]
        public ActionResult AddComment(UploadFeedbackModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DateTime = DateTime.Now.ToLocalTime();
                viewModel.UserName = User.Identity.Name;

                Mapper.Initialize(cfg => cfg.CreateMap<UploadFeedbackModel, CommentDTO>());
                var commentDto = Mapper.Map<UploadFeedbackModel, CommentDTO>(viewModel);
                _commentService.CreateComment(commentDto);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("AddCommentPartial", viewModel);
                }
                else
                {
                    return RedirectToAction("Comments");
                }

            }
            ModelState.AddModelError("","Сообщение не может быть пустым");
            return View("FeedBack", viewModel);

        }
    }
}