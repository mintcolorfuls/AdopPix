﻿using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly ITokenPaymentService tokenPaymentService;
        private readonly IPaymentLoggingProcedure paymentLoggingProcedure;
        private readonly IUserProfileProcedure userProfileProcedure;

        public PaymentController(IUnitOfWork unitOfWork,
                               UserManager<User> userManager,
                               ITokenPaymentService tokenPaymentService,
                               IPaymentLoggingProcedure paymentLoggingProcedure,
                               IUserProfileProcedure userProfileProcedure)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.tokenPaymentService = tokenPaymentService;
            this.paymentLoggingProcedure = paymentLoggingProcedure;
            this.userProfileProcedure = userProfileProcedure;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfile = await unitOfWork.UserProfile.GetByIdAsync(user.Id);

            TopUpViewModel topUpViewModel = new TopUpViewModel
            {
                CurrentMoney = userProfile.Money,
                Money = 0,
            };

            return View(topUpViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(TopUpViewModel model, string omiseToken, string omiseSource)
        {
            if(!ModelState.IsValid) return View(model);
            if(string.IsNullOrEmpty(omiseToken)) return BadRequest();
            if(model.Money < 20)
            {
                ModelState.AddModelError("Money", "The amount must be greater than 20 thb.");
                return View(model);
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var chargeId = await tokenPaymentService.CreateCharge(model.Money, "THB", omiseToken);
            var chargeDetail = await tokenPaymentService.GetChargeById(chargeId);

            PaymentLogging paymentLogging = new PaymentLogging
            {
                UserId = user.Id,
                Charge = chargeDetail.Charge,
                Name = chargeDetail.Name,
                Amount = chargeDetail.Amount,
                Currency = chargeDetail.Currency,
                Brand = chargeDetail.Brand,
                Financing = chargeDetail.Financing,
                Created = DateTime.Now
            };

            await paymentLoggingProcedure.CreateAsync(paymentLogging);

            var userProfile = await userProfileProcedure.FindByIdAsync(user.Id);
            userProfile.Money += chargeDetail.Amount;
            await userProfileProcedure.UpdateAsync(userProfile);

            return Redirect("/Payment");
        }
    }
}
