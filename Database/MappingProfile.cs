﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DatabaseModels;
using System;

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

            CreateMap<Session, SessionDto>();
            CreateMap<SessionForCreationDto, Session>();
            CreateMap<SessionForUpdateDto, Session>();

        }
    }
}
