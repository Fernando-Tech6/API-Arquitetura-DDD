using System;

namespace Api.Domain.Dtos
{
    public class UserDtoCreateResult
    {   /*Será utilizado para retorno ao criar um user*/

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; }


    }
}
