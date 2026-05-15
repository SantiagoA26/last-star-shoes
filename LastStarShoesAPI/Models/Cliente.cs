using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

/// <summary>
/// Clase que representa a un cliente en el sistema de Last Star Shoes. Un cliente es una persona que realiza compras en la plataforma y tiene información personal asociada, como su nombre, correo electrónico, teléfono y dirección. Esta clase incluye propiedades para almacenar esta información, así como una colección de compras realizadas por el cliente. La relación entre el cliente y las compras permite rastrear el historial de compras de cada cliente, facilitando la gestión de pedidos y la personalización de la experiencia del usuario en la plataforma.
/// </summary>
public partial class Cliente
{

    /// <summary>
    /// Identificador único del cliente. Este campo es la clave primaria de la entidad y se utiliza para identificar de manera única a cada cliente en el sistema. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada cliente tenga un identificador válido y único dentro de la base de datos. Este identificador es esencial para la gestión de clientes y la asociación con las compras realizadas por cada cliente en la plataforma.
    /// </summary>
    public string IdCliente { get; set; } = null!;

    /// <summary>
    /// Nombre del cliente. Este campo almacena el nombre completo del cliente y es esencial para la identificación y personalización dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada cliente tenga un nombre válido asociado a su perfil en el sistema. El nombre del cliente se utiliza en diversas partes de la plataforma, como en la visualización de pedidos, la comunicación con el cliente y la personalización de la experiencia del usuario.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Email del cliente. Este campo almacena la dirección de correo electrónico del cliente, que se utiliza para la comunicación y autenticación dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada cliente tenga una dirección de correo electrónico válida asociada a su cuenta en el sistema. El email del cliente es fundamental para la gestión de pedidos, el envío de notificaciones y la personalización de la experiencia del usuario en la plataforma. Además, es importante destacar que el email debe ser único para cada cliente, lo que permite evitar duplicados y garantizar una comunicación efectiva con cada cliente registrado en el sistema.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Teléfono del cliente. Este campo almacena el número de teléfono del cliente, que se utiliza para la comunicación y contacto dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada cliente tenga un número de teléfono válido asociado a su cuenta en el sistema. El teléfono del cliente es esencial para la gestión de pedidos, el envío de notificaciones y la personalización de la experiencia del usuario en la plataforma. Además, el número de teléfono puede ser utilizado para verificar la identidad del cliente y proporcionar un canal adicional de comunicación en caso de ser necesario.
    /// </summary>
    public string Telefono { get; set; } = null!;

    /// <summary>
    /// Dirección del cliente. Este campo almacena la dirección física del cliente. La dirección del cliente es fundamental para la logística de la plataforma, permitiendo asegurar que los pedidos sean entregados correctamente y a tiempo. Además, la dirección puede ser utilizada para proporcionar opciones de entrega personalizadas según la ubicación del cliente.
    /// </summary>

    public string Direccion { get; set; } = null!;

    /// <summary>
    /// Fecha de registro del cliente. Este campo almacena la fecha y hora en que el cliente se registró en la plataforma. Es un valor de tipo DateTime que puede ser nulo, lo que permite registrar clientes sin una fecha de registro específica. La fecha de registro es importante para el seguimiento del historial del cliente, la segmentación de clientes según su antigüedad y la personalización de la experiencia del usuario en función del tiempo que han estado registrados en la plataforma.
    /// </summary>
    public DateTime? FechaRegistro { get; set; }

    /// <summary>
    /// password del cliente. Este campo almacena la contraseña del cliente, que se utiliza para la autenticación y seguridad de la cuenta dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada cliente tenga una contraseña válida asociada a su cuenta en el sistema. Es importante destacar que, por razones de seguridad, las contraseñas deben ser almacenadas de manera segura, utilizando técnicas como el hashing y salting para proteger la información sensible de los clientes. La contraseña es esencial para garantizar la seguridad de las cuentas de los clientes y proteger su información personal y sus compras realizadas en la plataforma.
    /// </summary>
    public string PasswordCliente { get; set; } = null!;

    /// <summary>
    /// Colección de compras realizadas por el cliente. Esta propiedad representa la relación entre el cliente y las compras que ha realizado en la plataforma. Es una colección de objetos de tipo Compra, lo que indica que un cliente puede tener múltiples compras asociadas a su cuenta. Esta relación es fundamental para el seguimiento del historial de compras del cliente, la gestión de pedidos y la personalización de la experiencia del usuario en función de sus preferencias y comportamientos de compra. Además, esta colección permite acceder fácilmente a los detalles de cada compra realizada por el cliente, facilitando la gestión eficiente de los pedidos y la atención al cliente en caso de ser necesario.
    /// </summary>
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
