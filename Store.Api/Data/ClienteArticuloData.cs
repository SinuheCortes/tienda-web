using Store.Api.Entitys;

namespace Store.Api.Data;

public class ClienteArticuloData
{
    private readonly ContextoTienda _contexto;
    public ClienteArticuloData()
    {
        _contexto = new ContextoTienda();
    }

    public bool Guardar(ClienteArticulo[] clienteArticulo)
    {
        _contexto.AddRange(clienteArticulo);
        return _contexto.SaveChanges() > 0;
    }
}
