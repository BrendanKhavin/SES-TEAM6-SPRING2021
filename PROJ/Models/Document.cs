using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}