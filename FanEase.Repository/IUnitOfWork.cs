using FanEase.Repository.Interfaces;

namespace FanEase.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //IVideoService videoService { get; }
        void Commit();
    }
}
