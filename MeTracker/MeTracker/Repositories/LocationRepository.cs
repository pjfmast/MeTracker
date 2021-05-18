using MeTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeTracker.Repositories {
    public class LocationRepository : ILocationRepository {
        private SQLiteAsyncConnection connection;
        private async Task CreateConnection() {
            if (connection != null) {
                return;
            }
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder))

            // Prefix FileSystem with namespace, instead of using Xamarin.Essentials
            //        to prevent ambigity between Models.Location and Xamarin.Essentials.Location:
            string libFolder = Xamarin.Essentials.FileSystem.AppDataDirectory;
            string databasePath = Path.Combine(libFolder, "Essentials.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<Models.Location>();

        }
        public async Task Save(Models.Location location) {
            await CreateConnection();
            await connection.InsertAsync(location);
        }


        public async Task<List<Location>> GetAll() {
            await CreateConnection();

            var locations = await connection.Table<Location>().ToListAsync();

            return locations;
        }
    }
}
