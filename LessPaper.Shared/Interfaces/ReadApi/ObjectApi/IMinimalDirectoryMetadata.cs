using System;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
{
    public interface IMinimalDirectoryMetadata: IMetadata
    {
        /// <summary>
        /// Number of total childs in the directory
        /// </summary>
        uint NumberOfChilds { get; }

        /// <summary>
        /// Date of last change
        /// </summary>
        DateTime LatestChangeDate { get; }

        /// <summary>
        /// Date of last view
        /// </summary>
        DateTime LatestViewDate { get; }
    }
}
