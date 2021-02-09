using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class EstadoConfig
    {
        public EstadoConfig(EntityTypeBuilder<Estado> entityTypeBuilder)
        {
        }
    }
}
