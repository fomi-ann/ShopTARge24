using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface IFileServices
    {
        Task UploadFilesToDB(KindergartenDto dto, Kindergarten domain);
    }
}
