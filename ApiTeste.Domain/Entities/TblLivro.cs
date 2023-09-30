using System;
using System.Collections.Generic;

namespace ApiTeste.Domain.Entities;

public partial class TblLivro
{
    public string Titulo { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int UsuarioIdInsert { get; set; }

    public int? UsuarioIdUpdate { get; set; }

    public int? UsuarioIdDelete { get; set; }

    public DateTime DthInsert { get; set; }

    public DateTime? DthUpdate { get; set; }

    public DateTime? DthDelete { get; set; }
}
