using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOfPreferences.Application.Models.Preference
{
    public class PreferenceModel
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}