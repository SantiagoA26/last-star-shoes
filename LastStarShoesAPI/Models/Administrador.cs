using System;
using System.Collections.Generic;

namespace LastStarShoesAPI.Models;

/// <summary>
/// Representa un administrador en el sistema de Last Star Shoes. Un administrador tiene la capacidad de gestionar productos, pedidos y usuarios dentro de la plataforma. Esta clase incluye propiedades para almacenar información básica del administrador, como su identificador, nombre, correo electrónico y contraseña. Además, establece una relación con la entidad Producto, indicando que un administrador puede estar asociado con múltiples productos que gestiona o supervisa.
/// </summary>
public partial class Administrador
{
    /// <summary>
    /// Identificador único del administrador. Este campo es la clave primaria de la entidad y se utiliza para identificar de manera única a cada administrador en el sistema. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada administrador tenga un identificador válido y único dentro de la base de datos.
    /// </summary>
    public string IdAdmin { get; set; } = null!;

    /// <summary>
    /// Nombre del administrador. Este campo almacena el nombre completo del administrador y es esencial para la identificación y personalización dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada administrador tenga un nombre válido asociado a su perfil en el sistema.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Email del administrador. Este campo almacena la dirección de correo electrónico del administrador, que se utiliza para la comunicación y autenticación dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que garantiza que cada administrador tenga una dirección de correo electrónico válida asociada a su cuenta en el sistema.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Contraseña del administrador. Este campo almacena la contraseña del administrador, que se utiliza para la autenticación y seguridad de la cuenta dentro de la plataforma. Es un valor de tipo cadena que no puede ser nulo, lo que asegura que cada administrador tenga una contraseña válida asociada a su cuenta en el sistema. Es importante destacar que, por razones de seguridad, las contraseñas deben ser almacenadas de manera segura, utilizando técnicas como el hashing y salting para proteger la información sensible de los administradores.
    /// </summary>
    public string Password { get; set; } = null!;


    /// <summary>
    /// Colección de productos asociados al administrador. Esta propiedad representa la relación entre el administrador y los productos que gestiona o supervisa dentro de la plataforma. Es una colección de objetos de tipo Producto, lo que indica que un administrador puede estar asociado con múltiples productos. Esta relación es fundamental para la gestión eficiente de los productos en el sistema, permitiendo a los administradores tener un control directo sobre los productos que están bajo su responsabilidad.
    /// </summary>
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
