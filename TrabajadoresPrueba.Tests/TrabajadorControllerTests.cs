using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajadoresPrueba.Controllers;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Models;
using Xunit;

namespace TrabajadoresPrueba.Tests
{
    public class TrabajadorControllerTests
    {
        // 🧱 Crea un contexto EF Core InMemory para pruebas
        private AppDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // base distinta por test
                .Options;

            return new AppDbContext(options);
        }

        // 🔧 Método helper para crear trabajadores válidos
        private Trabajador CrearTrabajador(string nombre = "Juan", string apellido = "Pérez")
        {
            return new Trabajador
            {
                Nombres = nombre,
                Apellidos = apellido,
                TipoDocumento = "DNI",
                NumeroDocumento = new Random().Next(10000000, 99999999).ToString(),
                Sexo = "Masculino",
                FechaNacimiento = DateTime.Now.AddYears(-25),
                Foto = "https://via.placeholder.com/60",
                Direccion = "Av. Siempre Viva 123"
            };
        }

        [Fact]
        public async Task Index_ReturnsViewWithData()
        {
            // Arrange
            var context = GetContext();
            context.Trabajadores.AddRange(
                CrearTrabajador("Juan", "Ramírez"),
                CrearTrabajador("María", "Gómez")
            );
            await context.SaveChangesAsync();

            var controller = new TrabajadorController(context);

            // Act
            var result = await controller.Index(null) as ViewResult;
            var model = result.Model as List<Trabajador>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task Create_AddsNewWorker_AndRedirectsToIndex()
        {
            // Arrange
            var context = GetContext();
            var controller = new TrabajadorController(context);
            var nuevo = CrearTrabajador("Lucía", "Ruiz");

            // Act
            var result = await controller.Create(nuevo) as RedirectToActionResult;

            // Assert
            Assert.Equal("Index", result.ActionName);
            Assert.Single(context.Trabajadores);
        }

        [Fact]
        public async Task Edit_UpdatesWorker_AndRedirects()
        {
            // Arrange
            var context = GetContext();
            var trabajador = CrearTrabajador("Carlos", "Pérez");
            context.Trabajadores.Add(trabajador);
            await context.SaveChangesAsync();

            var controller = new TrabajadorController(context);

            // Act
            trabajador.Nombres = "Carlos Alberto";
            var result = await controller.Edit(trabajador.Id, trabajador) as RedirectToActionResult;

            // Assert
            var actualizado = context.Trabajadores.First();
            Assert.Equal("Carlos Alberto", actualizado.Nombres);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task DeleteConfirmed_RemovesWorker_AndRedirects()
        {
            // Arrange
            var context = GetContext();
            var trabajador = CrearTrabajador("Luis", "Torres");
            context.Trabajadores.Add(trabajador);
            await context.SaveChangesAsync();

            var controller = new TrabajadorController(context);

            // Act
            var result = await controller.DeleteConfirmed(trabajador.Id) as RedirectToActionResult;

            // Assert
            Assert.Equal("Index", result.ActionName);
            Assert.Empty(context.Trabajadores);
        }
    }
}
