﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _TopAddressPartial : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _TopAddressPartial(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _addressService.GetListAll();
			return View(values);
		}
	}
}
