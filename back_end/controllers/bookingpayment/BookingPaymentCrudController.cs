// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/bookingpayment/bookingpaymentcrud")]
// public class BookingPaymentCrudController : ControllerBase
// {
//     private readonly DataBookingPaymentCrud _data;

//     public BookingPaymentCrudController(DataBookingPaymentCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] BookingPaymentCrud payment)
//     {
//         var result = await _data.CreateAsync(payment);
//         return Ok(result);
//     }

//     [HttpPost("update/{paymentId:int}")]
//     public async Task<IActionResult> Update(int paymentId, [FromBody] BookingPaymentCrud payment)
//     {
//         var result = await _data.UpdateAsync(paymentId, payment);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{paymentId:int}")]
//     public async Task<IActionResult> Delete(int paymentId)
//     {
//         var result = await _data.DeleteAsync(paymentId);
//         return Ok(result);
//     }
// }
