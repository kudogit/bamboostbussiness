using Bamboo.Core.Entities;
using Bamboo.Data.File;
using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories.File
{
    [ScopeDependency(ServiceType = typeof(IFileRepository))]
    public class FileRepository : EntityRepository<FileEntity>, IFileRepository
    {
        public FileRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
