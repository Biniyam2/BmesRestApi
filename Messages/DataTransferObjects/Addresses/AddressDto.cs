using BmesRestApi.Messages.DataTransferObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Addresses
{
    public class AddressDto : BaseDto
    {
        public string NameDto { get; set; }
        public string AddressLine1Dto { get; set; }
        public string AddressLine2Dto { get; set; }
        public string CityDto { get; set; }
        public string CountryDto { get; set; }
        public int ZipCodeDto { get; set; }
        public string StateDto { get; set; }
    }
}
