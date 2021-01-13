using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Models.Invoice
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string CartId { get; set; }

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string Comment { get; set; }
    }
}
