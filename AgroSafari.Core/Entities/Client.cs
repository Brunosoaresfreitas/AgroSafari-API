﻿namespace AgroSafari.Core.Entities
{
    public class Client : BaseEntity
    {
        public Client(string fullName, string email, string cpf, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            Age = DateTime.Now.Year - birthDate.Year;
            Cpf = cpf;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;

            HiredServices = new List<Service>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public List<Service> HiredServices { get; private set; }


        public void Update(string fullName, string email, DateTime birthDate, string cpf)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Cpf = cpf;
        }
    }
}
