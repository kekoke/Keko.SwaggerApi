using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Keko.SwaggerApi.Entities
{
    [Table("Contact")]
    public class Contact : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
