namespace LessPaper.Shared.Interfaces.General
{
    public interface IMetadata
    {
        /// <summary>
        /// Filename
        /// </summary>
        string ObjectName { get; }

        /// <summary>
        /// Unique object id
        /// </summary>
        string ObjectId { get; }

        /// <summary>
        /// Size of the object in Byte
        /// </summary>
        uint SizeInByte { get; }
    }
}
