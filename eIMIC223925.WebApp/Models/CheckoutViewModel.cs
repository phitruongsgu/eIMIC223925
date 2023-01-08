using eIMIC223925.ViewModels.Sales;
using System.Collections.Generic;

namespace eIMIC223925.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}
