using DEV.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEV.Persistence.Repositories
{
    public interface ICarRepository
    {
        /// <summary>
        /// Get All Cars from persistent storage
        /// </summary>
        /// <returns></returns>
        Task<List<Car>> GetAllCarsAsync();

        /// <summary>
        /// Get a car from persistent storage related to the respective id
        /// </summary>
        /// <returns></returns>
        Task<Car> GetACarAsync(int id);

        /// <summary>
        /// Add a car to the persistent storage
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task<int> AddACarAsync(Car car);

        /// <summary>
        /// Update details of an existing car in persistent storage
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task UpdateACarAsync(Car car);


        /// <summary>
        /// Deletes details of an existing car in persistent storage
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task DeleteACarAsync(int id);
    }
}
