using System;

namespace LessPaper.Shared.Interfaces.General
{
    public interface IMinimalDirectoryMetadata: IMetadata
    {
        /// <summary>
        /// Number of total childs in the directory
        /// </summary>
        uint NumberOfChilds { get; }
    }
}
