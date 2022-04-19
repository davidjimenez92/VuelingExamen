using System;
using System.Configuration;
using System.IO;
using VuelingExamen.CrossCutting.ProjectConfiguration;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;

namespace VuelingExamen.Infrastructure.Repositories.Implementations
{
    public class TextFileRepository : IFileRepository<Registry>
    {
        private static readonly VuelingExamenConfiguration config = ConfigurationManager.GetSection(nameof(VuelingExamenConfiguration)) as VuelingExamenConfiguration;
        public bool Add(Registry entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (StreamWriter streamWriter = File.AppendText(config.TextFilePath))
            {
                streamWriter.WriteLine(entity);
            }

            return true;
        }
    }
}
