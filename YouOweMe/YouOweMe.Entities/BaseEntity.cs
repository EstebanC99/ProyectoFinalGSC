﻿namespace YouOweMe.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; protected set; }

        public string? Descripcion { get; protected set; }
    }
}