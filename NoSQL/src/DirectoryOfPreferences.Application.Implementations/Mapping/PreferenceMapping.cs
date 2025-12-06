using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DirectoryOfPreferences.Application.Models.Preference;
using DirectoryOfPreferences.Domain.Entity;

namespace DirectoryOfPreferences.Application.Implementations.Mapping
{
    public class PreferenceMapping : Profile
    {
        public PreferenceMapping()
        {
            CreateMap<Preference, PreferenceModel>();
        }
    }
}