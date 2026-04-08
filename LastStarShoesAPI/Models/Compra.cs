using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

/// <summary>
/// Clase que representa una compra realizada por un cliente en el sistema de Last Star Shoes. Una compra es una transacción que incluye información sobre el cliente que realizó la compra, la fecha de la compra, el total de la compra y la dirección de envío. Esta clase también establece relaciones con otras entidades, como el cliente que realizó la compra y los detalles de la compra.
/// </summary>
public partial class Compra
{

    /// <summary>
    /// Identificador único de la compra. Este campo es la clave primaria de la entidad y se utiliza para identificar de manera única cada compra realizada en el sistema. Es un valor de tipo entero que se genera automáticamente, lo que garantiza que cada compra tenga un identificador válido y único dentro de la base de datos. Este identificador es esencial para la gestión de compras, permitiendo rastrear cada transacción de manera eficiente y asociar cada compra con el cliente correspondiente y los detalles de la compra. Además, el IdCompra se utiliza para realizar consultas, actualizaciones y eliminaciones específicas de cada compra en la plataforma, facilitando la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public int IdCompra { get; set; }

    /// <summary>
    /// Identificador del cliente que realizó la compra. Este campo es una clave foránea que se utiliza para establecer la relación entre la compra y el cliente que la realizó. Es un valor de tipo cadena que puede ser nulo, lo que permite registrar compras sin un cliente específico asociado. Sin embargo, en la mayoría de los casos, este campo debería contener el identificador del cliente para garantizar una gestión eficiente de las compras y permitir rastrear el historial de compras de cada cliente en la plataforma. La relación entre la compra y el cliente es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public string? IdCliente { get; set; }

    /// <summary>
    /// Fecha de la compra. Este campo almacena la fecha y hora en que se realizó la compra. Es un valor de tipo DateTime que puede ser nulo, lo que permite registrar compras sin una fecha específica. Sin embargo, en la mayoría de los casos, este campo debería contener la fecha de la compra para garantizar una gestión eficiente de las transacciones y permitir rastrear el historial de compras de cada cliente en la plataforma. La fecha de la compra es importante para el seguimiento del historial del cliente, la segmentación de clientes según su comportamiento de compra y la personalización de la experiencia del usuario en función del tiempo que han estado realizando compras en la plataforma.
    /// </summary>
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// Total de la compra. Este campo almacena el monto total de la compra realizada por el cliente. Es un valor de tipo decimal que puede ser nulo, lo que permite registrar compras sin un total específico. Sin embargo, en la mayoría de los casos, este campo debería contener el total de la compra para garantizar una gestión eficiente de las transacciones y permitir rastrear el historial de compras de cada cliente en la plataforma. El total de la compra es fundamental para la gestión de pedidos, el seguimiento de ingresos y la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias. 
    /// </summary>
    public decimal? Total { get; set; }

    /// <summary>
    /// Dirección de envío de la compra. Este campo almacena la dirección a la que se enviará el pedido asociado a la compra. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada compra tenga una dirección de envío válida asociada. La dirección de envío es esencial para la logística de la plataforma, permitiendo asegurar que los pedidos sean entregados correctamente y a tiempo. Además, la dirección de envío puede ser utilizada para proporcionar opciones de entrega personalizadas según la ubicación del cliente y mejorar la experiencia del usuario en la plataforma.
    /// </summary>
    public string DireccionEnvio { get; set; } = null!;

    /// <summary>
    /// Colección de detalles de la compra. Esta propiedad representa la relación entre la compra y los detalles específicos de cada producto incluido en la compra. Es una colección de objetos de tipo DetalleCompra, lo que indica que una compra puede tener múltiples detalles asociados a ella. Esta relación es fundamental para el seguimiento de los productos incluidos en cada compra, la gestión de pedidos y la personalización de la experiencia del usuario en función de sus hábitos de compra y preferencias. Además, esta colección permite acceder fácilmente a los detalles de cada producto incluido en la compra, facilitando la gestión eficiente de los pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    /// <summary>
    /// Identificador del cliente asociado a la compra. Esta propiedad representa la relación entre la compra y el cliente que la realizó. Es un objeto de tipo Cliente que puede ser nulo, lo que permite registrar compras sin un cliente específico asociado. Sin embargo, en la mayoría de los casos, esta propiedad debería contener el cliente asociado a la compra para garantizar una gestión eficiente de las transacciones y permitir rastrear el historial de compras de cada cliente en la plataforma. La relación entre la compra y el cliente es fundamental para la personalización de la experiencia del usuario, la gestión de pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual Cliente? IdClienteNavigation { get; set; }
}
