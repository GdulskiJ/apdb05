namespace WebApplication1;

public interface IVisitDb
{
    public ICollection<Visit> GetAll();
    public void Add(Visit visit);
}