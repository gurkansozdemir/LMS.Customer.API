namespace EDU.Core.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconPath { get; set; }
        public int RowNumber { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
