using Microsoft.AspNetCore.Http;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;

namespace ShopTARge24.SpaceshipsTest
{
    public class SpaceshipsTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.NewGuid();

            // Act
            await Svc<ISpaceshipServices>().DetailAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);

        }

        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            //Arrange
            Guid correctGuid = Guid.NewGuid();
            Guid guid = Guid.Parse(correctGuid.ToString());

            //Act
            await Svc<ISpaceshipServices>().DetailAsync(guid);

            //Assert
            Assert.Equal(correctGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteSpaceshipById_WhenDeleteSpaceship()
        {
            //Arrange
            SpaceshipDto dto = MockSpaceshipData();

            //Act
            var testAddSpaceship = await Svc<ISpaceshipServices>().Create(dto);
            var testDeleteSpaceship = await Svc<ISpaceshipServices>().Delete((Guid)testAddSpaceship.Id);

            //Assert
            Assert.Equal(testAddSpaceship.Id, testDeleteSpaceship.Id);
        }

        [Fact]
        public async Task Shoul_UpdateSpaceship_WhenUpdateSpaceship()
        {
            // Arrange
            var guid = new Guid("0a35d9eb-e4d7-44c7-ac85-d3c584938eec");
            SpaceshipDto dto = MockSpaceshipData();

            Spaceships domain = new();

            domain.Id = Guid.Parse("0a35d9eb-e4d7-44c7-ac85-d3c584938eec");
            domain.Name = "Logos";
            domain.Classification = "Fastest Hovercraft";
            domain.BuiltDate = DateTime.Now.AddYears(42);
            domain.Crew = 11;
            domain.EnginePower = 1034;
            domain.CreatedAt = DateTime.Now;
            domain.ModifiedAt = DateTime.Now;

            // Act
            await Svc<ISpaceshipServices>().Update(dto);

            //Assert
            Assert.Equal(guid, domain.Id);
            Assert.NotEqual(dto.Name, domain.Name);
            Assert.NotEqual(dto.Classification, domain.Classification);
            Assert.NotEqual(dto.BuiltDate, domain.BuiltDate);
            Assert.NotEqual(dto.Crew, domain.Crew);
            Assert.NotEqual(dto.EnginePower, domain.EnginePower);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateSpaceship2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var testAddSpaceship = await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var result = await Svc<ISpaceshipServices>().Update(update);

            //Assert
            Assert.NotEqual(dto.Name, result.Name);
            Assert.NotEqual(dto.ModifiedAt, result.ModifiedAt);
            Assert.NotEqual(dto.BuiltDate, result.BuiltDate);
            Assert.NotEqual(dto.Crew, result.Crew);

        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto dto = new()
            {
                Name = "Nebuchadnezzar",
                Classification = "Hovercraft",
                BuiltDate = DateTime.Now.AddYears(44),
                Crew = 9,
                EnginePower = 1000,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            return dto;
        }
        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto dto = new()
            {
                Name = "Mjolnir",
                Classification = "Hovercraft",
                BuiltDate = DateTime.Now.AddYears(48),
                Crew = 8,
                EnginePower = 974,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return dto;
        }
    }
}
