namespace AdminPanelCore.CORE.Entities.Abstarct
{
    public interface IDisplayEntity
    {
        int DisplayOrder { get; set; }
        bool IsDisplay { get; set; }
    }
}
