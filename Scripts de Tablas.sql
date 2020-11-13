use BDExFinal;

CREATE TABLE TblContinentes (
	IdContinente	TINYINT NOT NULL,
	TxtContinente	NVARCHAR(50) NOT NULL,
	FechaDeIngreso	DATE NOT NULL,
	IntEstado		BIT DEFAULT 1,
	CONSTRAINT IdContinentePK PRIMARY KEY (IdContinente)
	)

CREATE TABLE TblPaises (
	IdPais			SMALLINT NOT NULL,
	IdContinente	TINYINT NOT NULL,
	TxtPais			NVARCHAR(100) NOT NULL,
	TxtCapital		NVARCHAR(100) NOT NULL,
	IntAnioIndependencia SMALLINT NOT NULL,
	IntPoblacion	INT NOT NULL,
	TxtPresidenteActual NVARCHAR(100) NOT NULL,
	TxtIdiomaOficial NVARCHAR(50) NOT NULL,
	TxtMoneda		NVARCHAR(50),
	FechaDeIngreso	NVARCHAR(100),
	IntEstado		BIT DEFAULT 1 NOT NULL,
	CONSTRAINT IdPaisPK PRIMARY KEY (idPais),
	CONSTRAINT idContinenteFK FOREIGN KEY (IdContinente) REFERENCES TblContinentes(idContinente)
)


