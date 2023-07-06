using BLL.Services.DI.Abstract;
using Common.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using StoreOrderManager.Models;

namespace StoreOrderManager.Controllers
{
    [Route("/")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private const int pageSize = 10;
        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index() => Redirect("orders/page/1");
        // GET: OrderController
        [HttpGet("orders/page/{page}")]
        public async Task<IActionResult> OrdersList(int page = 1)
        {
            int totalOrders;
            List<OrderDTO> orders;

            totalOrders = _orderService.TotalOrders;
            orders = (await _orderService.GetOrderPageAsync(page, pageSize)).ToList();

            var pager = new Pager(totalOrders, page, pageSize);
            ViewBag.Pager = pager;

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
