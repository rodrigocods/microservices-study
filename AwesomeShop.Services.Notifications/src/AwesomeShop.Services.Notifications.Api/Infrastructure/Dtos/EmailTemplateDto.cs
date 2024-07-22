using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AwesomeShop.Services.Notifications.Api.Infrastructure.Dtos
{
    public class EmailTemplateDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Event { get; set; }
    }
}