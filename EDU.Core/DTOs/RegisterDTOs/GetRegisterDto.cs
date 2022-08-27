using EDU.Core.DTOs.AdvertDTOs;

namespace EDU.Core.DTOs.RegisterDTOs
{
    public class GetRegisterDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int AdvertId { get; set; }
        public bool IsAccept { get; set; }
        public GetAdvertDto Advert { get; set; }
    }
}
