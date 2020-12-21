using BmesRestApi.Messages.DataTransferObjects.Shared;
using BmesRestApi.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Customer
{
    public class PersonDto : BaseDto
    {
        public string FirstNameDto { get; set; }
        public string MiddleNameDto { get; set; }
        public string LastNameDto { get; set; }
        public string EmailAddressDto { get; set; }
        public string PhoneNumberDto { get; set; }
        public string DateOfBirthDto { get; set; }
        public int GenderDto { get; set; }
    }
}
