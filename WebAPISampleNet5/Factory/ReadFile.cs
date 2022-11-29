using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPISampleNet5.Factory
{
    public class ReadFile
    {
        IFileFactory factory;
        public ReadFile()
        {

        }


        public IFileFactory Init(IFormFile file)
        {
            string extension = file.FileName.Split(".").Last().ToLower();

            switch (extension)
            {
                case "csv":
                    {
                        return new CsvFactory();
                    }
                case "json":
                    {
                        return new JsonFactory();
                    }
                default:
                    return new CsvFactory();

            }
        }




    }
}
