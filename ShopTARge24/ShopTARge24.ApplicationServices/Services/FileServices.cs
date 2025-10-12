using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;

namespace ShopTARge24.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopTARge24Context _context;

        public FileServices
            (
                ShopTARge24Context context
            )
        {
            _context = context;
        }

        public async Task UploadFilesToDB(KindergartenDto dto, Kindergarten domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDB files = new FileToDB()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = file.FileName,
                            KindergartenId = domain.Id,
                        };
                        file.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDBs.Add(files);
                    }
                }
            }
        }
    }
}
