namespace WebApplication1;

public class MockVisitDb : IVisitDb
{
    private ICollection<Visit> _visits;

    public MockVisitDb()
    {
        _visits = new List<Visit>
        {
            new Visit()
            {
                VisitDate = "10.02.2024",
                Animals = new Animals()
                {
                    Id = 1,
                    Name = "Reksio",
                    Category = "dog",
                    FurColor = "blue"
                },
                Description = "wszystko ok",
                Price = 100,
            },
            new Visit()
            {
                VisitDate = "10.02.2023",
                Animals = new Animals()
                {
                    Id = 2,
                    Name = "Fiolemon",
                    Category = "cat",
                    FurColor = "gray"
                },
                Description = "wszystko ok, bedzie zyl",
                Price = 200,
            },
        };
    }
    
    
    
    
    public ICollection<Visit> GetAll()
    {
        return _visits;
    }

    public void Add(Visit visit)
    {
        _visits.Add(visit);
    }
}