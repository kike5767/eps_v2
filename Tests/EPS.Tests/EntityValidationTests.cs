using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using Xunit;

namespace EPS.Tests
{
    internal static class ValidationHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }
    }

    public class AfiliadoTests
    {
        [Fact]
        public void Nombre_IsRequired()
        {
            var m = new Afiliado { Documento = "ABC", Email = "a@b.com", FechaNacimiento = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Email_MustBeValid()
        {
            var m = new Afiliado { Nombre = "A", Documento = "ABC", Email = "no", FechaNacimiento = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Documento_MaxLength20()
        {
            var m = new Afiliado { Nombre = "A", Documento = new string('x', 21), Email = "a@b.com", FechaNacimiento = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }
    }

    public class PagoTests
    {
        [Fact]
        public void Valor_CannotBeNegative()
        {
            var m = new Pago { ContratoId = 1, Valor = -1m, Fecha = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void ContratoId_MustBeAtLeast1()
        {
            var m = new Pago { ContratoId = 0, Valor = 1m, Fecha = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Fecha_IsRequired()
        {
            var m = new Pago { ContratoId = 1, Valor = 1m };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }
    }

    public class CategoriaTests
    {
        [Fact]
        public void Nombre_IsRequired()
        {
            var m = new Categoria { };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Nombre_MaxLength50()
        {
            var m = new Categoria { Nombre = new string('x', 51) };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Categoria_Valid_NoErrors()
        {
            var m = new Categoria { Nombre = "OK" };
            var res = ValidationHelper.Validate(m);
            Assert.Empty(res);
        }
    }

    public class CitaTests
    {
        [Fact]
        public void AfiliadoId_MustBeAtLeast1()
        {
            var m = new Cita { AfiliadoId = 0, Fecha = DateTime.Today, Hora = TimeSpan.FromHours(9) };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Fecha_IsRequired()
        {
            var m = new Cita { AfiliadoId = 1, Hora = TimeSpan.FromHours(9) };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Hora_IsRequired()
        {
            var m = new Cita { AfiliadoId = 1, Fecha = DateTime.Today };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }
    }

    public class IndicadorTests
    {
        [Fact]
        public void Nombre_IsRequired()
        {
            var m = new Indicador { Valor = 1m };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Nombre_MaxLength50()
        {
            var m = new Indicador { Nombre = new string('x', 51), Valor = 1m };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Valor_CannotBeNegative()
        {
            var m = new Indicador { Nombre = "OK", Valor = -0.01m };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }
    }

    public class UsuarioTests
    {
        [Fact]
        public void Email_Format()
        {
            var m = new Usuario { Nombre = "A", Email = "no", Clave = "x" };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Nombre_IsRequired()
        {
            var m = new Usuario { Email = "a@b.com", Clave = "x" };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Clave_IsRequired()
        {
            var m = new Usuario { Nombre = "A", Email = "a@b.com" };
            var res = ValidationHelper.Validate(m);
            Assert.NotEmpty(res);
        }
    }
}
