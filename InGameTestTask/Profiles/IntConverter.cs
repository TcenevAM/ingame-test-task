using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InGameTestTask.Data;

namespace InGameTestTask.Profiles
{
    public class IntConverter<TDestination> : IValueConverter<List<int>, List<TDestination>> where TDestination : class
    {
        private readonly Context _context;

        public IntConverter(Context context)
        {
            _context = context;
        }

        public List<TDestination> Convert(List<int> sourceMember, ResolutionContext context)
        {
            return sourceMember?.Select(id => _context.Find<TDestination>(id)).ToList();
        }
    }
}