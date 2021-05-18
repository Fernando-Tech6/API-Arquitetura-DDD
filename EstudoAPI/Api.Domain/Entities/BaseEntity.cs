using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{        /*Será criando atributos que serão comuns em outras entidades*/
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        private DateTime? _createAt;    // Pode ser nula 
        public DateTime? CreateAt
        {
            get
            {
                return _createAt;
            }
            set
            {    /*Se o valor for igual a nulo, irá retornar a data e hora atual, se não retornar o valor*/
                _createAt = (value == null ? DateTime.UtcNow : value);
            }
        }

        public DateTime? UpdateAt { get; set; }





    }
}
