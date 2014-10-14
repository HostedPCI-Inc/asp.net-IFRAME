using System;
using System.ComponentModel.DataAnnotations;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class CreditCardModel
    {
        public string CardBin { get; set; }

        [Required]
        public string CardType { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public int ExpirationMonth { get; set; }

        [Required]
        public int ExpirationYear { get; set; }

        [Required]
        public string CvvCode { get; set; }

        public static CreditCard ConvertToDomain(CreditCardModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new CreditCard(model.CardType, model.CardNumber, model.ExpirationMonth,
                model.ExpirationYear, model.CvvCode);
        }
    }
}