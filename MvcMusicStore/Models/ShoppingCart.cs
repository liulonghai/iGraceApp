using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    public partial class ShoppingCart
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //默认是public还是private
        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        /// <summary>
        /// 根据上下文信息，获取购物车
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        /// <summary>
        /// 获取或生成购物车Id
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCardId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCardId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        /// <summary>
        /// 根据上下文信息，获取购物车
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        /// <summary>
        /// 把专辑添加到购物车
        /// </summary>
        /// <param name="album"></param>
        public void AddToCart(Album album)
        {
            //找到当前用户的购物车，并从中获取当前专辑
            var cartItem = storeDB.Carts.FirstOrDefault(
                c => c.CardId == ShoppingCartId && c.AlbumId == album.AlbumId
                );

            //如果购物车中还没这张专辑
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart()
                {
                    AlbumId = album.AlbumId,
                    CardId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 从购物车中删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carts.Single(
                cart => cart.CardId == ShoppingCartId && cart.RecordId == id
                );

            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }

                //save change
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(cart => cart.CardId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            //save changes
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 获取购物车项
        /// </summary>
        /// <returns></returns>
        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(cart => cart.CardId == ShoppingCartId).ToList();
        }

        /// <summary>
        /// 获取专辑总数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CardId == ShoppingCartId
                          select (int?)cartItems.Count
                              ).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        /// <summary>
        /// 获取专辑总价
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            decimal? total = (
                from cartItems in storeDB.Carts
                where cartItems.CardId == ShoppingCartId
                select (int?)cartItems.Count * cartItems.album.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var cart in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    AlbumId = cart.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = cart.album.Price,
                    Quantity = cart.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (orderDetail.Quantity * orderDetail.UnitPrice);
                storeDB.OrderDetails.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            //save changes
            storeDB.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(cart => cart.CardId == ShoppingCartId);

            foreach (var cart in shoppingCart)
            {
                cart.CardId = userName;
            }
            storeDB.SaveChanges();
        }

    }
}