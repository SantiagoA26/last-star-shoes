using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

/// <summary>
/// Clase que representa un producto en el sistema de Last Star Shoes. Un producto es un artículo que se ofrece para la venta en la plataforma y tiene información asociada, como su nombre, descripción, precio, categoría, género, stock y fecha de creación. Esta clase incluye propiedades para almacenar esta información, así como una colección de detalles de compra asociados al producto. La relación entre el producto y los detalles de compra permite rastrear las compras realizadas por los clientes que incluyen este producto, facilitando la gestión de pedidos y la personalización de la experiencia del usuario en la plataforma. Además, esta clase establece una relación con la entidad Administrador, indicando que un producto puede estar asociado con un administrador que lo gestiona o supervisa dentro de la plataforma.
/// </summary>
public partial class Producto
{
    /// <summary>
    /// Identificador único del producto. Este campo es la clave primaria de la entidad y se utiliza para identificar de manera única a cada producto en el sistema. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada producto tenga un identificador válido y único dentro de la base de datos. Este identificador es esencial para la gestión eficiente de los productos, permitiendo rastrear cada producto incluido en las compras realizadas por los clientes y asociar cada producto con el administrador correspondiente que lo gestiona o supervisa dentro de la plataforma. Además, el IdProducto se utiliza para realizar consultas, actualizaciones y eliminaciones específicas de cada producto en la plataforma, facilitando la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public string IdProducto { get; set; } = null!;

    /// <summary>
    /// Identificador del administrador asociado al producto. Este campo es una clave foránea que se utiliza para establecer la relación entre el producto y el administrador que lo gestiona o supervisa dentro de la plataforma. Es un valor de tipo cadena que puede ser nulo, lo que permite registrar productos sin un administrador específico asociado. Sin embargo, en la mayoría de los casos, este campo debería contener el identificador del administrador para garantizar una gestión eficiente de los productos y permitir rastrear cada producto incluido en las compras realizadas por los clientes en la plataforma. La relación entre el producto y el administrador es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public string? IdAdmin { get; set; }

    /// <summary>
    /// Nombre del producto. Este campo almacena el nombre del producto y es esencial para la identificación y presentación del producto dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada producto tenga un nombre válido asociado a su perfil en el sistema. El nombre del producto se utiliza en diversas partes de la plataforma, como en la visualización de productos, la gestión de pedidos y la personalización de la experiencia del usuario en función de sus preferencias y hábitos de compra. Además, el nombre del producto es fundamental para la gestión eficiente de los productos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Descripción del producto. Este campo almacena una descripción detallada del producto, proporcionando información adicional sobre sus características, beneficios y usos. Es un valor de tipo cadena que puede ser nulo, lo que permite registrar productos sin una descripción específica. Sin embargo, en la mayoría de los casos, este campo debería contener una descripción del producto para garantizar una presentación completa y atractiva del producto dentro de la plataforma. La descripción del producto es esencial para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Además, una descripción detallada del producto puede ayudar a los clientes a tomar decisiones informadas sobre sus compras y mejorar la satisfacción general con la plataforma.
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Precio del producto. Este campo almacena el precio del producto, que es el monto que los clientes deben pagar para adquirir el producto en la plataforma. Es un valor de tipo decimal que no puede ser nulo, lo que garantiza que cada producto tenga un precio válido asociado. El precio del producto es esencial para la gestión eficiente de los productos, permitiendo rastrear cada producto incluido en las compras realizadas por los clientes y calcular el total de las compras en función de los precios de los productos incluidos. Además, el precio del producto es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Un precio competitivo y atractivo puede mejorar la satisfacción general con la plataforma y fomentar la lealtad de los clientes.
    /// </summary>
    public decimal Precio { get; set; }

    /// <summary>
    /// Categoría del producto. Este campo almacena la categoría a la que pertenece el producto, lo que permite organizar y clasificar los productos dentro de la plataforma. Es un valor de tipo cadena. La categoría del producto es esencial para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes.
    /// </summary>
    public string Categoria { get; set; }

    /// <summary>
    /// Género del producto. Este campo almacena el género al que está dirigido el producto, lo que permite organizar y clasificar los productos dentro de la plataforma en función de su público objetivo. Es un valor de tipo cadena. El género del producto es esencial para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Además, una clasificación adecuada por género puede mejorar la satisfacción general con la plataforma y fomentar la lealtad de los clientes.
    /// </summary>
    public string Genero { get; set; }

    /// <summary>
    /// Stock del producto. Este campo almacena la cantidad de unidades disponibles del producto en el inventario de la plataforma. Es un valor de tipo entero que no puede ser nulo, lo que garantiza que cada producto tenga un stock válido asociado. El stock del producto es esencial para la gestión eficiente de los productos, permitiendo rastrear la disponibilidad de cada producto incluido en las compras realizadas por los clientes y gestionar los pedidos en función del stock disponible. Además, el stock del producto es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Un stock adecuado y actualizado puede mejorar la satisfacción general con la plataforma y fomentar la lealtad de los clientes.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Fecha de creación del producto. Este campo almacena la fecha y hora en que el producto fue creado en la plataforma. Es un valor de tipo DateTime que puede ser nulo, lo que permite registrar productos sin una fecha de creación específica. Sin embargo, en la mayoría de los casos, este campo debería contener la fecha de creación del producto para garantizar una gestión eficiente de los productos y permitir rastrear el historial de cada producto incluido en las compras realizadas por los clientes en la plataforma. La fecha de creación del producto es esencial para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Además, una fecha de creación adecuada puede mejorar la satisfacción general con la plataforma y fomentar la lealtad de los clientes.
    /// </summary>
    public DateTime? FechaCreacion { get; set; }

    /// <summary>
    /// Detalles de compra asociados al producto. Esta propiedad representa la relación entre el producto y los detalles específicos de cada compra que incluye el producto. Es una colección de objetos de tipo DetalleCompra, lo que indica que un producto puede estar incluido en múltiples detalles de compra asociados a diferentes compras realizadas por los clientes en la plataforma. Esta relación es fundamental para el seguimiento de los productos incluidos en cada compra, la gestión de pedidos y la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias. Además, esta colección permite acceder fácilmente a los detalles de cada compra que incluye el producto, facilitando la gestión eficiente de los pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    /// <summary>
    /// Identificador del administrador asociado al producto. Esta propiedad representa la relación entre el producto y el administrador que lo gestiona o supervisa dentro de la plataforma. Es un objeto de tipo Administrador que puede ser nulo, lo que permite registrar productos sin un administrador específico asociado. Sin embargo, en la mayoría de los casos, esta propiedad debería contener el administrador asociado al producto para garantizar una gestión eficiente de los productos y permitir rastrear cada producto incluido en las compras realizadas por los clientes en la plataforma. La relación entre el producto y el administrador es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en función de las preferencias y hábitos de compra de los clientes. Además, una asociación adecuada con un administrador puede mejorar la satisfacción general con la plataforma y fomentar la lealtad de los clientes.
    /// </summary>
    public virtual Administrador? IdAdminNavigation { get; set; }
}
