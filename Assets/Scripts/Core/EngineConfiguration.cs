using Platform;

namespace Platform
{
    public class EngineConfiguration : Configuration
    {
        public static readonly string[] DefaultTypeAssemblies = {"Assembly-CSharp", "OmegaStudio.Platform.Runtime"};

        public string[] TypeAssemblies = DefaultTypeAssemblies;
    }
}
