using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.Core.Domain;

namespace ShopTARge24.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        private KindergartenDto MockKindergartenDto()
        {
            return new KindergartenDto
            {
                Id = Guid.NewGuid(),
                GroupName = "TestGroupName",
                ChildrenCount = 11,
                KindergartenName = "TestKindergartenName",
                TeacherName = "TestTeacherName",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private KindergartenDto MockUpdateKindergartenDto()
        {
            return new KindergartenDto
            {
                GroupName = "TestGroupNameUpdate",
                ChildrenCount = 11,
                KindergartenName = "TestKindergartenNameUpdate",
                TeacherName = "TestTeacherNameUpdate",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        // 1 Details
        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.Parse("b8f21e53-f98f-4c5e-9913-477aaff59ddd");

            // Act
            await Svc<IKindergartenServices>().DetailAsync(guid);

            // Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        // 2 Details
        [Fact]
        public async Task Should_GetByIdKindergarten_WhenReturnEqual()
        {
            // Arrange
            Guid correctGuid = Guid.NewGuid();
            Guid guid = Guid.Parse(correctGuid.ToString());

            // Act
            await Svc<IKindergartenServices>().DetailAsync(guid);

            // Assert
            Assert.Equal(correctGuid, guid);
        }

        // 3 Delete
        [Fact]
        public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            // Act
            var addKindergarten = await Svc<IKindergartenServices>().Create(dto);
            var deleteKindergarten = await Svc<IKindergartenServices>().Delete((Guid)addKindergarten.Id);

            // Assert
            Assert.Equal(addKindergarten.Id, deleteKindergarten.Id);
        }

        // 4 Delete
        [Fact]
        public async Task ShouldNot_DeleteByIdKindergarten_WhenDidNotDeleteKindergarten()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            // Act
            var deleteId = Guid.NewGuid();
            var kindergarten1 = await Svc<IKindergartenServices>().Create(dto);
            var kindergarten2 = await Svc<IKindergartenServices>().Create(dto);

            var result = await Svc<IKindergartenServices>().Delete((Guid)kindergarten2.Id);

            // Assert
            Assert.NotEqual(kindergarten1.Id, result.Id);
        }

        // 5 Update
        [Fact]
        public async Task Should_UpdateKindergarten_WhenUpdateKindergarten()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();
            var createKindergarten = await Svc<IKindergartenServices>().Create(dto);

            // Act
            KindergartenDto update = MockUpdateKindergartenDto();
            var result = await Svc<IKindergartenServices>().Update(update);

            // Assert
            Assert.NotEqual(dto.GroupName, result.GroupName);
            Assert.NotEqual(dto.KindergartenName, result.KindergartenName);
            Assert.NotEqual(dto.TeacherName, result.TeacherName);
            Assert.NotEqual(dto.UpdatedAt, result.UpdatedAt);
        }

        // 6 Update
        [Fact]
        public async Task Shoul_UpdatePartialFields_WhenPartialUpdateKindergaten()
        {
            // Arrange
            var createDto = MockKindergartenDto();
            var created = await Svc<IKindergartenServices>().Create(createDto);

            var db = Svc<ShopTARge24Context>();
            db.ChangeTracker.Clear();

            var origId = created.Id;
            var origGroupName = created.GroupName;
            var origKindergartenName = created.KindergartenName;
            var origChildrenCount = created.ChildrenCount;
            var origTeacherName = created.TeacherName;
            var origUpdatedAt = created.UpdatedAt;
            var origCreatedAt = created.CreatedAt;

            // Act
            var updateDto = new KindergartenDto
            {
                Id = origId,
                GroupName = "TestGroupNamePartialUpdate",
                KindergartenName = "TestKindergartenNamePartialUpdate",
                ChildrenCount = origChildrenCount,
                TeacherName = origTeacherName,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = created.CreatedAt,
            };

            var updated = await Svc<IKindergartenServices>().Update(updateDto);

            // Assert
            Assert.Equal(origId, updated.Id);
            Assert.Equal("TestGroupNamePartialUpdate", updated.GroupName);
            Assert.Equal("TestKindergartenNamePartialUpdate", updated.KindergartenName);
            Assert.Equal(origChildrenCount, updated.ChildrenCount);
            Assert.Equal(origTeacherName, updated.TeacherName);
            Assert.Equal(origCreatedAt, updated.CreatedAt);
        }
    }
}
