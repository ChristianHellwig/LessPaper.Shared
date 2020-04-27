using System;
using System.Collections.Generic;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Models.General
{
    public class DirectoryMetadata : MinimalDirectoryMetadata, IDirectoryMetadata
    {

        public IFileMetadata[] FileChilds { get; set; }

        public IMinimalDirectoryMetadata[] DirectoryChilds { get; set; }
    }
}
