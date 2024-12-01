namespace CafeManagement.Application.Features.Cafe.Get
{
    public sealed record GetCafeQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Image LogoDetail { get; set; }
        public int EmployeeCount { get; set; }
        public string Location { get; set; }
    }

    public sealed record Image(byte[] Bytes, string ContentType);
}
