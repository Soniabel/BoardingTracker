using AutoMapper;
using BoardingTracker.Application.Infrastructure.Mapper;
using System;

namespace BoardingTracker.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(InitMapper);

        private static MapperConfiguration _configuration;

        public static IMapper Mapper { get; set; } = _mapper.Value;

        private static IMapper InitMapper()
        {
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile<BoardingTrackerMappingProfile>());

            return new Mapper(_configuration);
        }
    }
}
