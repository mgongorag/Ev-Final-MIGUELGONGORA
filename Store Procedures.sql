--SP PARA OBTENER LOS Continentes

CREATE PROCEDURE SPGetContinents
AS
BEGIN
	SELECT IdContinente, TxtContinente
	FROM tblContinentes
	WHERE intEstado = 1
END
/*
	AUTOR: Miguel Gongora
	FECHA: 12/11/2020
*/
--SP PARA AGREGAR PAIS A CONTINENTE
CREATE  PROCEDURE SPAddCountry (
									@_IdContinente			TINYINT,
									@_TxtPais				NVARCHAR(100),
									@_TxtCapital			NVARCHAR(100),
									@_IntAnioIndependencia	SMALLINT,
									@_IntPoblacion			INT,
									@_TxtPresidenteActual	NVARCHAR(100),
									@_TxtIdiomaOficial		NVARCHAR(50),
									@_TxtMoneda				NVARCHAR(50)
								)
AS
DECLARE @_State			BIT,
		@_Message		NVARCHAR(100),
		@_LastId		INT,
		@_RowsAffected	SMALLINT;

		SET @_State = 0;
BEGIN
	BEGIN TRANSACTION
		--Se obtiene el ultimo ID
		SELECT @_LastId = ISNULL(MAX(idPais), 0)
		FROM TblPaises;

		BEGIN TRY

			INSERT INTO TblPaises	(
										IdContinente,
										IdPais,
										TxtPais,
										TxtCapital,
										IntAnioIndependencia,
										IntPoblacion,
										TxtPresidenteActual,
										TxtIdiomaOficial,
										TxtMoneda,
										FechaDeIngreso,
										IntEstado
									)
			VALUES					(
										@_IdContinente,
										@_LastId + 1,
										@_TxtPais,
										@_TxtCapital,
										@_IntAnioIndependencia,
										@_IntPoblacion,
										@_TxtPresidenteActual,
										@_TxtIdiomaOficial,
										@_TxtMoneda,
										GETDATE(),
										1
									)
			SET @_RowsAffected = @@ROWCOUNT

		END TRY
		BEGIN CATCH
			SET @_RowsAffected = 0;
			SET @_Message = 'An error has occurred, please try again';
		END CATCH

		IF(@_RowsAffected > 0) 
			BEGIN
				SET @_State = 1;
				SET @_Message = 'Successfully executed';

				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Affected ', @_RowsAffected) AS RowsAffected;
						COMMIT;
		
			END 
		ELSE
			BEGIN
				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Affected ', @_RowsAffected) AS RowsAffected;
						ROLLBACK;
			END
END

/*
	AUTOR: Miguel Gongora
	FECHA: 12/11/2020
*/
--SP PARA ELIMINAR UN PAIS

CREATE PROCEDURE SPDeleteCountry	(
										@_IdCountry SMALLINT
									)
AS
DECLARE 
		@_State			BIT,
		@_Message		NVARCHAR(100),
		@_LastId		INT,
		@_RowsAffected	SMALLINT;

		SET @_State = 0;

BEGIN
	BEGIN TRANSACTION 
		BEGIN TRY
			UPDATE TblPaises
			SET IntEstado = 0
			WHERE IdPais = @_IdCountry;

			SET @_RowsAffected = @@ROWCOUNT

		END TRY
		BEGIN CATCH
			SET @_RowsAffected = 0
			SET @_Message = 'An error has occurred, please try again';
			ROLLBACK
		END CATCH

		IF (@_RowsAffected > 0)
			BEGIN
				SET @_State = 1;
				SET @_Message = 'Successfully executed';

				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Affected ', @_RowsAffected) AS RowsAffected;
						COMMIT;
			END
		ELSE
			BEGIN
				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Affected ', @_RowsAffected) AS RowsAffected;
						ROLLBACK;
			END
END


