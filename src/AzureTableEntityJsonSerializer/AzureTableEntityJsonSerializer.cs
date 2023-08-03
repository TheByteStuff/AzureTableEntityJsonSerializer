using System;

//using Microsoft.Azure.Cosmos.Table;
using Azure.Data.Tables;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheByteStuff.AzureTableEntityJsonSerializer
{
    /// <summary>
    /// Based on classes from https://www.nuget.org/packages/DynamicTableEntityJsonSerializer/1.0.0
    /// </summary>
    public class AzureTableEntityJsonSerializer
    {
        private readonly AzureTableEntityJsonConverter jsonConverter;

        public AzureTableEntityJsonSerializer(List<string> excludedProperties = null)
        {
            this.jsonConverter = new AzureTableEntityJsonConverter(excludedProperties);
        }

        public string Serialize(TableEntity entity)
        {
            string str;
            if (entity != null)
                str = JsonConvert.SerializeObject((object)entity, new JsonConverter[1]
                {
          (JsonConverter) this.jsonConverter
                });
            else
                str = (string)null;
            return str;
        }

        public TableEntity Deserialize(string serializedEntity)
        {
            TableEntity local;
            if (serializedEntity != null)
                local = JsonConvert.DeserializeObject<TableEntity>(serializedEntity, new JsonConverter[1] { (JsonConverter)this.jsonConverter });
            else
                local = null;
            return (TableEntity)local;
        }
    }
}