using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTeste.Domain.Entities;

public partial class TblLivro
{
    [Key]
    [Column(Order = 1)]
    public string Titulo { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    [Key]
    [Column(Order = 2)]
    public string Autor { get; set; } = null!;

    public int UsuarioIdInsert { get; set; }

    public int? UsuarioIdUpdate { get; set; }

    public int? UsuarioIdDelete { get; set; }

    public DateTime DthInsert { get; set; }

    public DateTime? DthUpdate { get; set; }

    public DateTime? DthDelete { get; set; }
}
