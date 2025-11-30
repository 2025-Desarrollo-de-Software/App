using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Users;

namespace TripGo.Ratings
{
    [Authorize]
    public class RatingAppService : ApplicationService, IRatingAppService
    {
        private readonly IRepository<Rating, Guid> _ratingRepository;
        private readonly ICurrentUser _currentUser;

        public RatingAppService(
            IRepository<Rating, Guid> ratingRepository,
            ICurrentUser currentUser)
        {
            _ratingRepository = ratingRepository;
            _currentUser = currentUser;
        }

        public async Task<RatingDto> RateDestinationAsync(RateDestinationDto input)
        {
            // Validar score (1-5)
            if (input.Score < 1 || input.Score > 5)
            {
                throw new UserFriendlyException("La calificación debe ser entre 1 y 5 estrellas");
            }

            // Obtener usuario actual
            var currentUserId = _currentUser.GetId();

            // Verificar si ya existe una calificación del usuario para este destino
            var existingRating = await _ratingRepository.FirstOrDefaultAsync(r =>
                r.UserId == currentUserId && r.DestinationId == input.DestinationId);

            if (existingRating != null)
            {
                // Actualizar calificación existente
                existingRating.Score = input.Score;
                existingRating.Comment = input.Comment;
                await _ratingRepository.UpdateAsync(existingRating);

                return ObjectMapper.Map<Rating, RatingDto>(existingRating);
            }
            else
            {
                // Crear nueva calificación
                var rating = new Rating(
                    id: GuidGenerator.Create(),
                    userId: currentUserId,
                    destinationId: input.DestinationId,
                    score: input.Score,
                    comment: input.Comment
                );

                await _ratingRepository.InsertAsync(rating);

                return ObjectMapper.Map<Rating, RatingDto>(rating);
            }
        }

        public async Task<ListResultDto<RatingDto>> GetUserRatingsAsync()
        {
            var currentUserId = _currentUser.GetId();

            var ratings = await _ratingRepository.GetListAsync(r => r.UserId == currentUserId);

            return new ListResultDto<RatingDto>(
                ObjectMapper.Map<List<Rating>, List<RatingDto>>(ratings)
            );
        }

        public async Task DeleteRatingAsync(Guid id)
        {
            var currentUserId = _currentUser.GetId();
            var rating = await _ratingRepository.GetAsync(id);

            // ✅ CORREGIDO: Usar UserFriendlyException
            if (rating.UserId != currentUserId)
            {
                throw new UserFriendlyException("No puedes eliminar calificaciones de otros usuarios");
            }

            await _ratingRepository.DeleteAsync(id);
        }
    }
}