using LicenseServiceGCA.Application.Domain.Requests.License;
using LicenseServiceGCA.Application.Domain.Requests.Token;
using LicenseServiceGCA.Application.Domain.Responses.Token;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Infrastructure.Api.Controllers
{
	[ApiController]
	[Route("/Token/")]
	[DisplayName("Token")]
	[Produces("application/json")]	
	public class TokenController : ControllerBase
	{
		private readonly IMediator _mediator;

		/// <summary>
		/// LicenseController
		/// </summary>
		/// <param name="mediator"></param>
		public TokenController(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}
		/// <summary>
		/// Get User JWT TOKEN
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("GetToken")]
		[AllowAnonymous]
		[SwaggerResponse(StatusCodes.Status200OK, "GET 200 License", typeof(GetTokenRequest))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, "GET 400 License", typeof(GetTokenRequest))]
		public async Task<IActionResult> GetToken([FromQuery] GetTokenRequest request)
		{			
			var resp = await _mediator.Send(request);

			if (resp.Success)
				return Ok(resp);
			else
				return BadRequest(resp);
		}
	}
}