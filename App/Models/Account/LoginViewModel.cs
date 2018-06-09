using App.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "A matrícula é obrigatória.")]
        [MaxLength(5, ErrorMessage = "Tamanho máximo de 5 caracteres.")]
        public string Registry { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(15, ErrorMessage = "Tamanho máximo de 15 caracteres")]
        public string Password { get; set; }

        private AppDBContext _context;

        public void Init(AppDBContext context)
        {
            _context = context;
        }

        //Verificação das informações digitadas para saber se os dados conferem com os salvos no banco
        public bool IsValid()
        {
            if (_context == null)
                return false;
            return _context.Usuarios.Any(c => c.Matricula.Equals(Registry) && c.Senha.Equals(Password.MD5Encrypt()));
        }

        //Retorno do usuário do banco de acordo com os dados digitados
        public Usuarios ToUsuario()
        {
            return _context.Usuarios.FirstOrDefault(c => c.Matricula.Equals(Registry) && c.Senha.Equals(Password.MD5Encrypt()));
        }
    }
}
