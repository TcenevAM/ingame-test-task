using System.Collections.Generic;

namespace InGameTestTask.Dtos.PatchDtos
{
    public abstract class PatchDtoBase
    {
        private HashSet<string> PropertiesInHttpRequest { get; set; }
            = new HashSet<string>();

        public bool IsFieldPresent(string propertyName)
        {
            return PropertiesInHttpRequest.Contains(propertyName.ToLowerInvariant());
        }

        public void SetHasProperty(string propertyName)
        {
            PropertiesInHttpRequest.Add(propertyName.ToLowerInvariant());
        }
    }
}