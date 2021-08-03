using CTechnology.BookPricingApi.Api.Features.BookPricing.Commands;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Handlers;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Models;
using CTechnology.BookPricingApi.Api.Features.BookPricing.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CTechnology.BookPricingApi.Api.Features.BookPricing.Controllers
{
    [ApiController]
    [Route("/book-prices")]
    public class BookPricesController : ControllerBase
    {
        private readonly IBookPriceCommandsHandler _commandsHandler;
        private readonly IBookPriceQueriesHandler _queriesHandler;

        public BookPricesController(IBookPriceCommandsHandler commandsHandler, IBookPriceQueriesHandler queriesHandler)
        {
            _commandsHandler = commandsHandler ?? throw new ArgumentNullException(nameof(commandsHandler));
            _queriesHandler = queriesHandler ?? throw new ArgumentNullException(nameof(queriesHandler));
        }

        /// <summary>
        /// Creates a new price of a specific book.
        /// </summary>
        /// <param name="command">Model of request body to create a new price associated to a specific book.</param>
        /// <returns>No specific return.</returns>
        /// <response code="201">Success: The price is created.</response>
        /// <response code="400">Bad Request: Check details in body.</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult> Post([FromBody] CreateBookPriceCommand command)
        {
            var result = await _commandsHandler.HandleAsync(command);
            return result switch
            {
                SuccessHandleResult success => CreatedAtRoute(nameof(GetOne), new { id = success.Id }, result),
                BadRequestHandleResult _ => BadRequest(),
                _ => throw new NotSupportedException()
            };
        }


        /// <summary>
        /// Retrieves an existing price.
        /// </summary>
        /// <param name="id">The price identifier.</param>
        /// <returns>Single price.</returns>
        /// <remarks>
        /// <strong>Remarks</strong> : In memory storage context, an initializing of price collection is performed.
        /// For testing, the following book identifier can be used to retrieve an existing book :
        /// <strong>94235bd9-a208-4b53-aca5-bd2b665656fb</strong>
        /// </remarks>
        /// <response code="200">Success: The price is retrieved.</response>
        /// <response code="404">Not Found: The book does not exist.</response>
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<BookPrice>> GetOne([FromRoute] Guid id)
        {
            var query = new GetBookPriceQuery(id);
            var result = await _queriesHandler.HandleAsync(query);
            return result switch
            {
                SuccessHandleResult<BookPrice> success => Ok(success.Result),
                NotFoundHandleResult _ => NotFound(),
                _ => throw new NotSupportedException()
            };
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<List<BookPrice>>> FindAll([FromQuery] Guid bookId)
        {
            var query = new FindAllBookPricesQuery(bookId);
            var result = await _queriesHandler.HandleAsync(query);
            return result switch
            {
                SuccessHandleResult<IEnumerable<BookPrice>> success => Ok(success.Result),
                NotFoundHandleResult _ => NotFound(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
