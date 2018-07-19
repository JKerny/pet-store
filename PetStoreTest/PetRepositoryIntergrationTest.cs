using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.PetStore.DAL.Context;
using PetStore.Repository;
using PetStore.Repository.PocoClasses;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;


namespace PetStoreTest
{
    [TestClass]
    public class PetRepositoryIntergrationTest
    {
        [TestMethod]
        public void GetPetByID_InvalidID_ReturnsNull()
        {
            //Arrange
            var petRepository = new PetRepository(new BaseRepository());
            //Act
            var noPetFound = petRepository.GetPetById(Guid.Empty);
            //Assert
            Assert.IsNull(noPetFound);
            
        }

        [TestMethod]
      //  [DataSource("System.Data.SqlClient","Server=LOCALHOST;Database=PetStore;User Id=global;Password=switch",)]
        public void SaveNewPetToDb_ValidPet_SavesCorrectly()
        {
            //Arrange
            var pet = new Pet
            {
                Id = Guid.Empty,
                Name = "Fiddo",
                AnimalTypeId = new Guid("DCFF12F5-B98E-43E4-9F8B-31612D9F1A1C"),
                DateOfBirth = DateTime.Now.AddYears(-1),
                Weight = 10
            };

            //Act
            var mockContext = Mock.Create<PetStoreContext>();
            var petRepo = new PetRepository(Mock.Create<BaseRepository>());
            petRepo.SavePet(pet);
            Mock.Arrange(() => mockContext.SaveChanges()).OccursOnce();

            //Assert
            Mock.Assert(mockContext);

        }
    }
}
