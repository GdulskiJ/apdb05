namespace WebApplication1;

public class MockDb : IMockDb
{
    private ICollection<Animals> _animals;

    public MockDb()
    {
        _animals = new List<Animals>
        {
            new Animals()
            {
                Id = 1,
                Name = "Reksio",
                Category = "dog",
                FurColor = "blue"
            },
            new Animals()
            {
                Id = 2,
                Name = "Fiolemon",
                Category = "cat",
                FurColor = "gray"
            }
        };
    }

    public ICollection<Animals> GetAll()
    {
        return _animals;
    }

    public Animals? GetById(int id)
    {
        return _animals.FirstOrDefault(animals => animals.Id == id);
    }

    public void Add(Animals animals)
    {
        _animals.Add(animals);
    }

    public void Remove(Animals animals)
    {
        _animals.Remove(animals);
    }
}