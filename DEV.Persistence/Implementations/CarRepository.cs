using DEV.Domain.Entities;
using DEV.Persistence.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DEV.Persistence.Implementations
{
    public class CarRepository : ICarRepository
    {
        private static List<Car> _cars = new List<Car>();
        private static int _maxId;

        private static List<Car> Cars
        {
            get
            {
                if (_cars.Count > 0)
                    return _cars;
                using (Stream manifestResourceStream = typeof(CarRepository).GetTypeInfo().Assembly.GetManifestResourceStream("cars.json"))
                {
                    using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                    {
                        using (JsonReader jsonReader = new JsonTextReader(streamReader))
                            _cars = new JsonSerializer().Deserialize<List<Car>>(jsonReader);
                    }
                }
                return _cars;
            }
        }

        private static int MaxId
        {
            get
            {
                if (_maxId == 0)
                {
                    _maxId = Cars.Max(x => x.Id);
                }
                return _maxId;
            }
        }

        public Task<int> AddACarAsync(Car car)
        {
            car.Id = ++_maxId;
            Cars.Add(car);
            return Task.FromResult(car.Id);
        }

        public Task<Car> GetACarAsync(int id)
        {
            return Task.FromResult(Cars.SingleOrDefault(x => x.Id == id));
        }

        public Task<List<Car>> GetAllCarsAsync()
        {
            return Task.FromResult(Cars);
        }

        public Task UpdateACarAsync(Car car)
        {
            var OriginalCar = Cars.SingleOrDefault(x => x.Id == car.Id);
            OriginalCar.Make = car.Make;
            OriginalCar.Model = car.Model;
            OriginalCar.Year = car.Year;
            OriginalCar.Colour = car.Colour;
            OriginalCar.Price = car.Price;
            return Task.CompletedTask;
        }
    }
}
