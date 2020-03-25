using LessPaper.Shared.Interfaces.ReadApi;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    class ReadApi : IReadApi
    {
        public ReadApi(IReadObjectApi objectApi)
        {
            this.ObjectApi = objectApi;
        }

        public IReadObjectApi ObjectApi { get; }
    }
}
