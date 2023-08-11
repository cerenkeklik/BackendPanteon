using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        BuildingManager pm = new BuildingManager(new EfBuildingDal());

        foreach (var item in pm.GetAll())
        {
            Console.WriteLine(item.BuildingCost);
        }
    }
}