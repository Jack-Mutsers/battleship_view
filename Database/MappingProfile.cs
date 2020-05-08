using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DatabaseModels;

namespace Database
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Highscore, HighscoresDto>();
            CreateMap<HighscoresForCreationDto, Highscore>();
            CreateMap<HighscoresForUpdateDto, Highscore>();

            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>();
        }
    }
}
