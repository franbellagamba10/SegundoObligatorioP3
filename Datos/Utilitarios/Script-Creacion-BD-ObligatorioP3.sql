create database ObligatorioP3
use ObligatorioP3

create table Usuarios(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	email varchar(50) NOT NULL UNIQUE,
	contrasenia varchar(20) NOT NULL,
	activo bit DEFAULT 1 NOT NULL,
);

create table Compra(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	fecha DateTime NOT NULL,	
);  --No hay List<item> porque es complicado almacenarlo asi
	--hay una tabla Compra_item que guarda como FKs idPlanta y idCompra

create table CompraImportacion(
	id int NOT NULL UNIQUE, 
	impuestoImportacion decimal not null DEFAULT 0,
	esSudamericano bit NOT NULL,
	tasaArancelaria decimal NOT NULL DEFAULT 0,
	medidasSanitarias varchar(max)

	FOREIGN KEY (id) REFERENCES Compra(id),
);

create table CompraPlaza(
	id int NOT NULL UNIQUE,
	IVA decimal NOT NULL DEFAULT 0,
	cobroFlete bit NOT NULL,
	costoEnvio decimal DEFAULT 0,

	FOREIGN KEY (id) REFERENCES Compra(id)
);



create table Tipo( -- !!!! CAMBIAR TipoPlanta
	id int IDENTITY(1,1) NOT NULL Primary Key,
	nombre varchar(20),
	descripcion varchar(max)
);



create table FrecuenciaRiego(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tiempo varchar(20) NOT NULL, -- ??? -----> por que string?
	cantidad int NOT NULL
);

create table TipoIluminacion(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	iluminacion varchar(20) NOT NULL
);	--### podriamos agregarle una descripcion.

create table Ficha(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	frecuenciaRiego int NOT NULL,
	tipoIluminacion int NOT NULL,
	temperatura decimal NOT NULL,

	FOREIGN KEY (frecuenciaRiego) REFERENCES FrecuenciaRiego(id),
	FOREIGN KEY (tipoIluminacion) REFERENCES TipoIluminacion(id)	
);

create table Planta(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tipo int NOT NULL,
	nombreCientifico varchar(50) NOT NULL,
	nombresVulgares varchar(max) NOT NULL, --En BD lo manejamos como cadena unica, separados por una coma. pero en la solucion lo recibimos como una lista y la desarmamos.
	descripcion varchar(max) NOT NULL,
	ambiente varchar(20) NOT NULL,
	alturaMaxima int NOT NULL,
	foto varchar(50),
	precio decimal NOT NULL, -- !!!!! en el UML es DOUBLE, no supe que poner xq double no existe en SQL
	ingresadoPor int,
	
	FOREIGN KEY (tipo) REFERENCES Tipo(id),
	FOREIGN KEY (ingresadoPor) REFERENCES Usuarios(id),
)

create table Items(
	compra int NOT NULL,
	planta int NOT NULL,
	cantidad int NOT NULL DEFAULT 1,
	precioUnidad decimal NOT NULL,

	FOREIGN KEY (compra) REFERENCES Compra(id),
	FOREIGN KEY (planta) REFERENCES Planta(id),
);

--Ignorar esto, es una idea para guardar las constantes que podamos llegar
-- a necesitar, no esta implementado
create table Constantes(
	id int IDENTITY(1,1) NOT NULL,
	descripcion varchar(20) NOT NULL,
	valorString varchar(10),
	valorDecimal decimal,
	valorBool bit,
	valorInt int
);
drop table Constantes;