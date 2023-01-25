using System;
using System.Reflection;

var carro1 = new Carro() {
    Cor = "Preto",
    Preco = 45000m,
    NumeroAssentos = 5,
};

var carro2 = InstanciaObjeto(carro1);
carro2.Cor = "Branco";
carro2.Preco = 45000m;
carro2.NumeroAssentos = 5;

ListaMetodosEPropriedades(carro1);
Console.WriteLine();
ListaMetodosEPropriedades(carro2);

void ListaMetodosEPropriedades<T>(T objeto)
{
    var metodos = objeto.GetType().GetMethods();
    Console.WriteLine($"Métodos do objeto {objeto.ToString()}");
    foreach (var metodo in metodos)
    {
        Console.WriteLine($"Método {metodo.Name} que retorna {metodo.ReturnType}");
    }

    var propriedades = objeto.GetType().GetProperties();
    Console.WriteLine($"Propriedades do objeto {objeto.ToString()}");
    foreach (var propriedade in propriedades)
    {
        Console.WriteLine($"Propriedade {propriedade.Name} com valor {propriedade.GetValue(objeto)}");
    }
}

T InstanciaObjeto<T>(T objeto) where T : class
{
    return Activator.CreateInstance<T>();
}

class Carro
{
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public int NumeroAssentos { get; set; }

    public void Acelerar()
    {
        Console.WriteLine("Estou acelerando");
    }

    public decimal PrecoComDesconto(decimal porcentagem)
    {
        return Preco * porcentagem;
    }
}