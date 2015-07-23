using System;
namespace ZooApp.Services
{
    public interface IAnimalServices
    {
        void Create(ZooApp.Models.Animal animal);
        void Delete(int id);
        void Edit(ZooApp.Models.Animal animal);
        ZooApp.Models.Animal Find(int id);
        System.Collections.Generic.IList<ZooApp.Models.Animal> List();
    }
}
