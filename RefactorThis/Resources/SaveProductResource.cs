using Newtonsoft.Json;
using RefactorThis.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefactorThis.Resources
{
    public class SaveProductResource
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public IList<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}
