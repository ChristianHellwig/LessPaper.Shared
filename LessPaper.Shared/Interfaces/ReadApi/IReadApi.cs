using System;
using System.Collections.Generic;
using System.Text;
using LessPaper.Shared.Interfaces.ReadApi.ObjectApi;

namespace LessPaper.Shared.Interfaces.ReadApi
{
    public interface IReadApi
    {
        IObjectApi FilesApi { get; }
    }
}
