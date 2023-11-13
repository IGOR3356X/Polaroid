using Polaroid.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polaroid.ContentObjects
{
    internal class Connect
    {
        public static PolaroidEntities connect {  get; set; } = new PolaroidEntities();
    }
}
