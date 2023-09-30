using System;
using System.Collections.Generic;

namespace ApiTeste.Domain.Entities;

public partial class TblPessoaFisica
{
    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public int UsuarioIdInsert { get; set; }

    public int? UsuarioIdUpdate { get; set; }

    public int? UsuarioIdDelete { get; set; }

    public DateTime DthInsert { get; set; }

    public DateTime? DthUpdate { get; set; }

    public DateTime? DthDelete { get; set; }

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
