using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        //BuildingTest();

        //  BuildingTypesTest();

        //BuildingManager pm = new BuildingManager(new EfBuildingDal());

        //foreach (var item in pm.GetBuildingDetails().Data)
        //{
        //    Console.WriteLine(item.BuildingType);
        //    Console.WriteLine(item.BuildingCost);
        //}
    }

    private static void BuildingTypesTest()
    {
        BuildingTypeManager btm = new BuildingTypeManager(new EfBuildingTypeDal());

        foreach (var item in btm.GetAll())
        {
            Console.WriteLine(item.BType);
        }
    }

    private static void BuildingTest()
    {
        BuildingManager pm = new BuildingManager(new EfBuildingDal());

        foreach (var item in pm.GetAll().Data)
        {
            Console.WriteLine(item.BuildingCost);
        }
    }
}