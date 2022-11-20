using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.ValidationRules;
using RealEstate.EntityLayer.Concrete;

namespace RealEstate.PresentationLayer.Controllers
{
    public class MemberController : Controller
    {
        IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            var values = _memberService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            MemberValidatior memberValidatior = new MemberValidatior();
            ValidationResult validationResult = memberValidatior.Validate(member);
            if (validationResult.IsValid)
            {
                _memberService.TInsert(member);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }

        public IActionResult DeleteMember(int id)
        {
            var member = _memberService.TGetByID(id);
            _memberService.TDelete(member);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var member = _memberService.TGetByID(id);

            return View(member);
        }
        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.TUpdate(member);

            return RedirectToAction("Index");
        }

    }
}
