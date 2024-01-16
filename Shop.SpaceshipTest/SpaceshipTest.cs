using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {
            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            Guid guid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            //kuidas teha automaatselt guidi?
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            //Act
            await Svc<ISpaceshipServices>().GetAsync(guid);
            //Assert
            Assert.NotEqual(guid, wrongGuid);
        }
        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnEqual()
        {
            Guid databaseGuid = Guid.Parse("6ccca6ad-c119-427c-8f16-5f1076340f73");
            Guid getGuid = Guid.Parse("6ccca6ad-c119-427c-8f16-5f1076340f73");

            //Arrange
            //Guid dbGuid = Guid.Parse(Guid.NewGuid().ToString());

            //Act
            await Svc<ISpaceshipServices>().GetAsync(getGuid);

            //Assert
            Assert.Equal(databaseGuid, getGuid);
        }
        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //Arrange
            SpaceshipDto spaceship = MockSpaceshipData();

            //Act
            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship.Id);

            //Assert
            Assert.Equal(result, addSpaceship);

        }
        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDidNotDeleteTheWrightSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id, addSpaceship.Id);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("2b8b9080-60ef-442b-9822-f1ad47984736");
            //Arrange
            //old data from db
            Spaceship spaceship = new Spaceship();

            //new data
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            spaceship.Name = "asdasd";
            spaceship.Type = "asdasd";
            spaceship.Passengers = 123123;
            spaceship.EnginePower = 123123;
            spaceship.Crew = 123;
            spaceship.Company = "asdasd";
            spaceship.CargoWeight = 123456;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            //Act
            await Svc<ISpaceshipServices>().Update(dto);

            //Assert
            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginePower, dto.EnginePower);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passengers.ToString(), dto.Passengers.ToString());

        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var updateSpaceship = await Svc<ISpaceshipServices>().Update(update);

            Assert.Matches(updateSpaceship.Name, createSpaceship.Name);
            Assert.NotEqual(updateSpaceship.EnginePower, createSpaceship.EnginePower);
            Assert.NotEqual(updateSpaceship.Crew, createSpaceship.Crew);
            Assert.DoesNotMatch(updateSpaceship.Passengers.ToString(), createSpaceship.Passengers.ToString());
        }
        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            await Svc<ISpaceshipServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }
        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto nullDto = new()
            {
                Id = null,
                Name = "Name123",
                Type = "type123",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "Company123",
                CargoWeight = 123,
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };
            return nullDto;
        }
        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto update = new()
            {
                Name = "asd123",
                Type = "asd",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "asd",
                CargoWeight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return update;
        }
        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd123",
                Type = "asd",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "asd",
                CargoWeight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return spaceship;
        }
    }
}
