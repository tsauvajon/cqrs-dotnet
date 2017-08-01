using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS
{
    /// <summary>
    /// Base for a repo
    /// Does not implement <see cref="IBaseRepository{T}"/>
    /// </summary>
    public class BaseRepository
    {
        private readonly IConnectionMultiplexer redisConnection;

        /// <summary>
        /// The Namespace is the first part of any key created by this Repository, e.g. "location" or "employee"
        /// </summary>
        private readonly string nameSpace;

        public BaseRepository(IConnectionMultiplexer redisConnection, string nameSpace)
        {
            this.redisConnection = redisConnection;
            this.nameSpace = nameSpace;
        }

        private string MakeKey(string keySuffix)
        {
            if (!keySuffix.StartsWith(nameSpace + ":"))
            {
                return nameSpace + ":" + keySuffix;
            }

            // Already prefixed
            return keySuffix;
        }

        private string MakeKey(int id)
        {
            return MakeKey(id.ToString());
        }

        public T Get<T>(string keySuffix)
        {
            var key = MakeKey(keySuffix);
            var database = redisConnection.GetDatabase();
            var serializedObject = database.StringGet(key);
            
            if (serializedObject.IsNullOrEmpty)
            {
                throw new ArgumentNullException();
            }

            return JsonConvert.DeserializeObject<T>(serializedObject.ToString());
        }

        public T Get<T>(int id)
        {
            return Get<T>(id.ToString());
        }

        public List<T> GetMultiple<T>(List<int> ids)
        {
            var database = redisConnection.GetDatabase();
            List<RedisKey> keys = new List<RedisKey>();

            foreach (int id in ids)
            {
                keys.Add(MakeKey(id));
            }

            var serializedItems = database.StringGet(keys.ToArray(), CommandFlags.None);
            List<T> items = new List<T>();

            foreach (var item in serializedItems)
            {
                items.Add(JsonConvert.DeserializeObject<T>(item.ToString())); ;
            }

            return items;
        }

        public bool Exists(string keySuffix)
        {
            var key = MakeKey(keySuffix);
            var database = redisConnection.GetDatabase();
            var serializedObject = database.StringGet(key);

            return !serializedObject.IsNullOrEmpty;
        }

        public bool Exists(int id)
        {
            return Exists(id.ToString());
        }

        public void Save(string keySuffix, object entity)
        {
            var key = MakeKey(keySuffix);
            var database = redisConnection.GetDatabase();
            database.StringSet(MakeKey(key), JsonConvert.SerializeObject(entity));
        }

        public void Save(int id, object entity)
        {
            Save(id.ToString(), entity);
        }
    }
}
