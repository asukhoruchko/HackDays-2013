using Umbrella.Core;

namespace Umbrella.BL.Services
{
    public class UmbrellaService
    {
        private readonly CdManager cdManager = new CdManager();

        public void Do()
        {
            cdManager.OpenDrives();
        }
    }
}
