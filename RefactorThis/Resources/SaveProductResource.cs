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

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal DeliveryPrice { get; set; }
    }
}
