using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using blog.Entities;
using blog.Model;
using blog.DTOs;

namespace blog.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePostRequest, Post>();

            CreateMap<CreateCommentRequest, Comment>();

            CreateMap<Comment, CommentResponsDTO>().ForMember(dest=>dest.CommentId, opt=> opt.MapFrom(src => src.CommentId));

            CreateMap<Post, PostResponseDTO>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<UpdatePostRequest, Post>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop)=>{
                        if (prop == null)
                            return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop))
                            return false;
                        return true;
                    }
                ));
            CreateMap<UpdateCommentRequest, Comment>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop)=>{
                        if (prop == null)
                            return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop))
                            return false;
                        return true;
                    }
                ));
        }
    }
}