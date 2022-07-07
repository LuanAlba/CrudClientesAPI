using CrudClientAPI.Shared;

namespace CrudClientAPI.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public ClientStatus Status { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string FullName { get; private set; }

        public Client(string firstName, string lastName, string phoneNumber, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;

            Status = ClientStatus.Active;
        }

        public void UpdateFullName(string fullName) => FullName = fullName?.Replace("  ", " ");

        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName?.Trim();
            LastName = lastName?.Trim();

            UpdateFullName($"{FirstName} {LastName}");
        }

        public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void UpdateBirth(DateTime birthDate) => BirthDate = birthDate;
        public void DeleteClient() => Status = ClientStatus.Deleted;
    }
}