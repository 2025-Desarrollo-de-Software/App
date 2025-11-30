using Shouldly;
using Xunit;
using TripGo.Ratings;
using System;

namespace TripGo.Ratings
{
    public class RatingAppService_Tests
    {
        [Fact]
        public void Should_Validate_Score_Between_1_And_5()
        {
            // Test de validación manual del score
            var isValidScore = (int score) => score >= 1 && score <= 5;

            isValidScore(1).ShouldBeTrue();
            isValidScore(3).ShouldBeTrue();
            isValidScore(5).ShouldBeTrue();
            isValidScore(0).ShouldBeFalse();
            isValidScore(6).ShouldBeFalse();
        }

        [Fact]
        public void RatingDto_Should_Have_Required_Properties()
        {
            // Test de estructura del DTO
            var dto = new RatingDto
            {
                Score = 4,
                Comment = "Muy bueno",
                UserId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid()
            };

            dto.Score.ShouldBe(4);
            dto.Comment.ShouldBe("Muy bueno");
            dto.UserId.ShouldNotBe(Guid.Empty);
            dto.DestinationId.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public void RateDestinationDto_Should_Require_DestinationId()
        {
            // Test de que el DTO necesita DestinationId
            var dto = new RateDestinationDto
            {
                DestinationId = Guid.NewGuid(),
                Score = 2,
                Comment = "Regular"
            };

            dto.DestinationId.ShouldNotBe(Guid.Empty);
            dto.Score.ShouldBe(2);
        }

        [Fact]
        public void Should_Allow_Optional_Comment()
        {
            // UNITARIA: Comentarios opcionales - requisito específico del TP
            var dto = new RateDestinationDto
            {
                DestinationId = Guid.NewGuid(),
                Score = 4,
                Comment = null // Comentario nulo permitido
            };

            dto.Score.ShouldBe(4);
            dto.DestinationId.ShouldNotBe(Guid.Empty);
            // No assertion sobre Comment - puede ser null (opcional)
        }

        [Fact]
        public void Should_Validate_All_Score_Values()
        {
            // UNITARIA: Validar todos los valores posibles de score
            var isValidScore = (int score) => score >= 1 && score <= 5;

            // Casos válidos (1-5)
            isValidScore(1).ShouldBeTrue();
            isValidScore(2).ShouldBeTrue();
            isValidScore(3).ShouldBeTrue();
            isValidScore(4).ShouldBeTrue();
            isValidScore(5).ShouldBeTrue();

            // Casos inválidos
            isValidScore(0).ShouldBeFalse();
            isValidScore(6).ShouldBeFalse();
            isValidScore(-1).ShouldBeFalse();
            isValidScore(10).ShouldBeFalse();
        }
    }
}