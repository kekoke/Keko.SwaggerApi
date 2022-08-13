using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Keko.SwaggerApi.Core.Entities
{
    [Table("TodoItem")]
    public class TodoItem : Entity
    {
        public string Text { get; set; }
        public string Seq { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime TargetTime{ get; set; }

    }
}
