﻿namespace SolucaoErp.Model;
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public Categoria Categoria { get; set;}
}