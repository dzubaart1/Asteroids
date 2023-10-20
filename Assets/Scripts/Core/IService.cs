using System.Threading.Tasks;
using Platform;

namespace Core
{
    public interface IService
    {
        public Task InitializeServiceAsync();
        public void ResetService();
        public void DestroyService();
    }
    
    public interface IService<TConfig> : IService where TConfig : Configuration
    {
        public TConfig Configuration { get; }
    }
}