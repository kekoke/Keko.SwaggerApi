using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Keko.SwaggerApi.Entities
{
    [Table("Address")]
    public class Address:Entity
    {
        public string Street { get; set; }
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

    }
}
