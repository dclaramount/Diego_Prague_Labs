using System;
using AutoMapper;
using DeveloperTest.Entities;
using DeveloperTest.Models;
using DeveloperTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers
{
    [ApiController]
    [Route("api/store")]
    [Authorize(Policy = "MustBeUser")]
    public class StoreController : ControllerBase
    {
        public readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


        }

        /// <summary>
        /// Returns an Invoice based on the InvoiceId
        /// </summary>
        /// <param name="includeDetails">Includes the list of items in the invoice</param>
        /// <param name="includeUserAccount">Includes the User Information (if exist) linked to the Invoice</param>
        /// <returns>An IAction Result</returns>
        /// <response code="200">Returns the requested Invoice</response>
        /// <response code="400">Values provided do not match the type/expected one.</response>
        /// <response code="404">Invoice requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while retrieving the Invoice.</response>
        [HttpGet]
        [Route("invoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInvoice(int invoiceId, bool includeDetails = false, bool includeUserAccount = false)
        {
            if (!await _storeRepository.InvoiceExist(invoiceId))
            {
                return NotFound();
            }
            var invoiceEntity = await _storeRepository.GetInvoiceAsync(invoiceId);
            if (invoiceEntity == null)
            {
                return NotFound();
            }
            if (includeDetails && !includeUserAccount)
                return Ok(_mapper.Map<InvoiceWithDetailsDto>(invoiceEntity));
            else if (!includeDetails && includeUserAccount)
                return Ok(_mapper.Map<InvoiceWithUserAccountDto>(invoiceEntity));
            else if (includeDetails && includeUserAccount)
                return Ok(_mapper.Map<InvoiceWithDetailsAndUserAccountDto>(invoiceEntity));

            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoiceEntity));
        }

        /// <summary>
        /// Get List of Unpaid Invoices
        /// </summary>
        /// <param name="includeDetails">Includes the list of items in the invoice</param>
        /// <param name="includeUserAccount">Includes the User Information (if exist) linked to the Invoice</param>
        /// <returns>List of Unpaid Invoices</returns>
        /// <response code="200">Returns the list of ALL the Unpaid Invoice</response>
        /// <response code="400">One of the values provided as optional are of the wrong type</response>
        /// <response code="500">Internal Server Error while retrieving the List of Invoices.</response>
        [HttpGet]
        [Route("unpaidInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUnpaidInvoices(bool includeDetails=false, bool includeUserAccount=false)
        {
            Console.WriteLine(User.Claims);
            var invoiceEntities = await _storeRepository.GetInvoicesAsync("Unpaid");

            if (includeDetails && !includeUserAccount)
                return Ok(_mapper.Map<IEnumerable<InvoiceWithDetailsDto>>(invoiceEntities));
            else if (!includeDetails && includeUserAccount)
                return Ok(_mapper.Map<IEnumerable<InvoiceWithUserAccountDto>>(invoiceEntities));
            else if (includeDetails && includeUserAccount)
                return Ok(_mapper.Map<IEnumerable<InvoiceWithDetailsAndUserAccountDto>>(invoiceEntities));

            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoiceEntities));
        }
        /// <summary>
        /// Fetchs a User Account based on the User Account Id
        /// </summary>
        /// <param name="userAccountId"></param>
        /// <returns>An Action Result of the Type User Account</returns>
        /// <response code="200">Returns the requested User Account</response>
        /// <response code="400">Values provided do not match the type/expected one.</response>
        /// <response code="404">User Account requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while retrieving the User Account.</response>
        [HttpGet]
        [Route("userAccount/{userAccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserAccountDto>> GetUserAccount(int userAccountId)
        {
            if (!await _storeRepository.UserAccountExist(userAccountId))
            {
                return NotFound();
            }
            var userAccountEntity = await _storeRepository.GetUserAccountAsync(userAccountId);
            if (userAccountEntity == null)
            {
                return NotFound();
            }
            return (_mapper.Map<UserAccountDto>(userAccountEntity));
        }
        /// <summary>
        /// Fetchs an Invoice Line based on the Invoice Line Id
        /// </summary>
        /// <param name="userAccountId"></param>
        /// <returns>An Action Result of the Type Invoice Line</returns>
        /// <response code="200">Returns the requested Invoice Line</response>
        /// <response code="400">Values provided do not match the type/expected one.</response>
        /// <response code="404">Invoice Line requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while retrieving the Invoice Line.</response>
        [HttpGet]
        [Route("invoiceLine/{invoiceLineId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InvoiceLineDto>> GetInvoiceLine(int invoiceLineId)
        {
            if (!await _storeRepository.InvoiceLineExist(invoiceLineId))
            {
                return NotFound();
            }
            var invoiceLineEntity = await _storeRepository.GetInvoiceLineAsync(invoiceLineId);
            if (invoiceLineEntity == null)
            {
                return NotFound();
            }
            return (_mapper.Map<InvoiceLineDto>(invoiceLineEntity));
        }
        /// <summary>
        /// Fetchs an Item based on Item Id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>An Action Result of the Type Item</returns>
        /// <response code="200">Returns the requested Item</response>
        /// <response code="400">Values provided do not match the type/expected one.</response>
        /// <response code="404">Item requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while retrieving the Item.</response>
        [HttpGet]
        [Route("item/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ItemDto>> GetItem(int itemId)
        {
            if (!await _storeRepository.ItemExist(itemId))
            {
                return NotFound();
            }
            var itemEntity = await _storeRepository.GetItemAsync(itemId);
            if (itemEntity == null)
            {
                return NotFound();
            }
            return (_mapper.Map<ItemDto>(itemEntity));
        }
        /// <summary>
        /// Updates the Status of Invoice
        /// </summary>
        /// <param name="invoiceId">Invoice Id that for which the status needs to be updated</param>
        /// <param name="newStatus">New Status that wants to be applied in to the requested Invoice ("Paid" or "Unpaid")</param>
        /// <response code="204">Update was Succesfull</response>
        /// <response code="400">Values provided as new Status is not an accepted value.</response>
        /// <response code="404">Item requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while updating the Invoice.</response>
        [HttpPut("updateStatus/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateInvoiceStatus(int invoiceId, string newStatus)
        {
            if (!await _storeRepository.InvoiceExist(invoiceId))
            {
                return NotFound();
            }
            var invoice = await _storeRepository.GetInvoiceAsync(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            if(newStatus=="Unpaid" || newStatus=="Paid")
            {
                invoice.Status = newStatus;
            }
            else
            {
                return BadRequest();
            }
            await _storeRepository.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// End Point to Edit General Fields (User Account and Invoice Related Fields NOT Invoice Lines or Items)
        /// </summary>
        /// <param name="invoiceId">Invoice Id that for which we want to edit</param>
        /// <param name="patchDocument">Pre-structured JSON that provides the schema of updates</param>
        /// <response code="204">Update was Succesfull</response>
        /// <response code="400">Values provided as the requested new ones are not accepted in the model.</response>
        /// <response code="404">Invoice requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while updating the Invoice.</response>
        [HttpPatch("updateInvoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateInvoice(int invoiceId, JsonPatchDocument<InvoiceWithDetailsAndUserAccountForUpdateDto> patchDocument)
        {
            if (patchDocument.Operations.Where(o => o.path.Contains("invoiceLines") || o.path.Contains("item")).ToList().Count() > 0)
                return BadRequest("You are using the wrong End Point to update this field, please refer to API documentation. You should be using updateLineInvoice/{lineInvoiceId}");
            if (!await _storeRepository.InvoiceExist(invoiceId))
            {
                return NotFound();
            }
            var invoiceEntity = await _storeRepository.GetInvoiceAsync(invoiceId);
            if (invoiceEntity == null)
            {
                return NotFound();
            }
            var invoiceToPatch = _mapper.Map<InvoiceWithDetailsAndUserAccountForUpdateDto>(invoiceEntity);

            patchDocument.ApplyTo(invoiceToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(invoiceToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(invoiceToPatch, invoiceEntity);
            await _storeRepository.SaveChangesAsync();
            return NoContent();
        }


        /// <summary>
        /// End Point to Edit Invoice Lines and their Items under it
        /// </summary>
        /// <param name="lineInvoiceId">Invoice Line Id that for which we want to edit</param>
        /// <param name="patchDocument">Pre-structured JSON that provides the schema of updates</param>
        /// <response code="204">Update was Succesfull</response>
        /// <response code="400">Values provided as the requested new ones are not accepted in the model.</response>
        /// <response code="404">Invoice Line requested was not Found in the Data Base.</response>
        /// <response code="500">Internal Server Error while updating the Invoice.</response>
        [HttpPatch("updateInvoiceLine/{lineInvoiceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateInvoiceLines(int lineInvoiceId, JsonPatchDocument<InvoiceLineForUpdateDto> patchDocument)
        {
            if (!await _storeRepository.InvoiceLineExist(lineInvoiceId))
            {
                return NotFound();
            }
            var invoiceLineEntity = await _storeRepository.GetInvoiceLineAsync(lineInvoiceId);
            if (invoiceLineEntity == null)
            {
                return NotFound();
            }
            var invoiceLineToPatch = _mapper.Map<InvoiceLineForUpdateDto>(invoiceLineEntity);

            patchDocument.ApplyTo(invoiceLineToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(invoiceLineToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(invoiceLineToPatch, invoiceLineEntity);
            await _storeRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}

