using LessPaper.Shared.Enums;

namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
{
    public interface ITag
    {
        string Value { get; }

        float Relevance { get; }

        TagSource Source { get; }
    }
}
