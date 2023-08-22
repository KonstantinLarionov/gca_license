using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Domain.Requests.License;
using LicenseServiceGCA.Application.Domain.Responses.License;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LicenseServiceGCA.Infrastructure.Api.Controllers
{
	[ApiController]
	[Route( "/License/" )]
	[DisplayName( "License" )]
	[Produces( "application/json" )]
	public class LicenseController : ControllerBase
	{
		private readonly IMediator _mediator;

		/// <summary>
		/// LicenseController
		/// </summary>
		/// <param name="mediator"></param>
		public LicenseController( IMediator mediator )
		{
			_mediator = mediator ?? throw new ArgumentNullException( nameof( mediator ) );
		}

		/// <summary>
		/// GET License
		/// </summary>
		/// <param name="request">GetListLicense</param>
		/// <returns></returns>
		[HttpGet]
		[Route( "checkLicense" )]
		[SwaggerResponse( StatusCodes.Status200OK, "GET 200 License", typeof( GetLicenseRequest ) )]
		[SwaggerResponse( StatusCodes.Status400BadRequest, "GET 400 License", typeof( GetLicenseRequest ) )]
		public async Task<IActionResult> CheckLicense( [FromQuery] GetLicenseRequest request )
		{
			var resp = await _mediator.Send( request );

			if ( resp.Success )
				return Ok( resp );
			else
				return BadRequest( resp );
		}
	}
}
