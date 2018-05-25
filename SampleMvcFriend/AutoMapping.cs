using AutoMapper;
using DataLayer;
using SampleMvcFriend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcFriend
{
    public class AutoMapping : IAutoMapper
    {
        private static IMapper _mapper;
        private static MapperConfiguration _config;
        public IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    AutoMapperRegistration();
                }
                return _mapper;
            }
        }

        public IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> input)
        {
            AutoMapperRegistration();
            return Mapper.Map<IEnumerable<T1>, IEnumerable<T2>>(input);
        }
        private void AutoMapperRegistration()
        {
            if (_config != null) return;

            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Friend, FriendModel>().ReverseMap();
            });
            _mapper = _config.CreateMapper();
        }
        public T2 Map<T1, T2>(T1 input)
        {
            AutoMapperRegistration();
            return Mapper.Map<T1, T2>(input);
        }
    }
}