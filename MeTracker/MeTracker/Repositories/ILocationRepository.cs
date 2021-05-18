using MeTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeTracker.Repositories {
    // todo p215 - create repository
    public interface ILocationRepository {
        Task Save(Location location);

        // todo p241-242 - GetAll is used to retrieve all locations and create a Heat map
        Task<List<Location>> GetAll();

    }
}
