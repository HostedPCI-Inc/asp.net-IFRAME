using System.Web.Mvc;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Models;
using HostedPCI.WebUI.Helpers;
using HostedPCI.WebUI.Models;
using HostedPCI.WebUI.Models.Entities;

namespace HostedPCI.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHostedPciService _service;
        private readonly IHostedPciDataConverter _converter;
        private readonly IHostedPciConfiguration _configuration;

        private readonly CustomerInfoModel _customer = DummyDataHelper.CreateCustomer();
        private readonly OrderModel _order = DummyDataHelper.CreateOrder();
        private readonly TransactionModel _transaction = DummyDataHelper.CreateTransaction();

        public OrderController(IHostedPciService service, IHostedPciDataConverter converter, IHostedPciConfiguration configuration)
        {
            _service = service;
            _converter = converter;
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            return RedirectToAction("checkout");
        }

        public ActionResult Checkout()
        {
            var model = new OrderPreviewModel
            {
                Customer = _customer,
                Order = _order
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Preview(CreditCardModel model)
        {
            if (!ModelState.IsValid)
                return null;

            return View(model);
        }

        [HttpPost]
        public ActionResult Auth(CreditCardModel model)
        {
            var card = CreditCardModel.ConvertToDomain(model);
            var transaction = TransactionModel.ConvertToDomain(_transaction);
            var customer = CustomerInfoModel.ConvertToDomain(_customer);
            var order = OrderModel.ConvertToDomain(_order);
            var threeDSec = new ThreeDSec("verifyenroll");
            var request = new AuthRequest(card, transaction, customer, order, threeDSec);

            string url;
            string rawRequest;
            string rawResponse;

            var response = _service.Send(_converter, _configuration.GetConfigurationSettings(),
                request, out url, out rawRequest, out rawResponse);

            var responseModel = new RequestResultModel(response, url, rawRequest, rawResponse);

            return View("Response", responseModel);
        }
    }
}
