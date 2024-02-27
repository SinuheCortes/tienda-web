using Store.Api.Data;
using Store.Api.Dtos;
using Store.Api.Entitys;

namespace Store.Api.Bussiness;

public class ClienteBussiness
{
    private readonly ClienteData _data;
    private readonly ClienteArticuloData _clienteArticuloData;
    public ClienteBussiness()
    {
        _data = new ClienteData();
        _clienteArticuloData = new ClienteArticuloData();
    }

    public Cliente[] ObtenerTodo()
    {
        return _data.ObtenerTodo();
    }

    public Cliente? ObtenerUnico(Guid id)
    {
        return _data.ObtenerUnico(id);
    }

    public bool Guardar(Cliente cliente)
    {
        return _data.Guardar(cliente);
    }

    public bool Actualizar(Guid id, Cliente cliente)
    {
        Cliente? clienteBd = _data.ObtenerUnico(id);
        if (clienteBd is null)
        {
            return false;
        }

        clienteBd.Nombre = cliente.Nombre;
        clienteBd.Apellidos = cliente.Apellidos;
        clienteBd.Direccion = cliente.Direccion;

        return _data.Actualizar(clienteBd);
    }

    public bool Eliminar(Guid id)
    {
        Cliente? cliente = _data.ObtenerUnico(id);
        if (cliente is null)
        {
            return false;
        }

        return _data.Eliminar(cliente);
    }

    public bool ComprarArticulos(ClienteArticuloDto[] clienteArticulosDto)
    {
        List<ClienteArticulo> clienteArticulos = [];
        foreach (var dto in clienteArticulosDto)
        {
            ClienteArticulo clienteArticulo = new() { IdArticulo = dto.IdArticulo, IdCliente = dto.IdCliente };
            clienteArticulos.Add(clienteArticulo);
        }
        return _clienteArticuloData.Guardar(clienteArticulos.ToArray());
    }
}
