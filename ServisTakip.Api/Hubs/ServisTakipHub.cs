using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using ServisTakip.Core.Utilities.Settings;
using StackExchange.Redis;

namespace ServisTakip.Api.Hubs
{
    public class ServisTakipHub : Hub
    {
        private readonly IDatabase _db;
        private readonly RedisSettings _settings;

        public ServisTakipHub(IConnectionMultiplexer multiplexer,IOptions<RedisSettings> settings)
        {
            _settings = settings.Value;
            _db = multiplexer.GetDatabase(5);
        }

        public override async Task OnConnectedAsync()
        {
            // await SaveToRedisAsync(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if(!string.IsNullOrEmpty(Context.ConnectionId))
            {
                // await _db.KeyDeleteAsync(Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        //private async Task SaveToRedisAsync(string key)
        //{
        //    string clientIp = Context.GetHttpContext().Connection.RemoteIpAddress.ToString();

        //    if (!string.IsNullOrEmpty(key))
        //    {
        //        await _db.KeyDeleteAsync(key);
        //    }
            
        //    await _db.StringSetAsync(key, clientIp);
        //}
    }
}
