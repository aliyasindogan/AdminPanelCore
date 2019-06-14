namespace AdminPanelCore.CORE.Entities.Abstarct
{
    public interface ISeoEntity
    {
        string Title { get; set; }
        string MetaDescription { get; set; }
        string MetaKeywords { get; set; }
    }
}
