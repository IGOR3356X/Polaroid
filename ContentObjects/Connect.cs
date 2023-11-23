using Polaroid.DataBase;

namespace Polaroid.ContentObjects
{
    internal class Connect
    {
        public static PolaroidEntities connect { get; set; } = new PolaroidEntities();
    }
}
