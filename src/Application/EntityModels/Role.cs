namespace JMTopUpBackend.Application
{
    public class Role : IKey<short>, IDescription, IUserAuditable
    {
        [Key]
        public short Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DescriptionTH { get; set; } = string.Empty;
        public string DescriptionEN { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}