/*
	AUTOR: Miguel Gongora
	FECHA: 12/11/2020
*/
--SP PARA ACTUALIZAR UN PAIS
CREATE  PROCEDURE SPUpdateCountry (
									@_IdContinente			TINYINT,
									@_IdPais				SMALLINT,
									@_TxtPais				NVARCHAR(100),
									@_TxtCapital			NVARCHAR(100),
									@_IntAnioIndependencia	SMALLINT,
									@_IntPoblacion			INT,
									@_TxtPresidenteActual	NVARCHAR(100),
									@_TxtIdiomaOficial		NVARCHAR(50),
									@_TxtMoneda				NVARCHAR(50)
								)
AS
DECLARE @_State			BIT,
		@_Message		NVARCHAR(100),
		@_LastId		INT,
		@_RowsAffected	SMALLINT;

		SET @_State = 0;
BEGIN
	BEGIN TRANSACTION
		--Se obtiene el ultimo ID
		SELECT @_LastId = ISNULL(MAX(idPais), 0)
		FROM TblPaises;

		BEGIN TRY

			UPDATE TblPaises
			SET				IdContinente			= @_IdContinente,
							TxtPais					= @_TxtPais,
							TxtCapital				= @_TxtCapital,
							IntAnioIndependencia	= @_IntAnioIndependencia,
							IntPoblacion			= @_IntPoblacion,
							TxtPresidenteActual		= @_TxtPresidenteActual,
							TxtIdiomaOficial		= @_TxtIdiomaOficial,
							TxtMoneda				= @_TxtMoneda
			WHERE IdPais = @_IdPais
			SET @_RowsAffected = @@ROWCOUNT

		END TRY
		BEGIN CATCH
			SET @_RowsAffected = 0;
			SET @_Message = 'An error has occurred, please try again';
		END CATCH

		IF(@_RowsAffected > 0) 
			BEGIN
				SET @_State = 1;
				SET @_Message = 'Update successfully executed';

				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Update ', @_RowsAffected) AS RowsAffected;
						COMMIT;
		
			END 
		ELSE
			BEGIN
				SELECT	@_State AS State,
						@_Message AS Message,
						CONCAT('Rows Update ', @_RowsAffected) AS RowsAffected;
						ROLLBACK;
			END
END



/*
	AUTOR: Miguel Gongora
	FECHA: 12/11/2020
*/
--SP PARA Obtener Paises por Continente
CREATE PROCEDURE SPGetCountriesByContinent	(
												@_IdContinent TINYINT
											)
AS
BEGIN
	SELECT 
			p.IdPais,
			p.TxtPais,
			p.TxtCapital,
			p.IntAnioIndependencia,
			p.IntPoblacion,
			p.TxtPresidenteActual,
			p.TxtMoneda,
			p.TxtIdiomaOficial
	FROM TblPaises p
	INNER JOIN TblContinentes c
	ON  p.IdContinente = c.IdContinente
	WHERE	c.IdContinente = @_IdContinent
	AND		p.IntEstado = 1
	ORDER BY p.TxtPais
END

CREATE PROCEDURE SPGetCountryById	(
												@_IdCountry TINYINT
											)
AS
BEGIN
	SELECT 
			IdContinente,
			IdPais,
			TxtPais,
			TxtCapital,
			IntAnioIndependencia,
			IntPoblacion,
			TxtPresidenteActual,
			TxtMoneda,
			TxtIdiomaOficial
	FROM TblPaises
	WHERE	IdPais = @_IdCountry
	AND		IntEstado = 1;
END


CREATE PROCEDURE SPGetAllCountries
AS
BEGIN
	SELECT 
			IdPais,
			TxtPais,
			TxtCapital,
			IntAnioIndependencia,
			IntPoblacion,
			TxtPresidenteActual,
			TxtMoneda,
			TxtIdiomaOficial
	FROM TblPaises
	WHERE IntEstado = 1
	ORDER BY IdPais
END








