using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Core.Domain;
using Shop.RealestateTest;

namespace Shop.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto realEstate = new();

            realEstate.Address = "test";
            realEstate.SizeSqrM = 123.123f;
            realEstate.RoomCount = 5;
            realEstate.Floor = 7;
            realEstate.BuildingType = "test";
            realEstate.BuiltInYear = DateTime.Now;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstateServices>().Create(realEstate);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            Guid guid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");

            await Svc<IRealEstateServices>().GetAsync(guid);

            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {

            RealEstateDto realEstate = MockRealEstateData();


            var addRealEstate = await Svc<IRealEstateServices>().Create(realEstate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);

            Assert.Equal(result, addRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var realEstate1 = await Svc<IRealEstateServices>().Create(realEstate);
            var realEstate2 = await Svc<IRealEstateServices>().Create(realEstate);

            var result = await Svc<IRealEstateServices>().Delete((Guid)realEstate2.Id);

            Assert.NotEqual(result.Id, realEstate1.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("2b8b9080-60ef-442b-9822-f1ad47984736");

            RealEstateDto dto = MockRealEstateData();

            RealEstate realEstate = new();

            realEstate.Id = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            realEstate.Address = "Address123";
            realEstate.SizeSqrM = 123.123f;
            realEstate.RoomCount = 7;
            realEstate.Floor = 5;
            realEstate.BuildingType = "BuildingType123";
            realEstate.BuiltInYear = DateTime.Now.AddYears(1);

            await Svc<IRealEstateServices>().Update(dto);

            Assert.Equal(realEstate.Id, guid);
            Assert.DoesNotMatch(realEstate.Address, dto.Address);
            Assert.DoesNotMatch(realEstate.Floor.ToString(), dto.Floor.ToString());
            Assert.NotEqual(realEstate.RoomCount, dto.RoomCount);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(update);

            Assert.DoesNotMatch(result.Address, createRealEstate.Address);
            Assert.NotEqual(result.UpdatedAt, createRealEstate.UpdatedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenNotUpdateData()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealestate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstate();
            var result = await Svc<IRealEstateServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "test",
                SizeSqrM = 123,
                RoomCount = 8,
                Floor = 8,
                BuildingType = "test",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return realEstate;
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "testtest",
                SizeSqrM = 123123,
                RoomCount = 12,
                Floor = 21,
                BuildingType = "test",
                BuiltInYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now.AddYears(1),
            };

            return realEstate;
        }

        private RealEstateDto MockNullRealEstate()
        {
            RealEstateDto nullDto = new()
            {
                Id = null,
                Address = "Address123",
                SizeSqrM = 123.123f,
                RoomCount = 12,
                Floor = 21,
                BuildingType = "BuildingType123",
                BuiltInYear = DateTime.Now.AddYears(-1),
                CreatedAt = DateTime.Now.AddYears(-1),
                UpdatedAt = DateTime.Now.AddYears(-1),
            };

            return nullDto;
        }
    }
}