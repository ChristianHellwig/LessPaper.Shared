using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Implemenations.General
{
    class Tag : ITag
    {
        public Tag(string value, float relevance, TagSource source)
        {
            this.Value = value;
            this.Relevance = relevance;
            this.Source = source;
        }

        public string Value { get; }

        public float Relevance { get; }

        public TagSource Source { get; }
    }
}
