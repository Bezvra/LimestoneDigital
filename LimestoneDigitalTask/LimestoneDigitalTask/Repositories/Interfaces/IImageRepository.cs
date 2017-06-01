using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimestoneDigitalTask.Repositories.Interfaces
{
    public interface IImageRepository
    {
        string GetImage(int id);
        List<string> GetImages(int id);
    }
}
