using AutoMapper;
using FloristApi.Models.Dtos;

namespace FloristApi.Models.Mappings
{
    public class FlowerProfile :Profile
    {
        public FlowerProfile()
        {
            CreateMap<CreateFlowerDto, Flower>();
                    
        }
    }
}
