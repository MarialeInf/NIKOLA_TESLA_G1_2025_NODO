using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.Repository;

namespace TeslaACDC.Tests;

[TestClass]
public class AlbumTests
{
    public AlbumTests()
    {
        
    }

     /* 
        Patrón AAA
        A = Arrange
        A = Act
        A = Assert
     */

    [TestMethod]
    public async Task HealthCheckTest()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest();

        // Arrange
        Assert.AreEqual(response, "OK");
    }

    [TestMethod]
    public async Task HealthCheckTestIsOk()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(true);

        // Arrange
        Assert.AreEqual(response, "OK!");
    }

    [TestMethod]
    public async Task HealthCheckTestIsNotOkay()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(false);

        // Arrange
        Assert.AreEqual(response, "Not cool");
    }

    [TestMethod]
    public async Task ValidateAlbumCreation()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "Rude Awakening (RE-MASTERED)",
            Year = 2025,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.AreEqual(response, String.Empty);

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_nameisempty()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 2025,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El nombre es requerido"));

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_yearoutofrangelower()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 1899,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_yearoutofrangehigher()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 2026,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));
    }

    

}