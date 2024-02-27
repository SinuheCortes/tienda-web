using Store.Api.Data;
using Store.Api.Dtos;
using Store.Api.Entitys;

namespace Store.Api.Bussiness;

public class ArticuloBussiness
{
    private readonly ArticuloData _data;
    public ArticuloBussiness()
    {
        _data = new ArticuloData();
    }

    public Articulo[] ObtenerTodo(int idTienda)
    {
        return _data.ObtenerTodo(idTienda);
    }

    public bool Guardar(ArticuloDto articuloDto)
    {
        Articulo articulo = new Articulo() { Codigo = Guid.NewGuid(), Descripcion = articuloDto.Descripcion, Precio = articuloDto.Precio, Imagen = articuloDto.Imagen, Stock = articuloDto.Stock };
        ArticuloTienda articuloTienda = new() { IdTienda = articuloDto.IdTienda, IdArticulo = articulo.Codigo };
        return _data.Guardar(articulo, articuloTienda);
    }

    public bool Actualizar(ArticuloDto articulo)
    {
        Articulo? articuloBd = _data.ObtenerUnico(articulo.Codigo);
        ArticuloTienda? articuloTienda = _data.ObtenerArticuloTienda(articulo.Codigo);
        if (articuloBd is null || articuloTienda is null)
        {
            return false;
        }
        articuloBd.Descripcion = articulo.Descripcion;
        articuloBd.Stock = articulo.Stock;
        articuloBd.Precio = articulo.Precio;
        articuloBd.Imagen = articulo.Imagen;
        articuloTienda.IdTienda = articulo.IdTienda;

        return _data.Actualizar(articuloBd, articuloTienda);
    }

    public bool Eliminar(Guid idArticulo)
    {
        Articulo? articulo = _data.ObtenerUnico(idArticulo);
        ArticuloTienda? articuloTienda = _data.ObtenerArticuloTienda(idArticulo);
        if (articulo is null || articuloTienda is null)
        {
            return false;
        }

        return _data.Eliminar(articulo, articuloTienda);
    }
}
