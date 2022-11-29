using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleNet5.Factory
{
    public interface IFileFactory
    {
        void ReadFile();

        void BodyStream();
    }
}
