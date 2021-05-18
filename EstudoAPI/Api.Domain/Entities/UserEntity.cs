namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity  // Herdando da base irá criar o id e os datetimes
    {
        public string Name { get; set; }

        public string Email { get; set; }

    }
}
