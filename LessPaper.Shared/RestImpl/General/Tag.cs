using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.RestImpl.General
{
    class Tag : ITag
    {

        public string Value { get; set; }

        public float Relevance { get; set; }

        public TagSource Source { get; set;  }
    }
}
