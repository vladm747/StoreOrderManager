using BLL.Services.DI.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StoreOrderManager.Controllers
{
    [Route("/")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: OrderController
        [HttpGet("orders")]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync(null, null);
            return View(orders);
        }


        //// GET: OrderController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrderController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: OrderController/Edit/5
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: OrderController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: OrderController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderConfirmed(int id)
        {
            await _orderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
