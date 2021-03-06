﻿using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.DocFx
{
    /// <summary>
    /// Command line runner for the 'docfx metadata' command.
    /// </summary>
    public sealed class DocFxMetadataRunner : DocFxTool<DocFxMetadataSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxMetadataRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DocFxMetadataRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs DocFx for the current folder with the given configuration.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(DocFxMetadataSettings settings)
        {
            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(DocFxMetadataSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("metadata");

            // parameters
            if (settings.Projects != null && settings.Projects.Any())
                builder.Append(string.Join(",", settings.Projects.Select(val => val.FullPath)));

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            return builder;
        }
    }
}
