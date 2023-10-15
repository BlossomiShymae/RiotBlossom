using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.Developer;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Static
{
    public interface IDeveloperApi
    {
        /// <summary>
        /// Get the list of all League of Legends queue constants.
        /// </summary>
        /// <returns></returns>
        Task<List<Queue>> GetQueuesAsync();
        /// <summary>
        /// Get the list of all League of Legends map constants.
        /// </summary>
        /// <returns></returns>
        Task<List<Map>> GetMapsAsync();
        /// <summary>
        /// Get the list of all League of Legends game mode constants.
        /// </summary>
        /// <returns></returns>
        Task<List<GameMode>> GetGameModesAsync();
        /// <summary>
        /// Get the list of all League of Legends game type constants.
        /// </summary>
        /// <returns></returns>
        Task<List<GameType>> GetGameTypesAsync();
    }

    internal class DeveloperApi : DataApi, IDeveloperApi
    {
        public DeveloperApi(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<GameMode>> GetGameModesAsync()
        {
            var data = await CallStaticAsync<List<GameMode>>(new()
            {
                Endpoint = nameof(DeveloperApi),
                Url = UrlMethod.StaticDeveloper,
                Method = UrlMethod.StaticDeveloperGameModes,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<GameType>> GetGameTypesAsync()
        {
            var data = await CallStaticAsync<List<GameType>>(new()
            {
                Endpoint = nameof(DeveloperApi),
                Url = UrlMethod.StaticDeveloper,
                Method = UrlMethod.StaticDeveloperGameTypes,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<Map>> GetMapsAsync()
        {
            var data = await CallStaticAsync<List<Map>>(new()
            {
                Endpoint = nameof(DeveloperApi),
                Url = UrlMethod.StaticDeveloper,
                Method = UrlMethod.StaticDeveloperMaps,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<Queue>> GetQueuesAsync()
        {
            var data = await CallStaticAsync<List<Queue>>(new()
            {
                Endpoint = nameof(DeveloperApi),
                Url = UrlMethod.StaticDeveloper,
                Method = UrlMethod.StaticDeveloperQueues
            }).ConfigureAwait(false);
            
            return data;
        }
    }
}