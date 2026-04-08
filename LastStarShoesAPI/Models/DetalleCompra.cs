using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

/// <summary>
/// DetalleCompra representa los detalles específicos de cada producto incluido en una compra realizada por un cliente en el sistema de Last Star Shoes. Esta clase incluye propiedades para almacenar información sobre la cantidad de productos comprados, el precio unitario, el subtotal y las relaciones con la compra y el producto asociado. La relación entre DetalleCompra, Compra y Producto permite rastrear los productos incluidos en cada compra, gestionar pedidos de manera eficiente y personalizar la experiencia del usuario en función de sus hábitos de compra y preferencias. Además, esta clase es fundamental para la gestión de pedidos, el seguimiento de ingresos y la atención al cliente en caso de ser necesario.
/// </summary>
public partial class DetalleCompra
{
    /// <summary>
    /// Identificador único del detalle de compra. Este campo es la clave primaria de la entidad y se utiliza para identificar de manera única cada detalle de compra registrado en el sistema. Es un valor de tipo entero que se genera automáticamente, lo que garantiza que cada detalle de compra tenga un identificador válido y único dentro de la base de datos. Este identificador es esencial para la gestión eficiente de los detalles de compra, permitiendo rastrear cada producto incluido en una compra específica y asociar cada detalle con la compra correspondiente y el producto asociado. Además, el IdFactura se utiliza para realizar consultas, actualizaciones y eliminaciones específicas de cada detalle de compra en la plataforma, facilitando la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public int IdFactura { get; set; }

    /// <summary>
    /// Identificador de la compra a la que pertenece el detalle de compra. Este campo es una clave foránea que se utiliza para establecer la relación entre el detalle de compra y la compra a la que pertenece. Es un valor de tipo entero que puede ser nulo, lo que permite registrar detalles de compra sin una compra específica asociada. Sin embargo, en la mayoría de los casos, este campo debería contener el identificador de la compra para garantizar una gestión eficiente de los detalles de compra y permitir rastrear cada producto incluido en una compra específica en la plataforma. La relación entre el detalle de compra y la compra es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public int? IdCompra { get; set; }

    /// <summary>
    /// Identificador del producto incluido en el detalle de compra. Este campo es una clave foránea que se utiliza para establecer la relación entre el detalle de compra y el producto asociado. Es un valor de tipo cadena que puede ser nulo, lo que permite registrar detalles de compra sin un producto específico asociado. Sin embargo, en la mayoría de los casos, este campo debería contener el identificador del producto para garantizar una gestión eficiente de los detalles de compra y permitir rastrear cada producto incluido en una compra específica en la plataforma. La relación entre el detalle de compra y el producto es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public string? IdProducto { get; set; }

    /// <summary>
    /// Cantidad de productos comprados. Este campo almacena la cantidad de unidades del producto incluido en el detalle de compra. Es un valor de tipo entero que no puede ser nulo, lo que garantiza que cada detalle de compra tenga una cantidad válida asociada. La cantidad de productos comprados es esencial para la gestión eficiente de los detalles de compra, permitiendo rastrear cada producto incluido en una compra específica y calcular el subtotal de cada detalle de compra en función del precio unitario y la cantidad. Además, la cantidad es fundamental para la gestión de inventarios, el seguimiento de ingresos y la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias.
    /// </summary>
    public int Cantidad { get; set; }

    /// <summary>
    /// Precio unitario del producto incluido en el detalle de compra. Este campo almacena el precio por unidad del producto asociado al detalle de compra. Es un valor de tipo decimal que no puede ser nulo, lo que garantiza que cada detalle de compra tenga un precio unitario válido asociado. El precio unitario es esencial para la gestión eficiente de los detalles de compra, permitiendo rastrear cada producto incluido en una compra específica y calcular el subtotal de cada detalle de compra en función del precio unitario y la cantidad. Además, el precio unitario es fundamental para la gestión de ingresos, la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias, y la atención al cliente en caso de ser necesario.
    /// </summary>
    public decimal PrecioUnitario { get; set; }

    /// <summary>
    /// Subtotal del detalle de compra. Este campo almacena el monto total del detalle de compra, calculado como el producto de la cantidad y el precio unitario. Es un valor de tipo decimal que no puede ser nulo, lo que garantiza que cada detalle de compra tenga un subtotal válido asociado. El subtotal es esencial para la gestión eficiente de los detalles de compra, permitiendo rastrear cada producto incluido en una compra específica y calcular el total de la compra en función de los subtotales de cada detalle de compra. Además, el subtotal es fundamental para la gestión de ingresos, la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias, y la atención al cliente en caso de ser necesario.
    /// </summary>
    public decimal Subtotal { get; set; }


    /// <summary>
    /// Identificador de la compra asociada al detalle de compra. Esta propiedad representa la relación entre el detalle de compra y la compra a la que pertenece. Es un objeto de tipo Compra que puede ser nulo, lo que permite registrar detalles de compra sin una compra específica asociada. Sin embargo, en la mayoría de los casos, esta propiedad debería contener la compra asociada al detalle de compra para garantizar una gestión eficiente de los detalles de compra y permitir rastrear cada producto incluido en una compra específica en la plataforma. La relación entre el detalle de compra y la compra es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual Compra? IdCompraNavigation { get; set; }

    /// <summary>
    /// Identificador del producto asociado al detalle de compra. Esta propiedad representa la relación entre el detalle de compra y el producto asociado. Es un objeto de tipo Producto que puede ser nulo, lo que permite registrar detalles de compra sin un producto específico asociado. Sin embargo, en la mayoría de los casos, esta propiedad debería contener el producto asociado al detalle de compra para garantizar una gestión eficiente de los detalles de compra y permitir rastrear cada producto incluido en una compra específica en la plataforma. La relación entre el detalle de compra y el producto es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual Producto? IdProductoNavigation { get; set; }
}
