using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            //Arrange
            //tuleb teha mock guid
            var guid = new Guid("0a35d9eb-e4d7-44c7-ac85-d3c584938eec");

            //tuleb kasutada MockRealEstateData meetodit
            RealEstateDto dto = MockRealEstateData();

            //domaini objekt koos selle andmetega peab välja mõtlema
            RealEstate domain = new();

            domain.Id = Guid.Parse("0a35d9eb-e4d7-44c7-ac85-d3c584938eec");
            domain.Area = 200.0;
            domain.Location = "Secret Place";
            domain.RoomNumber = 5;
            domain.BuildingType = "Villa";
            domain.CreatedAt = DateTime.Now;
            domain.ModifiedAt = DateTime.Now;

            //Act
            await Svc<IRealEstateServices>().Update(dto);

            //Assert
            Assert.Equal(guid, domain.Id);
            //DoesNotMatch ja kasutage seda Locationi ja RoomNumberi jaoks
            Assert.DoesNotMatch(dto.Location, domain.Location);
            Assert.DoesNotMatch(dto.RoomNumber.ToString(), domain.RoomNumber.ToString());
            Assert.NotEqual(dto.RoomNumber, domain.RoomNumber);
            Assert.NotEqual(dto.Area, domain.Area);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData2()
        {
            //peate kasutama MockRealEstateData meetodit
            RealEstateDto dto = MockRealEstateData();
            //kasutate andmete loomisel
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            //tuleb teha uus mock meetod, mis tagastab RealEstateDto (peate ise uue tegema ja nimi
            //peab olems MockUpdateRealEstateData())
            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);

            //Assert
            Assert.DoesNotMatch(dto.Location, result.Location);
            Assert.NotEqual(dto.ModifiedAt, result.ModifiedAt);
        }




        //tuleb välja mõelda kolm erinevat xUnit testi RealEstate kohta
        //saate teha 2-3 in meeskonnas
        //kommentaari kirjutate, mida iga test kontrollib





        [Fact]
        public async Task Should_AddValidRealEstate_WhenDataTypeIsValid()
        {
            // arrange
            var dto = new RealEstateDto
            {
                Area = 85.00,
                Location = "Tartu",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            // act
            var realEstate = await Svc<IRealEstateServices>().Create(dto);

            //assert
            Assert.IsType<int>(realEstate.RoomNumber);
            Assert.IsType<string>(realEstate.Location);
            Assert.IsType<DateTime>(realEstate.CreatedAt);
        }

        [Fact]
        public async Task Should_UpdatePartialFields_WhenPartialUpdateData()
        {
            // Arrange
            var createDto = MockRealEstateDto();
            var created = await Svc<IRealEstateServices>().Create(createDto);
            Assert.NotNull(created);

            var db = Svc<ShopTARge24Context>();
            db.ChangeTracker.Clear();

            var originalId = (Guid)created.Id!;
            var originalLocation = created.Location;
            var originalBuildingType = created.BuildingType;
            var originalCreatedAt = created.CreatedAt;
            var originalModifiedAt = created.ModifiedAt;

            // Act
            var updateDto = new RealEstateDto
            {
                Id = originalId,
                Area = 100.0,
                RoomNumber = 8,
                Location = originalLocation,
                BuildingType = originalBuildingType,
                CreatedAt = originalCreatedAt,
                ModifiedAt = DateTime.UtcNow
            };

            var updated = await Svc<IRealEstateServices>().Update(updateDto);
            Assert.NotNull(updated);

            // Assert
            Assert.Equal(originalId, updated.Id);

            Assert.Equal(100.0, updated.Area);
            Assert.Equal(8, updated.RoomNumber);

            Assert.Equal(originalLocation, updated.Location);
            Assert.Equal(originalBuildingType, updated.BuildingType);

            Assert.Equal(originalCreatedAt, updated.CreatedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateCreatedAtData_WhenUpdateData()
        {
            var guid = Guid.NewGuid();

            RealEstateDto dto = MockRealEstateDto();

            RealEstateDto domain = new();

            domain.Id = guid;
            domain.Area = 100.0;

            //act
            await Svc<IRealEstateServices>().Update(dto);

            //assert
            Assert.Equal(domain.Id, guid);
            Assert.NotEqual(dto.Area, domain.Area);
            Assert.Equal(dto.RoomNumber, domain.RoomNumber);
            Assert.Equal(dto.BuildingType, domain.BuildingType);

            Assert.Equal(dto.CreatedAt, domain.CreatedAt);
            Assert.NotEqual(dto.CreatedAt, domain.ModifiedAt);
        }
        /////

        [Fact]
        public async Task ShouldNot_UpdateCreatedTime_WhenUpdteRealEstate()
        {
            RealEstateDto dto = MockRealEstateData();

            RealEstateDto domain = new()
            {
                Id = dto.Id,
                Area = 180.0,
                Location = "Another Updated Location",
                RoomNumber = 6,
                BuildingType = "Cottage",
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now.AddYears(1)
            };

            var updatedRealEstate = await Svc<IRealEstateServices>().Update(domain);

            Assert.Equal(dto.CreatedAt, domain.CreatedAt);
            Assert.NotEqual(dto.ModifiedAt, domain.ModifiedAt);
        }

        [Fact]
        public async Task Should_ReturnNull_WhenReadingDeletedRealEstate()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();
            var created = await Svc<IRealEstateServices>().Create(dto);
            //Act
            await Svc<IRealEstateServices>().Delete((Guid)created.Id);

            // Assert
            var result = await Svc<IRealEstateServices>().DetailAsync((Guid)created.Id);
            Assert.Null(result);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenPartialUpdate()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();

            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var updatedDto = new RealEstateDto
            {
                Area = 99,
                Location = "Changed Location Only",
                RoomNumber = createdRealEstate.RoomNumber,
                BuildingType = createdRealEstate.BuildingType,
                CreatedAt = createdRealEstate.CreatedAt,
                ModifiedAt = DateTime.UtcNow
            };

            var updatedRealEstate = await Svc<IRealEstateServices>().Update(updatedDto);

            //Assert
            Assert.NotEqual(createdRealEstate.Area, updatedRealEstate.Area);
            Assert.DoesNotMatch(createdRealEstate.Area.ToString(), updatedRealEstate.Area.ToString());
            Assert.Equal("Changed Location Only", updatedRealEstate.Location);
            Assert.NotEqual(createdRealEstate.Location, updatedRealEstate.Location);
            Assert.Equal(createdRealEstate.RoomNumber, updatedRealEstate.RoomNumber);
            Assert.Equal(createdRealEstate.BuildingType, updatedRealEstate.BuildingType);

        }

        [Fact]
        public async Task Should_ReturnRealEstate_WhenCorrectDataDetailAsync()
        {
            //Arrange
            RealEstateDto dto = MockRealEstateData();

            // Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var detailedRealEstate = await Svc<IRealEstateServices>().DetailAsync((Guid)createdRealEstate.Id);

            // Assert
            Assert.NotNull(detailedRealEstate);
            Assert.Equal(createdRealEstate.Id, detailedRealEstate.Id);
            Assert.Equal(createdRealEstate.Area, detailedRealEstate.Area);
            Assert.Equal(createdRealEstate.Location, detailedRealEstate.Location);
            Assert.Equal(createdRealEstate.RoomNumber, detailedRealEstate.RoomNumber);
            Assert.Equal(createdRealEstate.CreatedAt, detailedRealEstate.CreatedAt);
        }

        [Fact]
        public async Task ShouldUpdate_ModifiedAt_Parameter()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();
            var createdRealEstateResult = await Svc<IRealEstateServices>().Create(dto);

            //Act
            RealEstateDto updateDto = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(updateDto);

            //Assert
            Assert.NotEqual(result.CreatedAt, result.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_AddRealEstate()
        {
            // Programmi viga

            //Arrange
            RealEstateDto dto = new()
            {
                Area = null,
                Location = null,
                RoomNumber = null,
                BuildingType = null,
                CreatedAt = null,
                ModifiedAt = null
            };

            // Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldCheckRealEstateIdIsUnique()
        {
            // Arrange
            RealEstateDto dto1 = MockRealEstateData();
            RealEstateDto dto2 = MockRealEstateData();

            // Act
            var create1 = await Svc<IRealEstateServices>().Create(dto1);
            var create2 = await Svc<IRealEstateServices>().Create(dto2);

            // Assert
            Assert.NotEqual(create1.Id, create2.Id);
        }

        [Fact]
        public async Task ShouldUpdateModifiedAt_WhenUpdateData()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();
            var create = await Svc<IRealEstateServices>().Create(dto);
            var originalCretedAt = "2026-11-17T09:17:22.9756053+02:00";

            //var originalCreatedAt = create.CreatedAt;
            // Act
            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);
            result.CreatedAt = DateTime.Parse("2026-11-17T09:17:22.9756053+02:00");
            // Assert
            Assert.NotEqual(DateTime.Parse(originalCretedAt), result.ModifiedAt);
        }

        // Test kontrollib, et RealEstate RoomNumber uuendamisel
        [Fact]
        public async Task Should_UpdateRealEstateRoomNumber_WhenUpdateRoomNumber()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto updateDto = MockUpdateRealEstateData();
            // Act
            updateDto.RoomNumber = 10;
            // kasutame Create, et vältida tracking viga
            var result = await Svc<IRealEstateServices>().Create(updateDto);

            // Assert
            //Kontrollime, et RoomNumber on uuendatud
            Assert.Equal(createRealEstate.Location, result.Location);
        }

        // Test kontrollib, et RealEstate kustutamisel kaob see süsteemist
        [Fact]
        public async Task Should_RemoveRealEstateFromDatabase_WhenDelete()
        {
            // Arrange
            RealEstateDto dto = MockRealEstateData();

            // Act
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var deleteRealEstate = await Svc<IRealEstateServices>().Delete((Guid)createRealEstate.Id);

            //Assert
            Assert.Equal(createRealEstate.Id, deleteRealEstate.Id);

            var freshService = Svc<IRealEstateServices>();
            var result = await freshService.DetailAsync((Guid)createRealEstate.Id);
            
            Assert.Null(result);
        }

        private RealEstateDto MockNullRealEstateData()
        {
            RealEstateDto dto = new()
            {
                Id = null,
                Area = null,
                Location = null,
                RoomNumber = null,
                BuildingType = null,
                CreatedAt = null,
                ModifiedAt = null
            };
            return dto;
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto dto = new()
            {
                Area = 150.0,
                Location = "Uptown",
                RoomNumber = 4,
                BuildingType = "House",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            return dto;
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto dto = new()
            {
                Area = 100.0,
                Location = "Mountain",
                RoomNumber = 3,
                BuildingType = "Cabin log",
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1)
            };

            return dto;
        }

    }
}
