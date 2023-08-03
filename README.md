# TheByteStuff.AzureTableEntityJsonSerializer

[![Join the chat at https://gitter.im/TheByteStuff/AzureTableUtilities](https://badges.gitter.im/TheByteStuff/AzureTableUtilities.svg)](https://gitter.im/TheByteStuff/AzureTableUtilities?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


AzureTableEntityJsonSerializer/Deserializer for use with Azure.Data.Tables TableEntity.

Based on the nuget package offered by DoguArslan (https://www.nuget.org/packages/DynamicTableEntityJsonSerializer) which uses Microsoft.WindowsAzure.Storage.Table and .Net Framework 4.5, this package is adapted from the original work to function using Azure.Data.Tables TableEntity and a broader .NetStandard 2.1.  The serialization offered under stock Azure.Data.Tables converts Int32 to Int64 upon reserialziation, this serializer preserves Int32.


The Byte Stuff, LLC is not affiliated with Microsoft nor the original author nor have either endorsed this project.

Personal and commercial use of this software is free; however, a donation is appreciated if you find the software useful.

Suggestions or donations are both appreciated and welcome can be made by using the [Contact tab](https://www.thebytestuff.com/Contact?utm_source=nuget&amp;utm_medium=www&amp;utm_campaign=AzureTableEntityJsonSerializer).
