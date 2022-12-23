using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.DataAccess.Concrete.EntityFramework.Contexts
{
    public sealed class MsDbContext : ProjectDbContext
    {
        IHttpContextAccessor _httpContextAccessor;

        public const string DEFAULT_SCHEMA = "dbo";
        public const string CONST_SCHEMA = "Const";

        public MsDbContext(DbContextOptions<MsDbContext> options, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(options, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
