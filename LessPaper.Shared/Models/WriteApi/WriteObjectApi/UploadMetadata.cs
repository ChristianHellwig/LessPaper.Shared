using System;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using LessPaper.Shared.Models.General;

namespace LessPaper.Shared.Models.WriteApi.WriteObjectApi
{
    public class UploadMetadata : Metadata, IUploadMetadata
    {
        public uint QuickNumber { get; set; }
    }
}
