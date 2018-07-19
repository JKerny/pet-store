using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Repository;

namespace PetStoreTest
{
    [TestClass]
    public class PetRepositoryTest
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
    }
}
