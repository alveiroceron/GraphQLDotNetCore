using System;

namespace WebAPI.Client.Model
{
    public class Account
    {
        public Guid Id { get; set; }
        public TypeOfAccount Type { get; set; }
        public string Description { get; set; }

    }
}
