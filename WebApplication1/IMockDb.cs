namespace WebApplication1;

public interface IMockDb
{
    public ICollection<Animals> GetAll();
    public Animals? GetById(int id);
    public void Add(Animals animals);
    
    public void Remove(Animals animals);
    
}