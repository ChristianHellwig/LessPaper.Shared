using LessPaper.Shared.Interfaces.ReadApi;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    class ReadApi : IReadApi
    {
        public IReadObjectApi ObjectApi { get; }
    }
}
