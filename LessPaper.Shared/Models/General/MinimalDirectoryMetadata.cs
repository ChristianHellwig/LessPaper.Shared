using System;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Models.General
{
    public class MinimalDirectoryMetadata: Metadata, IMinimalDirectoryMetadata
    {
        public uint NumberOfChilds { get; set; }

    }
}
