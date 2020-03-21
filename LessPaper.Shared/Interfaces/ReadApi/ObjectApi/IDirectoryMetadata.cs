namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
{
    public interface IDirectoryMetadata: IMinimalDirectoryMetadata
    {
        /// <summary>
        /// Information of file childs
        /// </summary>
        IFileMetadata[] FileChilds { get; }

        /// <summary>
        /// Minimal information of directory childs
        /// </summary>
        IMinimalDirectoryMetadata[] DirectoryChilds { get; }
    }
}
