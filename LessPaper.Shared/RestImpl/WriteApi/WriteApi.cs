using System;
using System.Collections.Generic;
using System.Text;
using LessPaper.Shared.Interfaces.WriteApi;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;

namespace LessPaper.Shared.RestImpl.WriteApi
{
    class WriteApi: IWriteApi
    {
        public IWriteObjectApi ObjectApi { get; set; }
    }
}
