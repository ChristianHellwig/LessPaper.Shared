using System;

namespace LessPaper.Shared.Interfaces.General
{
    public interface IMetadata
    {
        /// <summary>
        /// Filename
        /// </summary>
        string ObjectName { get; }

        /// <summary>
        /// Unique object id
        /// </summary>
        string ObjectId { get; }

        /// <summary>
        /// Size of the object in Bytes
        /// </summary>
        uint SizeInBytes { get; }

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
