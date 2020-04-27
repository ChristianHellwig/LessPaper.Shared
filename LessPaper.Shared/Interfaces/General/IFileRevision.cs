using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Interfaces.General
{
    public interface IFileRevision
    {
        /// <summary>
        /// Revisionsnummer
        /// </summary>
        uint RevisionNumber { get; }

        /// <summary>
        /// Size of the object in Bytes
        /// </summary>
        uint SizeInBytes { get; }

        /// <summary>
        /// Date of last change
        /// </summary>
        DateTime ChangeDate { get; }

        /// <summary>
        /// File name
        /// </summary>
        string BlobId { get; }
    }
}
