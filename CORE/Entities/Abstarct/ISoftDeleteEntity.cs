namespace AdminPanelCore.CORE.Entities.Abstarct
{
    public interface ISoftDeleteEntity
    {
        bool IsActive { get; set; }
    }
}
