using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooApp.Models;

namespace ZooApp.Services
{
    public class AnimalServices : ZooApp.Services.IAnimalServices
    {
        //Creating a constant string used to represent key in dictionary for looking up 'Animal' entities
        const string ANIMALS_CACHE_KEY = "ANIMALS_CACHE_KEY";
        private IGenericRepository _repo;

        public AnimalServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        // Find Animal
        public IList<Animal> List()
        {
            // Attemping to retrieve a list of animals from the cache
            var animals = HttpRuntime.Cache[ANIMALS_CACHE_KEY]; 
            
            // If the cache is empty...
            if (animals == null) 
            {
                // Retrieve the 'Animal' entity from the database, and return it as a list
                animals = _repo.Query<Animal>().ToList();
                
                // Add the 'Animal' entities stored in the 'animal' variable to the cache.
                HttpRuntime.Cache[ANIMALS_CACHE_KEY] = animals;
            }
            
           // We have to cast as an IList of animals because the Cache object 
           // is a weakly typed. Therefore any value retrieved from the weakly typed
           // DICTIONARY cache is stored as an object and must be cast as an IList<Animal>
            return animals as IList<Animal>;
        }

        public Animal Find(int id)
        {
            return _repo.Find<Animal>(id);
        }

        public void Create(Animal animal)
        {
            
            _repo.Add<Animal>(animal);
            _repo.SaveChanges();
            HttpRuntime.Cache.Remove(ANIMALS_CACHE_KEY);
            

        }

        public void Edit(Animal animal)
        {
            var original = this.Find(animal.Id);
            original.Name = animal.Name;
            original.Species = animal.Species;
            original.Quantity = animal.Quantity;
            _repo.SaveChanges();
            HttpRuntime.Cache.Remove(ANIMALS_CACHE_KEY);

        }

        public void Delete(int id)
        {
            _repo.Delete<Animal>(id);
            _repo.SaveChanges();
            HttpRuntime.Cache.Remove(ANIMALS_CACHE_KEY);

        }

    }
}