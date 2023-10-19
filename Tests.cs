using System;
using StackExchange.Redis;

namespace gredis;

public class Tests {

    public static void testRedis() {
        ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379,password=");
        IDatabase db = conn.GetDatabase(0);

        RedisValue stringGet = db.StringGet("k3");
        string val = db.StringGet("k3");
        string s = stringGet.ToString();
        Console.WriteLine("");
        conn.Dispose();
    }

}