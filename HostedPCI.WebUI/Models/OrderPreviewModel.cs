using HostedPCI.WebUI.Models.Entities;

namespace HostedPCI.WebUI.Models
{
    public class OrderPreviewModel
    {
        public CustomerInfoModel Customer { get; set; }
        public OrderModel Order { get; set; }
        public CreditCardModel CreditCard { get; set; }
    }
}