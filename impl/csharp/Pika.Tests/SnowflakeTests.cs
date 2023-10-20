using Pika.Snowflakes;

namespace Pika.Tests;

public class SnowflakeTests
{
    [Fact]
    public void TestSnowflake()
    {
        const ulong epoch = 1640995200000UL;
        const ulong nodeId = 1UL;
        var snowflake = new Snowflake(epoch, nodeId);
        var id = snowflake.Gen();
        var decoded = snowflake.Decode(id);

        Assert.Equal(1U, decoded.NodeId);
        Assert.Equal(1U, decoded.Seq);
        Assert.Equal(epoch, decoded.Epoch);
        Assert.Equal(id, decoded.Id);
    }

    [Fact]
    public void TestSnowflakes()
    {
        var snowflake = new Snowflake(1640995200000UL, 1UL);
        var ids = new HashSet<ulong>();

        for (var i = 0; i < 10000; i++)
        {
            var id = snowflake.Gen();
            Assert.DoesNotContain(id, ids);
            ids.Add(id);
        }
    }
}