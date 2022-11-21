using EasyAbp.CacheManagement.Samples;
using Xunit;

namespace EasyAbp.CacheManagement.MongoDB.Samples
{
    [Collection(MongoTestCollection.Name)]
    public class SampleRepository_Tests : SampleRepository_Tests<CacheManagementMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
