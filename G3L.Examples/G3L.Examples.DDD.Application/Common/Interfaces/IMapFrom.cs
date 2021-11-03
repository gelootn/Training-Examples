using AutoMapper;

namespace G3L.Examples.DDD.Application.Common.Interfaces
{
    public interface IMapFrom<TSource>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(TSource), GetType());
    }
}