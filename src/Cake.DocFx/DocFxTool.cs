﻿using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Base class for the DocFx runners.
    /// </summary>
    /// <typeparam name="TSettings">The type of tool settings to use.</typeparam>
    public abstract class DocFxTool<TSettings> : Tool<TSettings> 
        where TSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        protected DocFxTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>
        /// The name of the tool.
        /// </returns>
        protected override string GetToolName() => "DocFx";

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable names.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames() => new[] {"docfx", "docfx.exe"};
    }
}
