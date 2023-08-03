using System;
using Xunit;

using Newtonsoft.Json;
using System.Collections.Generic;

using Azure.Data.Tables;

using TheByteStuff.AzureTableEntityJsonSerializer;

namespace AzureTableEntityJsonSerializerXUnitTest
{
    public class AzureTableEntityJsonSerializerXUnitTest
    {
        private string BasicEntity = "{\"PartitionKey\":\"PartitionKey\",\"RowKey\":\"RowKey\",\"Timestamp\":\"2021-01-01T10:00:00+02:00\",\"ETag\":null}";

        [Fact]
        public void TestSerialize()
        {
            AzureTableEntityJsonSerializer serializer = new AzureTableEntityJsonSerializer();

            string PartitionKeyValue = "PartitionKeyValueXX";
            string RowKeyValue = "RowKeyValueXX";
            string TimeStampValue = "2021-08-21T12:15:30-05:00";
            string EtagValue = "EtagValueXX";

            TableEntity dte4 = new TableEntity(PartitionKeyValue, RowKeyValue);
            dte4.ETag = new Azure.ETag(EtagValue);
            dte4.Timestamp = DateTimeOffset.Parse(TimeStampValue);
            string Serialized = serializer.Serialize(dte4);

            string ExpectedValue = String.Format("{{\"PartitionKey\":\"{0}\",\"RowKey\":\"{1}\",\"Timestamp\":\"{2}\",\"odata.etag\":{{\"odata.etag\":\"{3}\",\"EdmType\":\"String\"}}}}", PartitionKeyValue, RowKeyValue, TimeStampValue, EtagValue);
            Assert.Equal(ExpectedValue, Serialized);
        }

        [Fact]
        public void TestDeserialize()
        {
            AzureTableEntityJsonSerializer serializer = new AzureTableEntityJsonSerializer();

            TableEntity dte2 = serializer.Deserialize(BasicEntity);

            TableEntity dte3 = new TableEntity("PartitionKey", "RowKey");
            dte3.Timestamp = DateTimeOffset.Parse("2021-01-01T10:00:00+02:00");

            Assert.Equal(dte3.RowKey, dte2.RowKey);
            Assert.Equal(dte3.PartitionKey, dte2.PartitionKey);
            //Assert.Equal(dte3.Properties, dte2.Properties);
            Assert.Equal(dte3.ETag.ToString(), dte2.ETag.ToString());
            Assert.Equal(dte3.Timestamp, dte2.Timestamp);
        }
    }
}
