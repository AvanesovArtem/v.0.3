using AutoMapper;
using UserStore.BLL.DTO;
using UserStore.DAL.Entities;
using UserStore.Models;


namespace UserStore
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product,ProductDTO>().ReverseMap();
                cfg.CreateMap<ProductDTO,Product>().ReverseMap();
                cfg.CreateMap<ProductDTO,ProductViewModel>().ReverseMap();
                cfg.CreateMap<ProductViewModel,ProductDTO>().ReverseMap();

                cfg.CreateMap<Comment,CommentDTO>().ReverseMap();
                cfg.CreateMap<CommentDTO,Comment>().ReverseMap();
                cfg.CreateMap<CommentDTO,CommentViewModel>().ReverseMap();
                cfg.CreateMap<CommentViewModel,CommentDTO>().ReverseMap();

            });
        }
    }
}