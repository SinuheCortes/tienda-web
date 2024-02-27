using Store.Api.Entitys;

namespace Store.Api.Data;

public class ClienteData
{
    private readonly ContextoTienda _contexto;
    public ClienteData()
    {
        _contexto = new ContextoTienda();
    }
    public Cliente[] ObtenerTodo()
    {
        return [.. _contexto.Clientes];
    }

    public Cliente? ObtenerUnico(Guid id)
    {
        return _contexto.Clientes.Find(id);
    }

    public bool Guardar(Cliente cliente)
    {
        _contexto.Add(cliente);
        return _contexto.SaveChanges() > 0;
    }

    public bool Actualizar(Cliente cliente)
    {
        _contexto.Update(cliente);
        return _contexto.SaveChanges() > 0;
    }

    public bool Eliminar(Cliente cliente)
    {
        _contexto.Remove(cliente);
        return _contexto.SaveChanges() > 0;
    }
}
