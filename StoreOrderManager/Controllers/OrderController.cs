using BLL.Services.DI.Abstract;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace StoreOrderManager.Controllers
{
    [Route("/")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        // GET: OrderController
        [HttpGet("orders/")]
        public async Task<IActionResult> OrdersList()
        {
            var orders = await _orderService.GetAllAsync(null, null);
            return View(orders);
        }

        //GET: OrderController/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return View(order);
        }

        //POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDTO order)
        {
            try
            {
                await _orderService.UpdateAsync(id, order);
            }
            catch
            {
                RedirectToAction("Error", "Home");
            }
            return RedirectToAction(nameof(Details), new { id = order.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            var products = new List<ProductDTO>();
            foreach (var orderDetail in order.OrderDetails)
            {
                products.Add(await _productService.GetProductByIdAsync(orderDetail.ProductId));
            }
            ViewBag.Products = products;
            return View(order);
        }
        // GET: OrderController/Delete/5
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
            return RedirectToAction(nameof(OrdersList));
        }
    }
}
