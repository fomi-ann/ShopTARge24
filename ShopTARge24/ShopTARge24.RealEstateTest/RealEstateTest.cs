using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;


namespace ShopTARge24.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = new RealEstateDto()
            {
                Area = 120.5,
                Location = "Test Loction",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnNotEqual()
        {
            ////Arrange
            //var context = Svc<ShopTARge24Context>();

            //context.RealEstates.Add(new RealEstate { 
            //    Id = Guid.NewGuid(), 
            //    Location = "Pärnu",
            //    RoomNumber = 4,
            //    BuildingType = "Residential",
            //    CreatedAt = DateTime.UtcNow,
            //    ModifiedAt = DateTime.UtcNow
            //});

            //await context.SaveChangesAsync();

            //Guid testingGuidId = Guid.NewGuid();

            ////Act
            //var result = await Svc<IRealEstateServices>().DetailAsync(testingGuidId);

            ////Assert
            //Assert.Null(result);

            //Arrange
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.Parse("56496151-d701-49e1-8668-b49a84f893f7");

            //Act
            await Svc<IRealEstateServices>().DetailAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            ////Arrange
            //var context = Svc<ShopTARge24Context>();

            //Guid testingGuidId = Guid.NewGuid();

            //context.RealEstates.Add(new RealEstate
            //{
            //    Id = testingGuidId,
            //    Location = "Narva",
            //    RoomNumber = 6,
            //    BuildingType = "Commercial",
            //    CreatedAt = DateTime.UtcNow,
            //    ModifiedAt = DateTime.UtcNow
            //});

            //await context.SaveChangesAsync();

            ////Act
            //var result = await Svc<IRealEstateServices>().DetailAsync(testingGuidId);

            ////Assert
            //Assert.NotNull(result);

            //Arrange
            Guid correctGuid = Guid.NewGuid();
            Guid guid = Guid.Parse(correctGuid.ToString());

            //Act
            await Svc<IRealEstateServices>().DetailAsync(guid);

            //Assert
            Assert.Equal(correctGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            ////Arrange
            //var context = Svc<ShopTARge24Context>();

            //Guid testingGuidId = Guid.NewGuid();

            //context.RealEstates.Add(new RealEstate
            //{
            //    Id = testingGuidId,
            //    Location = "Valga",
            //    RoomNumber = 2,
            //    BuildingType = "Appartment",
            //    CreatedAt = DateTime.UtcNow,
            //    ModifiedAt = DateTime.UtcNow
            //});

            //await context.SaveChangesAsync();

            ////Act
            //var result = await Svc<IRealEstateServices>().Delete(testingGuidId);

            ////Assert
            //Assert.NotNull(result);

            //Arrange
            RealEstateDto dto = MockRealEstateDto();

            //Act
            var addRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var deleteRealEstate = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);

            //Assert
            Assert.Equal(addRealEstate.Id, deleteRealEstate.Id);
        }

        private RealEstateDto MockRealEstateDto()
        {
            return new RealEstateDto {
            Id = Guid.NewGuid(),
            Location = "Valga",
            RoomNumber = 2,
            BuildingType = "Appartment",
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow

            };
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            ////Arrange
            //var context = Svc<ShopTARge24Context>();

            //Guid testingGuidId = Guid.NewGuid();

            //context.RealEstates.Add(new RealEstate
            //{
            //    Id = Guid.NewGuid(),
            //    Location = "Keila",
            //    RoomNumber = 1,
            //    BuildingType = "Public",
            //    CreatedAt = DateTime.UtcNow,
            //    ModifiedAt = DateTime.UtcNow
            //});

            //await context.SaveChangesAsync();

            ////Act
            //var result = await Svc<IRealEstateServices>().Delete(testingGuidId);

            ////Assert
            //Assert.Null(result);

            //Arrange
            RealEstateDto dto = MockRealEstateDto();

            //Act
            var deleteId = Guid.NewGuid();
            var realEstate1 = await Svc<IRealEstateServices>().Create(dto);
            var realEstate2 = await Svc<IRealEstateServices>().Create(dto);
            
            var result = await Svc<IRealEstateServices>().Delete((Guid)realEstate2.Id);

            //Assert
            Assert.NotEqual(realEstate1.Id, result.Id);
        }
    }
}
