#Trabajo Practico Nro. 1
- ¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
    - La relacion Cliente-Pedido es de composicion
    - La relacion Cadete-Pedido es de agregacion
    - La relacion Cadeteria-Cliente es de composicion
- ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
    - Para la clase cadeteria deberian considerarse metodos como:
        AgregarCadete, que agregue un cadete nuevo a la lista de cadetes
        RemoverCadete, que quite un cadete de la lista
        Otro que devuelva una lista de los cadetes disponibles
        Por ultimos quizas un metodo que busque un cadete por ID o Nombre
    - Para la clase cadete podrian considerarse los siguientes metodos:
        Un metodo que asigne un pedido al cadete
        Un metodo que muestre una lista de pedidos asignados del cadete
- Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
    - Los atributos como 'Nombre', 'Id', 'Direccion', 'Telefono' y 'Listados' deberian de ser privados
    - Los metodos como 'verDireccionCliente' o 'verDatosCliente', son publicos
- ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
    - Podria ser una interfaz comun entre cliente y cadete en el que se puedan ver datos o actualizar datos
    - Usar, por ejemplo una clase base llamada persona que contenga atributos como Nombre, direccion, telefono
